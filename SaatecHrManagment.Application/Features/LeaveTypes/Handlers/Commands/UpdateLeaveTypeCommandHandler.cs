using AutoMapper;
using MediatR;
using SaatecHrManagment.Application.DTOs.LeaveType.Validations;
using SaatecHrManagment.Application.Exceptions;
using SaatecHrManagment.Application.Features.LeaveTypes.Requests.Command;
using SaatecHrManagment.Application.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SaatecHrManagment.Application.Features.LeaveTypes.Handlers.Commands
{
    public class UpdateLeaveTypeCommandHandler : IRequestHandler<UpdateLeaveTypeCommand, Unit>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public UpdateLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateLeaveTypeDTOValidator();

            var check = await validator.ValidateAsync(request.LeaveTypeDTO);

            if (!check.IsValid) throw new ValidationException(check);

            var item = await _leaveTypeRepository.Get(request.LeaveTypeDTO.Id);

            _mapper.Map(request.LeaveTypeDTO, item);

            await _leaveTypeRepository.Update(item);

            return Unit.Value;

        }
    }
}
