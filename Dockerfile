FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["RecipeBook.Api/RecipeBook.Api.csproj", "RecipeBook.Api/"]
RUN dotnet restore "RecipeBook.Api/RecipeBook.Api.csproj"
COPY . .
WORKDIR "/src/RecipeBook.Api"
RUN dotnet build "RecipeBook.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RecipeBook.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RecipeBook.Api.dll"]