FROM microsoft/dotnet:latest
RUN mkdir -p /app
COPY . /app
WORKDIR /app

RUN dotnet restore
RUN dotnet build

EXPOSE 5000/tcp
ENV ASPNETCORE_URLS http://*:5000

CMD ["dotnet", "run"]