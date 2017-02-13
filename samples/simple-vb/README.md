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
    ```https://github.com/Autodesk-Forge/forge-api-dotnet-client.git```


### Create an App
[Create an app](https://developer.autodesk.com/en/docs/oauth/v2/tutorials/create-app/) on the 
Forge Developer portal, and ensure that you select the Data Management and Model Derivative APIs. 
Note the client ID and client secret.


### Configure & Build the sample
A developer can use either use environment variables or inserting the client id and secret directly
into the code. However, the secret key should never be exposed for security reasons, so it is recommended
to not have the keys in code unless they are encrypted.
 
1. Use environment variables:
 
  * Open a Visual Studio 2015 Console window (aka Command Prompt window).
  * Create 2 environment variables `FORGE_CLIENT_ID` and `FORGE_CLIENT_SECRET` with the client ID and client secret generated when creating the app.
  
    ```
    set FORGE_CLIENT_ID=<your client id>
    
    set FORGE_CLIENT_SECRET=<your client secret>
    ```
  * Start Visual Studio from the command prompt, typing ``` devenv ```, and load the project.
 
2. Hardcode the keys in code (unsafe, but ok for testing)
  * Open Visual Studio 2015 IDE
  * Load the project
  * Put the client id and secret in their respective placeholders in file Module1.vb, line #37 and #38
 
3. Build the sample.
 
 
### Run the App
* Run the app from Visual Studio.
* If you want to run it from the command line, follow these instructions:

  1. Go back on the Console window you opened previously,
  2. Go in the directory where is the sample, for example: ``` cd "\Users\cyrille\Documents\Visual Studio 2015\Projects\forge-api-dotnet-client\samples\simple-vb" ```
  3. If you built the Release version, type: ``` simple-vb\bin\Release\forge.simple-vb ```


## Support
* [Get Help](https://developer.autodesk.com/en/support/get-help)
* [Stackoverflow](http://stackoverflow.com/questions/tagged/forge)


## License

This sample is licensed under the terms of the [MIT License](http://opensource.org/licenses/MIT).
Please see the [LICENSE](LICENSE) file for full details.
