# Autodesk.Forge.ItemsApi

All URIs are relative to *https://developer.api.autodesk.com/*

Method | HTTP request | Description
------------- | ------------- | -------------
[**GetItem**](ItemsApi.md#getitem) | **GET** /data/v1/projects/{project_id}/items/{item_id} | 
[**GetItemParentFolder**](ItemsApi.md#getitemparentfolder) | **GET** /data/v1/projects/{project_id}/items/{item_id}/parent | 
[**GetItemRefs**](ItemsApi.md#getitemrefs) | **GET** /data/v1/projects/{project_id}/items/{item_id}/refs | 
[**GetItemRelationshipsRefs**](ItemsApi.md#getitemrelationshipsrefs) | **GET** /data/v1/projects/{project_id}/items/{item_id}/relationships/refs | 
[**GetItemTip**](ItemsApi.md#getitemtip) | **GET** /data/v1/projects/{project_id}/items/{item_id}/tip | 
[**GetItemVersions**](ItemsApi.md#getitemversions) | **GET** /data/v1/projects/{project_id}/items/{item_id}/versions | 
[**PostItem**](ItemsApi.md#postitem) | **POST** /data/v1/projects/{project_id}/items | 
[**PostItemRelationshipsRef**](ItemsApi.md#postitemrelationshipsref) | **POST** /data/v1/projects/{project_id}/items/{item_id}/relationships/refs | 


<a name="getitem"></a>
# **GetItem**
> Item GetItem (string projectId, string itemId)



Returns a resource item by ID for any item within a given project. Resource items represent word documents, fusion design files, drawings, spreadsheets, etc. 

### Example
```csharp
using System;
using System.Diagnostics;
using Autodesk.Forge;
using Autodesk.Forge.Client;
using Autodesk.Forge.Model;

namespace Example
{
    public class GetItemExample
    {
        public void main()
        {
            
            // Configure OAuth2 access token for authorization: oauth2_access_code
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ItemsApi();
            var projectId = projectId_example;  // string | the `project id`
            var itemId = itemId_example;  // string | the `item id`

            try
            {
                Item result = apiInstance.GetItem(projectId, itemId);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ItemsApi.GetItem: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **projectId** | **string**| the &#x60;project id&#x60; | 
 **itemId** | **string**| the &#x60;item id&#x60; | 

### Return type

[**Item**](Item.md)

### Authorization

[oauth2_access_code](../README.md#oauth2_access_code)

### HTTP request headers

 - **Content-Type**: application/vnd.api+json
 - **Accept**: application/vnd.api+json, application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getitemparentfolder"></a>
# **GetItemParentFolder**
> Folder GetItemParentFolder (string projectId, string itemId)



Returns the \"parent\" folder for the given item. 

### Example
```csharp
using System;
using System.Diagnostics;
using Autodesk.Forge;
using Autodesk.Forge.Client;
using Autodesk.Forge.Model;

namespace Example
{
    public class GetItemParentFolderExample
    {
        public void main()
        {
            
            // Configure OAuth2 access token for authorization: oauth2_access_code
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ItemsApi();
            var projectId = projectId_example;  // string | the `project id`
            var itemId = itemId_example;  // string | the `item id`

            try
            {
                Folder result = apiInstance.GetItemParentFolder(projectId, itemId);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ItemsApi.GetItemParentFolder: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **projectId** | **string**| the &#x60;project id&#x60; | 
 **itemId** | **string**| the &#x60;item id&#x60; | 

### Return type

[**Folder**](Folder.md)

### Authorization

[oauth2_access_code](../README.md#oauth2_access_code)

### HTTP request headers

 - **Content-Type**: application/vnd.api+json
 - **Accept**: application/vnd.api+json, application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getitemrefs"></a>
# **GetItemRefs**
> JsonApiCollection GetItemRefs (string projectId, string itemId, List<string> filterType = null, List<string> filterId = null, List<string> filterExtensionType = null)



Returns the resources (`items`, `folders`, and `versions`) which have a custom relationship with the given `item_id`. Custom relationships can be established between an item and other resources within the 'data' domain service (folders, items, and versions). 

### Example
```csharp
using System;
using System.Diagnostics;
using Autodesk.Forge;
using Autodesk.Forge.Client;
using Autodesk.Forge.Model;

namespace Example
{
    public class GetItemRefsExample
    {
        public void main()
        {
            
            // Configure OAuth2 access token for authorization: oauth2_access_code
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ItemsApi();
            var projectId = projectId_example;  // string | the `project id`
            var itemId = itemId_example;  // string | the `item id`
            var filterType = new List<string>(); // List<string> | filter by the `type` of the `ref` target (optional) 
            var filterId = new List<string>(); // List<string> | filter by the `id` of the `ref` target (optional) 
            var filterExtensionType = new List<string>(); // List<string> | filter by the extension type (optional) 

            try
            {
                JsonApiCollection result = apiInstance.GetItemRefs(projectId, itemId, filterType, filterId, filterExtensionType);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ItemsApi.GetItemRefs: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **projectId** | **string**| the &#x60;project id&#x60; | 
 **itemId** | **string**| the &#x60;item id&#x60; | 
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

<a name="getitemrelationshipsrefs"></a>
# **GetItemRelationshipsRefs**
> Refs GetItemRelationshipsRefs (string projectId, string itemId, List<string> filterType = null, List<string> filterId = null, List<string> filterRefType = null, string filterDirection = null, List<string> filterExtensionType = null)



Returns the custom relationships that are associated to the given `item_id`. Custom relationships can be established between an item and other resources within the 'data' domain service (folders, items, and versions). 

### Example
```csharp
using System;
using System.Diagnostics;
using Autodesk.Forge;
using Autodesk.Forge.Client;
using Autodesk.Forge.Model;

namespace Example
{
    public class GetItemRelationshipsRefsExample
    {
        public void main()
        {
            
            // Configure OAuth2 access token for authorization: oauth2_access_code
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ItemsApi();
            var projectId = projectId_example;  // string | the `project id`
            var itemId = itemId_example;  // string | the `item id`
            var filterType = new List<string>(); // List<string> | filter by the `type` of the `ref` target (optional) 
            var filterId = new List<string>(); // List<string> | filter by the `id` of the `ref` target (optional) 
            var filterRefType = new List<string>(); // List<string> | filter by `refType` (optional) 
            var filterDirection = filterDirection_example;  // string | filter by the direction of the reference (optional) 
            var filterExtensionType = new List<string>(); // List<string> | filter by the extension type (optional) 

            try
            {
                Refs result = apiInstance.GetItemRelationshipsRefs(projectId, itemId, filterType, filterId, filterRefType, filterDirection, filterExtensionType);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ItemsApi.GetItemRelationshipsRefs: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **projectId** | **string**| the &#x60;project id&#x60; | 
 **itemId** | **string**| the &#x60;item id&#x60; | 
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

<a name="getitemtip"></a>
# **GetItemTip**
> Version GetItemTip (string projectId, string itemId)



Returns the \"tip\" version for the given item. Multiple versions of a resource item can be uploaded in a project. The tip version is the most recent one. 

### Example
```csharp
using System;
using System.Diagnostics;
using Autodesk.Forge;
using Autodesk.Forge.Client;
using Autodesk.Forge.Model;

namespace Example
{
    public class GetItemTipExample
    {
        public void main()
        {
            
            // Configure OAuth2 access token for authorization: oauth2_access_code
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ItemsApi();
            var projectId = projectId_example;  // string | the `project id`
            var itemId = itemId_example;  // string | the `item id`

            try
            {
                Version result = apiInstance.GetItemTip(projectId, itemId);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ItemsApi.GetItemTip: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **projectId** | **string**| the &#x60;project id&#x60; | 
 **itemId** | **string**| the &#x60;item id&#x60; | 

### Return type

[**Version**](Version.md)

### Authorization

[oauth2_access_code](../README.md#oauth2_access_code)

### HTTP request headers

 - **Content-Type**: application/vnd.api+json
 - **Accept**: application/vnd.api+json, application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getitemversions"></a>
# **GetItemVersions**
> Versions GetItemVersions (string projectId, string itemId, List<string> filterType = null, List<string> filterId = null, List<string> filterExtensionType = null, List<int?> filterVersionNumber = null, int? pageNumber = null, int? pageLimit = null)



Returns versions for the given item. Multiple versions of a resource item can be uploaded in a project. 

### Example
```csharp
using System;
using System.Diagnostics;
using Autodesk.Forge;
using Autodesk.Forge.Client;
using Autodesk.Forge.Model;

namespace Example
{
    public class GetItemVersionsExample
    {
        public void main()
        {
            
            // Configure OAuth2 access token for authorization: oauth2_access_code
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ItemsApi();
            var projectId = projectId_example;  // string | the `project id`
            var itemId = itemId_example;  // string | the `item id`
            var filterType = new List<string>(); // List<string> | filter by the `type` of the `ref` target (optional) 
            var filterId = new List<string>(); // List<string> | filter by the `id` of the `ref` target (optional) 
            var filterExtensionType = new List<string>(); // List<string> | filter by the extension type (optional) 
            var filterVersionNumber = new List<int?>(); // List<int?> | filter by `versionNumber` (optional) 
            var pageNumber = 56;  // int? | specify the page number (optional) 
            var pageLimit = 56;  // int? | specify the maximal number of elements per page (optional) 

            try
            {
                Versions result = apiInstance.GetItemVersions(projectId, itemId, filterType, filterId, filterExtensionType, filterVersionNumber, pageNumber, pageLimit);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ItemsApi.GetItemVersions: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **projectId** | **string**| the &#x60;project id&#x60; | 
 **itemId** | **string**| the &#x60;item id&#x60; | 
 **filterType** | [**List<string>**](string.md)| filter by the &#x60;type&#x60; of the &#x60;ref&#x60; target | [optional] 
 **filterId** | [**List<string>**](string.md)| filter by the &#x60;id&#x60; of the &#x60;ref&#x60; target | [optional] 
 **filterExtensionType** | [**List<string>**](string.md)| filter by the extension type | [optional] 
 **filterVersionNumber** | [**List<int?>**](int?.md)| filter by &#x60;versionNumber&#x60; | [optional] 
 **pageNumber** | **int?**| specify the page number | [optional] 
 **pageLimit** | **int?**| specify the maximal number of elements per page | [optional] 

### Return type

[**Versions**](Versions.md)

### Authorization

[oauth2_access_code](../README.md#oauth2_access_code)

### HTTP request headers

 - **Content-Type**: application/vnd.api+json
 - **Accept**: application/vnd.api+json, application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="postitem"></a>
# **PostItem**
> ItemCreated PostItem (string projectId, CreateItem body)



Creates a new item in the 'data' domain service. 

### Example
```csharp
using System;
using System.Diagnostics;
using Autodesk.Forge;
using Autodesk.Forge.Client;
using Autodesk.Forge.Model;

namespace Example
{
    public class PostItemExample
    {
        public void main()
        {
            
            // Configure OAuth2 access token for authorization: oauth2_access_code
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ItemsApi();
            var projectId = projectId_example;  // string | the `project id`
            var body = new CreateItem(); // CreateItem | describe the item to be created

            try
            {
                ItemCreated result = apiInstance.PostItem(projectId, body);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ItemsApi.PostItem: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **projectId** | **string**| the &#x60;project id&#x60; | 
 **body** | [**CreateItem**](CreateItem.md)| describe the item to be created | 

### Return type

[**ItemCreated**](ItemCreated.md)

### Authorization

[oauth2_access_code](../README.md#oauth2_access_code)

### HTTP request headers

 - **Content-Type**: application/vnd.api+json
 - **Accept**: application/vnd.api+json, application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="postitemrelationshipsref"></a>
# **PostItemRelationshipsRef**
> void PostItemRelationshipsRef (string projectId, string itemId, CreateRef body)



Creates a custom relationship between an item and another resource within the 'data' domain service (folder, item, or version). 

### Example
```csharp
using System;
using System.Diagnostics;
using Autodesk.Forge;
using Autodesk.Forge.Client;
using Autodesk.Forge.Model;

namespace Example
{
    public class PostItemRelationshipsRefExample
    {
        public void main()
        {
            
            // Configure OAuth2 access token for authorization: oauth2_access_code
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ItemsApi();
            var projectId = projectId_example;  // string | the `project id`
            var itemId = itemId_example;  // string | the `item id`
            var body = new CreateRef(); // CreateRef | describe the ref to be created

            try
            {
                apiInstance.PostItemRelationshipsRef(projectId, itemId, body);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ItemsApi.PostItemRelationshipsRef: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **projectId** | **string**| the &#x60;project id&#x60; | 
 **itemId** | **string**| the &#x60;item id&#x60; | 
 **body** | [**CreateRef**](CreateRef.md)| describe the ref to be created | 

### Return type

void (empty response body)

### Authorization

[oauth2_access_code](../README.md#oauth2_access_code)

### HTTP request headers

 - **Content-Type**: application/vnd.api+json
 - **Accept**: application/vnd.api+json, application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

