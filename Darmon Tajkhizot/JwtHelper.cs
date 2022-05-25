using System;

public static class JwtHelper
{
    // Generates a random string (token)
    public static string GetRandomString()
    {
        // Base 64 encoded guid
        return Encode();
    }
    public static string Encode()
    {
        return Encode(Guid.NewGuid());
    }

    private static string Encode(Guid guid)
    {
        return Convert.ToBase64String(guid.ToByteArray()).Replace("/", "_").Replace("+", "-")[..22];
    }

}
