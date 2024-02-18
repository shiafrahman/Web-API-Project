using Newtonsoft.Json;

namespace SchoolManagement.Models.DTOs
{
    public class StudentDto
    {
        public long StudentId { get; set; }

        public long? DepartmentId { get; set; }

        public string? StudentName { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Address { get; set; }
        

        public string? DepartmentName { get; set; }

        public long? TotalStudent { get; set; }

        
    }
}
