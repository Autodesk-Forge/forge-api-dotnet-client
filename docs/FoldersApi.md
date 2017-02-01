# Autodesk.Forge.FoldersApi

All URIs are relative to *https://developer.api.autodesk.com/*

Method | HTTP request | Description
------------- | ------------- | -------------
[**GetFolder**](FoldersApi.md#getfolder) | **GET** /data/v1/projects/{project_id}/folders/{folder_id} | 
[**GetFolderContents**](FoldersApi.md#getfoldercontents) | **GET** /data/v1/projects/{project_id}/folders/{folder_id}/contents | 
[**GetFolderParent**](FoldersApi.md#getfolderparent) | **GET** /data/v1/projects/{project_id}/folders/{folder_id}/parent | 
[**GetFolderRefs**](FoldersApi.md#getfolderrefs) | **GET** /data/v1/projects/{project_id}/folders/{folder_id}/refs | 
[**GetFolderRelationshipsRefs**](FoldersApi.md#getfolderrelationshipsrefs) | **GET** /data/v1/projects/{project_id}/folders/{folder_id}/relationships/refs | 
[**PostFolderRelationshipsRef**](FoldersApi.md#postfolderrelationshipsref) | **POST** /data/v1/projects/{project_id}/folders/{folder_id}/relationships/refs | 


<a name="getfolder"></a>
# **GetFolder**
> Folder GetFolder (string projectId, string folderId)



Returns the folder by ID for any folder within a given project. All folders or sub-folders within a project are associated with their own unique ID, including the root folder. 

### Example
```csharp
using System;
using System.Diagnostics;
using Autodesk.Forge;
using Autodesk.Forge.Client;
using Autodesk.Forge.Model;

namespace Example
{
    public class GetFolderExample
    {
        public void main()
        {
            
            // Configure OAuth2 access token for authorization: oauth2_access_code
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new FoldersApi();
            var projectId = projectId_example;  // string | the `project id`
            var folderId = folderId_example;  // string | the `folder id`

            try
            {
                Folder result = apiInstance.GetFolder(projectId, folderId);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling FoldersApi.GetFolder: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **projectId** | **string**| the &#x60;project id&#x60; | 
 **folderId** | **string**| the &#x60;folder id&#x60; | 

### Return type

[**Folder**](Folder.md)

### Authorization

[oauth2_access_code](../README.md#oauth2_access_code)

### HTTP request headers

 - **Content-Type**: application/vnd.api+json
 - **Accept**: application/vnd.api+json, application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getfoldercontents"></a>
# **GetFolderContents**
> JsonApiCollection GetFolderContents (string projectId, string folderId, List<string> filterType = null, List<string> filterId = null, List<string> filterExtensionType = null, int? pageNumber = null, int? pageLimit = null)



Returns a collection of items and folders within a folder. Items represent word documents, fusion design files, drawings, spreadsheets, etc. 

### Example
```csharp
using System;
using System.Diagnostics;
using Autodesk.Forge;
using Autodesk.Forge.Client;
using Autodesk.Forge.Model;

namespace Example
{
    public class GetFolderContentsExample
    {
        public void main()
        {
            
            // Configure OAuth2 access token for authorization: oauth2_access_code
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new FoldersApi();
            var projectId = projectId_example;  // string | the `project id`
            var folderId = folderId_example;  // string | the `folder id`
            var filterType = new List<string>(); // List<string> | filter by the `type` of the `ref` target (optional) 
            var filterId = new List<string>(); // List<string> | filter by the `id` of the `ref` target (optional) 
            var filterExtensionType = new List<string>(); // List<string> | filter by the extension type (optional) 
            var pageNumber = 56;  // int? | specify the page number (optional) 
            var pageLimit = 56;  // int? | specify the maximal number of elements per page (optional) 

            try
            {
                JsonApiCollection result = apiInstance.GetFolderContents(projectId, folderId, filterType, filterId, filterExtensionType, pageNumber, pageLimit);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling FoldersApi.GetFolderContents: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **projectId** | **string**| the &#x60;project id&#x60; | 
 **folderId** | **string**| the &#x60;folder id&#x60; | 
 **filterType** | [**List<string>**](string.md)| filter by the &#x60;type&#x60; of the &#x60;ref&#x60; target | [optional] 
 **filterId** | [**List<string>**](string.md)| filter by the &#x60;id&#x60; of the &#x60;ref&#x60; target | [optional] 
 **filterExtensionType** | [**List<string>**](string.md)| filter by the extension type | [optional] 
 **pageNumber** | **int?**| specify the page number | [optional] 
 **pageLimit** | **int?**| specify the maximal number of elements per page | [optional] 

### Return type

[**JsonApiCollection**](JsonApiCollection.md)

### Authorization

[oauth2_access_code](../README.md#oauth2_access_code)

### HTTP request headers

 - **Content-Type**: application/vnd.api+json
 - **Accept**: application/vnd.api+json, application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getfolderparent"></a>
# **GetFolderParent**
> Folder GetFolderParent (string projectId, string folderId)



Returns the parent folder (if it exists). In a project, subfolders and resource items are stored under a folder except the root folder which does not have a parent of its own. 

### Example
```csharp
using System;
using System.Diagnostics;
using Autodesk.Forge;
using Autodesk.Forge.Client;
using Autodesk.Forge.Model;

namespace Example
{
    public class GetFolderParentExample
    {
        public void main()
        {
            
            // Configure OAuth2 access token for authorization: oauth2_access_code
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new FoldersApi();
            var projectId = projectId_example;  // string | the `project id`
            var folderId = folderId_example;  // string | the `folder id`

            try
            {
                Folder result = apiInstance.GetFolderParent(projectId, folderId);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling FoldersApi.GetFolderParent: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **projectId** | **string**| the &#x60;project id&#x60; | 
 **folderId** | **string**| the &#x60;folder id&#x60; | 

### Return type

[**Folder**](Folder.md)

### Authorization

[oauth2_access_code](../README.md#oauth2_access_code)

### HTTP request headers

 - **Content-Type**: application/vnd.api+json
 - **Accept**: application/vnd.api+json, application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getfolderrefs"></a>
# **GetFolderRefs**
> JsonApiCollection GetFolderRefs (string projectId, string folderId, List<string> filterType = null, List<string> filterId = null, List<string> filterExtensionType = null)



Returns the resources (`items`, `folders`, and `versions`) which have a custom relationship with the given `folder_id`. Custom relationships can be established between a folder and other resources within the 'data' domain service (folders, items, and versions). 

### Example
```csharp
using System;
using System.Diagnostics;
using Autodesk.Forge;
using Autodesk.Forge.Client;
using Autodesk.Forge.Model;

namespace Example
{
    public class GetFolderRefsExample
    {
        public void main()
        {
            
            // Configure OAuth2 access token for authorization: oauth2_access_code
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new FoldersApi();
            var projectId = projectId_example;  // string | the `project id`
            var folderId = folderId_example;  // string | the `folder id`
            var filterType = new List<string>(); // List<string> | filter by the `type` of the `ref` target (optional) 
            var filterId = new List<string>(); // List<string> | filter by the `id` of the `ref` target (optional) 
            var filterExtensionType = new List<string>(); // List<string> | filter by the extension type (optional) 

            try
            {
                JsonApiCollection result = apiInstance.GetFolderRefs(projectId, folderId, filterType, filterId, filterExtensionType);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling FoldersApi.GetFolderRefs: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **projectId** | **string**| the &#x60;project id&#x60; | 
 **folderId** | **string**| the &#x60;folder id&#x60; | 
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

<a name="getfolderrelationshipsrefs"></a>
# **GetFolderRelationshipsRefs**
> Refs GetFolderRelationshipsRefs (string projectId, string folderId, List<string> filterType = null, List<string> filterId = null, List<string> filterRefType = null, string filterDirection = null, List<string> filterExtensionType = null)



Returns the custom relationships that are associated to the given `folder_id`. Custom relationships can be established between a folder and other resources within the 'data' domain service (folders, items, and versions). 

### Example
```csharp
using System;
using System.Diagnostics;
using Autodesk.Forge;
using Autodesk.Forge.Client;
using Autodesk.Forge.Model;

namespace Example
{
    public class GetFolderRelationshipsRefsExample
    {
        public void main()
        {
            
            // Configure OAuth2 access token for authorization: oauth2_access_code
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new FoldersApi();
            var projectId = projectId_example;  // string | the `project id`
            var folderId = folderId_example;  // string | the `folder id`
            var filterType = new List<string>(); // List<string> | filter by the `type` of the `ref` target (optional) 
            var filterId = new List<string>(); // List<string> | filter by the `id` of the `ref` target (optional) 
            var filterRefType = new List<string>(); // List<string> | filter by `refType` (optional) 
            var filterDirection = filterDirection_example;  // string | filter by the direction of the reference (optional) 
            var filterExtensionType = new List<string>(); // List<string> | filter by the extension type (optional) 

            try
            {
                Refs result = apiInstance.GetFolderRelationshipsRefs(projectId, folderId, filterType, filterId, filterRefType, filterDirection, filterExtensionType);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling FoldersApi.GetFolderRelationshipsRefs: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **projectId** | **string**| the &#x60;project id&#x60; | 
 **folderId** | **string**| the &#x60;folder id&#x60; | 
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

<a name="postfolderrelationshipsref"></a>
# **PostFolderRelationshipsRef**
> void PostFolderRelationshipsRef (string projectId, string folderId, CreateRef body)



Creates a custom relationship between a folder and another resource within the 'data' domain service (folder, item, or version). 

### Example
```csharp
using System;
using System.Diagnostics;
using Autodesk.Forge;
using Autodesk.Forge.Client;
using Autodesk.Forge.Model;

namespace Example
{
    public class PostFolderRelationshipsRefExample
    {
        public void main()
        {
            
            // Configure OAuth2 access token for authorization: oauth2_access_code
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new FoldersApi();
            var projectId = projectId_example;  // string | the `project id`
            var folderId = folderId_example;  // string | the `folder id`
            var body = new CreateRef(); // CreateRef | describe the ref to be created

            try
            {
                apiInstance.PostFolderRelationshipsRef(projectId, folderId, body);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling FoldersApi.PostFolderRelationshipsRef: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **projectId** | **string**| the &#x60;project id&#x60; | 
 **folderId** | **string**| the &#x60;folder id&#x60; | 
 **body** | [**CreateRef**](CreateRef.md)| describe the ref to be created | 

### Return type

void (empty response body)

### Authorization

[oauth2_access_code](../README.md#oauth2_access_code)

### HTTP request headers

 - **Content-Type**: application/vnd.api+json
 - **Accept**: application/vnd.api+json, application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

