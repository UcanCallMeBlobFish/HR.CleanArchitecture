using FluentValidation;
using SaatecHrManagment.Application.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaatecHrManagment.Application.DTOs.LeaveAllocation.Validator
{
    public class LeaveAllocationDtoValidator : AbstractValidator<LeaveAllocationDTO>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;

        public LeaveAllocationDtoValidator(ILeaveAllocationRepository leaveAllocationRepository)
        {
            _leaveAllocationRepository = leaveAllocationRepository;

            Include(new ILeaveAllocationDtoValidator(_leaveAllocationRepository));


        }
    }
}
