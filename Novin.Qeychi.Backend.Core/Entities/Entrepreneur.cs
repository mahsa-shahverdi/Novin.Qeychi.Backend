using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novin.Qeychi.Backend.Core.Entities
{
    public class Entrepreneur : User
    {
        public required string NationalCode { get; set; }
        public required string Address { get; set; }
    }
}
