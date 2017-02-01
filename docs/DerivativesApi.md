# Autodesk.Forge.DerivativesApi

All URIs are relative to *https://developer.api.autodesk.com/*

Method | HTTP request | Description
------------- | ------------- | -------------
[**DeleteManifest**](DerivativesApi.md#deletemanifest) | **DELETE** /modelderivative/v2/designdata/{urn}/manifest | 
[**GetDerivativeManifest**](DerivativesApi.md#getderivativemanifest) | **GET** /modelderivative/v2/designdata/{urn}/manifest/{derivativeUrn} | 
[**GetFormats**](DerivativesApi.md#getformats) | **GET** /modelderivative/v2/designdata/formats | 
[**GetManifest**](DerivativesApi.md#getmanifest) | **GET** /modelderivative/v2/designdata/{urn}/manifest | 
[**GetMetadata**](DerivativesApi.md#getmetadata) | **GET** /modelderivative/v2/designdata/{urn}/metadata | 
[**GetModelviewMetadata**](DerivativesApi.md#getmodelviewmetadata) | **GET** /modelderivative/v2/designdata/{urn}/metadata/{guid} | 
[**GetModelviewProperties**](DerivativesApi.md#getmodelviewproperties) | **GET** /modelderivative/v2/designdata/{urn}/metadata/{guid}/properties | 
[**GetThumbnail**](DerivativesApi.md#getthumbnail) | **GET** /modelderivative/v2/designdata/{urn}/thumbnail | 
[**Translate**](DerivativesApi.md#translate) | **POST** /modelderivative/v2/designdata/job | 


<a name="deletemanifest"></a>
# **DeleteManifest**
> Result DeleteManifest (string urn)



Deletes the manifest and all its translated output files (derivatives). However, it does not delete the design source file. 

### Example
```csharp
using System;
using System.Diagnostics;
using Autodesk.Forge;
using Autodesk.Forge.Client;
using Autodesk.Forge.Model;

namespace Example
{
    public class DeleteManifestExample
    {
        public void main()
        {
            
            // Configure OAuth2 access token for authorization: oauth2_access_code
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";
            // Configure OAuth2 access token for authorization: oauth2_application
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new DerivativesApi();
            var urn = urn_example;  // string | The Base64 (URL Safe) encoded design URN 

            try
            {
                Result result = apiInstance.DeleteManifest(urn);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DerivativesApi.DeleteManifest: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **urn** | **string**| The Base64 (URL Safe) encoded design URN  | 

### Return type

[**Result**](Result.md)

### Authorization

[oauth2_access_code](../README.md#oauth2_access_code), [oauth2_application](../README.md#oauth2_application)

### HTTP request headers

 - **Content-Type**: application/x-www-form-urlencoded
 - **Accept**: application/vnd.api+json, application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getderivativemanifest"></a>
# **GetDerivativeManifest**
> void GetDerivativeManifest (string urn, string derivativeUrn, int? range = null)



Downloads a selected derivative. To download the file, you need to specify the file’s URN, which you retrieve by calling the [GET {urn}/manifest](https://developer.autodesk.com/en/docs/model-derivative/v2/reference/http/urn-manifest-GET) endpoint.  Note that the Model Derivative API uses 2 types of URNs. The **design URN** is generated when you upload the source design file to Forge, and is used when calling most of the Model Derivative endpoints. A **derivative URN** is generated for each translated output file format, and is used for downloading the output design files.  You can set the range of bytes that are returned when downloading the derivative, using the range header. 

### Example
```csharp
using System;
using System.Diagnostics;
using Autodesk.Forge;
using Autodesk.Forge.Client;
using Autodesk.Forge.Model;

namespace Example
{
    public class GetDerivativeManifestExample
    {
        public void main()
        {
            
            // Configure OAuth2 access token for authorization: oauth2_access_code
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";
            // Configure OAuth2 access token for authorization: oauth2_application
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new DerivativesApi();
            var urn = urn_example;  // string | The Base64 (URL Safe) encoded design URN 
            var derivativeUrn = derivativeUrn_example;  // string | The URL-encoded URN of the derivatives. The URN is retrieved from the GET :urn/manifest endpoint. 
            var range = 56;  // int? | This is the standard RFC 2616 range request header. It only supports one range specifier per request: 1. Range:bytes=0-63 (returns the first 64 bytes) 2. Range:bytes=64-127 (returns the second set of 64 bytes) 3. Range:bytes=1022- (returns all the bytes from offset 1022 to the end) 4. If the range header is not specified, the whole content is returned.  (optional) 

            try
            {
                apiInstance.GetDerivativeManifest(urn, derivativeUrn, range);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DerivativesApi.GetDerivativeManifest: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **urn** | **string**| The Base64 (URL Safe) encoded design URN  | 
 **derivativeUrn** | **string**| The URL-encoded URN of the derivatives. The URN is retrieved from the GET :urn/manifest endpoint.  | 
 **range** | **int?**| This is the standard RFC 2616 range request header. It only supports one range specifier per request: 1. Range:bytes&#x3D;0-63 (returns the first 64 bytes) 2. Range:bytes&#x3D;64-127 (returns the second set of 64 bytes) 3. Range:bytes&#x3D;1022- (returns all the bytes from offset 1022 to the end) 4. If the range header is not specified, the whole content is returned.  | [optional] 

### Return type

void (empty response body)

### Authorization

[oauth2_access_code](../README.md#oauth2_access_code), [oauth2_application](../README.md#oauth2_application)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/octet-stream

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getformats"></a>
# **GetFormats**
> Formats GetFormats (DateTime? ifModifiedSince = null, string acceptEncoding = null)



Returns an up-to-date list of Forge-supported translations, that you can use to identify which types of derivatives are supported for each source file type. You can set this endpoint to only return the list of supported translations if they have been updated since a specified date.  See the [Supported Translation Formats table](https://developer.autodesk.com/en/docs/model-derivative/v2/overview/supported-translations) for more details about supported translations.  Note that we are constantly adding new file formats to the list of Forge translations. 

### Example
```csharp
using System;
using System.Diagnostics;
using Autodesk.Forge;
using Autodesk.Forge.Client;
using Autodesk.Forge.Model;

namespace Example
{
    public class GetFormatsExample
    {
        public void main()
        {
            
            // Configure OAuth2 access token for authorization: oauth2_access_code
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";
            // Configure OAuth2 access token for authorization: oauth2_application
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new DerivativesApi();
            var ifModifiedSince = 2013-10-20;  // DateTime? | The supported formats are only returned if they were modified since the specified date. An invalid date returns the latest supported format list. If the supported formats have not been modified since the specified date, the endpoint returns a `NOT MODIFIED` (304) response.  (optional) 
            var acceptEncoding = acceptEncoding_example;  // string | If specified with `gzip` or `*`, content will be compressed and returned in a GZIP format.  (optional) 

            try
            {
                Formats result = apiInstance.GetFormats(ifModifiedSince, acceptEncoding);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DerivativesApi.GetFormats: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **ifModifiedSince** | **DateTime?**| The supported formats are only returned if they were modified since the specified date. An invalid date returns the latest supported format list. If the supported formats have not been modified since the specified date, the endpoint returns a &#x60;NOT MODIFIED&#x60; (304) response.  | [optional] 
 **acceptEncoding** | **string**| If specified with &#x60;gzip&#x60; or &#x60;*&#x60;, content will be compressed and returned in a GZIP format.  | [optional] 

### Return type

[**Formats**](Formats.md)

### Authorization

[oauth2_access_code](../README.md#oauth2_access_code), [oauth2_application](../README.md#oauth2_application)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/vnd.api+json, application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getmanifest"></a>
# **GetManifest**
> Manifest GetManifest (string urn, string acceptEncoding = null)



Returns information about derivatives that correspond to a specific source file, including derviative URNs and statuses.  The URNs of the derivatives are used to download the generated derivatives when calling the [GET {urn}/manifest/{derivativeurn}](https://developer.autodesk.com/en/docs/model-derivative/v2/reference/http/urn-manifest-derivativeurn-GET) endpoint.  The statuses are used to verify whether the translation of requested output files is complete.  Note that different output files might complete their translation processes at different times, and therefore may have different `status` values.  When translating a source file a second time, the previously created manifest is not deleted; it appends the information (only new translations) to the manifest. 

### Example
```csharp
using System;
using System.Diagnostics;
using Autodesk.Forge;
using Autodesk.Forge.Client;
using Autodesk.Forge.Model;

namespace Example
{
    public class GetManifestExample
    {
        public void main()
        {
            
            // Configure OAuth2 access token for authorization: oauth2_access_code
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";
            // Configure OAuth2 access token for authorization: oauth2_application
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new DerivativesApi();
            var urn = urn_example;  // string | The Base64 (URL Safe) encoded design URN 
            var acceptEncoding = acceptEncoding_example;  // string | If specified with `gzip` or `*`, content will be compressed and returned in a GZIP format.  (optional) 

            try
            {
                Manifest result = apiInstance.GetManifest(urn, acceptEncoding);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DerivativesApi.GetManifest: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **urn** | **string**| The Base64 (URL Safe) encoded design URN  | 
 **acceptEncoding** | **string**| If specified with &#x60;gzip&#x60; or &#x60;*&#x60;, content will be compressed and returned in a GZIP format.  | [optional] 

### Return type

[**Manifest**](Manifest.md)

### Authorization

[oauth2_access_code](../README.md#oauth2_access_code), [oauth2_application](../README.md#oauth2_application)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/vnd.api+json, application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getmetadata"></a>
# **GetMetadata**
> Metadata GetMetadata (string urn, string acceptEncoding = null)



Returns a list of model view (metadata) IDs for a design model. The metadata ID enables end users to select an object tree and properties for a specific model view.  Although most design apps (e.g., Fusion and Inventor) only allow a single model view (object tree and set of properties), some apps (e.g., Revit) allow users to design models with multiple model views (e.g., HVAC, architecture, perspective).  Note that you can only retrieve metadata from an input file that has been translated into an SVF file. 

### Example
```csharp
using System;
using System.Diagnostics;
using Autodesk.Forge;
using Autodesk.Forge.Client;
using Autodesk.Forge.Model;

namespace Example
{
    public class GetMetadataExample
    {
        public void main()
        {
            
            // Configure OAuth2 access token for authorization: oauth2_access_code
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";
            // Configure OAuth2 access token for authorization: oauth2_application
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new DerivativesApi();
            var urn = urn_example;  // string | The Base64 (URL Safe) encoded design URN 
            var acceptEncoding = acceptEncoding_example;  // string | If specified with `gzip` or `*`, content will be compressed and returned in a GZIP format.  (optional) 

            try
            {
                Metadata result = apiInstance.GetMetadata(urn, acceptEncoding);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DerivativesApi.GetMetadata: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **urn** | **string**| The Base64 (URL Safe) encoded design URN  | 
 **acceptEncoding** | **string**| If specified with &#x60;gzip&#x60; or &#x60;*&#x60;, content will be compressed and returned in a GZIP format.  | [optional] 

### Return type

[**Metadata**](Metadata.md)

### Authorization

[oauth2_access_code](../README.md#oauth2_access_code), [oauth2_application](../README.md#oauth2_application)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/vnd.api+json, application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getmodelviewmetadata"></a>
# **GetModelviewMetadata**
> Metadata GetModelviewMetadata (string urn, string guid, string acceptEncoding = null)



Returns an object tree, i.e., a hierarchical list of objects for a model view.  To call this endpoint you first need to call the [GET {urn}/metadata](https://developer.autodesk.com/en/docs/model-derivative/v2/reference/http/urn-metadata-GET) endpoint, to determine which model view (object tree and set of properties) to use.  Although most design apps (e.g., Fusion and Inventor) only allow a single model view, some apps (e.g., Revit) allow users to design models with multiple model views (e.g., HVAC, architecture, perspective).  Note that you can only retrieve metadata from an input file that has been translated into an SVF file. 

### Example
```csharp
using System;
using System.Diagnostics;
using Autodesk.Forge;
using Autodesk.Forge.Client;
using Autodesk.Forge.Model;

namespace Example
{
    public class GetModelviewMetadataExample
    {
        public void main()
        {
            
            // Configure OAuth2 access token for authorization: oauth2_access_code
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";
            // Configure OAuth2 access token for authorization: oauth2_application
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new DerivativesApi();
            var urn = urn_example;  // string | The Base64 (URL Safe) encoded design URN 
            var guid = guid_example;  // string | Unique model view ID. Call [GET {urn}/metadata](https://developer.autodesk.com/en/docs/model-derivative/v2/reference/http/urn-metadata-GET) to get the ID 
            var acceptEncoding = acceptEncoding_example;  // string | If specified with `gzip` or `*`, content will be compressed and returned in a GZIP format.  (optional) 

            try
            {
                Metadata result = apiInstance.GetModelviewMetadata(urn, guid, acceptEncoding);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DerivativesApi.GetModelviewMetadata: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **urn** | **string**| The Base64 (URL Safe) encoded design URN  | 
 **guid** | **string**| Unique model view ID. Call [GET {urn}/metadata](https://developer.autodesk.com/en/docs/model-derivative/v2/reference/http/urn-metadata-GET) to get the ID  | 
 **acceptEncoding** | **string**| If specified with &#x60;gzip&#x60; or &#x60;*&#x60;, content will be compressed and returned in a GZIP format.  | [optional] 

### Return type

[**Metadata**](Metadata.md)

### Authorization

[oauth2_access_code](../README.md#oauth2_access_code), [oauth2_application](../README.md#oauth2_application)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/vnd.api+json, application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getmodelviewproperties"></a>
# **GetModelviewProperties**
> Metadata GetModelviewProperties (string urn, string guid, string acceptEncoding = null)



Returns a list of properties for each object in an object tree. Properties are returned according to object ID and do not follow a hierarchical structure.  The following image displays a typical list of properties for a Revit object:  ![](https://developer.doc.autodesk.com/bPlouYTd/7/_images/Properties.png)  To call this endpoint you need to first call the [GET {urn}/metadata](https://developer.autodesk.com/en/docs/model-derivative/v2/reference/http/urn-metadata-GET) endpoint, which returns a list of model view (metadata) IDs for a design input model. Select a model view (metadata) ID to use when calling the Get Properties endpoint.  Note that you can only get properties from a design input file that was previously translated into an SVF file. 

### Example
```csharp
using System;
using System.Diagnostics;
using Autodesk.Forge;
using Autodesk.Forge.Client;
using Autodesk.Forge.Model;

namespace Example
{
    public class GetModelviewPropertiesExample
    {
        public void main()
        {
            
            // Configure OAuth2 access token for authorization: oauth2_access_code
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";
            // Configure OAuth2 access token for authorization: oauth2_application
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new DerivativesApi();
            var urn = urn_example;  // string | The Base64 (URL Safe) encoded design URN 
            var guid = guid_example;  // string | Unique model view ID. Call [GET {urn}/metadata](https://developer.autodesk.com/en/docs/model-derivative/v2/reference/http/urn-metadata-GET) to get the ID 
            var acceptEncoding = acceptEncoding_example;  // string | If specified with `gzip` or `*`, content will be compressed and returned in a GZIP format.  (optional) 

            try
            {
                Metadata result = apiInstance.GetModelviewProperties(urn, guid, acceptEncoding);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DerivativesApi.GetModelviewProperties: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **urn** | **string**| The Base64 (URL Safe) encoded design URN  | 
 **guid** | **string**| Unique model view ID. Call [GET {urn}/metadata](https://developer.autodesk.com/en/docs/model-derivative/v2/reference/http/urn-metadata-GET) to get the ID  | 
 **acceptEncoding** | **string**| If specified with &#x60;gzip&#x60; or &#x60;*&#x60;, content will be compressed and returned in a GZIP format.  | [optional] 

### Return type

[**Metadata**](Metadata.md)

### Authorization

[oauth2_access_code](../README.md#oauth2_access_code), [oauth2_application](../README.md#oauth2_application)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/vnd.api+json, application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getthumbnail"></a>
# **GetThumbnail**
> System.IO.Stream GetThumbnail (string urn, int? width = null, int? height = null)



Returns the thumbnail for the source file. 

### Example
```csharp
using System;
using System.Diagnostics;
using Autodesk.Forge;
using Autodesk.Forge.Client;
using Autodesk.Forge.Model;

namespace Example
{
    public class GetThumbnailExample
    {
        public void main()
        {
            
            // Configure OAuth2 access token for authorization: oauth2_access_code
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";
            // Configure OAuth2 access token for authorization: oauth2_application
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new DerivativesApi();
            var urn = urn_example;  // string | The Base64 (URL Safe) encoded design URN 
            var width = 56;  // int? | The desired width of the thumbnail. Possible values are 100, 200 and 400.  (optional) 
            var height = 56;  // int? | The desired height of the thumbnail. Possible values are 100, 200 and 400.  (optional) 

            try
            {
                System.IO.Stream result = apiInstance.GetThumbnail(urn, width, height);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DerivativesApi.GetThumbnail: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **urn** | **string**| The Base64 (URL Safe) encoded design URN  | 
 **width** | **int?**| The desired width of the thumbnail. Possible values are 100, 200 and 400.  | [optional] 
 **height** | **int?**| The desired height of the thumbnail. Possible values are 100, 200 and 400.  | [optional] 

### Return type

**System.IO.Stream**

### Authorization

[oauth2_access_code](../README.md#oauth2_access_code), [oauth2_application](../README.md#oauth2_application)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/octet-stream

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="translate"></a>
# **Translate**
> Job Translate (JobPayload job, bool? xAdsForce = null)



Translate a source file from one format to another.  Derivatives are stored in a manifest that is updated each time this endpoint is used on a source file.  Note that this endpoint is asynchronous and initiates a process that runs in the background, rather than keeping an open HTTP connection until completion. Use the [GET {urn}/manifest](https://developer.autodesk.com/en/docs/model-derivative/v2/reference/http/urn-manifest-GET) endpoint to poll for the job’s completion. 

### Example
```csharp
using System;
using System.Diagnostics;
using Autodesk.Forge;
using Autodesk.Forge.Client;
using Autodesk.Forge.Model;

namespace Example
{
    public class TranslateExample
    {
        public void main()
        {
            
            // Configure OAuth2 access token for authorization: oauth2_access_code
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";
            // Configure OAuth2 access token for authorization: oauth2_application
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new DerivativesApi();
            var job = new JobPayload(); // JobPayload | 
            var xAdsForce = true;  // bool? | `true`: the endpoint replaces previously translated output file types with the newly generated derivatives  `false` (default): previously created derivatives are not replaced  (optional)  (default to false)

            try
            {
                Job result = apiInstance.Translate(job, xAdsForce);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DerivativesApi.Translate: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **job** | [**JobPayload**](JobPayload.md)|  | 
 **xAdsForce** | **bool?**| &#x60;true&#x60;: the endpoint replaces previously translated output file types with the newly generated derivatives  &#x60;false&#x60; (default): previously created derivatives are not replaced  | [optional] [default to false]

### Return type

[**Job**](Job.md)

### Authorization

[oauth2_access_code](../README.md#oauth2_access_code), [oauth2_application](../README.md#oauth2_application)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/vnd.api+json, application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

