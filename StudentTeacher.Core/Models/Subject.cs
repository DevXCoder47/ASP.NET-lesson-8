using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentTeacherManagement.Core.Models
{
    public class Subject
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Hours { get; set; }
    }
}
