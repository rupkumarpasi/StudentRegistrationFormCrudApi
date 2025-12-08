using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace StudentRegistrationForm.Models;

public partial class Address
{
    public Guid AddressId { get; set; }

    public Guid StudentId { get; set; }

    public string AddressType { get; set; } = null!;

    public string Province { get; set; } = null!;

    public string District { get; set; } = null!;

    public string MunicipalityVdc { get; set; } = null!;

    public string? WardNumber { get; set; }

    public string? ToleStreet { get; set; }

    public string? HouseNumber { get; set; }

    public bool? IsSameAsPermanent { get; set; }

    public DateTime? CreatedAt { get; set; }

    
    public virtual Student? Student { get; set; } = null!;
}
