# prod-mang-sys
Client side was developed with Angular latest version.
Server side was developed with .NET Core 3.1

A sqlite database pre-configured is copied to the container for the sake of simplicity, you could use your own config.

If you want to consume the containerized API, execute the next command:
  docker-compose up --build -d
  
Else, you could build and run the API using dotnet sdk 3.1 or execute the DLL using your installed dotnet runtime 3.1

API -> http://localhost:5000
CLIENT -> http://localhost:4200
 

