# JSON and NuGet Assignment

Console application for reading JSON and XML data in C# with the .NET class library and the `Newtonsoft.Json` NuGet package.

## How to Run

```bash
dotnet restore
dotnet run
```

## Version History

### Version 1 - Manual JSON file and XML reader

- Created a .NET console project.
- Added the `Newtonsoft.Json` NuGet package reference.
- Created `Data/user.json` manually.
- Added an XML reader example using `System.Xml.Linq`.
- Added comments in the program to explain the JSON deserialization stage.

### Version 2 - Multiple JSON entries and loop output

- Created `Data/users.json` as a JSON object that contains several user entries.
- Added `UserCollection` to match the JSON object structure.
- Deserialized all entries from the JSON file into C# objects.
- Added a `foreach` loop to output every user to the console.
