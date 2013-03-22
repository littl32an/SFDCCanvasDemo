require('./buffertools')
EventEmitter = require('events').EventEmitter
isPacketComplete = require('./packet').isPacketComplete
packetLength = require('./packet').packetLength
packetHeaderLength = require('./packet').HEADER_LENGTH
Packet = require('./packet').Packet

class MessageIO extends EventEmitter
  constructor: (@socket, @_packetSize, @debug) ->
    @socket.addListener('data', @eventData)

    @packetDataSize = @_packetSize - packetHeaderLength
    @packetBuffer = new Buffer(0)
    @payloadBuffer = new Buffer(0)

  eventData: (data) =>
    if (@packetBuffer.length > 0)
      @packetBuffer = Buffer.concat([@packetBuffer, data])
    else
      @packetBuffer = data

    packetsData = []
    endOfMessage = false

    while isPacketComplete(@packetBuffer)
      length = packetLength(@packetBuffer)
      packet = new Packet(@packetBuffer.slice(0, length))
      @logPacket('Received', packet);

      packetsData.push(packet.data())
      if (packet.isLast())
        endOfMessage = true

      @packetBuffer = @packetBuffer.slice(length)

    if packetsData.length > 0
      @emit('data', Buffer.concat(packetsData))
      if endOfMessage
        @emit('message')

  packetSize: (packetSize) ->
    if arguments.length > 0
      @debug.log("Packet size changed from #{@_packetSize} to #{packetSize}")
      @_packetSize = packetSize
      @packetDataSize = @_packetSize - packetHeaderLength

    @_packetSize

  encryptAllFutureTraffic: (securePair) ->
    @securePair = securePair

    @socket.removeAllListeners('data')
    @securePair.encrypted.removeAllListeners('data')

    @socket.pipe(@securePair.encrypted)
    @securePair.encrypted.pipe(@socket)

    @securePair.cleartext.addListener('data', @eventData)

  # TODO listen for 'drain' event when socket.write returns false.
  sendMessage: (packetType, data) ->
    numberOfPackets = (Math.floor((data.length - 1) / @packetDataSize)) + 1

    for packetNumber in [0..numberOfPackets - 1]
      payloadStart = packetNumber * @packetDataSize
      if packetNumber < numberOfPackets - 1
        payloadEnd = payloadStart + @packetDataSize
      else
        payloadEnd = data.length
      packetPayload = data.slice(payloadStart, payloadEnd)

      packet = new Packet(packetType)
      packet.last(packetNumber == numberOfPackets - 1)
      packet.packetId(packetNumber + 1)
      packet.addData(packetPayload)

      @sendPacket(packet)

  sendPacket: (packet) =>
    @logPacket('Sent', packet);

    if (@securePair)
      @securePair.cleartext.write(packet.buffer)
    else
      @socket.write(packet.buffer)

  logPacket: (direction, packet) ->
    @debug.packet(direction, packet)
    @debug.data(packet)

module.exports = MessageIO
