## Simple Blogging Plataform ##

Simple blogging platform to managing blog posts and their associated comments

Monolithic application developed in 4 layers:
- API
- Application
- Domain
- Infrastructure

### Getting Started ###

Make sure you have installed docker in your environment.
Clone simple-blog repository and run the following command at the root of the project:

```
docker compose up
```

After the docker containers are created, enter the url http://localhost:8080/swagger/index.html to view the API documentation

### Next Steps ###
- Implement authentication and authorization with JWT tokens.
- Add unit and integration tests using xUnit.
- Deploy the application using Azure App Service (Web App for Containers) or a kubernates service.
- Configure a workflow with github actions to create the CI/CD pipeline.
- Add monitoring logs, health checks and performance metrics.
- Use some service (Azure Key Vault) to store sensitive data such as database password.
- Create docker images and docker compose yaml files specific to production and development.
    - For development, create a bind volume of the application and run it with the "dotnet watch run" command to speed up development.
    - For production, create the images with limited privilege users. A reverse proxy has been added to not expose the application directly, but it is not yet configured with ssl. So, add nginx configuration to run only with SSL and create an SSL certificate from a valid certification unit.
- Configure the .NET application to only work with ssl in the production environment and create production profiles in launchSettings.json to run in the production environment through Visual Studio.