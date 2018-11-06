#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM microsoft/dotnet:2.1-aspnetcore-runtime-nanoserver-1803 AS base
WORKDIR /app
EXPOSE 56380
EXPOSE 44316

FROM microsoft/dotnet:2.1-sdk-nanoserver-1803 AS build
WORKDIR /src
COPY ["Auth.Web/Auth.Web.csproj", "Auth.Web/"]
RUN dotnet restore "Auth.Web/Auth.Web.csproj"
COPY . .
WORKDIR "/src/Auth.Web"
RUN dotnet build "Auth.Web.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Auth.Web.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Auth.Web.dll", "--environment=Development"]