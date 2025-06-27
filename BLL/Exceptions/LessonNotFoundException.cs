using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Exceptions
{
    public class LessonNotFoundException : Exception
    {
        public LessonNotFoundException(string message = "Result not found.") : base(message) { }
    }
}
