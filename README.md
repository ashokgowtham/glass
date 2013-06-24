Glass
=====

###Glass
* Its reflective
  * A reflection wrapper for .net
* Its smooth
  * Fluent APIs make development easy and smooth - LINQ friendly
* Its transparent
  * Simple APIs that are intuitive and clear

###Sample

```csharp
var staticTypesInMscorlib = from Type t in mscorlibAssembly.Types
    orderby t.Name
    where t.IsStatic
    select t;
```
