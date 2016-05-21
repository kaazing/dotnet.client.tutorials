# Kaazing .NET Windows Phone WebSocket AMQP Demo

This demo shows how native Windows Phone application can communicate over the web with an AMQP server
via Kaazing WebSocket Gateway using Kaazing .NET WebSocket Client library. The application
publishes text messages to the server and listens to the messages from the server over WebSocket.
## Minimum Requirements for Running or Building Kaazing .NET Windows Phone WebSocket Demo

* Microsoft .NET Framework 4.5.2
* Microsoft Visual Studio 2015 or higher

## Steps for building the project

* Load the solution `AmqpDemo.sln` in Microsoft Visual Studio
* Using NuGet Package Manager, update the references to Kaazing.Enterprise and Xamarin.Forms. *If necessary, remove installed Kaazing.Enterprize and Xamarin.Forms NuGet packages and add them again.*

## Interact with Kaazing .NET WebSocket AMQP Client API

Detailed instructions to create Kaazing .NET WebSocket AMQP Demo from scratch to be able to send and receive messages
over WebSocket can be found [here](http://kaazing.com/doc/5.0/amqp_client_docs/dev-dotnet/o_dev_dotnet.html).

## API Documentation

API Documentation for Kaazing .NET WebSocket AMQP Client library is available:

* [Kaazing AMQP](https://kaazing.com/doc/amqp/4.0/apidoc/client/dotnet/html/N_Kaazing_AMQP.htm)
* [Kaazing.Security](https://kaazing.com/doc/amqp/4.0/apidoc/client/dotnet/gateway/html/N_Kaazing_Security.htm)
