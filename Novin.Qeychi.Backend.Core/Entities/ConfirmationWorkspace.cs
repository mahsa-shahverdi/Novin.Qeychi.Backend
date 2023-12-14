using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novin.Qeychi.Backend.Core.Entities
{
    public class ConfirmationWorkspace : Thing
    {
        public required string BusinessLicenseId { get; set; }
        public required Entrepreneur Entrepreneur { get; set; }
        public required BeautySalon BeautySalon { get; set; }
        public required byte[] ImgForBusinessLicense { get; set; }
        public required byte[] ImgForEntrepreneurNationalCard { get; set; }
        public required byte[] ImgForOwnershipDocumentOrLease { get; set; }
        public required bool IsVerify { get; set; }
        public required Uri LinkOfExclusivePanel { get; set; }
    }
}
