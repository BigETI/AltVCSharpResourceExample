# alt:V C♯ Resource Example

This repository contains an example for how to make C♯ resources for alt:V.

# Building and testing

- "Publish" a .NET build by executing
```
dotnet publish -c Release
```
- Copy contents from `./bin/Release/publish/` to its resource folder on your alt:V server.
- Add resource and C♯ module in `server.cfg` if not done yet.
- Start server

# License

This repository is licensed under the ["MIT License"](https://github.com/BigETI/AltVCSharpResourceExample/blob/master/LICENSE).
