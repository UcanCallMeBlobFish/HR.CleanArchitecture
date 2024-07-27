using FluentValidation;
using SaatecHrManagment.Application.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaatecHrManagment.Application.DTOs.LeaveRequest.Validators
{
    public class UpdateLeaveRequestDtoValidator:AbstractValidator<UpdateLeaveRequestDTO>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;

        public UpdateLeaveRequestDtoValidator(ILeaveRequestRepository leaveRequestRepository)
        {
            _leaveRequestRepository = leaveRequestRepository;
            Include(new ILeaveRequestDTOValidator(_leaveRequestRepository));
            RuleFor(p => p.Id).NotNull().WithMessage("{PropertyName} must present !!!");

        }
    }
}
