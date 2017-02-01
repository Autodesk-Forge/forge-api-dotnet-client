# Autodesk.Forge.ProjectsApi

All URIs are relative to *https://developer.api.autodesk.com/*

Method | HTTP request | Description
------------- | ------------- | -------------
[**GetHubProjects**](ProjectsApi.md#gethubprojects) | **GET** /project/v1/hubs/{hub_id}/projects | 
[**GetProject**](ProjectsApi.md#getproject) | **GET** /project/v1/hubs/{hub_id}/projects/{project_id} | 
[**GetProjectHub**](ProjectsApi.md#getprojecthub) | **GET** /project/v1/hubs/{hub_id}/projects/{project_id}/hub | 
[**PostStorage**](ProjectsApi.md#poststorage) | **POST** /data/v1/projects/{project_id}/storage | 
[**PostVersion**](ProjectsApi.md#postversion) | **POST** /data/v1/projects/{project_id}/versions | 


<a name="gethubprojects"></a>
# **GetHubProjects**
> Projects GetHubProjects (string hubId, List<string> filterId = null, List<string> filterExtensionType = null)



Returns a collection of projects for a given `hub_id`. A project represents an A360 project or a BIM 360 project which is set up under an A360 hub or BIM 360 account, respectively. Within a hub or an account, multiple projects can be created to be used. 

### Example
```csharp
using System;
using System.Diagnostics;
using Autodesk.Forge;
using Autodesk.Forge.Client;
using Autodesk.Forge.Model;

namespace Example
{
    public class GetHubProjectsExample
    {
        public void main()
        {
            
            // Configure OAuth2 access token for authorization: oauth2_access_code
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ProjectsApi();
            var hubId = hubId_example;  // string | the `hub id` for the current operation
            var filterId = new List<string>(); // List<string> | filter by the `id` of the `ref` target (optional) 
            var filterExtensionType = new List<string>(); // List<string> | filter by the extension type (optional) 

            try
            {
                Projects result = apiInstance.GetHubProjects(hubId, filterId, filterExtensionType);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ProjectsApi.GetHubProjects: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **hubId** | **string**| the &#x60;hub id&#x60; for the current operation | 
 **filterId** | [**List<string>**](string.md)| filter by the &#x60;id&#x60; of the &#x60;ref&#x60; target | [optional] 
 **filterExtensionType** | [**List<string>**](string.md)| filter by the extension type | [optional] 

### Return type

[**Projects**](Projects.md)

### Authorization

[oauth2_access_code](../README.md#oauth2_access_code)

### HTTP request headers

 - **Content-Type**: application/vnd.api+json
 - **Accept**: application/vnd.api+json, application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getproject"></a>
# **GetProject**
> Project GetProject (string hubId, string projectId)



Returns a project for a given `project_id`. 

### Example
```csharp
using System;
using System.Diagnostics;
using Autodesk.Forge;
using Autodesk.Forge.Client;
using Autodesk.Forge.Model;

namespace Example
{
    public class GetProjectExample
    {
        public void main()
        {
            
            // Configure OAuth2 access token for authorization: oauth2_access_code
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ProjectsApi();
            var hubId = hubId_example;  // string | the `hub id` for the current operation
            var projectId = projectId_example;  // string | the `project id`

            try
            {
                Project result = apiInstance.GetProject(hubId, projectId);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ProjectsApi.GetProject: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **hubId** | **string**| the &#x60;hub id&#x60; for the current operation | 
 **projectId** | **string**| the &#x60;project id&#x60; | 

### Return type

[**Project**](Project.md)

### Authorization

[oauth2_access_code](../README.md#oauth2_access_code)

### HTTP request headers

 - **Content-Type**: application/vnd.api+json
 - **Accept**: application/vnd.api+json, application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getprojecthub"></a>
# **GetProjectHub**
> Hub GetProjectHub (string hubId, string projectId)



Returns the hub for a given `project_id`. 

### Example
```csharp
using System;
using System.Diagnostics;
using Autodesk.Forge;
using Autodesk.Forge.Client;
using Autodesk.Forge.Model;

namespace Example
{
    public class GetProjectHubExample
    {
        public void main()
        {
            
            // Configure OAuth2 access token for authorization: oauth2_access_code
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ProjectsApi();
            var hubId = hubId_example;  // string | the `hub id` for the current operation
            var projectId = projectId_example;  // string | the `project id`

            try
            {
                Hub result = apiInstance.GetProjectHub(hubId, projectId);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ProjectsApi.GetProjectHub: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **hubId** | **string**| the &#x60;hub id&#x60; for the current operation | 
 **projectId** | **string**| the &#x60;project id&#x60; | 

### Return type

[**Hub**](Hub.md)

### Authorization

[oauth2_access_code](../README.md#oauth2_access_code)

### HTTP request headers

 - **Content-Type**: application/vnd.api+json
 - **Accept**: application/vnd.api+json, application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="poststorage"></a>
# **PostStorage**
> StorageCreated PostStorage (string projectId, CreateStorage body)



Creates a storage location in the OSS where data can be uploaded to. 

### Example
```csharp
using System;
using System.Diagnostics;
using Autodesk.Forge;
using Autodesk.Forge.Client;
using Autodesk.Forge.Model;

namespace Example
{
    public class PostStorageExample
    {
        public void main()
        {
            
            // Configure OAuth2 access token for authorization: oauth2_access_code
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ProjectsApi();
            var projectId = projectId_example;  // string | the `project id`
            var body = new CreateStorage(); // CreateStorage | describe the file the storage is created for

            try
            {
                StorageCreated result = apiInstance.PostStorage(projectId, body);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ProjectsApi.PostStorage: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **projectId** | **string**| the &#x60;project id&#x60; | 
 **body** | [**CreateStorage**](CreateStorage.md)| describe the file the storage is created for | 

### Return type

[**StorageCreated**](StorageCreated.md)

### Authorization

[oauth2_access_code](../README.md#oauth2_access_code)

### HTTP request headers

 - **Content-Type**: application/vnd.api+json
 - **Accept**: application/vnd.api+json, application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="postversion"></a>
# **PostVersion**
> VersionCreated PostVersion (string projectId, CreateVersion body)



Creates a new version of an item in the 'data' domain service. 

### Example
```csharp
using System;
using System.Diagnostics;
using Autodesk.Forge;
using Autodesk.Forge.Client;
using Autodesk.Forge.Model;

namespace Example
{
    public class PostVersionExample
    {
        public void main()
        {
            
            // Configure OAuth2 access token for authorization: oauth2_access_code
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ProjectsApi();
            var projectId = projectId_example;  // string | the `project id`
            var body = new CreateVersion(); // CreateVersion | describe the version to be created

            try
            {
                VersionCreated result = apiInstance.PostVersion(projectId, body);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ProjectsApi.PostVersion: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **projectId** | **string**| the &#x60;project id&#x60; | 
 **body** | [**CreateVersion**](CreateVersion.md)| describe the version to be created | 

### Return type

[**VersionCreated**](VersionCreated.md)

### Authorization

[oauth2_access_code](../README.md#oauth2_access_code)

### HTTP request headers

 - **Content-Type**: application/vnd.api+json
 - **Accept**: application/vnd.api+json, application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

