// File: Models/DTOs/CreateStudentRequest.cs
namespace StudentRegistrationForm.Models.DTOs
{
    public class CreateStudentRequest
    {
        public StudentCreateDto student { get; set; } = null!;
    }

    public class StudentCreateDto
    {
        public string? ApplicationDate { get; set; }
        public string? PlaceOfApplication { get; set; }

        // One-to-One Entities
        public PersonalDetail? PersonalDetail { get; set; }
        public ContactInfo? ContactInfo { get; set; }
        public Citizenship? Citizenship { get; set; }
        public EthnicityInfo? EthnicityInfo { get; set; }
        public Financial? Financial { get; set; }
        public Transportation? Transportation { get; set; }
        public DocumentInfoCreateDto? DocumentInfo { get; set; }  // Navigation hataya

        // Collections
        public List<AddressCreateDto> Addresses { get; set; } = new();
        public List<GuardianCreateDto> Guardians { get; set; } = new();
        public List<AcademicHistoryCreateDto> AcademicHistories { get; set; } = new();
        public List<EmergencyContactCreateDto> EmergencyContacts { get; set; } = new();
        public List<EnrollmentCreateDto> Enrollments { get; set; } = new();

        // Ye teen missing the pehle – ab add kar diye!
        public List<AchievementCreateDto> Achievements { get; set; } = new();
        public List<ExtracurricularCreateDto> Extracurriculars { get; set; } = new();
        public List<ScholarshipCreateDto> Scholarships { get; set; } = new();
    }

    // DocumentInfo ke liye alag DTO (circular reference avoid karne ke liye)
    public class DocumentInfoCreateDto
    {
        public string? PhotoPath { get; set; }
        public string? SignaturePath { get; set; }
        public string? CitizenshipDocumentPath { get; set; }
        public string? CharacterCertificatePath { get; set; }
        public string? ProvisionalAdmitCardPath { get; set; }
    }

    // Child DTOs
    public class AddressCreateDto
    {
        public string AddressType { get; set; } = null!;
        public string Province { get; set; } = null!;
        public string District { get; set; } = null!;
        public string MunicipalityVdc { get; set; } = null!;
        public string? WardNumber { get; set; }
        public string? ToleStreet { get; set; }
        public string? HouseNumber { get; set; }
        public bool? IsSameAsPermanent { get; set; }
    }

    public class GuardianCreateDto
    {
        public string FullName { get; set; } = null!;
        public string Relation { get; set; } = null!;
        public string? Occupation { get; set; }
        public string? Mobile { get; set; }
        public string? Email { get; set; }
        public bool IsPrimaryContact { get; set; }
    }

    public class AcademicHistoryCreateDto
    {
        public string Qualification { get; set; } = null!;
        public string BoardUniversity { get; set; } = null!;
        public string InstitutionName { get; set; } = null!;
        public int PassedYear { get; set; }
        public string GpaorDivision { get; set; } = null!;
    }

    public class EnrollmentCreateDto
    {
        public string CurrentProgramEnrollment { get; set; } = null!;
        public string Program { get; set; } = null!;
        public string CourseLevel { get; set; } = null!;
        public string AcademicYear { get; set; } = null!;
        public string SemesterOrClass { get; set; } = null!;
        public string Section { get; set; } = null!;
        public string RollNumber { get; set; } = null!;
        public string RegistrationNumber { get; set; } = null!;
        public string EnrollDate { get; set; } = null!;
        public string AcademicStatus { get; set; } = null!;
        public Guid? FacultyId { get; set; }
    }

    public class EmergencyContactCreateDto
    {
        public string ContactName { get; set; } = null!;
        public string Relation { get; set; } = null!;
        public string ContactNumber { get; set; } = null!;
    }

    // Missing DTOs – ab add kar diye!
    public class AchievementCreateDto
    {
        public string? AwardTitle { get; set; }
        public string? IssuingOrganization { get; set; }
        public int? YearReceived { get; set; }
    }

    public class ExtracurricularCreateDto
    {
        public string? ActivityType { get; set; }
        public string? OtherDetails { get; set; }
    }

    public class ScholarshipCreateDto
    {
        public string? ScholarshipType { get; set; }
        public string? ProviderName { get; set; }
        public decimal? ScholarshipAmount { get; set; }
    }
}