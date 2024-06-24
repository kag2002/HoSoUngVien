FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR /src
COPY ["src/HoSoUngVien.Web.Host/HoSoUngVien.Web.Host.csproj", "src/HoSoUngVien.Web.Host/"]
COPY ["src/HoSoUngVien.Web.Core/HoSoUngVien.Web.Core.csproj", "src/HoSoUngVien.Web.Core/"]
COPY ["src/HoSoUngVien.Application/HoSoUngVien.Application.csproj", "src/HoSoUngVien.Application/"]
COPY ["src/HoSoUngVien.Core/HoSoUngVien.Core.csproj", "src/HoSoUngVien.Core/"]
COPY ["src/HoSoUngVien.EntityFrameworkCore/HoSoUngVien.EntityFrameworkCore.csproj", "src/HoSoUngVien.EntityFrameworkCore/"]
WORKDIR "/src/src/HoSoUngVien.Web.Host"
RUN dotnet restore 

WORKDIR /src
COPY ["src/HoSoUngVien.Web.Host", "src/HoSoUngVien.Web.Host"]
COPY ["src/HoSoUngVien.Web.Core", "src/HoSoUngVien.Web.Core"]
COPY ["src/HoSoUngVien.Application", "src/HoSoUngVien.Application"]
COPY ["src/HoSoUngVien.Core", "src/HoSoUngVien.Core"]
COPY ["src/HoSoUngVien.EntityFrameworkCore", "src/HoSoUngVien.EntityFrameworkCore"]
WORKDIR "/src/src/HoSoUngVien.Web.Host"
RUN dotnet publish -c Release -o /publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:7.0
EXPOSE 80
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "HoSoUngVien.Web.Host.dll"]
