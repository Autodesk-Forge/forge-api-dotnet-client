# Autodesk.Forge.BucketsApi

All URIs are relative to *https://developer.api.autodesk.com/*

Method | HTTP request | Description
------------- | ------------- | -------------
[**CreateBucket**](BucketsApi.md#createbucket) | **POST** /oss/v2/buckets | 
[**DeleteBucket**](BucketsApi.md#deletebucket) | **DELETE** /oss/v2/buckets/{bucketKey} | 
[**GetBucketDetails**](BucketsApi.md#getbucketdetails) | **GET** /oss/v2/buckets/{bucketKey}/details | 
[**GetBuckets**](BucketsApi.md#getbuckets) | **GET** /oss/v2/buckets | 


<a name="createbucket"></a>
# **CreateBucket**
> Bucket CreateBucket (PostBucketsPayload postBuckets, string xAdsRegion = null)



Use this endpoint to create a bucket. Buckets are arbitrary spaces created and owned by applications. Bucket keys are globally unique across all regions, regardless of where they were created, and they cannot be changed. The application creating the bucket is the owner of the bucket. 

### Example
```csharp
using System;
using System.Diagnostics;
using Autodesk.Forge;
using Autodesk.Forge.Client;
using Autodesk.Forge.Model;

namespace Example
{
    public class CreateBucketExample
    {
        public void main()
        {
            
            // Configure OAuth2 access token for authorization: oauth2_application
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new BucketsApi();
            var postBuckets = new PostBucketsPayload(); // PostBucketsPayload | Body Structure
            var xAdsRegion = xAdsRegion_example;  // string | The region where the bucket resides Acceptable values: `US`, `EMEA` Default is `US`  (optional)  (default to US)

            try
            {
                Bucket result = apiInstance.CreateBucket(postBuckets, xAdsRegion);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling BucketsApi.CreateBucket: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **postBuckets** | [**PostBucketsPayload**](PostBucketsPayload.md)| Body Structure | 
 **xAdsRegion** | **string**| The region where the bucket resides Acceptable values: &#x60;US&#x60;, &#x60;EMEA&#x60; Default is &#x60;US&#x60;  | [optional] [default to US]

### Return type

[**Bucket**](Bucket.md)

### Authorization

[oauth2_application](../README.md#oauth2_application)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/vnd.api+json, application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deletebucket"></a>
# **DeleteBucket**
> void DeleteBucket (string bucketKey)



This endpoint will delete a bucket. 

### Example
```csharp
using System;
using System.Diagnostics;
using Autodesk.Forge;
using Autodesk.Forge.Client;
using Autodesk.Forge.Model;

namespace Example
{
    public class DeleteBucketExample
    {
        public void main()
        {
            
            // Configure OAuth2 access token for authorization: oauth2_application
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new BucketsApi();
            var bucketKey = bucketKey_example;  // string | URL-encoded bucket key

            try
            {
                apiInstance.DeleteBucket(bucketKey);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling BucketsApi.DeleteBucket: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **bucketKey** | **string**| URL-encoded bucket key | 

### Return type

void (empty response body)

### Authorization

[oauth2_application](../README.md#oauth2_application)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/vnd.api+json, application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getbucketdetails"></a>
# **GetBucketDetails**
> Bucket GetBucketDetails (string bucketKey)



This endpoint will return the buckets owned by the application. This endpoint supports pagination.

### Example
```csharp
using System;
using System.Diagnostics;
using Autodesk.Forge;
using Autodesk.Forge.Client;
using Autodesk.Forge.Model;

namespace Example
{
    public class GetBucketDetailsExample
    {
        public void main()
        {
            
            // Configure OAuth2 access token for authorization: oauth2_application
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new BucketsApi();
            var bucketKey = bucketKey_example;  // string | URL-encoded bucket key

            try
            {
                Bucket result = apiInstance.GetBucketDetails(bucketKey);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling BucketsApi.GetBucketDetails: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **bucketKey** | **string**| URL-encoded bucket key | 

### Return type

[**Bucket**](Bucket.md)

### Authorization

[oauth2_application](../README.md#oauth2_application)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/vnd.api+json, application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getbuckets"></a>
# **GetBuckets**
> Buckets GetBuckets (string region = null, int? limit = null, string startAt = null)



This endpoint will return the buckets owned by the application. This endpoint supports pagination. 

### Example
```csharp
using System;
using System.Diagnostics;
using Autodesk.Forge;
using Autodesk.Forge.Client;
using Autodesk.Forge.Model;

namespace Example
{
    public class GetBucketsExample
    {
        public void main()
        {
            
            // Configure OAuth2 access token for authorization: oauth2_application
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new BucketsApi();
            var region = region_example;  // string | The region where the bucket resides Acceptable values: `US`, `EMEA` Default is `US`  (optional)  (default to US)
            var limit = 56;  // int? | Limit to the response size, Acceptable values: 1-100 Default = 10  (optional)  (default to 10)
            var startAt = startAt_example;  // string | Key to use as an offset to continue pagination This is typically the last bucket key found in a preceding GET buckets response  (optional) 

            try
            {
                Buckets result = apiInstance.GetBuckets(region, limit, startAt);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling BucketsApi.GetBuckets: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **region** | **string**| The region where the bucket resides Acceptable values: &#x60;US&#x60;, &#x60;EMEA&#x60; Default is &#x60;US&#x60;  | [optional] [default to US]
 **limit** | **int?**| Limit to the response size, Acceptable values: 1-100 Default &#x3D; 10  | [optional] [default to 10]
 **startAt** | **string**| Key to use as an offset to continue pagination This is typically the last bucket key found in a preceding GET buckets response  | [optional] 

### Return type

[**Buckets**](Buckets.md)

### Authorization

[oauth2_application](../README.md#oauth2_application)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/vnd.api+json, application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

