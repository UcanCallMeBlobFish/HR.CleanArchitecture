using SaatecHrManagment.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SaatecHrManagment.Application.Persistence.Infrastructure
{
    public interface IEmailSender
    {
        Task<bool> SendEmail(Email email);

    }
}
