using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentTeacherManagement.Core.Models
{
    public class Student : User
    {
        public DateTime EnrolledAt { get; set; }
        public virtual Group? Group { get; set; }
    }
}
