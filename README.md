[![build status](https://api.travis-ci.org/cyrillef/models.autodesk.io.png)](https://travis-ci.org/cyrillef/models.autodesk.io)
[![nuget](https://img.shields.io/badge/nuget-3.5.0-blue.svg)](https://www.nuget.org/)
![Platforms](https://img.shields.io/badge/platform-windows-lightgray.svg)
[![License](http://img.shields.io/:license-mit-blue.svg)](http://opensource.org/licenses/MIT)

*Forge API*:
[![oAuth2](https://img.shields.io/badge/oAuth2-v1-green.svg)](http://autodesk-forge.github.io/)
[![Data-Management](https://img.shields.io/badge/Data%20Management-v1-green.svg)](http://autodesk-forge.github.io/)
[![OSS](https://img.shields.io/badge/OSS-v2-green.svg)](http://autodesk-forge.github.io/)
[![Model-Derivative](https://img.shields.io/badge/Model%20Derivative-v2-green.svg)](http://autodesk-forge.github.io/)
[![Viewer](https://img.shields.io/badge/Forge%20Viewer-v2.12-green.svg)](http://autodesk-forge.github.io/)


# Forge .Net (C#) SDK

## Overview
This .Net SDK enables you to easily integrate the Forge REST APIs into your application,
including <a href="https://developer.autodesk.com/en/docs/oauth/v2/overview/" target="_blank">OAuth</a>,
 <a href="https://developer.autodesk.com/en/docs/data/v2/overview/" target="_blank">Data Management</a>,
 <a href="https://developer.autodesk.com/en/docs/model-derivative/v2/overview/" target="_blank">Model Derivative</a>,
and <a href="https://developer.autodesk.com/en/docs/design-automation/v2/overview/" target="_blank">Design Automation</a>.


### Requirements
* .NET 4.0 or later
* A registered app on the <a href="https://developer.autodesk.com/myapps" target="_blank">Forge Developer portal</a>.
* Building the API client library requires [Visual Studio 2015](https://www.visualstudio.com/downloads/) to be installed.


### Dependencies
- [RestSharp](https://www.nuget.org/packages/RestSharp) - 105.1.0 or later
- [Json.NET](https://www.nuget.org/packages/Newtonsoft.Json/) - 8.0.3 or later

The DLLs included in the package may not be the latest version. We recommned using
[NuGet](https://docs.nuget.org/consume/installing-nuget) to obtain the latest version of the packages:
```
Install-Package RestSharp
Install-Package Newtonsoft.Json
```

NOTE: RestSharp versions greater than 105.1.0 have a bug which causes file uploads to fail.
See [RestSharp#742](https://github.com/restsharp/RestSharp/issues/742)


### Build the SDK from sources
Run the following command to generate the DLL
- [Mac/Linux] `/bin/sh build.sh`
- [Windows] `build.bat`


## nuget Installation in your application
To install the API client library to your local application, simply execute:

```shell
Install-Package forge-apis
```

## Tutorial
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
		private static string FORGE_CLIENT_ID ="" ; // 'your_client_id'
		private static string FORGE_CLIENT_SECRET ="" ; // 'your_client_secret'
		private static Scope[] _scope =new Scope[] { Scope.DataRead, Scope.DataWrite } ;
		private static TwoLeggedApi _twoLeggedApi =new TwoLeggedApi () ;

        // Synchronous example
        internal static ApiResponse<dynamic> _2leggedSynchronous () {
            try {
                ApiResponse<dynamic> bearer =_twoLeggedApi.AuthenticateWithHttpInfo (FORGE_CLIENT_ID, FORGE_CLIENT_SECRET, oAuthConstants.CLIENT_CREDENTIALS, _scope) ;
                //string token =bearer.Data.token_type + " " + bearer.Data.access_token ;
                //DateTime dt =DateTime.Now ;
                //dt.AddSeconds (double.Parse (bearer.Data.expires_in.ToString ())) ;
                return (bearer.Data) ;
            } catch ( Exception /*ex*/ ) {
                return (null) ;
            }
        }

        public void Test () {
            dynamic bearer =_2leggedSynchronous () ;
            string token =bearer.token_type + " " + bearer.access_token ;
            // ...
        }

        // Asynchronous example (recommended)
        internal static async Task<ApiResponse<dynamic>> _2leggedAsync () {
        	try {
        		ApiResponse<dynamic> bearer =await _twoLeggedApi.AuthenticateAsyncWithHttpInfo (FORGE_CLIENT_ID, FORGE_CLIENT_SECRET, oAuthConstants.CLIENT_CREDENTIALS, _scope) ;
                //string token =bearer.Data.token_type + " " + bearer.Data.access_token ;
                //DateTime dt =DateTime.Now ;
                //dt.AddSeconds (double.Parse (bearer.Data.expires_in.ToString ())) ;
        		return (bearer.Data) ;
        	} catch ( Exception /*ex*/ ) {
        		return (null) ;
        	}
        }

        public async void TestAsync () {
            dynamic bearer =await _2leggedAsync () ;
            string token =bearer.token_type + " " + bearer.access_token ;
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
		private static string FORGE_CLIENT_ID ="" ; // 'your_client_id'
		private static string FORGE_CLIENT_SECRET ="" ; // 'your_client_secret'
		private static string FORGE_CALLBACK =null ; // 'http://localhost:' + PORT + '/oauth' ;
		private static Scope[] _scope =new Scope[] { Scope.DataRead, Scope.DataWrite } ;
		private static ThreeLeggedApi _threeLeggedApi =new ThreeLeggedApi () ;

        // For a Synchronous example refer to the 2legged example

        // Asynchronous example (recommended)
        // http://stackoverflow.com/questions/4019466/httplistener-access-denied
        //   ex: netsh http add urlacl url=http://+:3006/oauth user=cyrille
        // Embedded webviews are strongly discouraged for oAuth - https://developers.google.com/identity/protocols/OAuth2InstalledApp
        private static HttpListener _httpListener =null ;
        internal delegate void NewBearerDelegate (dynamic bearer) ;

        internal static void _3leggedAsync (NewBearerDeletegate cb) {
            try {
                if ( !HttpListener.IsSupported )
                    return ; // HttpListener is not supported on this platform.
                _httpListener =new HttpListener () ;
                _httpListener.Prefixes.Add (FORGE_CALLBACK.Replace ("localhost", "+") + "/") ;
                _httpListener.Start () ;
                IAsyncResult result =_httpListener.BeginGetContext (_3leggedAsyncWaitForCode, cb) ;

                // Generate a URL page that asks for permissions for the specified scopes.
                string oauthUrl =_threeLeggedApi.Authorize (FORGE_CLIENT_ID, oAuthConstants.CODE, FORGE_CALLBACK, _scope) ;
                System.Diagnostics.Process.Start (new System.Diagnostics.ProcessStartInfo (oauthUrl)) ;
            } catch ( Exception /*ex*/ ) {
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
                var context =_httpListener.EndGetContext (ar) ;
                string code =context.Request.QueryString ["code"] ;

                var responseString ="<html><body>You can now close this window!</body></html>" ;
                byte[] buffer =Encoding.UTF8.GetBytes (responseString) ;
                var response =context.Response ;
                response.ContentLength64 =buffer.Length ;
                response.OutputStream.Write (buffer, 0, buffer.Length) ;
                response.OutputStream.Close () ;

```

##### Retrieve an Access Token
Request an access token using the authorization code you received, as shown below:

```csharp
                if ( !string.IsNullOrEmpty (code) ) {
                    // Request an access token using the authorization code
                    ApiResponse<dynamic> bearer =await _threeLeggedApi.GettokenAsyncWithHttpInfo (FORGE_CLIENT_ID, FORGE_CLIENT_SECRET, oAuthConstants.AUTHORIZATION_CODE, code, FORGE_CALLBACK) ;
                    //string token =bearer.Data.token_type + " " + bearer.Data.access_token ;
                    //DateTime dt =DateTime.Now ;
                    //dt.AddSeconds (double.Parse (bearer.Data.expires_in.ToString ())) ;

                    // The `credentials` object contains an `access_token` and an optional `refresh_token` that you can use to call the endpoints.
                    ((NewBearerDelegate)ar.AsyncState)?.Invoke (bearer.Data) ;
                }
            } catch ( Exception /*ex*/ ) {
            } finally {
                _httpListener.Stop () ;
            }
        }

        public static void TestAsync () {
            _3leggedAsync (new NewBearerDelegate (gotit)) ;
        }

        protected static void gotit (dynamic bearer) {
            //string token =bearer.token_type + " " + bearer.access_token ;
            //DateTime dt =DateTime.Now ;
            //dt.AddSeconds (double.Parse (bearer.expires_in.ToString ())) ;
            // ...
        }

	}
}
```

Note that access tokens expire after a short period of time. The `expires_in` field in the `bearer` object gives
the validity of an access token in seconds.
To refresh your access token, call the `_threeLeggedApi.RefreshtokenAsyncWithHttpInfo()` method.


<a name="documentation-for-api-endpoints"></a>
## Documentation for API Endpoints

All URIs are relative to *https://developer.api.autodesk.com/*

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


<a name="documentation-for-models"></a>
## Documentation for Models

 - [Model.Activity](docs/Activity.md)
 - [Model.ActivityOptional](docs/ActivityOptional.md)
 - [Model.ActivityVersion](docs/ActivityVersion.md)
 - [Model.AppPackage](docs/AppPackage.md)
 - [Model.AppPackageOptional](docs/AppPackageOptional.md)
 - [Model.AppPackageVersion](docs/AppPackageVersion.md)
 - [Model.BadInput](docs/BadInput.md)
 - [Model.BaseAttributesCreatedUpdated](docs/BaseAttributesCreatedUpdated.md)
 - [Model.BaseAttributesCreatedUpdatedAttributes](docs/BaseAttributesCreatedUpdatedAttributes.md)
 - [Model.BaseAttributesExtensionObject](docs/BaseAttributesExtensionObject.md)
 - [Model.Bucket](docs/Bucket.md)
 - [Model.BucketObjects](docs/BucketObjects.md)
 - [Model.Buckets](docs/Buckets.md)
 - [Model.BucketsItems](docs/BucketsItems.md)
 - [Model.Conflict](docs/Conflict.md)
 - [Model.CreateItem](docs/CreateItem.md)
 - [Model.CreateItemData](docs/CreateItemData.md)
 - [Model.CreateItemDataRelationships](docs/CreateItemDataRelationships.md)
 - [Model.CreateItemDataRelationshipsTip](docs/CreateItemDataRelationshipsTip.md)
 - [Model.CreateItemDataRelationshipsTipData](docs/CreateItemDataRelationshipsTipData.md)
 - [Model.CreateItemIncluded](docs/CreateItemIncluded.md)
 - [Model.CreateItemRelationships](docs/CreateItemRelationships.md)
 - [Model.CreateItemRelationshipsStorage](docs/CreateItemRelationshipsStorage.md)
 - [Model.CreateItemRelationshipsStorageData](docs/CreateItemRelationshipsStorageData.md)
 - [Model.CreateRef](docs/CreateRef.md)
 - [Model.CreateRefData](docs/CreateRefData.md)
 - [Model.CreateRefDataMeta](docs/CreateRefDataMeta.md)
 - [Model.CreateStorage](docs/CreateStorage.md)
 - [Model.CreateStorageData](docs/CreateStorageData.md)
 - [Model.CreateStorageDataAttributes](docs/CreateStorageDataAttributes.md)
 - [Model.CreateStorageDataRelationships](docs/CreateStorageDataRelationships.md)
 - [Model.CreateStorageDataRelationshipsTarget](docs/CreateStorageDataRelationshipsTarget.md)
 - [Model.CreateVersion](docs/CreateVersion.md)
 - [Model.CreateVersionData](docs/CreateVersionData.md)
 - [Model.CreateVersionDataRelationships](docs/CreateVersionDataRelationships.md)
 - [Model.CreateVersionDataRelationshipsItem](docs/CreateVersionDataRelationshipsItem.md)
 - [Model.CreateVersionDataRelationshipsItemData](docs/CreateVersionDataRelationshipsItemData.md)
 - [Model.DesignAutomationActivities](docs/DesignAutomationActivities.md)
 - [Model.DesignAutomationAppPackages](docs/DesignAutomationAppPackages.md)
 - [Model.DesignAutomationEngines](docs/DesignAutomationEngines.md)
 - [Model.DesignAutomationWorkItems](docs/DesignAutomationWorkItems.md)
 - [Model.Diagnostics](docs/Diagnostics.md)
 - [Model.Engine](docs/Engine.md)
 - [Model.Folder](docs/Folder.md)
 - [Model.FolderAttributes](docs/FolderAttributes.md)
 - [Model.FolderRelationships](docs/FolderRelationships.md)
 - [Model.Forbidden](docs/Forbidden.md)
 - [Model.Formats](docs/Formats.md)
 - [Model.FormatsFormats](docs/FormatsFormats.md)
 - [Model.Hub](docs/Hub.md)
 - [Model.HubAttributes](docs/HubAttributes.md)
 - [Model.HubRelationships](docs/HubRelationships.md)
 - [Model.Hubs](docs/Hubs.md)
 - [Model.Item](docs/Item.md)
 - [Model.ItemAttributes](docs/ItemAttributes.md)
 - [Model.ItemCreated](docs/ItemCreated.md)
 - [Model.ItemRelationships](docs/ItemRelationships.md)
 - [Model.Job](docs/Job.md)
 - [Model.JobAcceptedJobs](docs/JobAcceptedJobs.md)
 - [Model.JobIgesOutputPayload](docs/JobIgesOutputPayload.md)
 - [Model.JobIgesOutputPayloadAdvanced](docs/JobIgesOutputPayloadAdvanced.md)
 - [Model.JobObjOutputPayload](docs/JobObjOutputPayload.md)
 - [Model.JobObjOutputPayloadAdvanced](docs/JobObjOutputPayloadAdvanced.md)
 - [Model.JobPayload](docs/JobPayload.md)
 - [Model.JobPayloadInput](docs/JobPayloadInput.md)
 - [Model.JobPayloadItem](docs/JobPayloadItem.md)
 - [Model.JobPayloadOutput](docs/JobPayloadOutput.md)
 - [Model.JobStepOutputPayload](docs/JobStepOutputPayload.md)
 - [Model.JobStepOutputPayloadAdvanced](docs/JobStepOutputPayloadAdvanced.md)
 - [Model.JobStlOutputPayload](docs/JobStlOutputPayload.md)
 - [Model.JobStlOutputPayloadAdvanced](docs/JobStlOutputPayloadAdvanced.md)
 - [Model.JobSvfOutputPayload](docs/JobSvfOutputPayload.md)
 - [Model.JobThumbnailOutputPayload](docs/JobThumbnailOutputPayload.md)
 - [Model.JobThumbnailOutputPayloadAdvanced](docs/JobThumbnailOutputPayloadAdvanced.md)
 - [Model.JsonApiAttributes](docs/JsonApiAttributes.md)
 - [Model.JsonApiCollection](docs/JsonApiCollection.md)
 - [Model.JsonApiDocument](docs/JsonApiDocument.md)
 - [Model.JsonApiDocumentBase](docs/JsonApiDocumentBase.md)
 - [Model.JsonApiError](docs/JsonApiError.md)
 - [Model.JsonApiErrorErrors](docs/JsonApiErrorErrors.md)
 - [Model.JsonApiErrorLinks](docs/JsonApiErrorLinks.md)
 - [Model.JsonApiLink](docs/JsonApiLink.md)
 - [Model.JsonApiLinks](docs/JsonApiLinks.md)
 - [Model.JsonApiLinksPaging](docs/JsonApiLinksPaging.md)
 - [Model.JsonApiLinksRelated](docs/JsonApiLinksRelated.md)
 - [Model.JsonApiLinksSelf](docs/JsonApiLinksSelf.md)
 - [Model.JsonApiMeta](docs/JsonApiMeta.md)
 - [Model.JsonApiMetaLink](docs/JsonApiMetaLink.md)
 - [Model.JsonApiRelationships](docs/JsonApiRelationships.md)
 - [Model.JsonApiRelationshipsLinksExternalResource](docs/JsonApiRelationshipsLinksExternalResource.md)
 - [Model.JsonApiRelationshipsLinksInternal](docs/JsonApiRelationshipsLinksInternal.md)
 - [Model.JsonApiRelationshipsLinksInternalResource](docs/JsonApiRelationshipsLinksInternalResource.md)
 - [Model.JsonApiRelationshipsLinksRefs](docs/JsonApiRelationshipsLinksRefs.md)
 - [Model.JsonApiRelationshipsLinksRefsLinks](docs/JsonApiRelationshipsLinksRefsLinks.md)
 - [Model.JsonApiResource](docs/JsonApiResource.md)
 - [Model.JsonApiTypeId](docs/JsonApiTypeId.md)
 - [Model.JsonApiVersion](docs/JsonApiVersion.md)
 - [Model.JsonApiVersionJsonapi](docs/JsonApiVersionJsonapi.md)
 - [Model.Manifest](docs/Manifest.md)
 - [Model.ManifestChildren](docs/ManifestChildren.md)
 - [Model.ManifestDerivative](docs/ManifestDerivative.md)
 - [Model.Message](docs/Message.md)
 - [Model.Messages](docs/Messages.md)
 - [Model.Metadata](docs/Metadata.md)
 - [Model.MetadataCollection](docs/MetadataCollection.md)
 - [Model.MetadataData](docs/MetadataData.md)
 - [Model.MetadataMetadata](docs/MetadataMetadata.md)
 - [Model.MetadataObject](docs/MetadataObject.md)
 - [Model.NotFound](docs/NotFound.md)
 - [Model.ObjectDetails](docs/ObjectDetails.md)
 - [Model.ObjectFullDetails](docs/ObjectFullDetails.md)
 - [Model.ObjectFullDetailsDeltas](docs/ObjectFullDetailsDeltas.md)
 - [Model.Permission](docs/Permission.md)
 - [Model.PostBucketsPayload](docs/PostBucketsPayload.md)
 - [Model.PostBucketsPayloadAllow](docs/PostBucketsPayloadAllow.md)
 - [Model.PostBucketsSigned](docs/PostBucketsSigned.md)
 - [Model.PostObjectSigned](docs/PostObjectSigned.md)
 - [Model.Project](docs/Project.md)
 - [Model.ProjectAttributes](docs/ProjectAttributes.md)
 - [Model.ProjectRelationships](docs/ProjectRelationships.md)
 - [Model.Projects](docs/Projects.md)
 - [Model.Reason](docs/Reason.md)
 - [Model.Refs](docs/Refs.md)
 - [Model.RelRef](docs/RelRef.md)
 - [Model.RelRefMeta](docs/RelRefMeta.md)
 - [Model.Result](docs/Result.md)
 - [Model.Storage](docs/Storage.md)
 - [Model.StorageCreated](docs/StorageCreated.md)
 - [Model.StorageRelationships](docs/StorageRelationships.md)
 - [Model.StorageRelationshipsTarget](docs/StorageRelationshipsTarget.md)
 - [Model.StorageRelationshipsTargetData](docs/StorageRelationshipsTargetData.md)
 - [Model.Version](docs/Version.md)
 - [Model.VersionAttributes](docs/VersionAttributes.md)
 - [Model.VersionCreated](docs/VersionCreated.md)
 - [Model.VersionRelationships](docs/VersionRelationships.md)
 - [Model.Versions](docs/Versions.md)
 - [Model.WorkItem](docs/WorkItem.md)
 - [Model.WorkItemResp](docs/WorkItemResp.md)


## Documentation for Authorization

### oauth2_access_code

- **Type**: OAuth
- **Flow**: accessCode
- **Authorization URL**: /authentication/v1/authorize
- **Scopes**: 
  - data:read: The application will be able to read the end user’s data within the Autodesk ecosystem.
  - data:write: The application will be able to create, update, and delete data on behalf of the end user within the Autodesk ecosystem.
  - data:create: The application will be able to create data on behalf of the end user within the Autodesk ecosystem.
  - data:search: The application will be able to search the end user’s data within the Autodesk ecosystem.
  - bucket:create: The application will be able to create an OSS bucket it will own.
  - bucket:read: The application will be able to read the metadata and list contents for OSS buckets that it has access to.
  - bucket:update: The application will be able to set permissions and entitlements for OSS buckets that it has permission to modify.
  - bucket:delete: The application will be able to delete a bucket that it has permission to delete.
  - code:all: The application will be able to author and execute code on behalf of the end user (e.g., scripts processed by the Design Automation API).
  - account:read: For Product APIs, the application will be able to read the account data the end user has entitlements to.
  - account:write: For Product APIs, the application will be able to update the account data the end user has entitlements to.
  - user-profile:read: The application will be able to read the end user’s profile data.

### oauth2_application

- **Type**: OAuth
- **Flow**: application
- **Authorization URL**: 
- **Scopes**: 
  - data:read: The application will be able to read the end user’s data within the Autodesk ecosystem.
  - data:write: The application will be able to create, update, and delete data on behalf of the end user within the Autodesk ecosystem.
  - data:create: The application will be able to create data on behalf of the end user within the Autodesk ecosystem.
  - data:search: The application will be able to search the end user’s data within the Autodesk ecosystem.
  - bucket:create: The application will be able to create an OSS bucket it will own.
  - bucket:read: The application will be able to read the metadata and list contents for OSS buckets that it has access to.
  - bucket:update: The application will be able to set permissions and entitlements for OSS buckets that it has permission to modify.
  - bucket:delete: The application will be able to delete a bucket that it has permission to delete.
  - code:all: The application will be able to author and execute code on behalf of the end user (e.g., scripts processed by the Design Automation API).
  - account:read: For Product APIs, the application will be able to read the account data the end user has entitlements to.
  - account:write: For Product APIs, the application will be able to update the account data the end user has entitlements to.
  - user-profile:read: The application will be able to read the end user’s profile data.



## Support

forge.help@autodesk.com



## License

This sample is licensed under the terms of the [MIT License](http://opensource.org/licenses/MIT).
Please see the [LICENSE](LICENSE) file for full details.
