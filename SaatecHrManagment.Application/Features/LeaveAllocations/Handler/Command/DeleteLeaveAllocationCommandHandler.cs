using AutoMapper;
using MediatR;
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
    public class DeleteLeaveAllocationCommandHandler : IRequestHandler<DeleteLeaveAllocationCommand, Unit>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly IMapper _mapper;

        public DeleteLeaveAllocationCommandHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(DeleteLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            var item = await _leaveAllocationRepository.Get(request.Id);
            if (item == null) throw new NotFoundException(nameof(LeaveTypes), request.Id);
            else
                await _leaveAllocationRepository.Delete(item);
            return Unit.Value;
        }
    }
}
