# IONOS Windows Hosting ASP.Net Core WebAPI

This is a sample project to demonstrate how to handle ASP.Net Core WebAPIs hosted with IONOS Windows Hosting.
There are some limitations:

## HTTP requests
HTTP requests are only allowed when using GET or POST. PUT/PATCH/DELETE/etc is denied.

## Proxy
When calling external HTTP requests, a proxy is required.
The proxy can be set globally.

```cs
#if !DEBUG
    System.Net.Http.HttpClient.DefaultProxy = new System.Net.WebProxy("http://winproxy.server.lan:3128");
#endif
```
[Source](https://www.ionos.de/hilfe/hosting/net/skript-beispiele-fuer-das-herstellen-externer-http-verbindungen-windows-hosting/)

## HTTPS redirect
HTTPS redirects can't be handled by ASP.Net Core.
```cs
public void Configure(IApplicationBuilder app)
{
    app.UseHttpsRedirection(); // this won't work
    [...]
}
```

Instead one should use an .htacces file like this:
```
RewriteEngine On
RewriteCond %{SERVER_PORT} !=443
RewriteRule ^(.*)$ https://%{HTTP_HOST}/$1 [R=301,L]
```

## Hosting Model InProcess is not supported
The default hosting model InProcess is not supported.
In the *.csproj file one should add the following line to use the  OutOfProcess hosting model.
```
<PropertyGroup>
    <AspNetCoreHostingModel>OutOfProcess</AspNetCoreHostingModel>
</PropertyGroup>
```

More information can be found in the [Help center](https://www.ionos.de/hilfe/hosting/net/einschraenkungen-bei-aspnet-anwendungen/)
