Salesforce Force.com Canvas SDK
============================


####Note

The Force.com Canvas feature is currently available through a pilot program. For information on enabling it for your organization, contact salesforce.com. Any unreleased services or features referenced in this or other press releases or public statements are not currently available and may not be delivered on time or at all. Customers who purchase our services should make their purchase decisions based upon features that are currently available. More information about our safe habor statement can be found on our [website](http://www.salesforce.com/company/investor/safe_harbor.jsp). 

### Version

Master now points to version v27.0 (Spring 2013), Note: Spring 2013 requires a mandatory upgrade and some small coding changes, please see the [release notes](https://na1.salesforce.com/help/doc/en/salesforce_spring13_release_notes.pdf) and the examples). If you still need the previous release: 
	
	// Clone the entire repository
	git clone git@github.com:forcedotcom/SalesforceCanvasFrameworkSDK.git
	
	// List the Tags
	git tag
	
	// Check out the previous version
	git checkout v26.0

###Introduction

Force.com Canvas is a mechanism for consuming third-party applications within Salesforce. Its goal is to connect applications at a UI level instead of just an API level. The purpose of this GitHub repository is to provide third-party applications with a Java/JavaScript SDK and examples so you can easily integrate canvas-style applications into Salesforce, while developing in the technology and platform of your choice. 

The best place to get started building canvas applications is the [Spring '13 online developer's guide](http://www.salesforce.com/us/developer/docs/platform_connect/index.htm) (version 27.0).

Currently, we provide Java and Ruby examples, but you can develop in whatever language you prefer. Most of the integration with Salesforce is through JavaScript and REST. You can also run and test your application locally from your own host, or from [Heroku](http://www.heroku.com/).


### Examples

While this SDK contains some very basic Java examples, it doesn't contain all the examples. We recommend you explore the [Heroku Quick Start](http://www.salesforce.com/us/developer/docs/platform_connect/index_Left.htm#CSHID=quick_start_simple_create_app.htm|StartTopic=Content%2Fquick_start_simple_create_app.htm|SkinName=webhelp), for additional examples in Java and other languages.

For other examples and resources, check out [Force.com](http://Developer.force.com/)

### Prerequisites

Below are some useful commands and links for your convenience. Before you use them, you'll need to make sure you have the necessary software installed on your computer [here](http://www.salesforce.com/us/developer/docs/platform_connect/index_Left.htm#CSHID=quick_start_prereqs.htm|StartTopic=Content%2Fquick_start_prereqs.htm|SkinName=webhelp).

### How to clone the SDK repository

	git clone git@github.com:forcedotcom/SalesforceCanvasFrameworkSDK.git

### How to build canvas locally

If you prefer, you can build and test your application locally before you push to Heroku or any other server. If you decide to test locally, you'll also need to generate a local keystore so you can do SSL.

    mvn package
    
### First time keystore generation 
This is only needed to support SSL (https) when running locally. Heroku uses [piggyback SSL](https://devcenter.heroku.com/articles/ssl) so it's not needed there.

      > keytool -keystore keystore -alias jetty -genkey -keyalg RSA
      Enter keystore password: 123456
      Re-enter new password: 123456
      What is your first and last name?
        [Unknown]:  John Doe
      What is the name of your organizational unit?
        [Unknown]:  myorgunit
      What is the name of your organization?
        [Unknown]:  myorg
      What is the name of your City or Locality?
        [Unknown]:  San Fancisco
      What is the name of your State or Province?
        [Unknown]:  CA
      What is the two-letter country code for this unit?
        [Unknown]:  us
      Is CN=salesforce.com, OU=platform, O=chimera, L=San Fancisco, ST=CA, C=us correct?
        [no]:  yes

      Enter key password for <jetty>
	(RETURN if same as keystore password):  
      Re-enter new password: 


### How to run canvas locally

If you're running and testing locally, this will start your Java Web server.

    sh target/bin/webapp

### Canvas URL


    If you're running locally 
    https://localhost:8443/examples/hello-world.jsp
    
    Or if you're running on Heroku
    https://<your-heroku-app>.herokuapp.com/examples/hello-world.jsp

### Canvas callback URLs

    If you're running locally
    https://localhost:8443/sdk/callback.html
    
    Or if you're running on Heroku
    https://<your-heroku-app>.herokuapp.com/sdk/callback.html

### How to push new changes to heroku

To commit your changes into your local git repository and push those changes to Heroku, do the following. Note: Your repository name may be diffferent than 'heroku', use git remote -v to confirm.

      git add -A
      git commit -m "My change comments"
      git push heroku master

### How to get Heroku logs

To access your logs on Heroku, use the following command. For more information on Heroku logs click [here](https://devcenter.heroku.com/articles/logging).

      heroku logs --tail



