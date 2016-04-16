# Kaazing .NET Desktop WebSocket Echo Demo

This demo shows how standalone .NET desktop application can communicate over the web with an `echo` service
running within Kaazing WebSocket Gateway using Kaazing .NET WebSocket Client library. The application
sends text messages to the `echo` service over WebSocket using Kaazing .NET WebSocket Client library.
The `echo` service, running inside the Kaazing WebSocket Gateway, reflects back the message that is
received by the .NET application. Kaazing .NET WebSocket Client library is located in `lib` folder
under the top-level directory.

## Minimum Requirements for Running or Building Kaazing .NET Desktop WebSocket Demo

* Microsoft .NET Framework 4.5.2
* Microsoft Visual Studio 2013 or higher

## Steps for building the project

* Load the solution `EchoDemo.sln` in Microsoft Visual Studio
* Update the references to Kaazing .NET WebSocket Client library

## Interact with Kaazing .NET WebSocket Client API

Detailed instructions to create Kaazing .NET WebSocket Demo from scratch to be able to send and receive messages
over WebSocket can be found [here](http://developer.kaazing.com/documentation/gateway/4.0/dev-dotnet/o_dev_dotnet.html).

## API Documentation

API Documentation for Kaazing .NET WebSocket Client library is available:

* [Kaazing.HTML5](http://developer.kaazing.com/documentation/gateway/4.0/apidoc/client/dotnet/gateway/html/N_Kaazing_HTML5.htm)
* [Kaazing.Security](http://developer.kaazing.com/documentation/gateway/4.0/apidoc/client/dotnet/gateway/html/N_Kaazing_Security.htm)
