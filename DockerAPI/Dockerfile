# Get .Net Core SDK to build project
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app

# Copy the CSPROJ file and restore any dependencies (via NUGET)
COPY *.csproj ./
RUN dotnet restore

# Copy the project files and build our release
COPY . ./
RUN dotnet publish -c Release -o out

# Get .Net Core Runtime Library
# We don't include SDK .Net Core library into the docker image
# since it is not require for runtime, only for building
# Generate image 
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
EXPOSE 80
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "DockerAPI.dll"]

# Run this command to build Docker Image 
# docker build -t dockerid/dockerapi .

# Run this command to list Dockers Images on the PC
# docker images

# Run this command to start container
# docker run -p 8080:80 dockerid/dockerapi

# Run this command to stop container
# docker stop "IMAGEID"

# Run this command to push image to DockerHub
# docker push dockerid/dockerapi