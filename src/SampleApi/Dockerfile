FROM microsoft/dotnet:1.0.0-core

# Copy the app
COPY . /app

# Set the Working Directory
WORKDIR /app

ENV ASPNETCORE_URLS http://*:80

# Start the app
ENTRYPOINT dotnet SampleApi.dll
