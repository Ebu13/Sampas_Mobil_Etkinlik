# Temel imaj olarak .NET Core ASP.NET runtime kullanıyoruz
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

# Zaman dilimi ayarlarını yapıyoruz
RUN apt-get update && apt-get install -y tzdata \
    && ln -snf /usr/share/zoneinfo/Europe/Istanbul /etc/localtime \
    && echo "Europe/Istanbul" > /etc/timezone

# Port ayarlarını güncelliyoruz
EXPOSE 5262
EXPOSE 7218

# SDK imajı kullanarak uygulamayı derliyoruz
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Sampas_Mobil_Etkinlik.csproj", "./"]
RUN dotnet restore "Sampas_Mobil_Etkinlik.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "Sampas_Mobil_Etkinlik.csproj" -c Release -o /app/build

# Uygulamayı yayınlıyoruz
FROM build AS publish
RUN dotnet publish "Sampas_Mobil_Etkinlik.csproj" -c Release -o /app/publish

# Final aşamasında temel runtime imajını kullanarak uygulamayı çalıştırıyoruz
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Ortam değişkenlerini ayarlıyoruz
ENV ASPNETCORE_URLS=http://*:5262;https://*:7218
ENV ASPNETCORE_ENVIRONMENT=Development

ENTRYPOINT ["dotnet", "Sampas_Mobil_Etkinlik.dll"]
