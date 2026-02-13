using Dotnet_API_11_.Dtos.StudentDto;

namespace Dotnet_API_11_.Services.StudentService
{
    public interface IStudentService
    {
        Task<List<GetAllStudents>> GetAllStudentsAsync();
        Task<GetStudentByIdDto?> GetStudentByIdAsync(int id);
        Task<GetStudentByIdDto?> CreateStudentAsync(CreateStudentDto student);
        Task<bool> UpdateStudentAsync(int id,UpdateStudentDto student);
        Task<bool> DeleteStudentAsync(int id);

    }
}
