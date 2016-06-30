# Kaazing .NET Desktop AMQP Tutorial

This .NET desktop application communicates with an AMQP server via Kaazing WebSocket Gateway. The application publishes and listens  for text messages with the AMQP server.

## Minimum Requirements for Running or Building

* Microsoft .NET Framework 4.5.2
* Microsoft Visual Studio 2015 or higher

## Steps for Building the Project

* Load the solution `AmqpDemo.sln` in Microsoft Visual Studio
* Execute 'Build/Build All'

__Note:__ To test basic authentication for the Gateway connection use the URL `wss://sandbox.kaazing.net/amqp091-auth` for location.
</br>
username: tutorial </br>
password: tutorial 

## Interact with Kaazing .NET AMQP Client API

Documentation on how to create Kaazing .NET AMQP applications from scratch can be found [here](http://kaazing.com/doc/5.0/amqp_client_docs/dev-dotnet/o_dev_dotnet.html).

## API Documentation

API Documentation for Kaazing .NET AMQP Client library is available:

* [Kaazing AMQP](http://kaazing.com/doc/5.0/amqp_client_docs/apidoc/client/dotnet/html/N_Kaazing_AMQP.htm)
* [Kaazing.Security](http://kaazing.com/doc/5.0/amqp_client_docs/apidoc/client/dotnet/gateway/html/N_Kaazing_Security.htm)
