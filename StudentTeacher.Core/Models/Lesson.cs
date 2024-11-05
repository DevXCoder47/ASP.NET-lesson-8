using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentTeacherManagement.Core.Models
{
    public class Lesson
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public virtual Teacher Teacher{ get; set;}
        public virtual Subject Subject { get; set; }
        public virtual Group Group { get; set; }
    }
}
