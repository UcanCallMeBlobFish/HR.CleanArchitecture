using FluentValidation;
using SaatecHrManagment.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaatecHrManagment.Application.DTOs.LeaveType.Validations
{
    public class UpdateLeaveTypeDTOValidator : AbstractValidator<LeaveTypeDTO>
    {
        public UpdateLeaveTypeDTOValidator()
        {
            Include(new ILeaveTypeDtoValidator());

            RuleFor(p => p.Id).NotNull().WithMessage("{PropertyName} must not be null since its pk.");
        }
    }
}
