﻿using SaatecHrManagment.Application.Models.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SaatecHrManagment.Application.Persistence.IdentityContracts
{
    public interface IAuthService
    {
        Task<AuthResponse> Login(AuthRequest request);
        Task<RegistrationResponse> Register(RegistrationRequest request);
    }
}
