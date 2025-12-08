using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace StudentRegistrationForm.Models;

public partial class PersonalDetail
{
    public Guid StudentId { get; set; }

    public string FirstName { get; set; } = null!;

    public string? MiddleName { get; set; }

    public string LastName { get; set; } = null!;

    public DateOnly DateOfBirth { get; set; }

    public string? PlaceOfBirth { get; set; }

    public string? Nationality { get; set; }

    public string? Gender { get; set; }

    public string? BloodGroup { get; set; }

    public string? MaritalStatus { get; set; }

    public string? Religion { get; set; }

    public string? DisabilityStatus { get; set; }

    public string? DisabilityType { get; set; }

    public int? DisabilityPercentage { get; set; }

    public string? ImagePath { get; set; }

    
    public virtual Student? Student { get; set; } = null!;
}
