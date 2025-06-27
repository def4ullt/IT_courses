using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Exceptions
{
    public class CourseNotFoundException : Exception
    {
        public CourseNotFoundException(string message = "Course not found.") : base(message) { }
    }
}
