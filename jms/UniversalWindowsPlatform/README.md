# Kaazing .NET Windows Store JMS Tutorial

This Windows Store application communicates with a JMS broker via Kaazing WebSocket Gateway. The application publishes and listens for messages from the JMS broker over WebSocket.

## Minimum Requirements for Running or Building

* Microsoft .NET Framework 4.5.2
* Microsoft Visual Studio 2015 or higher

## Steps for Building the Project

* Load the solution `JmsDemo.sln` in Microsoft Visual Studio
* Execute 'Build/Build All'

__Note:__ To test basic authentication for the Gateway connection use the URL `wss://sandbox.kaazing.net/jms-auth` for location.</br>
username: tutorial </br>
password: tutorial 

## Interact with Kaazing .NET JMS Client API

Documentation on how to create Kaazing .NET JMS applications from scratch can be found [here](http://kaazing.com/doc/5.0/jms_client_docs/dev-dotnet/o_dev_dotnet.html).

## API Documentation

API Documentation for Kaazing .NET JMS Client library is available:

* [Kaazing.JMS](https://kaazing.com/doc/5.0/jms_client_docs/apidoc/client/dotnet/jms/html/N_Kaazing_JMS.htm)
* [Kaazing.JMS.Stomp](https://kaazing.com/doc/5.0/jms_client_docs/apidoc/client/dotnet/jms/html/N_Kaazing_JMS_Stomp.htm)
* [Kaazing.JMS.Util](https://kaazing.com/doc/5.0/jms_client_docs/apidoc/client/dotnet/jms/html/N_Kaazing_JMS_Util.htm)
* [Kaazing.Security](https://kaazing.com/doc/5.0/jms_client_docs/apidoc/client/dotnet/jms/html/N_Kaazing_Security.htm)
