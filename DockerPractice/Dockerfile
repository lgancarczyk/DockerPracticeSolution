#FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
#WORKDIR /source
#
#COPY *.csproj ./
#RUN dotnet restore 
#
#COPY . ./
#RUN dotner publish -c Release -o out
#
#FROM mcr.microsoft.com/dotnet/aspnet:6.0
#WORKDIR /app
#EXPOSE 80
#COPY --from=build-env /app/out .
#ENTRYPOINT ["dotnet", "DockerPractice.dll"]
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /source

COPY . .
RUN dotnet restore "./DockerPractice.csproj" --disable-parallel
RUN dotnet publish "./DockerPractice.csproj" -c release -o /app --no-restore


FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app ./
EXPOSE 80

ENTRYPOINT ["dotnet", "DockerPractice.dll"]