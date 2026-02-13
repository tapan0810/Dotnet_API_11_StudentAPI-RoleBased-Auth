using Dotnet_API_11_.Data;
using Dotnet_API_11_.Dtos.StudentDto;
using Dotnet_API_11_.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dotnet_API_11_.Services.StudentService
{
    public class StudentService(StudentAuthDbContext _context) : IStudentService
    {
        public async Task<GetStudentByIdDto?> CreateStudentAsync(CreateStudentDto student)
        {
            if (student is null)
                return null;

            var stud = new Student
            {
                StudentName = student.StudentName,
                Email = student.Email,
                PhoneNumber = student.PhoneNumber,
                Description = student.Description
            };

            _context.Students.Add(stud);
            await _context.SaveChangesAsync();

            return new GetStudentByIdDto
            {
                Id = stud.Id,
                StudentName = stud.StudentName,
                Email = stud.Email,
                PhoneNumber = stud.PhoneNumber,
                Description = stud.Description
            };
        }

        public async Task<bool> DeleteStudentAsync(int id)
        {
            var stud = await _context.Students.FirstOrDefaultAsync(x=> x.Id == id);

            if(stud is null)
                return false;

            _context.Students.Remove(stud);
            await _context.SaveChangesAsync();

            return true;

        }

        public async Task<List<GetAllStudents>> GetAllStudentsAsync()
        {
            return await _context.Students.Select(
                s => new GetAllStudents
                {
                    Id = s.Id,
                    StudentName = s.StudentName
                }).ToListAsync();
        }

        public async Task<GetStudentByIdDto?> GetStudentByIdAsync(int id)
        {
            return await _context.Students
                .Where(x => x.Id == id)
                .Select(
                s => new GetStudentByIdDto
                {
                    Id = s.Id,
                    StudentName = s.StudentName,
                    Email = s.Email,
                    PhoneNumber = s.PhoneNumber,
                    Description = s.Description
                }).FirstOrDefaultAsync();

        }

        public async Task<bool> UpdateStudentAsync(int id,UpdateStudentDto student)
        {
           var stud = await _context.Students.FirstOrDefaultAsync(x => x.Id == id);

            if(stud is null) return false;

            if (student is null)
                return false;

            stud.StudentName = student.StudentName;
            stud.Email = student.Email;
            stud.PhoneNumber = student.PhoneNumber;
            stud.Description = student.Description;

            await _context.SaveChangesAsync();

            return true;

        }
    }
}
