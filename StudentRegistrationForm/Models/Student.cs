using System;
using System.Collections.Generic;

namespace StudentRegistrationForm.Models;

public partial class Student
{
    public Guid StudentId { get; set; }

    public DateOnly ApplicationDate { get; set; }

    public string? PlaceOfApplication { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<AcademicHistory> AcademicHistories { get; set; } = new List<AcademicHistory>();

    public virtual ICollection<Achievement> Achievements { get; set; } = new List<Achievement>();

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    public virtual Citizenship? Citizenship { get; set; }

    public virtual ContactInfo? ContactInfo { get; set; }

    public virtual DocumentInfo? DocumentInfo { get; set; }

    public virtual ICollection<EmergencyContact> EmergencyContacts { get; set; } = new List<EmergencyContact>();

    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

    public virtual EthnicityInfo? EthnicityInfo { get; set; }

    public virtual ICollection<Extracurricular> Extracurriculars { get; set; } = new List<Extracurricular>();

    public virtual Financial? Financial { get; set; }

    public virtual ICollection<Guardian> Guardians { get; set; } = new List<Guardian>();

    public virtual PersonalDetail? PersonalDetail { get; set; }

    public virtual ICollection<Scholarship> Scholarships { get; set; } = new List<Scholarship>();

    public virtual Transportation? Transportation { get; set; }
}
