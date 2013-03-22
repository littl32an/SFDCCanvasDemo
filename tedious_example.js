var Connection = require('tedious').Connection;

var config = {
	userName: 'test',
	password: 'test',
	server: '192.168.1.210',
};

var connection = new Connection(config);

connection.on('connect', 
	function(err) {
		//If no error, then good to go...
		executeStatement();
	}
);

var Request = require('tedious').Request;

function executeStatement() {
	request = new Request ("select 42, 'hello world'", 
		function(err, rowCount) {
			if (err) {
				console.log(err);
			} else {
				console.log(rowCount + 'rows');
			}
		}
	);
	
	request.on('row', 
		function(columns) {
			columns.forEach(
				function(column) {
					console.log(column.value);
				}
			);
		}
	);
	
	connection.execSql(request);
};