# Autodesk.Forge.ActivitiesApi

All URIs are relative to *https://developer.api.autodesk.com/*

Method | HTTP request | Description
------------- | ------------- | -------------
[**CreateActivity**](ActivitiesApi.md#createactivity) | **POST** /autocad.io/us-east/v2/Activities | Creates a new Activity.
[**DeleteActivity**](ActivitiesApi.md#deleteactivity) | **DELETE** /autocad.io/us-east/v2/Activities(&#39;{id}&#39;) | Removes a specific Activity.
[**DeleteActivityHistory**](ActivitiesApi.md#deleteactivityhistory) | **POST** /autocad.io/us-east/v2/Activities(&#39;{id}&#39;)/Operations.DeleteHistory | Removes the version history of the specified Activity.
[**GetActivity**](ActivitiesApi.md#getactivity) | **GET** /autocad.io/us-east/v2/Activities(&#39;{id}&#39;) | Returns the details of a specific Activity.
[**GetActivityVersions**](ActivitiesApi.md#getactivityversions) | **GET** /autocad.io/us-east/v2/Activities(&#39;{id}&#39;)/Operations.GetVersions | Returns all old versions of a specified Activity.
[**GetAllActivities**](ActivitiesApi.md#getallactivities) | **GET** /autocad.io/us-east/v2/Activities | Returns the details of all Activities.
[**PatchActivity**](ActivitiesApi.md#patchactivity) | **PATCH** /autocad.io/us-east/v2/Activities(&#39;{id}&#39;) | Updates an Activity by specifying only the changed attributes.
[**SetActivityVersion**](ActivitiesApi.md#setactivityversion) | **POST** /autocad.io/us-east/v2/Activities(&#39;{id}&#39;)/Operations.SetVersion | Sets the Activity to the specified version.


<a name="createactivity"></a>
# **CreateActivity**
> Activity CreateActivity (Activity activity)

Creates a new Activity.

### Example
```csharp
using System;
using System.Diagnostics;
using Autodesk.Forge;
using Autodesk.Forge.Client;
using Autodesk.Forge.Model;

namespace Example
{
    public class CreateActivityExample
    {
        public void main()
        {
            
            // Configure OAuth2 access token for authorization: oauth2_application
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ActivitiesApi();
            var activity = new Activity(); // Activity | 

            try
            {
                // Creates a new Activity.
                Activity result = apiInstance.CreateActivity(activity);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ActivitiesApi.CreateActivity: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **activity** | [**Activity**](Activity.md)|  | 

### Return type

[**Activity**](Activity.md)

### Authorization

[oauth2_application](../README.md#oauth2_application)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/vnd.api+json, application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deleteactivity"></a>
# **DeleteActivity**
> void DeleteActivity (string id)

Removes a specific Activity.

### Example
```csharp
using System;
using System.Diagnostics;
using Autodesk.Forge;
using Autodesk.Forge.Client;
using Autodesk.Forge.Model;

namespace Example
{
    public class DeleteActivityExample
    {
        public void main()
        {
            
            // Configure OAuth2 access token for authorization: oauth2_application
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ActivitiesApi();
            var id = id_example;  // string | 

            try
            {
                // Removes a specific Activity.
                apiInstance.DeleteActivity(id);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ActivitiesApi.DeleteActivity: " + e.Message );
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

<a name="deleteactivityhistory"></a>
# **DeleteActivityHistory**
> void DeleteActivityHistory (string id)

Removes the version history of the specified Activity.

### Example
```csharp
using System;
using System.Diagnostics;
using Autodesk.Forge;
using Autodesk.Forge.Client;
using Autodesk.Forge.Model;

namespace Example
{
    public class DeleteActivityHistoryExample
    {
        public void main()
        {
            
            // Configure OAuth2 access token for authorization: oauth2_application
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ActivitiesApi();
            var id = id_example;  // string | 

            try
            {
                // Removes the version history of the specified Activity.
                apiInstance.DeleteActivityHistory(id);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ActivitiesApi.DeleteActivityHistory: " + e.Message );
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

<a name="getactivity"></a>
# **GetActivity**
> Activity GetActivity (string id)

Returns the details of a specific Activity.

### Example
```csharp
using System;
using System.Diagnostics;
using Autodesk.Forge;
using Autodesk.Forge.Client;
using Autodesk.Forge.Model;

namespace Example
{
    public class GetActivityExample
    {
        public void main()
        {
            
            // Configure OAuth2 access token for authorization: oauth2_application
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ActivitiesApi();
            var id = id_example;  // string | 

            try
            {
                // Returns the details of a specific Activity.
                Activity result = apiInstance.GetActivity(id);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ActivitiesApi.GetActivity: " + e.Message );
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

[**Activity**](Activity.md)

### Authorization

[oauth2_application](../README.md#oauth2_application)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/vnd.api+json, application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getactivityversions"></a>
# **GetActivityVersions**
> DesignAutomationActivities GetActivityVersions (string id)

Returns all old versions of a specified Activity.

### Example
```csharp
using System;
using System.Diagnostics;
using Autodesk.Forge;
using Autodesk.Forge.Client;
using Autodesk.Forge.Model;

namespace Example
{
    public class GetActivityVersionsExample
    {
        public void main()
        {
            
            // Configure OAuth2 access token for authorization: oauth2_application
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ActivitiesApi();
            var id = id_example;  // string | 

            try
            {
                // Returns all old versions of a specified Activity.
                DesignAutomationActivities result = apiInstance.GetActivityVersions(id);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ActivitiesApi.GetActivityVersions: " + e.Message );
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

[**DesignAutomationActivities**](DesignAutomationActivities.md)

### Authorization

[oauth2_application](../README.md#oauth2_application)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/vnd.api+json, application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getallactivities"></a>
# **GetAllActivities**
> DesignAutomationActivities GetAllActivities ()

Returns the details of all Activities.

### Example
```csharp
using System;
using System.Diagnostics;
using Autodesk.Forge;
using Autodesk.Forge.Client;
using Autodesk.Forge.Model;

namespace Example
{
    public class GetAllActivitiesExample
    {
        public void main()
        {
            
            // Configure OAuth2 access token for authorization: oauth2_application
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ActivitiesApi();

            try
            {
                // Returns the details of all Activities.
                DesignAutomationActivities result = apiInstance.GetAllActivities();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ActivitiesApi.GetAllActivities: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**DesignAutomationActivities**](DesignAutomationActivities.md)

### Authorization

[oauth2_application](../README.md#oauth2_application)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/vnd.api+json, application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="patchactivity"></a>
# **PatchActivity**
> void PatchActivity (string id, ActivityOptional activity)

Updates an Activity by specifying only the changed attributes.

### Example
```csharp
using System;
using System.Diagnostics;
using Autodesk.Forge;
using Autodesk.Forge.Client;
using Autodesk.Forge.Model;

namespace Example
{
    public class PatchActivityExample
    {
        public void main()
        {
            
            // Configure OAuth2 access token for authorization: oauth2_application
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ActivitiesApi();
            var id = id_example;  // string | 
            var activity = new ActivityOptional(); // ActivityOptional | 

            try
            {
                // Updates an Activity by specifying only the changed attributes.
                apiInstance.PatchActivity(id, activity);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ActivitiesApi.PatchActivity: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **string**|  | 
 **activity** | [**ActivityOptional**](ActivityOptional.md)|  | 

### Return type

void (empty response body)

### Authorization

[oauth2_application](../README.md#oauth2_application)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/vnd.api+json, application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="setactivityversion"></a>
# **SetActivityVersion**
> void SetActivityVersion (string id, ActivityVersion activityVersion)

Sets the Activity to the specified version.

### Example
```csharp
using System;
using System.Diagnostics;
using Autodesk.Forge;
using Autodesk.Forge.Client;
using Autodesk.Forge.Model;

namespace Example
{
    public class SetActivityVersionExample
    {
        public void main()
        {
            
            // Configure OAuth2 access token for authorization: oauth2_application
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ActivitiesApi();
            var id = id_example;  // string | 
            var activityVersion = new ActivityVersion(); // ActivityVersion | 

            try
            {
                // Sets the Activity to the specified version.
                apiInstance.SetActivityVersion(id, activityVersion);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ActivitiesApi.SetActivityVersion: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **string**|  | 
 **activityVersion** | [**ActivityVersion**](ActivityVersion.md)|  | 

### Return type

void (empty response body)

### Authorization

[oauth2_application](../README.md#oauth2_application)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/vnd.api+json, application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

