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
    TeaPot = 418,
    Error = 500,
    NotImplemented = 501,
}
