using System;
using System.Collections.Generic;

namespace StudentRegistrationForm.Models;

public partial class Enrollment
{
    public Guid EnrollmentId { get; set; }

    public Guid StudentId { get; set; }

    public string? CurrentProgramEnrollment { get; set; }

    public Guid? FacultyId { get; set; }

    public string? Program { get; set; }

    public string? CourseLevel { get; set; }

    public string? AcademicYear { get; set; }

    public string? SemesterOrClass { get; set; }

    public string? Section { get; set; }

    public string? RollNumber { get; set; }

    public string? RegistrationNumber { get; set; }

    public DateOnly? EnrollDate { get; set; }

    public string? AcademicStatus { get; set; }

    public virtual Faculty? Faculty { get; set; }

    public virtual Student? Student { get; set; } = null!;
}
