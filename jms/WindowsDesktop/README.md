# Kaazing .NET Desktop WebSocket JMS Demo

This demo shows how standalone .NET desktop application can communicate over the web with a JMS server
via Kaazing WebSocket Gateway using Kaazing .NET WebSocket Client library. The application
publishes text messages to the server and listens to the messages from the server over WebSocket.
## Minimum Requirements for Running or Building Kaazing .NET Desktop WebSocket Demo

* Microsoft .NET Framework 4.5.2
* Microsoft Visual Studio 2013 or higher

## Steps for building the project

* Load the solution `JmsDemo.sln` in Microsoft Visual Studio
* Using NuGet Package Manager, update the references to Kaazing.Enterprise. *If necessary, remove installed Kaazing.Enterprize NuGet package and add it again.*

## Interact with Kaazing .NET WebSocket Client API

Detailed instructions to create Kaazing .NET WebSocket JMS Demo from scratch to be able to send and receive messages
over WebSocket can be found [here](http://developer.kaazing.com/documentation/gateway/4.0/dev-dotnet/o_dev_dotnet.html).

## API Documentation

API Documentation for Kaazing .NET WebSocket Client library is available:

* [Kaazing.HTML5](http://developer.kaazing.com/documentation/gateway/4.0/apidoc/client/dotnet/gateway/html/N_Kaazing_HTML5.htm)
* [Kaazing.Security](http://developer.kaazing.com/documentation/gateway/4.0/apidoc/client/dotnet/gateway/html/N_Kaazing_Security.htm)
