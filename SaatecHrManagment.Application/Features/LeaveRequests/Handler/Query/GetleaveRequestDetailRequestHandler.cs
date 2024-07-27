using AutoMapper;
using MediatR;
using SaatecHrManagment.Application.DTOs.LeaveRequest;
using SaatecHrManagment.Application.Features.LeaveRequests.Request.Query;
using SaatecHrManagment.Application.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SaatecHrManagment.Application.Features.LeaveRequests.Handler.Query
{
    public class GetleaveRequestDetailRequestHandler : IRequestHandler<GetleaveRequestDetailRequest, LeaveRequestDTO>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;

        public GetleaveRequestDetailRequestHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
        }

        public async Task<LeaveRequestDTO> Handle(GetleaveRequestDetailRequest request, CancellationToken cancellationToken)
        {
            var item = await _leaveRequestRepository.GetLeaveRequestWithDetails(request.Id);
            return _mapper.Map<LeaveRequestDTO>(item);
        }
    }
}
