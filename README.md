# JSON and NuGet Assignment

Console application for reading JSON and XML data in C# with the .NET class library and the `Newtonsoft.Json` NuGet package.

## How to Run

```bash
dotnet restore
dotnet run
```

## GitHub Repository

Suggested public repository URL for the final submission:

```text
https://github.com/fa1dpip/NuGET
```

Publishing from this environment is blocked because GitHub CLI is not installed and the connected GitHub app can only update existing repositories. After creating the public repository, push the local commit history with:

```bash
git remote add origin https://github.com/fa1dpip/NuGET.git
git push -u origin main
```

## Report

The PDF report is available at `Reports/TestReport.pdf`. The report source and console output preview are also stored in the `Reports` folder.

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

### Version 3 - Inheritance and user types

- Extended the base `User` class with inherited user types.
- Added `AdminUser`, `StandardUser`, and `ModeratorUser`.
- Created `Data/user-types.json` with specialized user type data.
- Deserialized each typed JSON entry into the correct inherited C# object.
- Used a loop to output every specialized user to the console.

### Version 4 - Submission materials

- Added the test report source in `Reports/TestReport.md`.
- Generated `Reports/TestReport.pdf` for Moodle submission.
- Added an expected console output text file and preview image.
- Documented the GitHub publishing step and current environment limitation.
