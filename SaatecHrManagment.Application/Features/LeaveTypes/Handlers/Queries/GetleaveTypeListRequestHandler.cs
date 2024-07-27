using AutoMapper;
using MediatR;
using SaatecHrManagment.Application.DTOs.LeaveType;
using SaatecHrManagment.Application.Features.LeaveTypes.Requests.Query;
using SaatecHrManagment.Application.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SaatecHrManagment.Application.Features.LeaveTypes.Handlers.Queries
{
    public class GetleaveTypeListRequestHandler : IRequestHandler<GetLeaveTypeListRequest, List<LeaveTypeDTO>>
    {
        private readonly ILeaveTypeRepository _leaveRepository;
        private readonly IMapper _mapper;

        public GetleaveTypeListRequestHandler(ILeaveTypeRepository leaveRepository, IMapper mapper)
        {
            _leaveRepository = leaveRepository;
            _mapper = mapper;
        }

        public async Task<List<LeaveTypeDTO>> Handle(GetLeaveTypeListRequest request, CancellationToken cancellationToken)
        {
            var items = await _leaveRepository.GetAll();

            return _mapper.Map<List<LeaveTypeDTO>>(items);

        }
    }
}
