# Autodesk.Forge .NET package

# 1.9.0
* Added support for .NET Core 3 and 5
* Added support for .NET Franwork 4.7.2 and 4.8

# 1.8.0
* [DerivativeWebhooksApi.CreateHookAsyncWithHttpInfo should return Task<ApiResponse<dynamic>>](DerivativeWebhooksApi.CreateHookAsyncWithHttpInfo should return Task<ApiResponse<dynamic>>)
* [OSS bucket name should not be hardcoded](https://github.com/Autodesk-Forge/forge-api-dotnet-client/issues/74)
* [do not add .json to parameters](https://github.com/Autodesk-Forge/forge-api-dotnet-client/issues/73)
* [Download derivative with DerivativesApi.GetDerivativeManifest is a void, range is an int](https://github.com/Autodesk-Forge/forge-api-dotnet-client/issues/71)
* [TwoLeggedApi: AuthenticateAsync never ends](https://github.com/Autodesk-Forge/forge-api-dotnet-client/issues/70)
* [HubsApi: cannot access EMEA hubs](https://github.com/Autodesk-Forge/forge-api-dotnet-client/issues/69)
* [Autodesk.Forge.dll is not generated when building the project](https://github.com/Autodesk-Forge/forge-api-dotnet-client/issues/65)
* [`content-type` hard coded](https://github.com/Autodesk-Forge/forge-api-dotnet-client/issues/62)
* [PATCH request](https://github.com/Autodesk-Forge/forge-api-dotnet-client/issues/50)
* [await derivativesAPI.GetModelviewPropertiesAsync(urn, guid, "*");" retrieves a 'System.OutOfMemoryException' for large files](https://github.com/Autodesk-Forge/forge-api-dotnet-client/issues/13)
* [Missing endpoint for getting properties of a single model item](https://github.com/Autodesk-Forge/forge-api-dotnet-client/issues/22)
* [Missing endpoint for patching items in DM-API](https://github.com/Autodesk-Forge/forge-api-dotnet-client/issues/38)
* [ProjectsApi.PostStorage should return StorageCreated object](https://github.com/Autodesk-Forge/forge-api-dotnet-client/issues/42)
* [FoldersApi.PostFolder should return ItemCreated ](https://github.com/Autodesk-Forge/forge-api-dotnet-client/issues/41)
* []()
* Various bugfixes
# 1.7.1
* Adding support for BIM360 OSS bucket name change

# 1.7.0
* [POST](https://forge.autodesk.com/en/docs/bim360/v1/reference/http/document-management-projects-project_id-versions-version_id-exports-POST/) & [GET](https://forge.autodesk.com/en/docs/bim360/v1/reference/http/document-management-projects-project_id-versions-version_id-exports-export_id-GET/) for PDF Export
* Fix scope typo: `user-profile:read`

# 1.6.0
* ItemsApi.PatchItem & FoldersApi.PatchFolder, along with PatchFolder & PatchItem (rename BIM 360 Items is not supported)
* Deprecating Design Automation v3 classes (please use [Autodesk.Forge.DesignAutomation](https://www.nuget.org/packages/Autodesk.Forge.DesignAutomation) instead)
* Design Automation v2 obsolete

# 1.5.2
* Fixes on Design Automation endpoints

# 1.5
* Include support for Design Automation v3
* Fix Derivative endpoints to support EMEA Region ([learn more](https://forge.autodesk.com/blog/bim-360-docs-api-changes-access-data-european-data-center))
* Add IFC for `JobPayloadItem`

# 1.4 
* Add `CheckReference` for `JobPayloadInput`
* Support GET Properties with `forceget` querystring parameter ([learn more](https://forge.autodesk.com/blog/faster-get-hierarchy-api-and-how-solve-error-413))

# 1.3
* Add `SearchFolderContentsAsync` method
* Add `PatchFolder` method

# 1.2 
* Support for .NET Core
