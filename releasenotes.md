# Autodesk.Forge .NET package

# (dev)
* ItemsApi.PatchItem & FoldersApi.PatchFolder, along with PatchFolder & PatchItem (rename BIM 360 Items is not supported)
* Deprecating Design Automation v3 classes (please use [Autodesk.Forge.DesignAutomation](https://www.nuget.org/packages/Autodesk.Forge.DesignAutomation) instead)

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
