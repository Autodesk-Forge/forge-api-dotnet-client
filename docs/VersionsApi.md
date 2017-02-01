# Autodesk.Forge.VersionsApi

All URIs are relative to *https://developer.api.autodesk.com/*

Method | HTTP request | Description
------------- | ------------- | -------------
[**GetVersion**](VersionsApi.md#getversion) | **GET** /data/v1/projects/{project_id}/versions/{version_id} | 
[**GetVersionItem**](VersionsApi.md#getversionitem) | **GET** /data/v1/projects/{project_id}/versions/{version_id}/item | 
[**GetVersionRefs**](VersionsApi.md#getversionrefs) | **GET** /data/v1/projects/{project_id}/versions/{version_id}/refs | 
[**GetVersionRelationshipsRefs**](VersionsApi.md#getversionrelationshipsrefs) | **GET** /data/v1/projects/{project_id}/versions/{version_id}/relationships/refs | 
[**PostVersionRelationshipsRef**](VersionsApi.md#postversionrelationshipsref) | **POST** /data/v1/projects/{project_id}/versions/{version_id}/relationships/refs | 


<a name="getversion"></a>
# **GetVersion**
> Version GetVersion (string projectId, string versionId)



Returns the version with the given `version_id`. 

### Example
```csharp
using System;
using System.Diagnostics;
using Autodesk.Forge;
using Autodesk.Forge.Client;
using Autodesk.Forge.Model;

namespace Example
{
    public class GetVersionExample
    {
        public void main()
        {
            
            // Configure OAuth2 access token for authorization: oauth2_access_code
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new VersionsApi();
            var projectId = projectId_example;  // string | the `project id`
            var versionId = versionId_example;  // string | the `version id`

            try
            {
                Version result = apiInstance.GetVersion(projectId, versionId);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling VersionsApi.GetVersion: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **projectId** | **string**| the &#x60;project id&#x60; | 
 **versionId** | **string**| the &#x60;version id&#x60; | 

### Return type

[**Version**](Version.md)

### Authorization

[oauth2_access_code](../README.md#oauth2_access_code)

### HTTP request headers

 - **Content-Type**: application/vnd.api+json
 - **Accept**: application/vnd.api+json, application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getversionitem"></a>
# **GetVersionItem**
> Item GetVersionItem (string projectId, string versionId)



Returns the item the given version is associated with. 

### Example
```csharp
using System;
using System.Diagnostics;
using Autodesk.Forge;
using Autodesk.Forge.Client;
using Autodesk.Forge.Model;

namespace Example
{
    public class GetVersionItemExample
    {
        public void main()
        {
            
            // Configure OAuth2 access token for authorization: oauth2_access_code
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new VersionsApi();
            var projectId = projectId_example;  // string | the `project id`
            var versionId = versionId_example;  // string | the `version id`

            try
            {
                Item result = apiInstance.GetVersionItem(projectId, versionId);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling VersionsApi.GetVersionItem: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **projectId** | **string**| the &#x60;project id&#x60; | 
 **versionId** | **string**| the &#x60;version id&#x60; | 

### Return type

[**Item**](Item.md)

### Authorization

[oauth2_access_code](../README.md#oauth2_access_code)

### HTTP request headers

 - **Content-Type**: application/vnd.api+json
 - **Accept**: application/vnd.api+json, application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getversionrefs"></a>
# **GetVersionRefs**
> JsonApiCollection GetVersionRefs (string projectId, string versionId, List<string> filterType = null, List<string> filterId = null, List<string> filterExtensionType = null)



Returns the resources (`items`, `folders`, and `versions`) which have a custom relationship with the given `version_id`. Custom relationships can be established between a version of an item and other resources within the 'data' domain service (folders, items, and versions). 

### Example
```csharp
using System;
using System.Diagnostics;
using Autodesk.Forge;
using Autodesk.Forge.Client;
using Autodesk.Forge.Model;

namespace Example
{
    public class GetVersionRefsExample
    {
        public void main()
        {
            
            // Configure OAuth2 access token for authorization: oauth2_access_code
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new VersionsApi();
            var projectId = projectId_example;  // string | the `project id`
            var versionId = versionId_example;  // string | the `version id`
            var filterType = new List<string>(); // List<string> | filter by the `type` of the `ref` target (optional) 
            var filterId = new List<string>(); // List<string> | filter by the `id` of the `ref` target (optional) 
            var filterExtensionType = new List<string>(); // List<string> | filter by the extension type (optional) 

            try
            {
                JsonApiCollection result = apiInstance.GetVersionRefs(projectId, versionId, filterType, filterId, filterExtensionType);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling VersionsApi.GetVersionRefs: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **projectId** | **string**| the &#x60;project id&#x60; | 
 **versionId** | **string**| the &#x60;version id&#x60; | 
 **filterType** | [**List<string>**](string.md)| filter by the &#x60;type&#x60; of the &#x60;ref&#x60; target | [optional] 
 **filterId** | [**List<string>**](string.md)| filter by the &#x60;id&#x60; of the &#x60;ref&#x60; target | [optional] 
 **filterExtensionType** | [**List<string>**](string.md)| filter by the extension type | [optional] 

### Return type

[**JsonApiCollection**](JsonApiCollection.md)

### Authorization

[oauth2_access_code](../README.md#oauth2_access_code)

### HTTP request headers

 - **Content-Type**: application/vnd.api+json
 - **Accept**: application/vnd.api+json, application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getversionrelationshipsrefs"></a>
# **GetVersionRelationshipsRefs**
> Refs GetVersionRelationshipsRefs (string projectId, string versionId, List<string> filterType = null, List<string> filterId = null, List<string> filterRefType = null, string filterDirection = null, List<string> filterExtensionType = null)



Returns the custom relationships that are associated to the given `version_id`. Custom relationships can be established between a version of an item and other resources within the 'data' domain service (folders, items, and versions). 

### Example
```csharp
using System;
using System.Diagnostics;
using Autodesk.Forge;
using Autodesk.Forge.Client;
using Autodesk.Forge.Model;

namespace Example
{
    public class GetVersionRelationshipsRefsExample
    {
        public void main()
        {
            
            // Configure OAuth2 access token for authorization: oauth2_access_code
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new VersionsApi();
            var projectId = projectId_example;  // string | the `project id`
            var versionId = versionId_example;  // string | the `version id`
            var filterType = new List<string>(); // List<string> | filter by the `type` of the `ref` target (optional) 
            var filterId = new List<string>(); // List<string> | filter by the `id` of the `ref` target (optional) 
            var filterRefType = new List<string>(); // List<string> | filter by `refType` (optional) 
            var filterDirection = filterDirection_example;  // string | filter by the direction of the reference (optional) 
            var filterExtensionType = new List<string>(); // List<string> | filter by the extension type (optional) 

            try
            {
                Refs result = apiInstance.GetVersionRelationshipsRefs(projectId, versionId, filterType, filterId, filterRefType, filterDirection, filterExtensionType);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling VersionsApi.GetVersionRelationshipsRefs: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **projectId** | **string**| the &#x60;project id&#x60; | 
 **versionId** | **string**| the &#x60;version id&#x60; | 
 **filterType** | [**List<string>**](string.md)| filter by the &#x60;type&#x60; of the &#x60;ref&#x60; target | [optional] 
 **filterId** | [**List<string>**](string.md)| filter by the &#x60;id&#x60; of the &#x60;ref&#x60; target | [optional] 
 **filterRefType** | [**List<string>**](string.md)| filter by &#x60;refType&#x60; | [optional] 
 **filterDirection** | **string**| filter by the direction of the reference | [optional] 
 **filterExtensionType** | [**List<string>**](string.md)| filter by the extension type | [optional] 

### Return type

[**Refs**](Refs.md)

### Authorization

[oauth2_access_code](../README.md#oauth2_access_code)

### HTTP request headers

 - **Content-Type**: application/vnd.api+json
 - **Accept**: application/vnd.api+json, application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="postversionrelationshipsref"></a>
# **PostVersionRelationshipsRef**
> void PostVersionRelationshipsRef (string projectId, string versionId, CreateRef body)



Creates a custom relationship between a version and another resource within the 'data' domain service (folder, item, or version). 

### Example
```csharp
using System;
using System.Diagnostics;
using Autodesk.Forge;
using Autodesk.Forge.Client;
using Autodesk.Forge.Model;

namespace Example
{
    public class PostVersionRelationshipsRefExample
    {
        public void main()
        {
            
            // Configure OAuth2 access token for authorization: oauth2_access_code
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new VersionsApi();
            var projectId = projectId_example;  // string | the `project id`
            var versionId = versionId_example;  // string | the `version id`
            var body = new CreateRef(); // CreateRef | describe the ref to be created

            try
            {
                apiInstance.PostVersionRelationshipsRef(projectId, versionId, body);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling VersionsApi.PostVersionRelationshipsRef: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **projectId** | **string**| the &#x60;project id&#x60; | 
 **versionId** | **string**| the &#x60;version id&#x60; | 
 **body** | [**CreateRef**](CreateRef.md)| describe the ref to be created | 

### Return type

void (empty response body)

### Authorization

[oauth2_access_code](../README.md#oauth2_access_code)

### HTTP request headers

 - **Content-Type**: application/vnd.api+json
 - **Accept**: application/vnd.api+json, application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

