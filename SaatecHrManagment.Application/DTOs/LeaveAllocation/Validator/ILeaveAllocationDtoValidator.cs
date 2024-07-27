using FluentValidation;
using SaatecHrManagment.Application.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaatecHrManagment.Application.DTOs.LeaveAllocation.Validator
{
    public class ILeaveAllocationDtoValidator : AbstractValidator<ILeaveAllocationDTO>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;

        public ILeaveAllocationDtoValidator(ILeaveAllocationRepository leaveAllocationRepository)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            RuleFor(p => p.NumberOfDays).GreaterThan(0).WithMessage("{PropertyName} must be positive");
            RuleFor(p => p.Period).GreaterThan(0).WithMessage("{PropertyName} must be positive");
            RuleFor(p => p.LeaveTypeId).NotNull().
                MustAsync(async (id, token) =>
                {
                    var item = _leaveAllocationRepository.Get(id);
                    bool check = item != null;
                    return check;
                }
                ).WithMessage("{PropertyName} id must exist");

        }


    }
}
