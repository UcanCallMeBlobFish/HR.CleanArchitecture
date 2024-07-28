using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using SaatecHrManagment.Application.CustomResponse;
using SaatecHrManagment.Application.DTOs.LeaveRequest.Validators;
using SaatecHrManagment.Application.DTOs.LeaveType.Validations;
using SaatecHrManagment.Application.Exceptions;
using SaatecHrManagment.Application.Features.LeaveRequests.Request.Command;
using SaatecHrManagment.Application.Models;
using SaatecHrManagment.Application.Persistence.Contracts;
using SaatecHrManagment.Application.Persistence.Infrastructure;
using SaatecHrManagment.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SaatecHrManagment.Application.Features.LeaveRequests.Handler.Command
{
    public class CreateLeaveRequestCommandHandler : IRequestHandler<CreateLeaveRequestCommand, CustomResponser>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;
        private readonly IEmailSender _sender;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;

        public CreateLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper, IEmailSender sender, ILeaveAllocationRepository leaveAllocationRepository)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
            _sender = sender;
            _leaveAllocationRepository = leaveAllocationRepository;
        }
        public async Task<CustomResponser> Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
        {

            var response = new CustomResponser();
            var validator = new CreateLeaveRequestDTOValidator(_leaveRequestRepository);
            var check = await validator.ValidateAsync(request.CreateLeaveRequestDTO);
            var userId = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(
                   q => q.Type == "uid")?.Value;



            var allocation = await _leaveAllocationRepository.GetUserAllocations(userId, request.CreateLeaveRequestDTO.LeaveTypeId);
            int daysRequested = (int)(request.CreateLeaveRequestDTO.EndDate - request.CreateLeaveRequestDTO.StartDate).TotalDays;
           
            if (daysRequested > allocation.NumberOfDays)
            {
                check.Errors.Add(new FluentValidation.Results.ValidationFailure(
                    nameof(request.CreateLeaveRequestDTO.EndDate), "You do not have enough days for this request"));
            }
            if (!check.IsValid)
            {
                response.Success = false;
                response.Errors = check.Errors.Select(x => x.ErrorMessage).ToList();
                response.Message = " Create Request Failed!!!";

            }

            
            var leaveRequest = _mapper.Map<LeaveRequest>(request.CreateLeaveRequestDTO);
            leaveRequest.RequestingEmployeeId = userId;
            await _leaveRequestRepository.Add(leaveRequest);

            response.Success = true;
            response.Message = "Creation succeed!";
            response.Id = leaveRequest.Id;
            
            try
            {

                var emailAddress = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Email).Value;

                var email = new Email
                {
                    To = emailAddress,
                    Body = $"Your leave request is done from {request.CreateLeaveRequestDTO.StartDate} to {request.CreateLeaveRequestDTO.EndDate}",
                    Subject = "Leave request accepted"
                };
                await _sender.SendEmail(email);

            }
            catch (Exception ex)
            {
                //some logic here.
            }
            return response;
        }
    }
}
