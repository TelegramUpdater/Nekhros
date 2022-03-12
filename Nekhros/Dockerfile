#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Nekhros/Nekhros.csproj", "Nekhros/"]
RUN dotnet restore "Nekhros/Nekhros.csproj"
COPY . .
WORKDIR "/src/Nekhros"
RUN dotnet build "Nekhros.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Nekhros.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Nekhros.dll"]