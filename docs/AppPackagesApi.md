# Autodesk.Forge.AppPackagesApi

All URIs are relative to *https://developer.api.autodesk.com/*

Method | HTTP request | Description
------------- | ------------- | -------------
[**CreateAppPackage**](AppPackagesApi.md#createapppackage) | **POST** /autocad.io/us-east/v2/AppPackages | Creates an AppPackage module.
[**DeleteAppPackage**](AppPackagesApi.md#deleteapppackage) | **DELETE** /autocad.io/us-east/v2/AppPackages(&#39;{id}&#39;) | Removes a specific AppPackage.
[**DeleteAppPackageHistory**](AppPackagesApi.md#deleteapppackagehistory) | **POST** /autocad.io/us-east/v2/AppPackages(&#39;{id}&#39;)/Operations.DeleteHistory | Removes the version history of the specified AppPackage.
[**GetAllAppPackages**](AppPackagesApi.md#getallapppackages) | **GET** /autocad.io/us-east/v2/AppPackages | Returns the details of all AppPackages.
[**GetAppPackage**](AppPackagesApi.md#getapppackage) | **GET** /autocad.io/us-east/v2/AppPackages(&#39;{id}&#39;) | Returns the details of a specific AppPackage.
[**GetAppPackageVersions**](AppPackagesApi.md#getapppackageversions) | **GET** /autocad.io/us-east/v2/AppPackages(&#39;{id}&#39;)/Operations.GetVersions | Returns all old versions of a specified AppPackage.
[**GetUploadUrl**](AppPackagesApi.md#getuploadurl) | **GET** /autocad.io/us-east/v2/AppPackages/Operations.GetUploadUrl | Requests a pre-signed URL for uploading a zip file that contains the binaries for this AppPackage.
[**GetUploadUrlWithRequireContentType**](AppPackagesApi.md#getuploadurlwithrequirecontenttype) | **GET** /autocad.io/us-east/v2/AppPackages/Operations.GetUploadUrl(RequireContentType&#x3D;{require}) | Requests a pre-signed URL for uploading a zip file that contains the binaries for this AppPackage. Unlike the GetUploadUrl method that takes no parameters, this method allows the client to request that the pre-signed URL to be issued so that the subsequent HTTP PUT operation will require Content-Type&#x3D;binary/octet-stream.
[**PatchAppPackage**](AppPackagesApi.md#patchapppackage) | **PATCH** /autocad.io/us-east/v2/AppPackages(&#39;{id}&#39;) | Updates an AppPackage by specifying only the changed attributes.
[**SetAppPackageVersion**](AppPackagesApi.md#setapppackageversion) | **POST** /autocad.io/us-east/v2/AppPackages(&#39;{id}&#39;)/Operations.SetVersion | Sets the AppPackage to the specified version.
[**UpdateAppPackage**](AppPackagesApi.md#updateapppackage) | **PUT** /autocad.io/us-east/v2/AppPackages(&#39;{id}&#39;) | Updates an AppPackage by redefining the entire Activity object.


<a name="createapppackage"></a>
# **CreateAppPackage**
> AppPackage CreateAppPackage (AppPackage appPackage)

Creates an AppPackage module.

### Example
```csharp
using System;
using System.Diagnostics;
using Autodesk.Forge;
using Autodesk.Forge.Client;
using Autodesk.Forge.Model;

namespace Example
{
    public class CreateAppPackageExample
    {
        public void main()
        {
            
            // Configure OAuth2 access token for authorization: oauth2_application
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AppPackagesApi();
            var appPackage = new AppPackage(); // AppPackage | 

            try
            {
                // Creates an AppPackage module.
                AppPackage result = apiInstance.CreateAppPackage(appPackage);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling AppPackagesApi.CreateAppPackage: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **appPackage** | [**AppPackage**](AppPackage.md)|  | 

### Return type

[**AppPackage**](AppPackage.md)

### Authorization

[oauth2_application](../README.md#oauth2_application)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/vnd.api+json, application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deleteapppackage"></a>
# **DeleteAppPackage**
> void DeleteAppPackage (string id)

Removes a specific AppPackage.

### Example
```csharp
using System;
using System.Diagnostics;
using Autodesk.Forge;
using Autodesk.Forge.Client;
using Autodesk.Forge.Model;

namespace Example
{
    public class DeleteAppPackageExample
    {
        public void main()
        {
            
            // Configure OAuth2 access token for authorization: oauth2_application
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AppPackagesApi();
            var id = id_example;  // string | 

            try
            {
                // Removes a specific AppPackage.
                apiInstance.DeleteAppPackage(id);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling AppPackagesApi.DeleteAppPackage: " + e.Message );
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

<a name="deleteapppackagehistory"></a>
# **DeleteAppPackageHistory**
> void DeleteAppPackageHistory (string id)

Removes the version history of the specified AppPackage.

### Example
```csharp
using System;
using System.Diagnostics;
using Autodesk.Forge;
using Autodesk.Forge.Client;
using Autodesk.Forge.Model;

namespace Example
{
    public class DeleteAppPackageHistoryExample
    {
        public void main()
        {
            
            // Configure OAuth2 access token for authorization: oauth2_application
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AppPackagesApi();
            var id = id_example;  // string | 

            try
            {
                // Removes the version history of the specified AppPackage.
                apiInstance.DeleteAppPackageHistory(id);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling AppPackagesApi.DeleteAppPackageHistory: " + e.Message );
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

<a name="getallapppackages"></a>
# **GetAllAppPackages**
> DesignAutomationAppPackages GetAllAppPackages ()

Returns the details of all AppPackages.

### Example
```csharp
using System;
using System.Diagnostics;
using Autodesk.Forge;
using Autodesk.Forge.Client;
using Autodesk.Forge.Model;

namespace Example
{
    public class GetAllAppPackagesExample
    {
        public void main()
        {
            
            // Configure OAuth2 access token for authorization: oauth2_application
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AppPackagesApi();

            try
            {
                // Returns the details of all AppPackages.
                DesignAutomationAppPackages result = apiInstance.GetAllAppPackages();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling AppPackagesApi.GetAllAppPackages: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**DesignAutomationAppPackages**](DesignAutomationAppPackages.md)

### Authorization

[oauth2_application](../README.md#oauth2_application)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/vnd.api+json, application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getapppackage"></a>
# **GetAppPackage**
> AppPackage GetAppPackage (string id)

Returns the details of a specific AppPackage.

### Example
```csharp
using System;
using System.Diagnostics;
using Autodesk.Forge;
using Autodesk.Forge.Client;
using Autodesk.Forge.Model;

namespace Example
{
    public class GetAppPackageExample
    {
        public void main()
        {
            
            // Configure OAuth2 access token for authorization: oauth2_application
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AppPackagesApi();
            var id = id_example;  // string | 

            try
            {
                // Returns the details of a specific AppPackage.
                AppPackage result = apiInstance.GetAppPackage(id);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling AppPackagesApi.GetAppPackage: " + e.Message );
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

[**AppPackage**](AppPackage.md)

### Authorization

[oauth2_application](../README.md#oauth2_application)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/vnd.api+json, application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getapppackageversions"></a>
# **GetAppPackageVersions**
> DesignAutomationAppPackages GetAppPackageVersions (string id)

Returns all old versions of a specified AppPackage.

### Example
```csharp
using System;
using System.Diagnostics;
using Autodesk.Forge;
using Autodesk.Forge.Client;
using Autodesk.Forge.Model;

namespace Example
{
    public class GetAppPackageVersionsExample
    {
        public void main()
        {
            
            // Configure OAuth2 access token for authorization: oauth2_application
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AppPackagesApi();
            var id = id_example;  // string | 

            try
            {
                // Returns all old versions of a specified AppPackage.
                DesignAutomationAppPackages result = apiInstance.GetAppPackageVersions(id);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling AppPackagesApi.GetAppPackageVersions: " + e.Message );
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

[**DesignAutomationAppPackages**](DesignAutomationAppPackages.md)

### Authorization

[oauth2_application](../README.md#oauth2_application)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/vnd.api+json, application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getuploadurl"></a>
# **GetUploadUrl**
> void GetUploadUrl ()

Requests a pre-signed URL for uploading a zip file that contains the binaries for this AppPackage.

### Example
```csharp
using System;
using System.Diagnostics;
using Autodesk.Forge;
using Autodesk.Forge.Client;
using Autodesk.Forge.Model;

namespace Example
{
    public class GetUploadUrlExample
    {
        public void main()
        {
            
            // Configure OAuth2 access token for authorization: oauth2_application
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AppPackagesApi();

            try
            {
                // Requests a pre-signed URL for uploading a zip file that contains the binaries for this AppPackage.
                apiInstance.GetUploadUrl();
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling AppPackagesApi.GetUploadUrl: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

void (empty response body)

### Authorization

[oauth2_application](../README.md#oauth2_application)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/vnd.api+json, application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getuploadurlwithrequirecontenttype"></a>
# **GetUploadUrlWithRequireContentType**
> void GetUploadUrlWithRequireContentType (bool? require)

Requests a pre-signed URL for uploading a zip file that contains the binaries for this AppPackage. Unlike the GetUploadUrl method that takes no parameters, this method allows the client to request that the pre-signed URL to be issued so that the subsequent HTTP PUT operation will require Content-Type=binary/octet-stream.

### Example
```csharp
using System;
using System.Diagnostics;
using Autodesk.Forge;
using Autodesk.Forge.Client;
using Autodesk.Forge.Model;

namespace Example
{
    public class GetUploadUrlWithRequireContentTypeExample
    {
        public void main()
        {
            
            // Configure OAuth2 access token for authorization: oauth2_application
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AppPackagesApi();
            var require = true;  // bool? | 

            try
            {
                // Requests a pre-signed URL for uploading a zip file that contains the binaries for this AppPackage. Unlike the GetUploadUrl method that takes no parameters, this method allows the client to request that the pre-signed URL to be issued so that the subsequent HTTP PUT operation will require Content-Type=binary/octet-stream.
                apiInstance.GetUploadUrlWithRequireContentType(require);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling AppPackagesApi.GetUploadUrlWithRequireContentType: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **require** | **bool?**|  | 

### Return type

void (empty response body)

### Authorization

[oauth2_application](../README.md#oauth2_application)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/vnd.api+json, application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="patchapppackage"></a>
# **PatchAppPackage**
> void PatchAppPackage (string id, AppPackageOptional appPackage)

Updates an AppPackage by specifying only the changed attributes.

### Example
```csharp
using System;
using System.Diagnostics;
using Autodesk.Forge;
using Autodesk.Forge.Client;
using Autodesk.Forge.Model;

namespace Example
{
    public class PatchAppPackageExample
    {
        public void main()
        {
            
            // Configure OAuth2 access token for authorization: oauth2_application
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AppPackagesApi();
            var id = id_example;  // string | 
            var appPackage = new AppPackageOptional(); // AppPackageOptional | 

            try
            {
                // Updates an AppPackage by specifying only the changed attributes.
                apiInstance.PatchAppPackage(id, appPackage);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling AppPackagesApi.PatchAppPackage: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **string**|  | 
 **appPackage** | [**AppPackageOptional**](AppPackageOptional.md)|  | 

### Return type

void (empty response body)

### Authorization

[oauth2_application](../README.md#oauth2_application)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/vnd.api+json, application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="setapppackageversion"></a>
# **SetAppPackageVersion**
> void SetAppPackageVersion (string id, AppPackageVersion appPackageVersion)

Sets the AppPackage to the specified version.

### Example
```csharp
using System;
using System.Diagnostics;
using Autodesk.Forge;
using Autodesk.Forge.Client;
using Autodesk.Forge.Model;

namespace Example
{
    public class SetAppPackageVersionExample
    {
        public void main()
        {
            
            // Configure OAuth2 access token for authorization: oauth2_application
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AppPackagesApi();
            var id = id_example;  // string | 
            var appPackageVersion = new AppPackageVersion(); // AppPackageVersion | 

            try
            {
                // Sets the AppPackage to the specified version.
                apiInstance.SetAppPackageVersion(id, appPackageVersion);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling AppPackagesApi.SetAppPackageVersion: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **string**|  | 
 **appPackageVersion** | [**AppPackageVersion**](AppPackageVersion.md)|  | 

### Return type

void (empty response body)

### Authorization

[oauth2_application](../README.md#oauth2_application)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/vnd.api+json, application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="updateapppackage"></a>
# **UpdateAppPackage**
> void UpdateAppPackage (string id, AppPackage appPackage)

Updates an AppPackage by redefining the entire Activity object.

### Example
```csharp
using System;
using System.Diagnostics;
using Autodesk.Forge;
using Autodesk.Forge.Client;
using Autodesk.Forge.Model;

namespace Example
{
    public class UpdateAppPackageExample
    {
        public void main()
        {
            
            // Configure OAuth2 access token for authorization: oauth2_application
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AppPackagesApi();
            var id = id_example;  // string | 
            var appPackage = new AppPackage(); // AppPackage | 

            try
            {
                // Updates an AppPackage by redefining the entire Activity object.
                apiInstance.UpdateAppPackage(id, appPackage);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling AppPackagesApi.UpdateAppPackage: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **string**|  | 
 **appPackage** | [**AppPackage**](AppPackage.md)|  | 

### Return type

void (empty response body)

### Authorization

[oauth2_application](../README.md#oauth2_application)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/vnd.api+json, application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

