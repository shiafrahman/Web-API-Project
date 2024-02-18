using Microsoft.AspNetCore.Mvc.Rendering;

namespace SchoolManagementClient.Models
{
    public class Student
    {
        public long StudentId { get; set; }

        public long DepartmentId { get; set; }

        public string? StudentName { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Address { get; set; }


        public string? DepartmentName { get; set; }

        public long? TotalStudent { get; set; }

        //public List<Student> DepartmentStudents { get; set; }
        //public long StudentId { get; set; }
        //public string StudentName { get; set; }
        //public string PhoneNumber { get; set; }
        //public long DepartmentId { get; set; }
        //public string Address { get; set; }
    }

    public class StudentService
    {
        private readonly HttpClient _client;

        public StudentService(HttpClient client)
        {
            _client = client;
        }



        public async Task<List<Student>> GetAllStudentsAsync()
        {
            var response = await _client.GetAsync("/api/students");
            response.EnsureSuccessStatusCode();
            var students = await response.Content.ReadAsAsync<List<Student>>();
            return students;
        }

        public async Task<Student> GetStudentAsync(long id)
        {
            var response = await _client.GetAsync($"/api/students/{id}");
            response.EnsureSuccessStatusCode();
            var student = await response.Content.ReadAsAsync<Student>();
            return student;
        }

        public async Task<Student> CreateStudentAsync(Student student)
        {
            var response = await _client.PostAsJsonAsync("/api/students", student);
            response.EnsureSuccessStatusCode();
            var createdStudent = await response.Content.ReadAsAsync<Student>();
            return createdStudent;
        }

        public async Task UpdateStudentAsync(long id, Student student)
        {
            var response = await _client.PutAsJsonAsync($"/api/students/{id}", student);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteStudentAsync(long id)
        {
            var response = await _client.DeleteAsync($"/api/students/{id}");
            response.EnsureSuccessStatusCode();
        }

        

    }
}
