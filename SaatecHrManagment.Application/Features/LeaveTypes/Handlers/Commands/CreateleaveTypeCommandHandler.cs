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
    public class CreateleaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeRequest, int>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public CreateleaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }
        public async Task<int> Handle(CreateLeaveTypeRequest request, CancellationToken cancellationToken)
        {
            var validator = new CreateLeaveTypeDTOValidator();

            var check = await validator.ValidateAsync(request.CreateLeaveTypeDTO);
            
            if (!check.IsValid) throw new ValidationException(check);


            LeaveType item = _mapper.Map<LeaveType>(request.CreateLeaveTypeDTO);
            await _leaveTypeRepository.Add(item);
            return item.Id;

        }
    }
}
