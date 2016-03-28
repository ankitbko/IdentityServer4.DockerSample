FROM microsoft/aspnet:1.0.0-rc1-update1-coreclr

COPY . /app
WORKDIR /app/approot

EXPOSE PORT
ENTRYPOINT ["./web"]