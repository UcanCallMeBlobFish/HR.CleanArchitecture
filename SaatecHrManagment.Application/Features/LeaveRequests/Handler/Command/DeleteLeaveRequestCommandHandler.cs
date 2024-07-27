using AutoMapper;
using MediatR;
using SaatecHrManagment.Application.Exceptions;
using SaatecHrManagment.Application.Features.LeaveRequests.Request.Command;
using SaatecHrManagment.Application.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SaatecHrManagment.Application.Features.LeaveRequests.Handler.Command
{
    public class DeleteLeaveRequestCommandHandler : IRequestHandler<DeleteLeaveRequestCommand, Unit>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;

        public DeleteLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var item = await _leaveRequestRepository.Get(request.Id);

            if (item is null) throw new NotFoundException(nameof(LeaveRequests), request.Id);
            else
                await _leaveRequestRepository.Delete(item);
            return Unit.Value;
        }
    }
}
