namespace CS_First_HTTP_Client;

public readonly record struct Login(string email, string password);

public readonly record struct ErrorResponse(string type, string error);

public readonly record struct AuthResponse(string userId, string jwt, DateTime expires, string refreshToken);

public readonly record struct users()