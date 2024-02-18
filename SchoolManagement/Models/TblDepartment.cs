using System;
using System.Collections.Generic;

namespace SchoolManagement.Models;

public partial class TblDepartment
{
    public long DepartmentId { get; set; }

    public string? DepartmentName { get; set; }

    public long? TotalStudent { get; set; }

    public virtual ICollection<TblStudent> TblStudents { get; set; } = new List<TblStudent>();
}
