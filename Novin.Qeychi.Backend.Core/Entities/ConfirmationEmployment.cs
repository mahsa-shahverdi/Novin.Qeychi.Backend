using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novin.Qeychi.Backend.Core.Entities
{
    public class ConfirmationEmployment : Thing
    {
        public required BeautySalon BeautySalon { get; set; }
        public required Stylist Stylist { get; set; }

    }
}
