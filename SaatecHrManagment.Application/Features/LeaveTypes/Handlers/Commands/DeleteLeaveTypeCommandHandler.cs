using AutoMapper;
using MediatR;
using SaatecHrManagment.Application.DTOs.LeaveType.Validations;
using SaatecHrManagment.Application.Exceptions;
using SaatecHrManagment.Application.Features.LeaveTypes.Requests.Command;
using SaatecHrManagment.Application.Persistence.Contracts;
using SaatecHrManagment.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SaatecHrManagment.Application.Features.LeaveTypes.Handlers.Commands
{
    public class DeleteLeaveTypeCommandHandler : IRequestHandler<DeleteLeaveTypeCommand, Unit>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public DeleteLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(DeleteLeaveTypeCommand request, CancellationToken cancellationToken)
        {


            var item = await _leaveTypeRepository.Get(request.Id);

            if (item == null) throw new NotFoundException(nameof(LeaveType), request.Id);
            else
                await _leaveTypeRepository.Delete(item);

            return Unit.Value;
        }
    }
}
