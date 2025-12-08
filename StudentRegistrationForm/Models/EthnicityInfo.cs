using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace StudentRegistrationForm.Models;

public partial class EthnicityInfo
{
    public Guid StudentId { get; set; }

    public string CasteEthnicity { get; set; } = null!;

    public string? EthnicityType { get; set; }

    

    public virtual Student? Student { get; set; } = null!;
}
