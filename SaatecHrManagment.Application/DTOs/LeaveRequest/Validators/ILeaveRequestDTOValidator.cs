using FluentValidation;
using SaatecHrManagment.Application.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaatecHrManagment.Application.DTOs.LeaveRequest.Validators
{
    public class ILeaveRequestDTOValidator : AbstractValidator<ILeaveRequestDTO>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;

        public ILeaveRequestDTOValidator(ILeaveRequestRepository leaveRequestRepository)
        {
            _leaveRequestRepository = leaveRequestRepository;

            RuleFor(p => p.StartDate)
                .LessThan(p => p.EndDate)
                .WithMessage("{PropertyName} must be before {ComparisonValue}");

            RuleFor(p => p.EndDate)
                .GreaterThan(p => p.StartDate)
                .WithMessage("{PropertyName} must be after {ComparisonValue}");

            RuleFor(p => p.LeaveTypeId)
                .GreaterThan(0)
            .MustAsync(async (id, token) => {
                var item = await _leaveRequestRepository.Get(id);
                bool check = item != null;
                    return check;
                })
                .WithMessage("{PropertyName} does not exist.");
        }
    }
}
