# Build and Push .NET API and Frontend Projects to GitHub Container Registry (GHCR) via CI/CD

## Overview

This repository demonstrates a CI/CD pipeline for .NET applications using GitHub Actions.  
It automatically builds and publishes Docker images for every `.csproj` project—primarily API and frontend components—to the GitHub Container Registry (GHCR) whenever changes are pushed or pull requests are opened against the `main` branch.

---

## Key Features

- **Automated Build:**  
  All .NET projects (API and frontend) are restored, built, and published in Release mode using .NET 8.
- **Containerization:**  
  A Dockerfile is dynamically generated for each published project, containerizing the app with the official ASP.NET 8.0 runtime image.
- **Image Publishing:**  
  Built images are automatically pushed to GHCR under your GitHub account or organization.
- **Continuous Integration & Delivery:**  
  The pipeline runs on every push and pull request to `main`.  
  This ensures your latest code is always available as a Docker image for deployment.

---

## Workflow Summary

The workflow is defined in [`.github/workflows/docker-image.yml`](.github/workflows/docker-image.yml) and consists of the following steps:

1. **Code Checkout:**  
   - Checks out the latest code.
2. **.NET Environment Setup:**  
   - Installs .NET 8 SDK.
3. **Build & Publish Projects:**  
   - Restores dependencies, builds, and publishes each project.
   - Generates Dockerfiles for each published output.
   - Builds Docker images and pushes them to GHCR.

---

## Limitations & Next Steps

- **Testing Not Implemented:**  
  Automated testing is **not** included in the pipeline.  
  > *Reason:* The application's test coverage and structure are currently insufficient and require further development.  
  > *Future improvement:* Once tests are defined and implemented, a test job can be added to the workflow to ensure code quality before building and publishing containers.

- **No Database Containerization:**  
  The workflow **does not build or include a Dockerized database** (such as SQL Server, PostgreSQL, etc.).  
  > *Reason:* The current implementation is focused only on the API and frontend projects.  
  > *Future improvement:* Add a database service/container to the workflow for more complete local development and deployment environments.

- **Images Built for API and Frontend Only:**  
  Only API and frontend projects are detected, built, and published.  
  Database or other supporting services are **not** included in this pipeline.

---

## Example: Dockerfile Template

Every published project receives a Dockerfile like:

```dockerfile
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
COPY . ./
EXPOSE 8080
ENTRYPOINT ["dotnet", "YourProject.dll"]
```

---

## Example: Pushed Image Naming

Images are named as follows:

```
ghcr.io/<owner>/<project>:latest
```

Where:
- `<owner>` is your GitHub username or organization (lowercase)
- `<project>` is the name of the `.csproj` (lowercase)

---

## How to Use the Published Images

After the workflow completes, you can run your containerized application using:

```sh
docker pull ghcr.io/<owner>/<project>:latest
docker run -p 8080:8080 ghcr.io/<owner>/<project>:latest
```

---

## Security and Secrets

- The workflow uses a secret (`MY_SECRET_TOKEN`) to authenticate to GHCR.
- Be sure to add this secret in your GitHub repository settings.

---

## Why is This Valuable?

- **Scalable:** Supports multiple .NET projects in one repository.
- **Portable:** Applications are ready to run anywhere Docker is supported.
- **Professional:** Demonstrates DevOps practices with automated builds and container publishing.

---

## Improvements to Consider

- **Define and implement automated tests for all projects.**
- **Integrate a database container into the CI/CD pipeline for local development and deployment.**
- **Add additional jobs for code analysis, security scanning, or multi-stage builds as needed.**

---

