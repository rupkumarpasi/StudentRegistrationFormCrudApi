using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace StudentRegistrationForm.Models;

public partial class AcademicHistory
{
    public Guid AcademicHistoryId { get; set; }

    public Guid StudentId { get; set; }

    public string Qualification { get; set; } = null!;

    public string? BoardUniversity { get; set; }

    public string? InstitutionName { get; set; }

    public int? PassedYear { get; set; }

    public string? GpaorDivision { get; set; }

    public string? MarksheetPath { get; set; }

    public DateTime? CreatedAt { get; set; }

    [JsonIgnore]
    public virtual Student? Student { get; set; } = null!;
}
