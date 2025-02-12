﻿using Microsoft.Extensions.Options;
using ProtoBuf.Grpc;
using ProtoCore.NET.Api.Helpers;
using ProtoCore.NET.Proto;

namespace ProtoCore.NET.Api.Services;

public class AuthenticationHandler : IAuthenticationService
{
    private readonly IOptions<AppSettings> _appSettings;

    public AuthenticationHandler(IOptions<AppSettings> appSettings)
    {
        _appSettings = appSettings;
    }

    public Task<AuthenticationResponse> Authenticate(AuthenticationRequest request, CallContext context = default)
    {
        var authenticationResponse = JwtAuthenticationManager.Authenticate(_appSettings, request);
        if (authenticationResponse == null)
            throw new RpcException(new Status(StatusCode.Unauthenticated, "Invalid ProtoUserResponse Credentials"));
        return Task.FromResult(authenticationResponse);
    }
}