namespace HRLeaveOut.MVC.Contracts
{
    public interface ILeaveAllocationService
    {
        Task<int> CreateLeaveAllocations(int leavetypeid);
    }
}
