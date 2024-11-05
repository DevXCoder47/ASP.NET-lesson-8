using StudentTeacherManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentTeacherManagement.Core.Interfaces
{
    public interface IStudentService
    {
        Task<IEnumerable<Student>> GetStudents(int skip, int take, CancellationToken cancellationToken = default);
        Task<Student?> GetStudentbyId(Guid id, CancellationToken cancellationToken = default);
        Task<Student> AddStudent(Student student, CancellationToken cancellationToken = default);
        Task<Student> UpdateStudent(Guid id, Student student, CancellationToken cancellationToken = default);
        Task<Student> UpdateStudent(Guid id, CancellationToken cancellationToken = default);
    }
}
