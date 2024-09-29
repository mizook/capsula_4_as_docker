# Utilizar la imagen oficial de .NET SDK como etapa de construcción
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copiar los archivos csproj y restaurar las dependencias
COPY *.csproj ./
RUN dotnet restore

# Copiar el resto de los archivos y construir la aplicación
COPY . ./
RUN dotnet publish -c Release -o out

# Utilizar la imagen de runtime de .NET
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/out ./

# Establecer la variable de entorno para que Kestrel escuche en todas las interfaces
ENV ASPNETCORE_URLS=http://+:5000

# Crear el directorio para la base de datos
RUN mkdir -p /app/db

# Exponer el puerto en el que la API escuchará
EXPOSE 5000

# Comando para ejecutar la aplicación
ENTRYPOINT ["dotnet", "MonolithicApi.dll"]
