# Kaazing .NET Desktop WebSocket AMQP Tutorial

This tutorial shows how standalone .NET desktop application can communicate over the web with an AMQP server via Kaazing WebSocket Gateway using Kaazing .NET WebSocket Client library. The application publishes text messages to the server and listens to the messages from the server over WebSocket.

## Minimum Requirements for Running or Building Kaazing .NET Desktop WebSocket AMQP tutorial

* Microsoft .NET Framework 4.5.2
* Microsoft Visual Studio 2015 or higher

## Steps for building the project

* Load the solution `AmqpDemo.sln` in Microsoft Visual Studio
* Execute 'Build/Build All'

__Note:__ To test basic authentication for WebSocket connection in demo app use URL - wss://sandbox.kaazing.net/amqp091-auth for location.

## Interact with Kaazing .NET WebSocket Client API

Checklist how to create Kaazing .NET WebSocket AMQP application from scratch, to be able to send and receive messages over WebSocket can be found [here](http://kaazing.com/doc/5.0/amqp_client_docs/dev-dotnet/o_dev_dotnet.html).

## API Documentation

API Documentation for Kaazing .NET WebSocket AMQP Client library is available:

* [Kaazing AMQP](https://kaazing.com/doc/amqp/4.0/apidoc/client/dotnet/html/N_Kaazing_AMQP.htm)
* [Kaazing.Security](https://kaazing.com/doc/amqp/4.0/apidoc/client/dotnet/gateway/html/N_Kaazing_Security.htm)
