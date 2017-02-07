# Forge 3 legged VB.Net Sample App

## Overview
This sample app uses the Forge .Net (C#) SDK to introduce the 
[OAuth](https://developer.autodesk.com/en/docs/oauth/v2/overview/), 
It shows the following typical workflow:

* Create a 3-legged authentication token


### Requirements
* .NET 4.0 or later
* A registered app on the <a href="https://developer.autodesk.com/myapps" target="_blank">Forge Developer portal</a>.
* Building the API client library requires [Visual Studio 2015](https://www.visualstudio.com/downloads/) to be installed.


### Installation
Clone the following repository:<br />
    ```https://github.com/Autodesk-Forge/forge-api-csharp-client.git```


### Create an App
[Create an app](https://developer.autodesk.com/en/docs/oauth/v2/tutorials/create-app/) on the 
Forge Developer portal, and ensure that you select the Data Management and Model Derivative APIs. 
Note the client ID and client secret.


### Configure the Parameters
* Open a Console window (aka Command Prompt window).
* Create 3 environment variables `FORGE_CLIENT_ID`, `FORGE_CLIENT_SECRET` and `FORGE_CALLBACK`
with the client ID, client secret, and redirect URL generated when creating the app.


### Build the sample
* Start Visual Studio from the command prompt, typing ``` devenv ```.
* Load the project in Visual Studio 2015, and build the sample.


### Run the App
* Run the app from Visual Studio.
* If you want to run it from the command line,follow these instructions:

  1. Go back on the Console window you opened previously,
  2. Go in the directory where is the sample, for example: ``` cd "\Users\cyrille\Documents\Visual Studio 2015\Projects\forge-api-dotnet-client\samples\3legged-vb" ```
  3. If you built the Release version, type: ``` 3legged-vb\bin\Release\forge.3legged-vb ```


## Support
* [Get Help](https://developer.autodesk.com/en/support/get-help)
* [Stackoverflow](http://stackoverflow.com/questions/tagged/forge)


## License

This sample is licensed under the terms of the [MIT License](http://opensource.org/licenses/MIT).
Please see the [LICENSE](LICENSE) file for full details.
