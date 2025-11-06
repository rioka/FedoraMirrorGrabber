FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["FedoraMirrorGrabber.App/FedoraMirrorGrabber.App.csproj", "FedoraMirrorGrabber.App/"]
COPY ["FedoraMirrorGrabber.Core/FedoraMirrorGrabber.Core.csproj", "FedoraMirrorGrabber.Core/"]
COPY ["Directory.Build.props", "Directory.Packages.props", "Nuget.config", ".editorconfig", "./"]
RUN dotnet restore "FedoraMirrorGrabber.App/FedoraMirrorGrabber.App.csproj"
COPY . .
WORKDIR "/src/FedoraMirrorGrabber.App"
RUN dotnet build "./FedoraMirrorGrabber.App.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
ARG TARGET_FRAMEWORK=net8.0
RUN dotnet publish "./FedoraMirrorGrabber.App.csproj" -f $TARGET_FRAMEWORK -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV FMG_FEDORA_RELEASE=42
ENV FMG_OUTPUTFILE="fedora.db"
ENV FMG_PROTOCOLS="http"
CMD ["sh", "-c", "dotnet FedoraMirrorGrabber.App.dll -r ${FMG_FEDORA_RELEASE} -o \"${FMG_OUTPUTFILE}\" -p \"${FMG_PROTOCOLS}\""]
