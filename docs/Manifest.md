# Autodesk.Forge.Model.Manifest
## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Urn** | **string** | The Base64 (URL safe) encoded source file URN | 
**Type** | **string** | Type of this JSON object | 
**Progress** | **string** | Overall progress for all translation jobs in the manifest. Possible values are: &#x60;complete&#x60; or &#x60;##%&#x60;  | 
**Status** | **string** | Overall status for translation jobs in the “manifest”. Possible values are: &#x60;pending&#x60;, &#x60;success&#x60;, &#x60;inprogress&#x60;, &#x60;failed&#x60; and &#x60;timeout&#x60;  | 
**HasThumbnail** | **bool?** | Indicates if a thumbnail has been generated for the source file URN | 
**Region** | **string** | Region  | [optional] 
**Derivatives** | [**List&lt;ManifestDerivative&gt;**](ManifestDerivative.md) | Requested output files for the source file URN | 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

