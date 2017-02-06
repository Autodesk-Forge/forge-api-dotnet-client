# Forge VB.Net Sample App

## Overview
This sample app uses the Forge .Net (C#) SDK to introduce the 
[OAuth](https://developer.autodesk.com/en/docs/oauth/v2/overview/), 
[Data Management](https://developer.autodesk.com/en/docs/data/v2/overview/) 
and [Model Derivative](https://developer.autodesk.com/en/docs/model-derivative/v2/overview/) Forge APIs, 
as well as the [Viewer](https://developer.autodesk.com/en/docs/viewer/v2/overview/) JavaScript library. 
It shows the following typical workflow:

* Create a 2-legged authentication token
* Create a bucket (an arbitrary space to store objects)
* Upload a file to the bucket
* Prepare the file for displaying in the Viewer (translate the file into SVF format)
* Display the translated file in the Viewer


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


### Build the sample
Load the project in Visual Studio 2015, and build the sample.


### Configure the Parameters
Open a Console window (aka Command Prompt window).
Create 2 environment variables `FORGE_CLIENT_ID` and `FORGE_CLIENT_SECRET` with the client ID and 
client secret generated when creating the app.


### Run the App
Run the app.


## Support
forge.help@autodesk.com


## License

This sample is licensed under the terms of the [MIT License](http://opensource.org/licenses/MIT).
Please see the [LICENSE](LICENSE) file for full details.
