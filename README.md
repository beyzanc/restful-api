# Patika.dev & Sipay .NET Bootcamp #Week 2: RESTful API Task Management System

This project implements a simple RESTful API using ASP.NET Core. The API provides functionalities to manage missions and includes various middleware components to handle logging, global exceptions, and user authorization.

## Features

- **Fake Services with Dependency Injection:** The project uses fake services, IMissionService and IUserService, with dependency injection to manage missions and handle user authentication.
- **Custom Date Format Extension:** An extension, CustomDateFormatExtension, is developed to format mission deadlines in a custom date format.
- **Global Logging Middleware:** The LogMiddleware is implemented to log incoming requests and outgoing responses at a basic level.
- **User Authorization with Custom Attribute:** The UserAuthorize custom attribute is used to check user authentication before accessing certain API endpoints.
- **Global Exception Handling Middleware:** The ExceptionMiddleware is designed to capture and return JSON-formatted error messages for all exceptions that occur within the application.

## API Endpoints

- **GET /api/missions:** Retrieves a list of all missions.
- **GET /api/missions/{id}:** Fetches a specific mission by its ID.
- **POST /api/missions/login:** Performs a fake user login to access protected endpoints.

## Extensions

### Custom Date Format Extension

The CustomDateFormatExtension provides an extension method for the **Mission** class to convert its **Deadline** property to a custom date format **(d MMMM yyyy)**.

```
public static string ToCustomDateFormat(this Mission mission)
{
    return mission.Deadline.ToString("d MMMM yyyy");
}
```

## Middleware

### Global Logging Middleware

The LogMiddleware logs incoming requests and outgoing responses at a basic level. The log message includes the timestamp, HTTP method, and request path.

### Global Exception Handling Middleware

The ExceptionMiddleware captures any exceptions that occur during API requests and returns a JSON-formatted error message containing the exception's message.
