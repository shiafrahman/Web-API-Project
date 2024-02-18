using SchoolManagement.Models;
using SchoolManagement.Models.DTOs;

namespace SchoolManagement.Service
{
    public interface IStudentRepo
    {
        Task<TblStudent> CreateStudentAsync(string stdname, string phone, long dptId, string address);
        Task<TblStudent> UpdateStudentAsync(long id, string stdname, string phone, long dptId, string address);
        Task<StudentDto> GetStudentByIdAsync(long id);
        Task<List<StudentDto>> GetAllStudentAsync();
        Task DeleteDeleteAsync(long id);
    }
}
