using HRLeaveOut.MVC.Contracts;
using HRLeaveOut.MVC.Services.Base;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.ComponentModel.DataAnnotations;

namespace HRLeaveOut.MVC.Services
{
    public class LeaveAllocationService : BaseHttpService, ILeaveAllocationService
    {
        public LeaveAllocationService(IClient client, ILocalStorageService localStorage) : base(client, localStorage)
        {
        }

        public async Task<int> CreateLeaveAllocations(int leaveTypeId)
        {
            try
            {
                var response = new Response<int>();
                CreateleaveAllocationDTO createLeaveAllocation = new() { LeaveTypeId = leaveTypeId };
                AddBearerToken();
                await _client.LeaveAllocationsPOSTAsync(createLeaveAllocation);
                
            }
            catch (ValidationException ex)
            {
                throw new ValidationException(ex.Message);
            }
            return leaveTypeId;
        }
    }
}
