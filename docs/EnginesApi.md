# Autodesk.Forge.EnginesApi

All URIs are relative to *https://developer.api.autodesk.com/*

Method | HTTP request | Description
------------- | ------------- | -------------
[**GetAllEngines**](EnginesApi.md#getallengines) | **GET** /autocad.io/us-east/v2/Engines | Returns the details of all available AutoCAD core engines.
[**GetEngine**](EnginesApi.md#getengine) | **GET** /autocad.io/us-east/v2/Engines(&#39;{id}&#39;) | Returns the details of a specific AutoCAD core engine.


<a name="getallengines"></a>
# **GetAllEngines**
> DesignAutomationEngines GetAllEngines ()

Returns the details of all available AutoCAD core engines.

### Example
```csharp
using System;
using System.Diagnostics;
using Autodesk.Forge;
using Autodesk.Forge.Client;
using Autodesk.Forge.Model;

namespace Example
{
    public class GetAllEnginesExample
    {
        public void main()
        {
            
            // Configure OAuth2 access token for authorization: oauth2_application
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new EnginesApi();

            try
            {
                // Returns the details of all available AutoCAD core engines.
                DesignAutomationEngines result = apiInstance.GetAllEngines();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling EnginesApi.GetAllEngines: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**DesignAutomationEngines**](DesignAutomationEngines.md)

### Authorization

[oauth2_application](../README.md#oauth2_application)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/vnd.api+json, application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getengine"></a>
# **GetEngine**
> Engine GetEngine (string id)

Returns the details of a specific AutoCAD core engine.

### Example
```csharp
using System;
using System.Diagnostics;
using Autodesk.Forge;
using Autodesk.Forge.Client;
using Autodesk.Forge.Model;

namespace Example
{
    public class GetEngineExample
    {
        public void main()
        {
            
            // Configure OAuth2 access token for authorization: oauth2_application
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new EnginesApi();
            var id = id_example;  // string | 

            try
            {
                // Returns the details of a specific AutoCAD core engine.
                Engine result = apiInstance.GetEngine(id);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling EnginesApi.GetEngine: " + e.Message );
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

[**Engine**](Engine.md)

### Authorization

[oauth2_application](../README.md#oauth2_application)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/vnd.api+json, application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

