﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SaatecHrManagment.Application.Persistence.Contracts;
using SaatecHrManagment.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace SaatecHrManagment.Persistence
{
   
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection AddPersistenceService(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<SaatecDbContext>(options =>
                 options.UseInMemoryDatabase("InMemoryDatabase"));


            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddScoped<ILeaveTypeRepository, LeaveTypeRepository>();
            services.AddScoped<ILeaveRequestRepository, LeaveRequestRepository>();
            services.AddScoped<ILeaveAllocationRepository, LeaveAllocationRepository>();

            return services;
        }

    }
}
