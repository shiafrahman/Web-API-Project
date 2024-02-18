using System.Text.Json.Serialization;

namespace SchoolManagementClient.Models
{
    public class Department
    {
        public long DepartmentId { get; set; }

        public string? DepartmentName { get; set; }

        public long? TotalStudent { get; set; }
        [JsonIgnore]
        public virtual ICollection<Student> TblStudents { get; set; } = new List<Student>();
    }
}
