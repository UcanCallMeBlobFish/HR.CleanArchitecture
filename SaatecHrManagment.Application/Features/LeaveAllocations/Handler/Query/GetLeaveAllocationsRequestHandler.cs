using AutoMapper;
using MediatR;
using SaatecHrManagment.Application.DTOs.LeaveAllocation;
using SaatecHrManagment.Application.Features.LeaveAllocations.Request.Query;
using SaatecHrManagment.Application.Persistence.Contracts;
using SaatecHrManagment.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SaatecHrManagment.Application.Features.LeaveAllocations.Handler.Query
{
    public class GetLeaveAllocationsRequestHandler : IRequestHandler<GetLeaveAllocationsRequest, List<LeaveAllocationDTO>>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly IMapper _mapper;

        public GetLeaveAllocationsRequestHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
        }
        public async Task<List<LeaveAllocationDTO>> Handle(GetLeaveAllocationsRequest request, CancellationToken cancellationToken)
        {
            var items = await _leaveAllocationRepository.GetLeaveAllocationsWithDetails();
            return _mapper.Map<List<LeaveAllocationDTO>>(items);
        }
    }
}
