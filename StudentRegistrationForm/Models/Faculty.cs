using System;
using System.Collections.Generic;

namespace StudentRegistrationForm.Models;

public partial class Faculty
{
    public Guid FacultyId { get; set; }

    public string FacultyName { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
}
