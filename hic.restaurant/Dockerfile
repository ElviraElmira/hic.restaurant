FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["hic.restaurant/hic.restaurant.csproj", "hic.restaurant/"]
RUN dotnet restore "hic.restaurant/hic.restaurant.csproj"
COPY . .
WORKDIR "/src/hic.restaurant"
RUN dotnet build "hic.restaurant.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "hic.restaurant.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "hic.restaurant.dll"]