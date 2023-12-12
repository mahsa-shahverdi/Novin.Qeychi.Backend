using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novin.Qeychi.Backend.Core.Entities
{
    public class Stylist : User
    {
        public required string Profession { get; set; }
    }
}
