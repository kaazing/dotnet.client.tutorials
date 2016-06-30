# Kaazing .NET Windows Store WebSocket Tutorial

This Windows Store application communicates with an `Echo` service hosted by Kaazing WebSocket Gateway. The application sends and receives text messages with the `Echo` service over WebSocket.

## Minimum Requirements for Running or Building

* Microsoft .NET Framework 4.5.2
* Microsoft Visual Studio 2015 or higher

## Steps for Building the Project

* Load the solution `EchoDemo.sln` in Microsoft Visual Studio
* Execute 'Build/Build All'

__Note:__ To test basic authentication for the Gateway connection use the URL `wss://sandbox.kaazing.net/echo-auth` for location. 
</br>
username: tutorial </br>
password: tutorial 
## Interact with Kaazing .NET WebSocket Client API

Documentation on how to create Kaazing .NET WebSocket applications from scratch can be found [here](http://kaazing.com/doc/5.0/websocket_client_docs/dev-dotnet/o_dev_dotnet.html).

## API Documentation

API Documentation for Kaazing .NET WebSocket Client library is available:

* [Kaazing.HTML5](http://kaazing.com/doc/5.0/websocket_client_docs/apidoc/client/dotnet/gateway/html/N_Kaazing_HTML5.htm)
* [Kaazing.Security](http://kaazing.com/doc/5.0/websocket_client_docs/apidoc/client/dotnet/gateway/html/N_Kaazing_Security.htm)
