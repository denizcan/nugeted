# nugeted
Nuget Easy Debug

This utility eases the development of nuget package. A classic way of testing parts of nuget package in an application that consumes that particular package requires compiling/pushing the nuget package, updating the application. This slows down development cycle.. nugeted watches the assemblies that belongs to nuget package, and copies them to .nuget cache to be directly referenced..

This is not the suggested way but for 2022, it works!
