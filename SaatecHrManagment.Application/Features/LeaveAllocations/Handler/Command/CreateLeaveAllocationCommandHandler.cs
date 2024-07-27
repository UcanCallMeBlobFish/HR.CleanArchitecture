using AutoMapper;
using MediatR;
using SaatecHrManagment.Application.DTOs.LeaveAllocation.Validator;
using SaatecHrManagment.Application.DTOs.LeaveRequest.Validators;
using SaatecHrManagment.Application.Exceptions;
using SaatecHrManagment.Application.Features.LeaveAllocations.Request.Command;
using SaatecHrManagment.Application.Persistence.Contracts;
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
        private readonly IMapper _mapper;

        public CreateLeaveAllocationCommandHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateLeaveAllocationDtoValidator(_leaveAllocationRepository);

            var check = await validator.ValidateAsync(request.CreateleaveAllocationDTO);

            if (!check.IsValid) throw new ValidationException(check);

            var item = _mapper.Map<LeaveAllocation>(request.CreateleaveAllocationDTO);
            await _leaveAllocationRepository.Add(item);
            return item.Id;

        }
    }
}
