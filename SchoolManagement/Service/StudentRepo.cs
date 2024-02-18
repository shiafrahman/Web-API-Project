using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SchoolManagement.Models;
using SchoolManagement.Models.DTOs;

namespace SchoolManagement.Service
{
    public class StudentRepo : IStudentRepo
    {
        private readonly FgfgContext _db;

        public StudentRepo(FgfgContext db)
        {
            _db = db;
        }

        public async Task<TblStudent> CreateStudentAsync(string stdname, string phone, long dptId, string address)
        {

            var std = new TblStudent
            {
                StudentName = stdname,
                PhoneNumber = phone,
                DepartmentId = dptId,
                Address = address
            };

            _db.TblStudents.Add(std);
            await _db.SaveChangesAsync();

            return std;
        }

        public async Task DeleteDeleteAsync(long id)
        {
            var std = await _db.TblStudents.FindAsync(id);

            if (std == null)
            {
                throw new ArgumentException("Student not found");
            }

            _db.TblStudents.Remove(std);
            await _db.SaveChangesAsync();
        }

        public async Task<List<StudentDto>> GetAllStudentAsync()
        {
            var std = await _db.TblStudents
                .Include(p => p.Department)
                .Select(p => new StudentDto
                {
                    StudentId = p.StudentId,
                    StudentName = p.StudentName,
                    PhoneNumber = p.PhoneNumber,
                    DepartmentId = p.Department.DepartmentId,
                    TotalStudent = p.Department.TotalStudent,
                    DepartmentName = p.Department.DepartmentName,
                    Address = p.Address
                })
                .ToListAsync();

            return std;
        }

        public async Task<StudentDto> GetStudentByIdAsync(long id)
        {
            var stdDto = await _db.TblStudents
               .Where(p => p.StudentId == id)
               .Select(p => new StudentDto
               {
                   StudentId = p.StudentId,
                   StudentName = p.StudentName,
                   PhoneNumber = p.PhoneNumber,
                   DepartmentId = p.Department.DepartmentId,
                   TotalStudent = p.Department.TotalStudent,
                   DepartmentName = p.Department.DepartmentName,
                   Address = p.Address
               })
               .SingleOrDefaultAsync();

            return stdDto;
        }

        public async Task<TblStudent> UpdateStudentAsync(long id, string stdname, string phone, long dptId, string address)
        {
            var std = await _db.TblStudents.FindAsync(id);

            if (std == null)
            {
                return null;
            }

            std.StudentName = stdname;
            std.PhoneNumber = phone;
            std.Address = address;
            std.DepartmentId = dptId;

            _db.TblStudents.Update(std);
            await _db.SaveChangesAsync();

            return std;
        }
    }
}
