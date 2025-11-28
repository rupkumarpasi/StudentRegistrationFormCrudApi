using System;
using System.Collections.Generic;

namespace StudentRegistrationForm.Models;

public partial class Transportation
{
    public Guid StudentId { get; set; }

    public bool? IsHosteller { get; set; }

    public string? TransportationMethod { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Student? Student { get; set; } = null!;
}
