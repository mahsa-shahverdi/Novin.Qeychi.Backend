using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novin.Qeychi.Backend.Core.Exceptions
{
    public class InvalidUsernameException : Exception
    {
        public InvalidUsernameException()
            :base("نام کاربری غیرمجاز") 
        {
            
        }
    }
}
