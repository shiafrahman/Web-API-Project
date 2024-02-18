using System;
using System.Collections.Generic;

namespace SchoolManagement.Models;

public partial class TblStudent
{
    public long StudentId { get; set; }

    public long DepartmentId { get; set; }

    public string? StudentName { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Address { get; set; }

    public virtual TblDepartment? Department { get; set; }
}
