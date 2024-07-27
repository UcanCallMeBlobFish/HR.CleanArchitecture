using AutoMapper;
using MediatR;
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

        public CreateLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper, IEmailSender sender)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
            _sender = sender;
        }
        public async Task<CustomResponser> Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
        {

            var response = new CustomResponser();
            var validator = new CreateLeaveRequestDTOValidator(_leaveRequestRepository);
            var check = await validator.ValidateAsync(request.CreateLeaveRequestDTO);

            if (!check.IsValid)
            {
                response.Success = false;
                response.Errors = check.Errors.Select(x => x.ErrorMessage).ToList();
                response.Message = " Create Request Failed!!!";

            }

            
            var item = _mapper.Map<LeaveRequest>(request.CreateLeaveRequestDTO);
            await _leaveRequestRepository.Add(item);

            response.Success = true;
            response.Message = "Creation succeed!";
            response.Id = item.Id;

            var email = new Email
            {
                To = "myemal@gmail.com",
                Body = $"Your leave request is done from {request.CreateLeaveRequestDTO.StartDate} to {request.CreateLeaveRequestDTO.EndDate}",
                Subject = "Leave request accepted"
            };
            try
            {
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
