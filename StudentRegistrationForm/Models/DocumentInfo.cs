using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace StudentRegistrationForm.Models;

public partial class DocumentInfo
{
    public Guid StudentId { get; set; }

    public string? PhotoPath { get; set; }

    public string? SignaturePath { get; set; }

    public string? CitizenshipDocumentPath { get; set; }

    public string? CharacterCertificatePath { get; set; }

    public string? ProvisionalAdmitCardPath { get; set; }

    
    public virtual Student? Student { get; set; } = null!;
}
