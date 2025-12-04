using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace StudentRegistrationForm.Models;

public partial class ContactInfo
{
    public Guid StudentId { get; set; }

    public string Email { get; set; } = null!;

    public string? AlternateEmail { get; set; }

    public string? PrimaryMobile { get; set; }

    public string? SecondaryMobile { get; set; }
    [JsonIgnore]
    public virtual Student? Student { get; set; } = null!;
}
