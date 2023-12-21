# DotNet8MediatR.WebApi

Please remove this line `<InvariantGlobalization>true</InvariantGlobalization>` in web api project
```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <InvariantGlobalization>true</InvariantGlobalization>
  </PropertyGroup>

</Project>
```

Example Request
```json
{
    "reqService": "2:Login",
    "reqData": {
	"CardNumber": "4532772818527395",
	"Password": "1234"
    }
}

{
    "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJKb2huIiwianRpIjoiYTYwM2I3ZjEtNWU5MS00NWQyLWFiNTktYjYzMWZiMTM0MjgzIiwiVXNlck5hbWUiOiJKb2huIiwiQ2FyZE51bWJlciI6IjQ1MzI3NzI4MTg1MjczOTUiLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJDdXN0b21lciIsImV4cCI6MTcwMzA3NDAyNCwiaXNzIjoiaHR0cHM6Ly9sb2NhbGhvc3Q6NzA3MCIsImF1ZCI6Imh0dHBzOi8vbG9jYWxob3N0OjcwNzAifQ.EWcezRlIn3YNH9PTBjoX5nouwiXZLSQVgCb_3BdotmA",
    "reqService": "1:BlogList",
    "reqData": {
        "PageSettng": {
            "PageNo": 1,
            "PageSize": 10
        }
    }
}
```
