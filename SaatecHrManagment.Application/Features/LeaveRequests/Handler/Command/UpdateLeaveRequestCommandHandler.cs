using AutoMapper;
using MediatR;
using SaatecHrManagment.Application.DTOs.LeaveRequest.Validators;
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
    internal class UpdateLeaveRequestCommandHandler : IRequestHandler<UpdateLeaveRequestCommand, Unit>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;

        public UpdateLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateLeaveRequestCommand request, CancellationToken cancellationToken)
        {

            var validator = new UpdateLeaveRequestDtoValidator(_leaveRequestRepository);

            var check = await validator.ValidateAsync(request.UpdateLeaveRequestDTO);

            if (!check.IsValid) throw new ValidationException(check);

            var item = await _leaveRequestRepository.Get(request.UpdateLeaveRequestDTO.Id);

            if (item is null) throw new Exception();
            else _mapper.Map(request.UpdateLeaveRequestDTO, item);
            await _leaveRequestRepository.Update(item);
            return Unit.Value;
        }
    }
}
