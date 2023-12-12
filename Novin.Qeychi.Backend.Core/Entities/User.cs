using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novin.Qeychi.Backend.Core.Entities
{
    public class User : Thing
    {
        public required string MobileNumber { get; set; }
        public required string Name { get; set; }
        public required string AccessLevel { get; set; }
    }
}
