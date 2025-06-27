using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Exceptions
{
    public class EnrollmentNotFoundException : Exception
    {
        public EnrollmentNotFoundException(string message = "Question not found.") : base(message) { }
    }
}
