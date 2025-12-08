using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace StudentRegistrationForm.Models;

public partial class Financial
{
    public Guid StudentId { get; set; }

    public string FeeCategory { get; set; } = null!;

    public string? AnnualFamilyIncome { get; set; }

    public string? BankAccountHolder { get; set; }

    public string? BankName { get; set; }

    public string? AccountNumber { get; set; }

    public string? Branch { get; set; }

    public virtual ICollection<Scholarship> Scholarships { get; set; } = new List<Scholarship>();
    
    public virtual Student? Student { get; set; } = null!;
}
