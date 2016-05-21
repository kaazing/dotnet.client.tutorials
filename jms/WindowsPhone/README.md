# Kaazing .NET Windows Phone WebSocket JMS Demo

This demo shows how native Windows Phone application can communicate over the web with a JMS server
via Kaazing WebSocket Gateway using Kaazing .NET WebSocket Client library. The application
publishes text messages to the server and listens to the messages from the server over WebSocket.
## Minimum Requirements for Running or Building Kaazing .NET Windows Phone WebSocket Demo

* Microsoft .NET Framework 4.5.2
* Microsoft Visual Studio 2015 or higher

## Steps for building the project

* Load the solution `JmsDemo.sln` in Microsoft Visual Studio
* Using NuGet Package Manager, update the references to Kaazing.Enterprise and Xamarin.Forms. *If necessary, remove installed Kaazing.Enterprize and Xamarin.Forms NuGet packages and add them again.*

## Interact with Kaazing .NET WebSocket JMS Client API

Detailed instructions to create Kaazing .NET WebSocket JMS Demo from scratch to be able to send and receive messages
over WebSocket can be found [here](http://kaazing.com/doc/5.0/jms_client_docs/dev-dotnet/o_dev_dotnet.html).

## API Documentation

API Documentation for Kaazing .NET WebSocket JMS Client library is available:

* [Kaazing.JMS](https://kaazing.com/doc/jms/4.0/apidoc/client/dotnet/jms/html/N_Kaazing_JMS.htm)
* [Kaazing.JMS.Stomp](https://kaazing.com/doc/jms/4.0/apidoc/client/dotnet/jms/html/N_Kaazing_JMS_Stomp.htm)
* [Kaazing.JMS.Util](https://kaazing.com/doc/jms/4.0/apidoc/client/dotnet/jms/html/N_Kaazing_JMS_Util.htm)
* [Kaazing.Security](http://developer.kaazing.com/documentation/gateway/4.0/apidoc/client/dotnet/gateway/html/N_Kaazing_Security.htm)
