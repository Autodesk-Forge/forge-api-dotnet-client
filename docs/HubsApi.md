# Autodesk.Forge.HubsApi

All URIs are relative to *https://developer.api.autodesk.com/*

Method | HTTP request | Description
------------- | ------------- | -------------
[**GetHub**](HubsApi.md#gethub) | **GET** /project/v1/hubs/{hub_id} | 
[**GetHubs**](HubsApi.md#gethubs) | **GET** /project/v1/hubs | 


<a name="gethub"></a>
# **GetHub**
> Hub GetHub (string hubId)



Returns data on a specific `hub_id`. 

### Example
```csharp
using System;
using System.Diagnostics;
using Autodesk.Forge;
using Autodesk.Forge.Client;
using Autodesk.Forge.Model;

namespace Example
{
    public class GetHubExample
    {
        public void main()
        {
            
            // Configure OAuth2 access token for authorization: oauth2_access_code
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new HubsApi();
            var hubId = hubId_example;  // string | the `hub id` for the current operation

            try
            {
                Hub result = apiInstance.GetHub(hubId);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling HubsApi.GetHub: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **hubId** | **string**| the &#x60;hub id&#x60; for the current operation | 

### Return type

[**Hub**](Hub.md)

### Authorization

[oauth2_access_code](../README.md#oauth2_access_code)

### HTTP request headers

 - **Content-Type**: application/vnd.api+json
 - **Accept**: application/vnd.api+json, application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="gethubs"></a>
# **GetHubs**
> Hubs GetHubs (List<string> filterId = null, List<string> filterExtensionType = null)



Returns a collection of accessible hubs for this member. A Hub represents an A360 Team/Personal hub or a BIM 360 account. 

### Example
```csharp
using System;
using System.Diagnostics;
using Autodesk.Forge;
using Autodesk.Forge.Client;
using Autodesk.Forge.Model;

namespace Example
{
    public class GetHubsExample
    {
        public void main()
        {
            
            // Configure OAuth2 access token for authorization: oauth2_access_code
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new HubsApi();
            var filterId = new List<string>(); // List<string> | filter by the `id` of the `ref` target (optional) 
            var filterExtensionType = new List<string>(); // List<string> | filter by the extension type (optional) 

            try
            {
                Hubs result = apiInstance.GetHubs(filterId, filterExtensionType);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling HubsApi.GetHubs: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **filterId** | [**List<string>**](string.md)| filter by the &#x60;id&#x60; of the &#x60;ref&#x60; target | [optional] 
 **filterExtensionType** | [**List<string>**](string.md)| filter by the extension type | [optional] 

### Return type

[**Hubs**](Hubs.md)

### Authorization

[oauth2_access_code](../README.md#oauth2_access_code)

### HTTP request headers

 - **Content-Type**: application/vnd.api+json
 - **Accept**: application/vnd.api+json, application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

