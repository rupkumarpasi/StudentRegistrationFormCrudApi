using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace StudentRegistrationForm.Models;

public partial class Achievement
{
    public Guid AchievementId { get; set; }

    public Guid StudentId { get; set; }

    public string? AwardTitle { get; set; }

    public string? IssuingOrganization { get; set; }

    public int? YearReceived { get; set; }

    public DateTime? CreatedAt { get; set; }

    
    public virtual Student? Student { get; set; } = null!;
}
