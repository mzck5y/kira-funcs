FROM mcr.microsoft.com/dotnet/runtime-deps:5.0-alpine3.12-amd64 AS base
WORKDIR /app

FROM mzck5y/oni-deps:latest AS nugget

FROM mcr.microsoft.com/dotnet/sdk:5.0-alpine3.12-amd64 AS build
WORKDIR /src
COPY ["*.csproj", "."]
COPY --from=nugget ./nuget.config ./
RUN dotnet restore
COPY . .
WORKDIR "/src/."
RUN dotnet build -c Release -o /app/build

FROM build AS publish
RUN dotnet publish -c Release -o /app/publish -p:PublishSingleFile=true -r linux-musl-x64 --self-contained true

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENV NATS_URL="nats://nats-event-server:4222"
ENV FUNCTION_ROUTE_PREFIX="api"
ENV FUNCTION_METRICS_ENDPONT="/metrics"

EXPOSE 80

ENTRYPOINT ["./kira.functions.createprovider.dll"]