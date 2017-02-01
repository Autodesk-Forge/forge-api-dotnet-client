# Autodesk.Forge.Model.ObjectFullDetails
## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**BucketKey** | **string** | Bucket key | [optional] 
**ObjectId** | **string** | Object URN | [optional] 
**ObjectKey** | **string** | Object name | [optional] 
**Sha1** | **byte[]** | Object SHA1 | [optional] 
**Size** | **int?** | Object size | [optional] 
**ContentType** | **string** | Object content-type | [optional] 
**Location** | **string** | URL to download the object | [optional] 
**BlockSizes** | **List&lt;int?&gt;** | For delta-encoding. Represents whether a signature exists at a specific block size | [optional] 
**Deltas** | [**List&lt;ObjectFullDetailsDeltas&gt;**](ObjectFullDetailsDeltas.md) | Patch files available for download related to this object | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

