FROM microsoft/dotnet:1.0.0-core

# Copy the app
COPY . /app

# Set the Working Directory
WORKDIR /app

# Configure the listening port to 80
ENV ASPNETCORE_URLS http://*:80

# Start the app
ENTRYPOINT dotnet IdSvrHost.dll
