FROM mcr.microsoft.com/dotnet/core/sdk:3.1 as build
ARG version
RUN echo "version = ${version}"
WORKDIR /src
COPY ./TestClient ./TestClient
WORKDIR /src/TestClient
RUN dotnet restore -nowarn:msb3202,nu1503
RUN dotnet build -c Debug -o /app

# FROM ubuntu:20.04 as uibuild
# ARG version
# RUN echo "version = ${version}"
# RUN apt-get update
# RUN apt-get install curl -y
# RUN curl -sL https://deb.nodesource.com/setup_12.x | bash -
# RUN apt-get install -y nodejs
# WORKDIR /src
# COPY ./TestClient/UI/login .
# RUN echo "${version}" > ./src/assets/version.txt 
# RUN npm install
# RUN npm run build

FROM build AS publish
RUN dotnet publish -c Release -o /app
COPY ./TestClient/localhost.conf /app/localhost.conf
COPY ./TestClient/UI /app/UI

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 as final
# COPY --from=uibuild /src/dist/login /TestClient/wwwroot
COPY --from=publish /app /TestClient
# COPY --from=build /src/TestClient/UI /TestClient/UI
RUN openssl req -new -x509 -nodes -days 365 -newkey rsa:2048 -keyout /TestClient/localhost.key -out /TestClient/localhost.crt -config /TestClient/localhost.conf -subj '/CN=www.mydom.com/O=My Company Name LTD./C=US'
RUN openssl pkcs12 -export -out /TestClient/localhost.pfx -inkey /TestClient/localhost.key -in /TestClient/localhost.crt --password pass:TestClient
RUN openssl verify -CAfile /TestClient/localhost.crt /TestClient/localhost.crt
RUN cp /TestClient/localhost.crt /usr/local/share/ca-certificates
RUN update-ca-certificates
RUN openssl verify /TestClient/localhost.crt
