using StudentTeacherManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentTeacherManagement.Core.Interfaces
{
    public interface IGroupService
    {
        Task<IEnumerable<Group>> GetGroups(string? name, int skip, int take, CancellationToken cancellationToken = default);
        Task<Group?> GetGroupById(Guid id, CancellationToken cancellationToken = default);
        Task<Group> AddGroup(Group group, CancellationToken cancellationToken = default);
        Task DeleteGroup(Guid id, CancellationToken cancellationToken = default);
        Task AddStudentToGroup(Guid groupId, Guid studentId, CancellationToken cancellationToken = default);
    }
}
