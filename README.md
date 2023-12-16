# DotNet8MediatR.WebApi

Please remove this line `<InvariantGlobalization>true</InvariantGlobalization>` in web api project
```
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <InvariantGlobalization>true</InvariantGlobalization>
  </PropertyGroup>

</Project>
```

```
Example Request

{
	"reqService": "1:BlogList",
	"reqData": {
		"PageSettng": {
			"PageNo" : 1,
			"PageSize" : 10
		}
	}
}

{
	"reqService": "2:Login",
	"reqData": {
		"CardNumber": "4532772818527395",
		"Password": "1234"
	}
}
```