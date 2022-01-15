namespace Faab.Crops;

public enum CropStatus
{
    Ok = 200,
    Created = 201,
    Accepted = 202,
    BadRequest = 400,
    Unauthenticated = 401,
    Unauthorized = 403,
    NotFound = 404,
    Timeout = 408,
    Conflict = 409,
    Teapot = 418,
    TooManyRequests = 429,
    Error = 500,
    NotImplemented = 501,
    NotAvailable = 503,
}