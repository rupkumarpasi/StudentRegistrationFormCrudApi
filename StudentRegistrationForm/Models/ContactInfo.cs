using System;
using System.Collections.Generic;

namespace StudentRegistrationForm.Models;

public partial class ContactInfo
{
    public Guid StudentId { get; set; }

    public string Email { get; set; } = null!;

    public string? AlternateEmail { get; set; }

    public string? PrimaryMobile { get; set; }

    public string? SecondaryMobile { get; set; }

    public virtual Student? Student { get; set; } = null!;
}
