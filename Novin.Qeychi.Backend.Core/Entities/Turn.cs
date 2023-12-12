using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novin.Qeychi.Backend.Core.Entities
{
    public class Turn : Thing
    {
        public required Customer Customer { get; set; }
        public required BeautySalon BeautySalon { get; set; }
        public required Stylist Stylist { get; set; }
        public required DateTime DateAndTime { get; set; }
        public required string OndemandService { get; set; }
        public required string Deposit { get; set; }
        public required bool IsPaid { get; set; }
        public required bool IsCancel {  get; set; }

    }
}
