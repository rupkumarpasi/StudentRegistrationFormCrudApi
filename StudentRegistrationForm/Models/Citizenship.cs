using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace StudentRegistrationForm.Models;

public partial class Citizenship
{
    public Guid StudentId { get; set; }

    public string CitizenshipNumber { get; set; } = null!;

    public DateOnly? IssueDate { get; set; }

    public string? IssueDistrict { get; set; }

    public string? CitizenshipCopyPath { get; set; }

    
    public virtual Student? Student { get; set; } = null!;
}
