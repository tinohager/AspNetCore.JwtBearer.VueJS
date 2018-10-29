# ASP.NET Core Web Application with JwtBearer Authentication

A very simple example without any client side token cache. But you can store the token in the localstorage for example. `localStorage.setItem('token', token);`

The access credentials for this demo app

```
    User: test
Password: test
```

ASP.NET Core middleware that enables an application to receive an OpenID Connect bearer token
``
PM> Install-Package Microsoft.AspNetCore.Authentication.JwtBearer -Version 2.1.0
``

![object detection result](doc/Preview.png)
