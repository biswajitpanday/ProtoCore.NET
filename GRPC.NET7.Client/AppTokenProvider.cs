﻿using GRPC.NET7.Proto;

namespace GRPC.NET7.Client;

public interface ITokenProvider
{
    Task<AuthenticationResponse> GetTokenAsync();
}

public class AppTokenProvider : ITokenProvider
{
    private AuthenticationResponse _token;
    public async Task<AuthenticationResponse> GetTokenAsync()
    {
        if (_token == null)
            _token = new AuthenticationResponse { AccessToken = "test", ExpiresIn = 300 };
        return _token;
    }
}