# Autodesk.Forge.WorkItemsApi

All URIs are relative to *https://developer.api.autodesk.com/*

Method | HTTP request | Description
------------- | ------------- | -------------
[**CreateWorkItem**](WorkItemsApi.md#createworkitem) | **POST** /autocad.io/us-east/v2/WorkItems | Creates a new WorkItem.
[**DeleteWorkItem**](WorkItemsApi.md#deleteworkitem) | **DELETE** /autocad.io/us-east/v2/WorkItems(&#39;{id}&#39;) | Removes a specific WorkItem.
[**GetAllWorkItems**](WorkItemsApi.md#getallworkitems) | **GET** /autocad.io/us-east/v2/WorkItems | Returns the details of all WorkItems.
[**GetWorkItem**](WorkItemsApi.md#getworkitem) | **GET** /autocad.io/us-east/v2/WorkItems(&#39;{id}&#39;) | Returns the details of a specific WorkItem.


<a name="createworkitem"></a>
# **CreateWorkItem**
> WorkItemResp CreateWorkItem (WorkItem workItem)

Creates a new WorkItem.

### Example
```csharp
using System;
using System.Diagnostics;
using Autodesk.Forge;
using Autodesk.Forge.Client;
using Autodesk.Forge.Model;

namespace Example
{
    public class CreateWorkItemExample
    {
        public void main()
        {
            
            // Configure OAuth2 access token for authorization: oauth2_application
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new WorkItemsApi();
            var workItem = new WorkItem(); // WorkItem | 

            try
            {
                // Creates a new WorkItem.
                WorkItemResp result = apiInstance.CreateWorkItem(workItem);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling WorkItemsApi.CreateWorkItem: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **workItem** | [**WorkItem**](WorkItem.md)|  | 

### Return type

[**WorkItemResp**](WorkItemResp.md)

### Authorization

[oauth2_application](../README.md#oauth2_application)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/vnd.api+json, application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deleteworkitem"></a>
# **DeleteWorkItem**
> void DeleteWorkItem (string id)

Removes a specific WorkItem.

### Example
```csharp
using System;
using System.Diagnostics;
using Autodesk.Forge;
using Autodesk.Forge.Client;
using Autodesk.Forge.Model;

namespace Example
{
    public class DeleteWorkItemExample
    {
        public void main()
        {
            
            // Configure OAuth2 access token for authorization: oauth2_application
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new WorkItemsApi();
            var id = id_example;  // string | 

            try
            {
                // Removes a specific WorkItem.
                apiInstance.DeleteWorkItem(id);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling WorkItemsApi.DeleteWorkItem: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **string**|  | 

### Return type

void (empty response body)

### Authorization

[oauth2_application](../README.md#oauth2_application)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/vnd.api+json, application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getallworkitems"></a>
# **GetAllWorkItems**
> DesignAutomationWorkItems GetAllWorkItems (int? skip = null)

Returns the details of all WorkItems.

### Example
```csharp
using System;
using System.Diagnostics;
using Autodesk.Forge;
using Autodesk.Forge.Client;
using Autodesk.Forge.Model;

namespace Example
{
    public class GetAllWorkItemsExample
    {
        public void main()
        {
            
            // Configure OAuth2 access token for authorization: oauth2_application
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new WorkItemsApi();
            var skip = 56;  // int? |  (optional) 

            try
            {
                // Returns the details of all WorkItems.
                DesignAutomationWorkItems result = apiInstance.GetAllWorkItems(skip);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling WorkItemsApi.GetAllWorkItems: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **skip** | **int?**|  | [optional] 

### Return type

[**DesignAutomationWorkItems**](DesignAutomationWorkItems.md)

### Authorization

[oauth2_application](../README.md#oauth2_application)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/vnd.api+json, application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getworkitem"></a>
# **GetWorkItem**
> WorkItemResp GetWorkItem (string id)

Returns the details of a specific WorkItem.

### Example
```csharp
using System;
using System.Diagnostics;
using Autodesk.Forge;
using Autodesk.Forge.Client;
using Autodesk.Forge.Model;

namespace Example
{
    public class GetWorkItemExample
    {
        public void main()
        {
            
            // Configure OAuth2 access token for authorization: oauth2_application
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new WorkItemsApi();
            var id = id_example;  // string | 

            try
            {
                // Returns the details of a specific WorkItem.
                WorkItemResp result = apiInstance.GetWorkItem(id);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling WorkItemsApi.GetWorkItem: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **string**|  | 

### Return type

[**WorkItemResp**](WorkItemResp.md)

### Authorization

[oauth2_application](../README.md#oauth2_application)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/vnd.api+json, application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

