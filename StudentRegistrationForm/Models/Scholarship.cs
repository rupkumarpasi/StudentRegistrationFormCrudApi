using System;
using System.Collections.Generic;

namespace StudentRegistrationForm.Models;

public partial class Scholarship
{
    public Guid ScholarshipId { get; set; }

    public Guid StudentId { get; set; }

    public string? ScholarshipType { get; set; }

    public string? ProviderName { get; set; }

    public decimal? ScholarshipAmount { get; set; }

    public Guid? FinancialStudentId { get; set; }

    public virtual Financial? FinancialStudent { get; set; }

    public virtual Student? Student { get; set; } = null!;
}
