using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace StudentRegistrationForm.Models;

public partial class Extracurricular
{
    public Guid ExtracurricularId { get; set; }

    public Guid StudentId { get; set; }

    public string? ActivityType { get; set; }

    public string? OtherDetails { get; set; }

    public DateTime? CreatedAt { get; set; }

    
    public virtual Student? Student { get; set; } = null!;
}
