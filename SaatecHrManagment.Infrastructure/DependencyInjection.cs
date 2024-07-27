using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SaatecHrManagment.Application.Models;
using SaatecHrManagment.Application.Persistence.Contracts;
using SaatecHrManagment.Application.Persistence.Infrastructure;
using SaatecHrManagment.Infrastructure.Email;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaatecHrManagment.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
            services.AddTransient<IEmailSender, EmailSender>();



            return services;
        }

    }
}
