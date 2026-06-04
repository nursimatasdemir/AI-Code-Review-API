FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080


FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/AiCodeReview.API/AiCodeReview.API.csproj", "src/AiCodeReview.API/"]
COPY ["src/AiCodeReview.Infrastructure/AiCodeReview.Infrastructure.csproj", "src/AiCodeReview.Infrastructure/"]
COPY ["src/AiCodeReview.Application/AiCodeReview.Application.csproj", "src/AiCodeReview.Application/"]
COPY ["src/AiCodeReview.Domain/AiCodeReview.Domain.csproj", "src/AiCodeReview.Domain/"]
RUN dotnet restore "src/AiCodeReview.API/AiCodeReview.API.csproj"
COPY . .
WORKDIR "/src/src/AiCodeReview.API"
RUN dotnet build "AiCodeReview.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "AiCodeReview.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AiCodeReview.API.dll"]
