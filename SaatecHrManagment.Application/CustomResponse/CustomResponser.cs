using System;
using System.Collections.Generic;
using System.Text;

namespace SaatecHrManagment.Application.CustomResponse
{
    public class CustomResponser
    {
        /// <summary>
        /// just for demonstration I used customeresponser for LeaveRequest -> handler -> command -> createleaverequesthandler.
        /// Actually there is no need for custom response at that moment, it just make project more complicated.
        /// </summary>
        public int Id { get; set; }
        public bool Success { get; set; } = true;
        public string Message { get; set; }
        public List<string> Errors { get; set; }
    }
}
