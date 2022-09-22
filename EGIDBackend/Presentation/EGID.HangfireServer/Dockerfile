FROM mcr.microsoft.com/dotnet/core/runtime:3.1.5-buster-slim
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1.5-buster-slim
LABEL description="EGID Hangfire"
LABEL version="1.0"
LABEL maintainer="EGID Team"

ARG env

ENV ASPNETCORE_ENVIRONMENT=$env
WORKDIR /app
COPY . .

Expose 80 443

ENTRYPOINT ["dotnet", "EGID.HangfireServer.dll"]
