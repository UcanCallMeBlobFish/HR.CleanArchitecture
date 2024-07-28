using AutoMapper;
using MediatR;
using SaatecHrManagment.Application.DTOs.LeaveAllocation.Validator;
using SaatecHrManagment.Application.DTOs.LeaveRequest.Validators;
using SaatecHrManagment.Application.Exceptions;
using SaatecHrManagment.Application.Features.LeaveAllocations.Request.Command;
using SaatecHrManagment.Application.Persistence.Contracts;
using SaatecHrManagment.Application.Persistence.IdentityContracts;
using SaatecHrManagment.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SaatecHrManagment.Application.Features.LeaveAllocations.Handler.Command
{
    public class CreateLeaveAllocationCommandHandler : IRequestHandler<CreateLeaveAllocationCommand, int>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IUserService _userService;


        private readonly IMapper _mapper;

        public CreateLeaveAllocationCommandHandler(ILeaveAllocationRepository leaveAllocationRepository,
            IMapper mapper, ILeaveTypeRepository leaveTypeRepository, IUserService userService)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
            _userService = userService;
        }

        public async Task<int> Handle(CreateLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateLeaveAllocationDtoValidator(_leaveTypeRepository);

            var check = await validator.ValidateAsync(request.CreateleaveAllocationDTO);

            if (!check.IsValid) throw new ValidationException(check);

            var leaveType = await _leaveTypeRepository.Get(request.CreateleaveAllocationDTO.LeaveTypeId);
            var employees = await _userService.GetEmployees();
            var period = DateTime.Now.Year;
            var allocations = new List<LeaveAllocation>();
            foreach (var emp in employees)
            {
                if (await _leaveAllocationRepository.AllocationExists(emp.Id, leaveType.Id, period))
                    continue;
                allocations.Add(new LeaveAllocation
                {
                    EmployeeId = emp.Id,
                    LeaveTypeId = leaveType.Id,
                    NumberOfDays = leaveType.DefaultDays,
                    Period = period
                });
            }

            await _leaveAllocationRepository.AddAllocations(allocations);
            return 1;
        }
    }
}
