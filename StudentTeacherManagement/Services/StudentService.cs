﻿using Microsoft.EntityFrameworkCore;
using StudentTeacherManagement.Core.Interfaces;
using StudentTeacherManagement.Core.Models;
using StudentTeacherManagement.Storage;
namespace StudentTeacherManagement.Services
{
    public class StudentService : IStudentService
    {
        private const int MinStudentAgeInYears = 4;
        private readonly DataContext _context;

        public StudentService(DataContext context)
        {
            _context = context;
        }

        public async Task<Student> AddStudent(Student student, CancellationToken cancellationToken = default)
        {
            ValidateStudent(student);
            _context.Add(student);
            await _context.SaveChangesAsync(cancellationToken);
            return student;
        }
        private void ValidateStudent(Student student)
        {
            if (string.IsNullOrEmpty(student.FirstName))
                throw new ArgumentException("FirstName must have value", nameof(student.FirstName));
            if (string.IsNullOrEmpty(student.LastName))
                throw new ArgumentException("FirstName must have value", nameof(student.LastName));
            if (student.DateOfBirth >= DateTime.Now.AddYears(-MinStudentAgeInYears))
                throw new ArgumentException("Date of birth must be greater", nameof(student.DateOfBirth));
        }

        public Task<Student?> GetStudentbyId(Guid id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Student>> GetStudents(int skip, int take, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Student> UpdateStudent(Guid id, Student student, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Student> UpdateStudent(Guid id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
