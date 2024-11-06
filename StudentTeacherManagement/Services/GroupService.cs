using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.IdentityModel.Tokens;
using StudentTeacherManagement.Core.Interfaces;
using StudentTeacherManagement.Core.Models;
using StudentTeacherManagement.Storage;
using Microsoft.EntityFrameworkCore;
namespace StudentTeacherManagement.Services
{
    internal class GroupService : IGroupService
    {
        private readonly DataContext context;
        public GroupService(DataContext context)
        {
            this.context = context;
        }
        public async Task<Group> AddGroup(Group group, CancellationToken cancellationToken = default)
        {
            if (group == null)
                throw new ArgumentException("Group must not be null");
            await context.Groups.AddAsync(group, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
            return group;
        }
        public async Task AddStudentToGroup(Guid groupId, Guid studentId, CancellationToken cancellationToken = default)
        {
            var student = await context.Students.FindAsync(studentId);
            if (student == null)
                throw new NullReferenceException("Such student doesn't exist");
            var group = await context.Groups.FindAsync(groupId);
            if(group == null)
                throw new NullReferenceException("Such group doesn't exist");
            student.Group = group;
            await context.SaveChangesAsync(cancellationToken);
        }
        public async Task DeleteGroup(Guid id, CancellationToken cancellationToken = default)
        {
            var groups = context.Groups.AsQueryable();
            var group = groups.FirstOrDefault(g => g.Id == id);
            if (group == null)
                throw new ArgumentException("Such group doesn't exist");
            context.Groups.Remove(group);
            await context.SaveChangesAsync(cancellationToken);
        }
        public async Task<Group?> GetGroupById(Guid id, CancellationToken cancellationToken = default)
        {
            var groups = context.Groups.AsQueryable();
            var group = await groups.FirstOrDefaultAsync(g => g.Id == id);
            return group;
        }
        public async Task<IEnumerable<Group>> GetGroups(string? name, int skip, int take, CancellationToken cancellationToken = default)
        {
            var groups = context.Groups.AsQueryable();
            if(!string.IsNullOrEmpty(name))
            {
                groups = groups.Where(g => g.Name.Contains(name));
            }
            return await groups.OrderBy(g => g.Name)
                .Skip(skip)
                .Take(take)
                .ToArrayAsync(cancellationToken);
        }
    }
}
