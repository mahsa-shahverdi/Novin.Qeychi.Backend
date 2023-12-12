using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novin.Qeychi.Backend.Core.Entities
{
    public class Customer : User
    {
        public required string City { get; set; }
        public DateTime? Birthdate { get; set; }
    }
}
