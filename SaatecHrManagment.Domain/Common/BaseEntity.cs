using System;
using System.Collections.Generic;
using System.Text;

namespace SaatecHrManagment.Domain.Common
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime? DateCreated { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? DateModified { get; set; }
        public string? ModifiedBy { get; set; }
    }
}
