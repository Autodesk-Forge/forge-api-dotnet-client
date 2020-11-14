# Autodesk.Forge.ObjectsApi

All URIs are relative to *https://developer.api.autodesk.com/*

Method | HTTP request | Description
------------- | ------------- | -------------
[**CopyTo**](ObjectsApi.md#copyto) | **PUT** /oss/v2/buckets/{bucketKey}/objects/{objectName}/copyto/{newObjName} | 
[**CreateSignedResource**](ObjectsApi.md#createsignedresource) | **POST** /oss/v2/buckets/{bucketKey}/objects/{objectName}/signed | 
[**DeleteObject**](ObjectsApi.md#deleteobject) | **DELETE** /oss/v2/buckets/{bucketKey}/objects/{objectName} | 
[**DeleteSignedResource**](ObjectsApi.md#deletesignedresource) | **DELETE** /oss/v2/signedresources/{id} | 
[**GetObject**](ObjectsApi.md#getobject) | **GET** /oss/v2/buckets/{bucketKey}/objects/{objectName} | 
[**GetObjectDetails**](ObjectsApi.md#getobjectdetails) | **GET** /oss/v2/buckets/{bucketKey}/objects/{objectName}/details | 
[**GetObjects**](ObjectsApi.md#getobjects) | **GET** /oss/v2/buckets/{bucketKey}/objects | 
[**GetSignedResource**](ObjectsApi.md#getsignedresource) | **GET** /oss/v2/signedresources/{id} | 
[**GetStatusBySessionId**](ObjectsApi.md#getstatusbysessionid) | **GET** /oss/v2/buckets/{bucketKey}/objects/{objectName}/status/{sessionId} | 
[**UploadChunk**](ObjectsApi.md#uploadchunk) | **PUT** /oss/v2/buckets/{bucketKey}/objects/{objectName}/resumable | 
[**UploadObject**](ObjectsApi.md#uploadobject) | **PUT** /oss/v2/buckets/{bucketKey}/objects/{objectName} | 
[**UploadSignedResource**](ObjectsApi.md#uploadsignedresource) | **PUT** /oss/v2/signedresources/{id} | 
[**UploadSignedResourcesChunk**](ObjectsApi.md#uploadsignedresourceschunk) | **PUT** /oss/v2/signedresources/{id}/resumable | 


<a name="copyto"></a>
# **CopyTo**
> ObjectDetails CopyTo (string bucketKey, string objectName, string newObjName)



Copies an object to another object name in the same bucket.

### Example
```csharp
using System;
using System.Diagnostics;
using Autodesk.Forge;
using Autodesk.Forge.Client;
using Autodesk.Forge.Model;

namespace Example
{
    public class CopyToExample
    {
        public void main()
        {
            
            // Configure OAuth2 access token for authorization: oauth2_application
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ObjectsApi();
            var bucketKey = bucketKey_example;  // string | URL-encoded bucket key
            var objectName = objectName_example;  // string | URL-encoded object name
            var newObjName = newObjName_example;  // string | URL-encoded Object key to use as the destination

            try
            {
                ObjectDetails result = apiInstance.CopyTo(bucketKey, objectName, newObjName);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ObjectsApi.CopyTo: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **bucketKey** | **string**| URL-encoded bucket key | 
 **objectName** | **string**| URL-encoded object name | 
 **newObjName** | **string**| URL-encoded Object key to use as the destination | 

### Return type

[**ObjectDetails**](ObjectDetails.md)

### Authorization

[oauth2_application](../README.md#oauth2_application)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/vnd.api+json, application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="createsignedresource"></a>
# **CreateSignedResource**
> PostObjectSigned CreateSignedResource (string bucketKey, string objectName, PostBucketsSigned postBucketsSigned, string access = null)



This endpoint creates a signed URL that can be used to download an object within the specified expiration time. Be aware that if the object the signed URL points to is deleted or expires before the signed URL expires, then the signed URL will no longer be valid. A successful call to this endpoint requires bucket owner access.

### Example
```csharp
using System;
using System.Diagnostics;
using Autodesk.Forge;
using Autodesk.Forge.Client;
using Autodesk.Forge.Model;

namespace Example
{
    public class CreateSignedResourceExample
    {
        public void main()
        {
            
            // Configure OAuth2 access token for authorization: oauth2_application
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ObjectsApi();
            var bucketKey = bucketKey_example;  // string | URL-encoded bucket key
            var objectName = objectName_example;  // string | URL-encoded object name
            var postBucketsSigned = new PostBucketsSigned(); // PostBucketsSigned | Body Structure
            var access = access_example;  // string | Access for signed resource Acceptable values: `read`, `write`, `readwrite`. Default value: `read`  (optional)  (default to read)

            try
            {
                PostObjectSigned result = apiInstance.CreateSignedResource(bucketKey, objectName, postBucketsSigned, access);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ObjectsApi.CreateSignedResource: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **bucketKey** | **string**| URL-encoded bucket key | 
 **objectName** | **string**| URL-encoded object name | 
 **postBucketsSigned** | [**PostBucketsSigned**](PostBucketsSigned.md)| Body Structure | 
 **access** | **string**| Access for signed resource Acceptable values: &#x60;read&#x60;, &#x60;write&#x60;, &#x60;readwrite&#x60;. Default value: &#x60;read&#x60;  | [optional] [default to read]

### Return type

[**PostObjectSigned**](PostObjectSigned.md)

### Authorization

[oauth2_application](../README.md#oauth2_application)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/vnd.api+json, application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deleteobject"></a>
# **DeleteObject**
> void DeleteObject (string bucketKey, string objectName)



Deletes an object from the bucket.

### Example
```csharp
using System;
using System.Diagnostics;
using Autodesk.Forge;
using Autodesk.Forge.Client;
using Autodesk.Forge.Model;

namespace Example
{
    public class DeleteObjectExample
    {
        public void main()
        {
            
            // Configure OAuth2 access token for authorization: oauth2_application
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ObjectsApi();
            var bucketKey = bucketKey_example;  // string | URL-encoded bucket key
            var objectName = objectName_example;  // string | URL-encoded object name

            try
            {
                apiInstance.DeleteObject(bucketKey, objectName);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ObjectsApi.DeleteObject: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **bucketKey** | **string**| URL-encoded bucket key | 
 **objectName** | **string**| URL-encoded object name | 

### Return type

void (empty response body)

### Authorization

[oauth2_application](../README.md#oauth2_application)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deletesignedresource"></a>
# **DeleteSignedResource**
> void DeleteSignedResource (string id, string region = null)



Delete a signed URL. A successful call to this endpoint requires bucket owner access.

### Example
```csharp
using System;
using System.Diagnostics;
using Autodesk.Forge;
using Autodesk.Forge.Client;
using Autodesk.Forge.Model;

namespace Example
{
    public class DeleteSignedResourceExample
    {
        public void main()
        {
            
            // Configure OAuth2 access token for authorization: oauth2_application
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ObjectsApi();
            var id = id_example;  // string | Id of signed resource
            var region = region_example;  // string | The region where the bucket resides Acceptable values: `US`, `EMEA` Default is `US`  (optional)  (default to US)

            try
            {
                apiInstance.DeleteSignedResource(id, region);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ObjectsApi.DeleteSignedResource: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **string**| Id of signed resource | 
 **region** | **string**| The region where the bucket resides Acceptable values: &#x60;US&#x60;, &#x60;EMEA&#x60; Default is &#x60;US&#x60;  | [optional] [default to US]

### Return type

void (empty response body)

### Authorization

[oauth2_application](../README.md#oauth2_application)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: text/plain

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getobject"></a>
# **GetObject**
> System.IO.Stream GetObject (string bucketKey, string objectName, string range = null, string ifNoneMatch = null, DateTime? ifModifiedSince = null, string acceptEncoding = null)



Download an object.

### Example
```csharp
using System;
using System.Diagnostics;
using Autodesk.Forge;
using Autodesk.Forge.Client;
using Autodesk.Forge.Model;

namespace Example
{
    public class GetObjectExample
    {
        public void main()
        {
            
            // Configure OAuth2 access token for authorization: oauth2_application
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ObjectsApi();
            var bucketKey = bucketKey_example;  // string | URL-encoded bucket key
            var objectName = objectName_example;  // string | URL-encoded object name
            var range = range_example;  // string | A range of bytes to download from the specified object. (optional) 
            var ifNoneMatch = ifNoneMatch_example;  // string | The value of this header is compared to the ETAG of the object. If they match, the body will not be included in the response. Only the object information will be included. (optional) 
            var ifModifiedSince = 2013-10-20;  // DateTime? | If the requested object has not been modified since the time specified in this field, an entity will not be returned from the server; instead, a 304 (not modified) response will be returned without any message body.  (optional) 
            var acceptEncoding = acceptEncoding_example;  // string | When gzip is specified, a gzip compressed stream of the object’s bytes will be returned in the response. Cannot use “Accept-Encoding:gzip” with Range header containing an end byte range. End byte range will not be honored if “Accept-Encoding: gzip” header is used.  (optional) 

            try
            {
                System.IO.Stream result = apiInstance.GetObject(bucketKey, objectName, range, ifNoneMatch, ifModifiedSince, acceptEncoding);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ObjectsApi.GetObject: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **bucketKey** | **string**| URL-encoded bucket key | 
 **objectName** | **string**| URL-encoded object name | 
 **range** | **string**| A range of bytes to download from the specified object. | [optional] 
 **ifNoneMatch** | **string**| The value of this header is compared to the ETAG of the object. If they match, the body will not be included in the response. Only the object information will be included. | [optional] 
 **ifModifiedSince** | **DateTime?**| If the requested object has not been modified since the time specified in this field, an entity will not be returned from the server; instead, a 304 (not modified) response will be returned without any message body.  | [optional] 
 **acceptEncoding** | **string**| When gzip is specified, a gzip compressed stream of the object’s bytes will be returned in the response. Cannot use “Accept-Encoding:gzip” with Range header containing an end byte range. End byte range will not be honored if “Accept-Encoding: gzip” header is used.  | [optional] 

### Return type

**System.IO.Stream**

### Authorization

[oauth2_application](../README.md#oauth2_application)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/octet-stream

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getobjectdetails"></a>
# **GetObjectDetails**
> ObjectFullDetails GetObjectDetails (string bucketKey, string objectName, DateTime? ifModifiedSince = null, string with = null)



Returns object details in JSON format.

### Example
```csharp
using System;
using System.Diagnostics;
using Autodesk.Forge;
using Autodesk.Forge.Client;
using Autodesk.Forge.Model;

namespace Example
{
    public class GetObjectDetailsExample
    {
        public void main()
        {
            
            // Configure OAuth2 access token for authorization: oauth2_application
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ObjectsApi();
            var bucketKey = bucketKey_example;  // string | URL-encoded bucket key
            var objectName = objectName_example;  // string | URL-encoded object name
            var ifModifiedSince = 2013-10-20;  // DateTime? | If the requested object has not been modified since the time specified in this field, an entity will not be returned from the server; instead, a 304 (not modified) response will be returned without any message body.  (optional) 
            var with = with_example;  // string | Extra information in details; multiple uses are supported Acceptable values: `createdDate`, `lastAccessedDate`, `lastModifiedDate`  (optional) 

            try
            {
                ObjectFullDetails result = apiInstance.GetObjectDetails(bucketKey, objectName, ifModifiedSince, with);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ObjectsApi.GetObjectDetails: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **bucketKey** | **string**| URL-encoded bucket key | 
 **objectName** | **string**| URL-encoded object name | 
 **ifModifiedSince** | **DateTime?**| If the requested object has not been modified since the time specified in this field, an entity will not be returned from the server; instead, a 304 (not modified) response will be returned without any message body.  | [optional] 
 **with** | **string**| Extra information in details; multiple uses are supported Acceptable values: &#x60;createdDate&#x60;, &#x60;lastAccessedDate&#x60;, &#x60;lastModifiedDate&#x60;  | [optional] 

### Return type

[**ObjectFullDetails**](ObjectFullDetails.md)

### Authorization

[oauth2_application](../README.md#oauth2_application)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/vnd.api+json, application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getobjects"></a>
# **GetObjects**
> BucketObjects GetObjects (string bucketKey, int? limit = null, string beginsWith = null, string startAt = null)



List objects in a bucket. It is only available to the bucket creator.

### Example
```csharp
using System;
using System.Diagnostics;
using Autodesk.Forge;
using Autodesk.Forge.Client;
using Autodesk.Forge.Model;

namespace Example
{
    public class GetObjectsExample
    {
        public void main()
        {
            
            // Configure OAuth2 access token for authorization: oauth2_application
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ObjectsApi();
            var bucketKey = bucketKey_example;  // string | URL-encoded bucket key
            var limit = 56;  // int? | Limit to the response size, Acceptable values: 1-100 Default = 10  (optional)  (default to 10)
            var beginsWith = beginsWith_example;  // string | Provides a way to filter the based on object key name (optional) 
            var startAt = startAt_example;  // string | Key to use as an offset to continue pagination This is typically the last bucket key found in a preceding GET buckets response  (optional) 

            try
            {
                BucketObjects result = apiInstance.GetObjects(bucketKey, limit, beginsWith, startAt);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ObjectsApi.GetObjects: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **bucketKey** | **string**| URL-encoded bucket key | 
 **limit** | **int?**| Limit to the response size, Acceptable values: 1-100 Default &#x3D; 10  | [optional] [default to 10]
 **beginsWith** | **string**| Provides a way to filter the based on object key name | [optional] 
 **startAt** | **string**| Key to use as an offset to continue pagination This is typically the last bucket key found in a preceding GET buckets response  | [optional] 

### Return type

[**BucketObjects**](BucketObjects.md)

### Authorization

[oauth2_application](../README.md#oauth2_application)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/vnd.api+json, application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getsignedresource"></a>
# **GetSignedResource**
> System.IO.Stream GetSignedResource (string id, string range = null, string ifNoneMatch = null, DateTime? ifModifiedSince = null, string acceptEncoding = null, string region = null)



Download an object using a signed URL.

### Example
```csharp
using System;
using System.Diagnostics;
using Autodesk.Forge;
using Autodesk.Forge.Client;
using Autodesk.Forge.Model;

namespace Example
{
    public class GetSignedResourceExample
    {
        public void main()
        {
            
            // Configure OAuth2 access token for authorization: oauth2_application
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ObjectsApi();
            var id = id_example;  // string | Id of signed resource
            var range = range_example;  // string | A range of bytes to download from the specified object. (optional) 
            var ifNoneMatch = ifNoneMatch_example;  // string | The value of this header is compared to the ETAG of the object. If they match, the body will not be included in the response. Only the object information will be included. (optional) 
            var ifModifiedSince = 2013-10-20;  // DateTime? | If the requested object has not been modified since the time specified in this field, an entity will not be returned from the server; instead, a 304 (not modified) response will be returned without any message body.  (optional) 
            var acceptEncoding = acceptEncoding_example;  // string | When gzip is specified, a gzip compressed stream of the object’s bytes will be returned in the response. Cannot use “Accept-Encoding:gzip” with Range header containing an end byte range. End byte range will not be honored if “Accept-Encoding: gzip” header is used.  (optional) 
            var region = region_example;  // string | The region where the bucket resides Acceptable values: `US`, `EMEA` Default is `US`  (optional)  (default to US)

            try
            {
                System.IO.Stream result = apiInstance.GetSignedResource(id, range, ifNoneMatch, ifModifiedSince, acceptEncoding, region);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ObjectsApi.GetSignedResource: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **string**| Id of signed resource | 
 **range** | **string**| A range of bytes to download from the specified object. | [optional] 
 **ifNoneMatch** | **string**| The value of this header is compared to the ETAG of the object. If they match, the body will not be included in the response. Only the object information will be included. | [optional] 
 **ifModifiedSince** | **DateTime?**| If the requested object has not been modified since the time specified in this field, an entity will not be returned from the server; instead, a 304 (not modified) response will be returned without any message body.  | [optional] 
 **acceptEncoding** | **string**| When gzip is specified, a gzip compressed stream of the object’s bytes will be returned in the response. Cannot use “Accept-Encoding:gzip” with Range header containing an end byte range. End byte range will not be honored if “Accept-Encoding: gzip” header is used.  | [optional] 
 **region** | **string**| The region where the bucket resides Acceptable values: &#x60;US&#x60;, &#x60;EMEA&#x60; Default is &#x60;US&#x60;  | [optional] [default to US]

### Return type

**System.IO.Stream**

### Authorization

[oauth2_application](../README.md#oauth2_application)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/octet-stream

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getstatusbysessionid"></a>
# **GetStatusBySessionId**
> void GetStatusBySessionId (string bucketKey, string objectName, string sessionId)



This endpoint returns status information about a resumable upload.

### Example
```csharp
using System;
using System.Diagnostics;
using Autodesk.Forge;
using Autodesk.Forge.Client;
using Autodesk.Forge.Model;

namespace Example
{
    public class GetStatusBySessionIdExample
    {
        public void main()
        {
            
            // Configure OAuth2 access token for authorization: oauth2_application
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ObjectsApi();
            var bucketKey = bucketKey_example;  // string | URL-encoded bucket key
            var objectName = objectName_example;  // string | URL-encoded object name
            var sessionId = sessionId_example;  // string | Unique identifier of a session of a file being uploaded

            try
            {
                apiInstance.GetStatusBySessionId(bucketKey, objectName, sessionId);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ObjectsApi.GetStatusBySessionId: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **bucketKey** | **string**| URL-encoded bucket key | 
 **objectName** | **string**| URL-encoded object name | 
 **sessionId** | **string**| Unique identifier of a session of a file being uploaded | 

### Return type

void (empty response body)

### Authorization

[oauth2_application](../README.md#oauth2_application)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/vnd.api+json, application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="uploadchunk"></a>
# **UploadChunk**
> ObjectDetails UploadChunk (string bucketKey, string objectName, int? contentLength, string contentRange, string sessionId, System.IO.Stream body, string contentDisposition = null, string ifMatch = null)



This endpoint allows resumable uploads for large files in chunks.

### Example
```csharp
using System;
using System.Diagnostics;
using Autodesk.Forge;
using Autodesk.Forge.Client;
using Autodesk.Forge.Model;

namespace Example
{
    public class UploadChunkExample
    {
        public void main()
        {
            
            // Configure OAuth2 access token for authorization: oauth2_application
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ObjectsApi();
            var bucketKey = bucketKey_example;  // string | URL-encoded bucket key
            var objectName = objectName_example;  // string | URL-encoded object name
            var contentLength = 56;  // int? | Indicates the size of the request body.
            var contentRange = contentRange_example;  // string | Byte range of a segment being uploaded
            var sessionId = sessionId_example;  // string | Unique identifier of a session of a file being uploaded
            var body = /path/to/file.txt;  // System.IO.Stream | 
            var contentDisposition = contentDisposition_example;  // string | The suggested default filename when downloading this object to a file after it has been uploaded. (optional) 
            var ifMatch = ifMatch_example;  // string | If-Match header containing a SHA-1 hash of the bytes in the request body can be sent by the calling service or client application with the request. If present, OSS will use the value of If-Match header to verify that a SHA-1 calculated for the uploaded bytes server side matches what was sent in the header. If not, the request is failed with a status 412 Precondition Failed and the data is not written.  (optional) 

            try
            {
                ObjectDetails result = apiInstance.UploadChunk(bucketKey, objectName, contentLength, contentRange, sessionId, body, contentDisposition, ifMatch);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ObjectsApi.UploadChunk: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **bucketKey** | **string**| URL-encoded bucket key | 
 **objectName** | **string**| URL-encoded object name | 
 **contentLength** | **int?**| Indicates the size of the request body. | 
 **contentRange** | **string**| Byte range of a segment being uploaded | 
 **sessionId** | **string**| Unique identifier of a session of a file being uploaded | 
 **body** | **System.IO.Stream****System.IO.Stream**|  | 
 **contentDisposition** | **string**| The suggested default filename when downloading this object to a file after it has been uploaded. | [optional] 
 **ifMatch** | **string**| If-Match header containing a SHA-1 hash of the bytes in the request body can be sent by the calling service or client application with the request. If present, OSS will use the value of If-Match header to verify that a SHA-1 calculated for the uploaded bytes server side matches what was sent in the header. If not, the request is failed with a status 412 Precondition Failed and the data is not written.  | [optional] 
 **contentType** |  **string** | Content type for the upload | [optional] 

### Return type

[**ObjectDetails**](ObjectDetails.md)

### Authorization

[oauth2_application](../README.md#oauth2_application)

### HTTP request headers

 - **Content-Type**: application/octet-stream
 - **Accept**: application/vnd.api+json, application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="uploadobject"></a>
# **UploadObject**
> ObjectDetails UploadObject (string bucketKey, string objectName, int? contentLength, System.IO.Stream body, string contentDisposition = null, string ifMatch = null)



Upload an object. If the specified object name already exists in the bucket, the uploaded content will overwrite the existing content for the bucket name/object name combination. 

### Example
```csharp
using System;
using System.Diagnostics;
using Autodesk.Forge;
using Autodesk.Forge.Client;
using Autodesk.Forge.Model;

namespace Example
{
    public class UploadObjectExample
    {
        public void main()
        {
            
            // Configure OAuth2 access token for authorization: oauth2_application
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ObjectsApi();
            var bucketKey = bucketKey_example;  // string | URL-encoded bucket key
            var objectName = objectName_example;  // string | URL-encoded object name
            var contentLength = 56;  // int? | Indicates the size of the request body.
            var body = /path/to/file.txt;  // System.IO.Stream | 
            var contentDisposition = contentDisposition_example;  // string | The suggested default filename when downloading this object to a file after it has been uploaded. (optional) 
            var ifMatch = ifMatch_example;  // string | If-Match header containing a SHA-1 hash of the bytes in the request body can be sent by the calling service or client application with the request. If present, OSS will use the value of If-Match header to verify that a SHA-1 calculated for the uploaded bytes server side matches what was sent in the header. If not, the request is failed with a status 412 Precondition Failed and the data is not written.  (optional) 

            try
            {
                ObjectDetails result = apiInstance.UploadObject(bucketKey, objectName, contentLength, body, contentDisposition, ifMatch);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ObjectsApi.UploadObject: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **bucketKey** | **string**| URL-encoded bucket key | 
 **objectName** | **string**| URL-encoded object name | 
 **contentLength** | **int?**| Indicates the size of the request body. | 
 **body** | **System.IO.Stream****System.IO.Stream**|  | 
 **contentDisposition** | **string**| The suggested default filename when downloading this object to a file after it has been uploaded. | [optional] 
 **ifMatch** | **string**| If-Match header containing a SHA-1 hash of the bytes in the request body can be sent by the calling service or client application with the request. If present, OSS will use the value of If-Match header to verify that a SHA-1 calculated for the uploaded bytes server side matches what was sent in the header. If not, the request is failed with a status 412 Precondition Failed and the data is not written.  | [optional] 
 **contentType** |  **string** | Content type for the upload | [optional] 

### Return type

[**ObjectDetails**](ObjectDetails.md)

### Authorization

[oauth2_application](../README.md#oauth2_application)

### HTTP request headers

 - **Content-Type**: application/octet-stream
 - **Accept**: application/vnd.api+json, application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="uploadsignedresource"></a>
# **UploadSignedResource**
> ObjectDetails UploadSignedResource (string id, int? contentLength, System.IO.Stream body, string contentDisposition = null, string xAdsRegion = null, string ifMatch = null)



Overwrite a existing object using a signed URL.  Conditions to call this operation:  Object is available Expiration period is valid Signed URL should be created with `write` or `readwrite` 

### Example
```csharp
using System;
using System.Diagnostics;
using Autodesk.Forge;
using Autodesk.Forge.Client;
using Autodesk.Forge.Model;

namespace Example
{
    public class UploadSignedResourceExample
    {
        public void main()
        {
            
            // Configure OAuth2 access token for authorization: oauth2_application
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ObjectsApi();
            var id = id_example;  // string | Id of signed resource
            var contentLength = 56;  // int? | Indicates the size of the request body.
            var body = /path/to/file.txt;  // System.IO.Stream | 
            var contentDisposition = contentDisposition_example;  // string | The suggested default filename when downloading this object to a file after it has been uploaded. (optional) 
            var xAdsRegion = xAdsRegion_example;  // string | The region where the bucket resides Acceptable values: `US`, `EMEA` Default is `US`  (optional)  (default to US)
            var ifMatch = ifMatch_example;  // string | If-Match header containing a SHA-1 hash of the bytes in the request body can be sent by the calling service or client application with the request. If present, OSS will use the value of If-Match header to verify that a SHA-1 calculated for the uploaded bytes server side matches what was sent in the header. If not, the request is failed with a status 412 Precondition Failed and the data is not written.  (optional) 

            try
            {
                ObjectDetails result = apiInstance.UploadSignedResource(id, contentLength, body, contentDisposition, xAdsRegion, ifMatch);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ObjectsApi.UploadSignedResource: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **string**| Id of signed resource | 
 **contentLength** | **int?**| Indicates the size of the request body. | 
 **body** | **System.IO.Stream****System.IO.Stream**|  | 
 **contentDisposition** | **string**| The suggested default filename when downloading this object to a file after it has been uploaded. | [optional] 
 **xAdsRegion** | **string**| The region where the bucket resides Acceptable values: &#x60;US&#x60;, &#x60;EMEA&#x60; Default is &#x60;US&#x60;  | [optional] [default to US]
 **ifMatch** | **string**| If-Match header containing a SHA-1 hash of the bytes in the request body can be sent by the calling service or client application with the request. If present, OSS will use the value of If-Match header to verify that a SHA-1 calculated for the uploaded bytes server side matches what was sent in the header. If not, the request is failed with a status 412 Precondition Failed and the data is not written.  | [optional] 
 **contentType** |  **string** | Content type for the upload | [optional] 

### Return type

[**ObjectDetails**](ObjectDetails.md)

### Authorization

[oauth2_application](../README.md#oauth2_application)

### HTTP request headers

 - **Content-Type**: application/octet-stream
 - **Accept**: application/vnd.api+json, application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="uploadsignedresourceschunk"></a>
# **UploadSignedResourcesChunk**
> ObjectDetails UploadSignedResourcesChunk (string id, string contentRange, string sessionId, System.IO.Stream body, string contentDisposition = null, string xAdsRegion = null)



Resumable upload for signed URLs.

### Example
```csharp
using System;
using System.Diagnostics;
using Autodesk.Forge;
using Autodesk.Forge.Client;
using Autodesk.Forge.Model;

namespace Example
{
    public class UploadSignedResourcesChunkExample
    {
        public void main()
        {
            
            // Configure OAuth2 access token for authorization: oauth2_application
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ObjectsApi();
            var id = id_example;  // string | Id of signed resource
            var contentRange = contentRange_example;  // string | Byte range of a segment being uploaded
            var sessionId = sessionId_example;  // string | Unique identifier of a session of a file being uploaded
            var body = /path/to/file.txt;  // System.IO.Stream | 
            var contentDisposition = contentDisposition_example;  // string | The suggested default filename when downloading this object to a file after it has been uploaded. (optional) 
            var xAdsRegion = xAdsRegion_example;  // string | The region where the bucket resides Acceptable values: `US`, `EMEA` Default is `US`  (optional)  (default to US)

            try
            {
                ObjectDetails result = apiInstance.UploadSignedResourcesChunk(id, contentRange, sessionId, body, contentDisposition, xAdsRegion);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ObjectsApi.UploadSignedResourcesChunk: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **string**| Id of signed resource | 
 **contentRange** | **string**| Byte range of a segment being uploaded | 
 **sessionId** | **string**| Unique identifier of a session of a file being uploaded | 
 **body** | **System.IO.Stream****System.IO.Stream**|  | 
 **contentDisposition** | **string**| The suggested default filename when downloading this object to a file after it has been uploaded. | [optional] 
 **xAdsRegion** | **string**| The region where the bucket resides Acceptable values: &#x60;US&#x60;, &#x60;EMEA&#x60; Default is &#x60;US&#x60;  | [optional] [default to US]
 **contentType** |  **string** | Content type for the upload | [optional] 

### Return type

[**ObjectDetails**](ObjectDetails.md)

### Authorization

[oauth2_application](../README.md#oauth2_application)

### HTTP request headers

 - **Content-Type**: application/octet-stream
 - **Accept**: application/vnd.api+json, application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

