using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novin.Qeychi.Backend.Core.Entities
{
    public class BeautySalon : Thing
    {
        public required string Title { get; set; }
        public required string City { get; set; }
        public required string Address { get; set; }
        public required string PhoneNumber { get; set; }
        public required bool IsActive { get; set; }
        public required decimal Rating { get; set; }
    }
}
