using System;
using System.Collections.Generic;

namespace StudentRegistrationForm.Models;

public partial class Guardian
{
    public Guid GuardianId { get; set; }

    public Guid StudentId { get; set; }

    public string FullName { get; set; } = null!;

    public string Relation { get; set; } = null!;

    public string? Occupation { get; set; }

    public string? Designation { get; set; }

    public string? Organization { get; set; }

    public string? Mobile { get; set; }

    public string? Email { get; set; }

    public bool? IsPrimaryContact { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Student? Student { get; set; } = null!;
}
