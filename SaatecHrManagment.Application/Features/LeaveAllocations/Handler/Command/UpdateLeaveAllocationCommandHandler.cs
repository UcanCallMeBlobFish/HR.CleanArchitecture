using AutoMapper;
using MediatR;
using SaatecHrManagment.Application.DTOs.LeaveAllocation.Validator;
using SaatecHrManagment.Application.Exceptions;
using SaatecHrManagment.Application.Features.LeaveAllocations.Request.Command;
using SaatecHrManagment.Application.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SaatecHrManagment.Application.Features.LeaveAllocations.Handler.Command
{
    public class UpdateLeaveAllocationCommandHandler : IRequestHandler<UpdateLeaveAllocationCommand, Unit>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly IMapper _mapper;

        public UpdateLeaveAllocationCommandHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateLeaveAllocationDtoValidator(_leaveAllocationRepository);

            var check = await validator.ValidateAsync(request.UpdateLeaveAllocationDTO);

            if (!check.IsValid) throw new Exception();

            var item = await _leaveAllocationRepository.Get(request.UpdateLeaveAllocationDTO.Id);
            if (item is null) throw new ValidationException(check);
            else
            {
                _mapper.Map(request.UpdateLeaveAllocationDTO, item);
                await _leaveAllocationRepository.Update(item);
            }

            return Unit.Value;
        }
    }
}
