#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["PersonalClassroom.Web/PersonalClassroom.Web.csproj", "PersonalClassroom.Web/"]
COPY ["NuGet.config",""]
RUN dotnet restore "PersonalClassroom.Web/PersonalClassroom.Web.csproj"  --configfile "./NuGet.config"
COPY . .
WORKDIR "/src/PersonalClassroom.Web"
RUN dotnet build "PersonalClassroom.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PersonalClassroom.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PersonalClassroom.Web.dll"]