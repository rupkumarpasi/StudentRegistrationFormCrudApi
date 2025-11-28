using System;
using System.Collections.Generic;

namespace StudentRegistrationForm.Models;

public partial class EmergencyContact
{
    public Guid EmergencyContactId { get; set; }

    public Guid StudentId { get; set; }

    public string ContactName { get; set; } = null!;

    public string Relation { get; set; } = null!;

    public string ContactNumber { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public virtual Student? Student { get; set; } = null!;
}
