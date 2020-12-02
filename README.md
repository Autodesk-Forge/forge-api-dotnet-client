![.NET Framework](https://img.shields.io/badge/.NET%20Framework-4.5.2-blue.svg)
![.NET Framework](https://img.shields.io/badge/.NET%20Core-2.0-blue.svg)
![Platforms](https://img.shields.io/badge/platform-windows|mac|linux-lightgray.svg)
![License](http://img.shields.io/:license-Apache-blue.svg)

*Forge API*:
[![oAuth2](https://img.shields.io/badge/oAuth2-v1-green.svg)](http://autodesk-forge.github.io/)
[![Data-Management](https://img.shields.io/badge/Data%20Management-v1-green.svg)](http://autodesk-forge.github.io/)
[![OSS](https://img.shields.io/badge/OSS-v2-green.svg)](http://autodesk-forge.github.io/)
[![Model-Derivative](https://img.shields.io/badge/Model%20Derivative-v2-green.svg)](http://autodesk-forge.github.io/)
[![Design-Automation](https://img.shields.io/badge/Design%20Automation-v3-green.svg)](http://autodesk-forge.github.io/)

# Forge .Net SDK

## Overview
This .Net SDK enables you to easily integrate the Forge REST APIs into your application,
including <a href="https://developer.autodesk.com/en/docs/oauth/v2/overview/" target="_blank">OAuth</a>,
 <a href="https://developer.autodesk.com/en/docs/data/v2/overview/" target="_blank">Data Management</a>,
 <a href="https://developer.autodesk.com/en/docs/model-derivative/v2/overview/" target="_blank">Model Derivative</a>,
and <a href="https://developer.autodesk.com/en/docs/design-automation/v2/overview/" target="_blank">Design Automation</a>.


### Requirements
* .NET Frameworks 4.5.2 or later
* .NET Core 2.0 or later
* A registered app on the <a href="https://developer.autodesk.com/myapps" target="_blank">Forge Developer portal</a>.
* Building the API client library requires [Visual Studio 2015](https://www.visualstudio.com/downloads/) to be installed.


### Dependencies
- [RestSharp](https://www.nuget.org/packages/RestSharp) 106.3.1 or later
- [Json.NET](https://www.nuget.org/packages/Newtonsoft.Json/) 11.0.2 or later

The DLLs included in the package may not be the latest version.
We recommend using [NuGet](https://docs.nuget.org/consume/installing-nuget) to obtain the latest version of the packages:
```
Install-Package RestSharp
Install-Package Newtonsoft.Json
```


### Build the SDK from sources
Run the following command to generate the DLL:
- [Mac/Linux] `/bin/sh build.sh`
- [Windows] `build.bat`

#### NuGet Deployment

Install [nuget CLI](https://docs.microsoft.com/en-us/nuget/install-nuget-client-tools#nugetexe-cli), generate an API Key and [save](https://docs.microsoft.com/en-us/nuget/tools/cli-ref-setapikey). Build application in `Release` mode. Run the following (CLI):

```bash
nuget pack /path/to/forge-api-dotnet-client/src/Autodesk.Forge/Autodesk.Forge.nuspec -build
# nuget pack "src/Autodesk.Forge/Autodesk.Forge.nuspec" -Prop Platform=AnyCPU -Prop Configuration=Release

nuget push /path/to/Autodesk.Forge.1.1.0.nupkg -Source /mycompany/repo/
# or on nuget.org
# nuget push /path/to/Autodesk.Forge.1.1.0.nupkg -Source https://api.nuget.org/v3/index.json -ApiKey %NUGETAPIKEY%
```


## Nuget Installation in your application
To install the API client library to your local application, simply execute:

```shell
Install-Package Autodesk.Forge
```

## Tutorial

> For a complete tutorial, please visit [Learn Forge](http://learnforge.autodesk.io) tutorial.

Follow this tutorial to see a step-by-step authentication guide, and examples of how to use the Forge APIs.

### Create an App
Create an app on the <a href="https://developer.autodesk.com/myapps" target="_blank">Forge Developer portal</a>.
Note the client key and client secret.

### Authentication
This SDK comes with an <a href="https://developer.autodesk.com/en/docs/oauth/v2/overview/" target="_blank">OAuth 2.0</a>
client that allows you to retrieve 2-legged and 3-legged tokens. It also enables you to refresh 3-legged tokens.
This tutorial uses both 2-legged and 3-legged tokens for calling different Data Management endpoints.


#### 2-Legged Token
This type of token is given directly to the application. To get a 2-legged token run the following code:

```csharp
using Autodesk.Forge;
using Autodesk.Forge.Client;
using Autodesk.Forge.Model;

namespace my_namespace {
	class my_class {
		// Initialize the oAuth 2.0 client configuration fron enviroment variables
		// you can also hardcode them in the code if you want in the placeholders below
		private static string FORGE_CLIENT_ID =Environment.GetEnvironmentVariable ("FORGE_CLIENT_ID")?? "your_client_id" ;
		private static string FORGE_CLIENT_SECRET =Environment.GetEnvironmentVariable ("FORGE_CLIENT_SECRET")?? "your_client_secret" ;
		private static Scope[] _scope =new Scope[] { Scope.DataRead, Scope.DataWrite } ;

		// Intialize the 2-legged oAuth 2.0 client.
		private static TwoLeggedApi _twoLeggedApi =new TwoLeggedApi () ;

		// Synchronous example
		internal static dynamic _2leggedSynchronous () {
			try {
				// Call the synchronous version of the 2-legged client with HTTP information
				// HTTP information will help you to verify if the call was successful as well
				// as read the HTTP transaction headers.
				ApiResponse<dynamic> bearer =_twoLeggedApi.AuthenticateWithHttpInfo (FORGE_CLIENT_ID, FORGE_CLIENT_SECRET, oAuthConstants.CLIENT_CREDENTIALS, _scope) ;
				if ( bearer.StatusCode != 200 )
					throw new Exception ("Request failed! (with HTTP response " + bearer.StatusCode + ")") ;

				// The JSON response from the oAuth server is the Data variable and has been
				// already parsed into a DynamicDictionary object.

				return (bearer.Data) ;
			} catch ( Exception /*ex*/ ) {
				return (null) ;
			}
		}

		public static void Test () {
			dynamic bearer =_2leggedSynchronous () ;
			if ( bearer == null ) {
				Console.WriteLine ("You were not granted a new access_token!") ;
				return ;
			}
			// The call returned successfully and you got a valid access_token.
			string token =bearer.token_type + " " + bearer.access_token ;
			Console.WriteLine ("Your synchronous token test is: " + token) ;
			// ...
		}

		// Asynchronous example (recommended)
		internal static async Task<dynamic> _2leggedAsync () {
			try {
				// Call the asynchronous version of the 2-legged client with HTTP information
				// HTTP information will help you to verify if the call was successful as well
				// as read the HTTP transaction headers.
				ApiResponse<dynamic> bearer =await _twoLeggedApi.AuthenticateAsyncWithHttpInfo (FORGE_CLIENT_ID, FORGE_CLIENT_SECRET, oAuthConstants.CLIENT_CREDENTIALS, _scope) ;
				//if ( bearer.StatusCode != 200 )
				//	throw new Exception ("Request failed! (with HTTP response " + bearer.StatusCode + ")") ;

				// The JSON response from the oAuth server is the Data variable and has been
				// already parsed into a DynamicDictionary object.

				return (bearer.Data) ;
			} catch ( Exception /*ex*/ ) {
				return (null) ;
			}
		}

		public async static void TestAsync () {
			if ( bearer == null ) {
				Console.WriteLine ("You were not granted a new access_token!") ;
				return ;
			}
			// The call returned successfully and you got a valid access_token.
			string token =bearer.token_type + " " + bearer.access_token ;
			Console.WriteLine ("Your async token test is: " + token) ;
			// ...
		}

	}
}
```


#### 3-Legged Token

##### Generate an Authentication URL
To ask for permissions from a user to retrieve an access token, you redirect the user to a consent page.
Run this code to create a consent page URL:

```csharp
using Autodesk.Forge;
using Autodesk.Forge.Client;

namespace my_namespace {
	class my_class {
		// Initialize the oAuth 2.0 client configuration fron enviroment variables
		// you can also hardcode them in the code if you want in the placeholders below
		private static string FORGE_CLIENT_ID =Environment.GetEnvironmentVariable ("FORGE_CLIENT_ID")?? "your_client_id" ;
		private static string FORGE_CLIENT_SECRET =Environment.GetEnvironmentVariable ("FORGE_CLIENT_SECRET")?? "your_client_secret" ;
		private static string PORT =Environment.GetEnvironmentVariable ("PORT")?? "3006" ;
		private static string FORGE_CALLBACK =Environment.GetEnvironmentVariable ("FORGE_CALLBACK")?? "http://localhost:" + PORT + "/oauth" ;
		private static Scope[] _scope =new Scope[] { Scope.DataRead, Scope.DataWrite } ;

		// Intialize the 3-legged oAuth 2.0 client.
		private static ThreeLeggedApi _threeLeggedApi =new ThreeLeggedApi () ;

		// Declare a local web listener to wait for the oAuth callback on the local machine.
		// Please read this article to configure your local machine properly
		// http://stackoverflow.com/questions/4019466/httplistener-access-denied
		//   ex: netsh http add urlacl url=http://+:3006/oauth user=cyrille
		// Embedded webviews are strongly discouraged for oAuth - https://developers.google.com/identity/protocols/OAuth2InstalledApp
		private static HttpListener _httpListener =null ;

		internal delegate void NewBearerDelegate (dynamic bearer) ;

		// For a Synchronous example refer to the 2legged example

		// Asynchronous example (recommended)
		internal static void _3leggedAsync (NewBearerDelegate cb) {
			try {
				if ( !HttpListener.IsSupported )
					return ; // HttpListener is not supported on this platform.
				// Initialize our web listerner
				_httpListener =new HttpListener () ;
				_httpListener.Prefixes.Add (FORGE_CALLBACK.Replace ("localhost", "+") + "/") ;
				_httpListener.Start () ;
				IAsyncResult result =_httpListener.BeginGetContext (_3leggedAsyncWaitForCode, cb) ;

				// Generate a URL page that asks for permissions for the specified scopes, and call our default web browser.
				string oauthUrl =_threeLeggedApi.Authorize (FORGE_CLIENT_ID, oAuthConstants.CODE, FORGE_CALLBACK, _scope) ;
				System.Diagnostics.Process.Start (new System.Diagnostics.ProcessStartInfo (oauthUrl)) ;
			} catch ( Exception ex ) {
				Console.WriteLine (ex.Message) ;
			}
		}
```

##### Retrieve an Authorization Code
Once a user receives permissions on the consent page, Forge will redirect
the page to the redirect URL you provided when you created the app. An authorization code is returned in the query string.

GET /callback?code={authorizationCode}

```csharp
		internal static async void _3leggedAsyncWaitForCode (IAsyncResult ar) {
			try {
				// Our local web listener was called back from the Autodesk oAuth server
				// That means the user logged properly and granted our application access
				// for the requested scope.
				// Let's grab the code fron the URL and request or final access_token

				//HttpListener listener =(HttpListener)result.AsyncState ;
				var context =_httpListener.EndGetContext (ar) ;
				string code =context.Request.QueryString [oAuthConstants.CODE] ;

				// The code is only to tell the user, he can close is web browser and return
				// to this application.
				var responseString ="<html><body>You can now close this window!</body></html>" ;
				byte[] buffer =Encoding.UTF8.GetBytes (responseString) ;
				var response =context.Response ;
				response.ContentType ="text/html" ;
				response.ContentLength64 =buffer.Length ;
				response.StatusCode =200 ;
				response.OutputStream.Write (buffer, 0, buffer.Length) ;
				response.OutputStream.Close () ;
```

##### Retrieve an Access Token
Request an access token using the authorization code you received, as shown below:

```csharp
				// Now request the final access_token
				if ( !string.IsNullOrEmpty (code) ) {
					// Call the asynchronous version of the 3-legged client with HTTP information
					// HTTP information will help you to verify if the call was successful as well
					// as read the HTTP transaction headers.
					ApiResponse<dynamic> bearer =await _threeLeggedApi.GettokenAsyncWithHttpInfo (FORGE_CLIENT_ID, FORGE_CLIENT_SECRET, oAuthConstants.AUTHORIZATION_CODE, code, FORGE_CALLBACK) ;
					//if ( bearer.StatusCode != 200 )
					//	throw new Exception ("Request failed! (with HTTP response " + bearer.StatusCode + ")") ;

					// The JSON response from the oAuth server is the Data variable and has been
					// already parsed into a DynamicDictionary object.

					//string token =bearer.Data.token_type + " " + bearer.Data.access_token ;
					//DateTime dt =DateTime.Now ;
					//dt.AddSeconds (double.Parse (bearer.Data.expires_in.ToString ())) ;

					((NewBearerDelegate)ar.AsyncState)?.Invoke (bearer.Data) ;
				} else {
					((NewBearerDelegate)ar.AsyncState)?.Invoke (null) ;
				}
			} catch ( Exception ex ) {
				Console.WriteLine (ex.Message) ;
				((NewBearerDelegate)ar.AsyncState)?.Invoke (null) ;
			} finally {
				_httpListener.Stop () ;
			}
		}

		private void Window_Initialized (object sender, EventArgs e) {
			_3leggedAsync (new NewBearerDelegate (gotit)) ;
		}

		// This is our application delegate. It is called upon success or failure
		// after the process completed
		static void gotit (dynamic bearer) {
			if ( bearer == null ) {
				MessageBox.Show ("Sorry, Authentication failed!", "3legged test", MessageBoxButton.OK, MessageBoxImage.Error) ;
				return ;
			}
			// The call returned successfully and you got a valid access_token.
			string token =bearer.token_type + " " + bearer.access_token ;
			DateTime dt =DateTime.Now ;
			dt.AddSeconds (double.Parse (bearer.expires_in.ToString ())) ;
			MessageBox.Show ("You are in!", "3legged test", MessageBoxButton.OK, MessageBoxImage.Information) ;
		}

	}
}
```

Note that access tokens expire after a short period of time. The `expires_in` field in the `bearer` object gives
the validity of an access token in seconds.
To refresh your access token, call the `_threeLeggedApi.RefreshtokenAsyncWithHttpInfo()` method.


## API Documentation

You can get the full documentation for the API on the [Developer Portal](https://developer.autodesk.com/)


### Documentation for API Endpoints

All URIs are relative to *https://developer.api.autodesk.com/* (for example createBucket URI is 'https://developer.api.autodesk.com/oss/v2/buckets')

Class | Method | HTTP request | Description
------------ | ------------- | ------------- | -------------
*ActivitiesApi* | [**CreateActivity**](docs/ActivitiesApi.md#createactivity) | **POST** /autocad.io/us-east/v2/Activities | Creates a new Activity.
*ActivitiesApi* | [**DeleteActivity**](docs/ActivitiesApi.md#deleteactivity) | **DELETE** /autocad.io/us-east/v2/Activities(&#39;{id}&#39;) | Removes a specific Activity.
*ActivitiesApi* | [**DeleteActivityHistory**](docs/ActivitiesApi.md#deleteactivityhistory) | **POST** /autocad.io/us-east/v2/Activities(&#39;{id}&#39;)/Operations.DeleteHistory | Removes the version history of the specified Activity.
*ActivitiesApi* | [**GetActivity**](docs/ActivitiesApi.md#getactivity) | **GET** /autocad.io/us-east/v2/Activities(&#39;{id}&#39;) | Returns the details of a specific Activity.
*ActivitiesApi* | [**GetActivityVersions**](docs/ActivitiesApi.md#getactivityversions) | **GET** /autocad.io/us-east/v2/Activities(&#39;{id}&#39;)/Operations.GetVersions | Returns all old versions of a specified Activity.
*ActivitiesApi* | [**GetAllActivities**](docs/ActivitiesApi.md#getallactivities) | **GET** /autocad.io/us-east/v2/Activities | Returns the details of all Activities.
*ActivitiesApi* | [**PatchActivity**](docs/ActivitiesApi.md#patchactivity) | **PATCH** /autocad.io/us-east/v2/Activities(&#39;{id}&#39;) | Updates an Activity by specifying only the changed attributes.
*ActivitiesApi* | [**SetActivityVersion**](docs/ActivitiesApi.md#setactivityversion) | **POST** /autocad.io/us-east/v2/Activities(&#39;{id}&#39;)/Operations.SetVersion | Sets the Activity to the specified version.
*AppPackagesApi* | [**CreateAppPackage**](docs/AppPackagesApi.md#createapppackage) | **POST** /autocad.io/us-east/v2/AppPackages | Creates an AppPackage module.
*AppPackagesApi* | [**DeleteAppPackage**](docs/AppPackagesApi.md#deleteapppackage) | **DELETE** /autocad.io/us-east/v2/AppPackages(&#39;{id}&#39;) | Removes a specific AppPackage.
*AppPackagesApi* | [**DeleteAppPackageHistory**](docs/AppPackagesApi.md#deleteapppackagehistory) | **POST** /autocad.io/us-east/v2/AppPackages(&#39;{id}&#39;)/Operations.DeleteHistory | Removes the version history of the specified AppPackage.
*AppPackagesApi* | [**GetAllAppPackages**](docs/AppPackagesApi.md#getallapppackages) | **GET** /autocad.io/us-east/v2/AppPackages | Returns the details of all AppPackages.
*AppPackagesApi* | [**GetAppPackage**](docs/AppPackagesApi.md#getapppackage) | **GET** /autocad.io/us-east/v2/AppPackages(&#39;{id}&#39;) | Returns the details of a specific AppPackage.
*AppPackagesApi* | [**GetAppPackageVersions**](docs/AppPackagesApi.md#getapppackageversions) | **GET** /autocad.io/us-east/v2/AppPackages(&#39;{id}&#39;)/Operations.GetVersions | Returns all old versions of a specified AppPackage.
*AppPackagesApi* | [**GetUploadUrl**](docs/AppPackagesApi.md#getuploadurl) | **GET** /autocad.io/us-east/v2/AppPackages/Operations.GetUploadUrl | Requests a pre-signed URL for uploading a zip file that contains the binaries for this AppPackage.
*AppPackagesApi* | [**GetUploadUrlWithRequireContentType**](docs/AppPackagesApi.md#getuploadurlwithrequirecontenttype) | **GET** /autocad.io/us-east/v2/AppPackages/Operations.GetUploadUrl(RequireContentType&#x3D;{require}) | Requests a pre-signed URL for uploading a zip file that contains the binaries for this AppPackage. Unlike the GetUploadUrl method that takes no parameters, this method allows the client to request that the pre-signed URL to be issued so that the subsequent HTTP PUT operation will require Content-Type=binary/octet-stream.
*AppPackagesApi* | [**PatchAppPackage**](docs/AppPackagesApi.md#patchapppackage) | **PATCH** /autocad.io/us-east/v2/AppPackages(&#39;{id}&#39;) | Updates an AppPackage by specifying only the changed attributes.
*AppPackagesApi* | [**SetAppPackageVersion**](docs/AppPackagesApi.md#setapppackageversion) | **POST** /autocad.io/us-east/v2/AppPackages(&#39;{id}&#39;)/Operations.SetVersion | Sets the AppPackage to the specified version.
*AppPackagesApi* | [**UpdateAppPackage**](docs/AppPackagesApi.md#updateapppackage) | **PUT** /autocad.io/us-east/v2/AppPackages(&#39;{id}&#39;) | Updates an AppPackage by redefining the entire Activity object.
*BucketsApi* | [**CreateBucket**](docs/BucketsApi.md#createbucket) | **POST** /oss/v2/buckets | 
*BucketsApi* | [**DeleteBucket**](docs/BucketsApi.md#deletebucket) | **DELETE** /oss/v2/buckets/{bucketKey} | 
*BucketsApi* | [**GetBucketDetails**](docs/BucketsApi.md#getbucketdetails) | **GET** /oss/v2/buckets/{bucketKey}/details | 
*BucketsApi* | [**GetBuckets**](docs/BucketsApi.md#getbuckets) | **GET** /oss/v2/buckets | 
*DerivativesApi* | [**DeleteManifest**](docs/DerivativesApi.md#deletemanifest) | **DELETE** /modelderivative/v2/designdata/{urn}/manifest | 
*DerivativesApi* | [**GetDerivativeManifest**](docs/DerivativesApi.md#getderivativemanifest) | **GET** /modelderivative/v2/designdata/{urn}/manifest/{derivativeUrn} | 
*DerivativesApi* | [**GetFormats**](docs/DerivativesApi.md#getformats) | **GET** /modelderivative/v2/designdata/formats | 
*DerivativesApi* | [**GetManifest**](docs/DerivativesApi.md#getmanifest) | **GET** /modelderivative/v2/designdata/{urn}/manifest | 
*DerivativesApi* | [**GetMetadata**](docs/DerivativesApi.md#getmetadata) | **GET** /modelderivative/v2/designdata/{urn}/metadata | 
*DerivativesApi* | [**GetModelviewMetadata**](docs/DerivativesApi.md#getmodelviewmetadata) | **GET** /modelderivative/v2/designdata/{urn}/metadata/{guid} | 
*DerivativesApi* | [**GetModelviewProperties**](docs/DerivativesApi.md#getmodelviewproperties) | **GET** /modelderivative/v2/designdata/{urn}/metadata/{guid}/properties | 
*DerivativesApi* | [**GetThumbnail**](docs/DerivativesApi.md#getthumbnail) | **GET** /modelderivative/v2/designdata/{urn}/thumbnail | 
*DerivativesApi* | [**Translate**](docs/DerivativesApi.md#translate) | **POST** /modelderivative/v2/designdata/job | 
*EnginesApi* | [**GetAllEngines**](docs/EnginesApi.md#getallengines) | **GET** /autocad.io/us-east/v2/Engines | Returns the details of all available AutoCAD core engines.
*EnginesApi* | [**GetEngine**](docs/EnginesApi.md#getengine) | **GET** /autocad.io/us-east/v2/Engines(&#39;{id}&#39;) | Returns the details of a specific AutoCAD core engine.
*FoldersApi* | [**GetFolder**](docs/FoldersApi.md#getfolder) | **GET** /data/v1/projects/{project_id}/folders/{folder_id} | 
*FoldersApi* | [**GetFolderContents**](docs/FoldersApi.md#getfoldercontents) | **GET** /data/v1/projects/{project_id}/folders/{folder_id}/contents | 
*FoldersApi* | [**GetFolderParent**](docs/FoldersApi.md#getfolderparent) | **GET** /data/v1/projects/{project_id}/folders/{folder_id}/parent | 
*FoldersApi* | [**GetFolderRefs**](docs/FoldersApi.md#getfolderrefs) | **GET** /data/v1/projects/{project_id}/folders/{folder_id}/refs | 
*FoldersApi* | [**GetFolderRelationshipsRefs**](docs/FoldersApi.md#getfolderrelationshipsrefs) | **GET** /data/v1/projects/{project_id}/folders/{folder_id}/relationships/refs | 
*FoldersApi* | [**PostFolderRelationshipsRef**](docs/FoldersApi.md#postfolderrelationshipsref) | **POST** /data/v1/projects/{project_id}/folders/{folder_id}/relationships/refs | 
*HubsApi* | [**GetHub**](docs/HubsApi.md#gethub) | **GET** /project/v1/hubs/{hub_id} | 
*HubsApi* | [**GetHubs**](docs/HubsApi.md#gethubs) | **GET** /project/v1/hubs | 
*ItemsApi* | [**GetItem**](docs/ItemsApi.md#getitem) | **GET** /data/v1/projects/{project_id}/items/{item_id} | 
*ItemsApi* | [**GetItemParentFolder**](docs/ItemsApi.md#getitemparentfolder) | **GET** /data/v1/projects/{project_id}/items/{item_id}/parent | 
*ItemsApi* | [**GetItemRefs**](docs/ItemsApi.md#getitemrefs) | **GET** /data/v1/projects/{project_id}/items/{item_id}/refs | 
*ItemsApi* | [**GetItemRelationshipsRefs**](docs/ItemsApi.md#getitemrelationshipsrefs) | **GET** /data/v1/projects/{project_id}/items/{item_id}/relationships/refs | 
*ItemsApi* | [**GetItemTip**](docs/ItemsApi.md#getitemtip) | **GET** /data/v1/projects/{project_id}/items/{item_id}/tip | 
*ItemsApi* | [**GetItemVersions**](docs/ItemsApi.md#getitemversions) | **GET** /data/v1/projects/{project_id}/items/{item_id}/versions | 
*ItemsApi* | [**PostItem**](docs/ItemsApi.md#postitem) | **POST** /data/v1/projects/{project_id}/items | 
*ItemsApi* | [**PostItemRelationshipsRef**](docs/ItemsApi.md#postitemrelationshipsref) | **POST** /data/v1/projects/{project_id}/items/{item_id}/relationships/refs | 
*ObjectsApi* | [**CopyTo**](docs/ObjectsApi.md#copyto) | **PUT** /oss/v2/buckets/{bucketKey}/objects/{objectName}/copyto/{newObjName} | 
*ObjectsApi* | [**CreateSignedResource**](docs/ObjectsApi.md#createsignedresource) | **POST** /oss/v2/buckets/{bucketKey}/objects/{objectName}/signed | 
*ObjectsApi* | [**DeleteObject**](docs/ObjectsApi.md#deleteobject) | **DELETE** /oss/v2/buckets/{bucketKey}/objects/{objectName} | 
*ObjectsApi* | [**DeleteSignedResource**](docs/ObjectsApi.md#deletesignedresource) | **DELETE** /oss/v2/signedresources/{id} | 
*ObjectsApi* | [**GetObject**](docs/ObjectsApi.md#getobject) | **GET** /oss/v2/buckets/{bucketKey}/objects/{objectName} | 
*ObjectsApi* | [**GetObjectDetails**](docs/ObjectsApi.md#getobjectdetails) | **GET** /oss/v2/buckets/{bucketKey}/objects/{objectName}/details | 
*ObjectsApi* | [**GetObjects**](docs/ObjectsApi.md#getobjects) | **GET** /oss/v2/buckets/{bucketKey}/objects | 
*ObjectsApi* | [**GetSignedResource**](docs/ObjectsApi.md#getsignedresource) | **GET** /oss/v2/signedresources/{id} | 
*ObjectsApi* | [**GetStatusBySessionId**](docs/ObjectsApi.md#getstatusbysessionid) | **GET** /oss/v2/buckets/{bucketKey}/objects/{objectName}/status/{sessionId} | 
*ObjectsApi* | [**UploadChunk**](docs/ObjectsApi.md#uploadchunk) | **PUT** /oss/v2/buckets/{bucketKey}/objects/{objectName}/resumable | 
*ObjectsApi* | [**UploadObject**](docs/ObjectsApi.md#uploadobject) | **PUT** /oss/v2/buckets/{bucketKey}/objects/{objectName} | 
*ObjectsApi* | [**UploadSignedResource**](docs/ObjectsApi.md#uploadsignedresource) | **PUT** /oss/v2/signedresources/{id} | 
*ObjectsApi* | [**UploadSignedResourcesChunk**](docs/ObjectsApi.md#uploadsignedresourceschunk) | **PUT** /oss/v2/signedresources/{id}/resumable | 
*ProjectsApi* | [**GetHubProjects**](docs/ProjectsApi.md#gethubprojects) | **GET** /project/v1/hubs/{hub_id}/projects | 
*ProjectsApi* | [**GetProject**](docs/ProjectsApi.md#getproject) | **GET** /project/v1/hubs/{hub_id}/projects/{project_id} | 
*ProjectsApi* | [**GetProjectHub**](docs/ProjectsApi.md#getprojecthub) | **GET** /project/v1/hubs/{hub_id}/projects/{project_id}/hub | 
*ProjectsApi* | [**PostStorage**](docs/ProjectsApi.md#poststorage) | **POST** /data/v1/projects/{project_id}/storage | 
*ProjectsApi* | [**PostVersion**](docs/ProjectsApi.md#postversion) | **POST** /data/v1/projects/{project_id}/versions | 
*VersionsApi* | [**GetVersion**](docs/VersionsApi.md#getversion) | **GET** /data/v1/projects/{project_id}/versions/{version_id} | 
*VersionsApi* | [**GetVersionItem**](docs/VersionsApi.md#getversionitem) | **GET** /data/v1/projects/{project_id}/versions/{version_id}/item | 
*VersionsApi* | [**GetVersionRefs**](docs/VersionsApi.md#getversionrefs) | **GET** /data/v1/projects/{project_id}/versions/{version_id}/refs | 
*VersionsApi* | [**GetVersionRelationshipsRefs**](docs/VersionsApi.md#getversionrelationshipsrefs) | **GET** /data/v1/projects/{project_id}/versions/{version_id}/relationships/refs | 
*VersionsApi* | [**PostVersionRelationshipsRef**](docs/VersionsApi.md#postversionrelationshipsref) | **POST** /data/v1/projects/{project_id}/versions/{version_id}/relationships/refs | 
*WorkItemsApi* | [**CreateWorkItem**](docs/WorkItemsApi.md#createworkitem) | **POST** /autocad.io/us-east/v2/WorkItems | Creates a new WorkItem.
*WorkItemsApi* | [**DeleteWorkItem**](docs/WorkItemsApi.md#deleteworkitem) | **DELETE** /autocad.io/us-east/v2/WorkItems(&#39;{id}&#39;) | Removes a specific WorkItem.
*WorkItemsApi* | [**GetAllWorkItems**](docs/WorkItemsApi.md#getallworkitems) | **GET** /autocad.io/us-east/v2/WorkItems | Returns the details of all WorkItems.
*WorkItemsApi* | [**GetWorkItem**](docs/WorkItemsApi.md#getworkitem) | **GET** /autocad.io/us-east/v2/WorkItems(&#39;{id}&#39;) | Returns the details of a specific WorkItem.


### Thumbnail

![thumbnail](/thumbnail.png)


## Support

forge.help@autodesk.com




## License

This sample is licensed under the terms of the [Apache License]. Please see the [LICENSE](LICENSE) file for full details.
