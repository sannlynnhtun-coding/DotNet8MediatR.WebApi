# DotNet8MediatR.WebApi

```bash
docker run -d --rm --name mongo -p 27017:27017 -v mongodbdata:/data/db mongo
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=acesa@123" -p 1444:1433 --name mssql2022 --hostname mssql2022 -d mcr.microsoft.com/mssql/server:2022-latest
docker run --name=mysql-container -e MYSQL_ROOT_PASSWORD=acesa123 -d -p 3306:3306 mysql:latest

docker login container-registry.oracle.com
username : [email]
password : [auth token]
docker pull container-registry.oracle.com/database/enterprise:latest

docker run -d -p 1521:1521 --name oracle container-registry.oracle.com/database/enterprise:latest
docker run -d -p 1521:1521 --name oracle -e ORACLE_SID=mydb -e ORACLE_PDB=mydbpdb1 -e ORACLE_PDB_PASSWORD=mydbpdb1 container-registry.oracle.com/database/enterprise:latest

create user sa identified by acesa123;
create user acesa identified by acesa123;
create user 'sa' identified by 'acesa123';


docker run -p 1521:1521 -p 5500:5500 --name my_oracle_db -e ORACLE_SID=mydb -e ORACLE_PDB=mydbpdb1 -e ORACLE_PDB_PASSWORD=mydbpdb1 -e ORACLE_CHARACTERSET=AL32UTF8 -v /path/to/data:/opt/oracle/oradata container-registry.oracle.com/database/enterprise:latest

docker run -p 1521:1521 -p 5500:5500 --name oracle-xe -e ORACLE_PWD=acesa123 oracle/database:18.4.0-xe
```

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
