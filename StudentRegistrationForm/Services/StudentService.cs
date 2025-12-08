// File: Services/StudentService.cs
using StudentRegistrationForm.Dto;
using StudentRegistrationForm.Models;
using StudentRegistrationForm.Repositories;

namespace StudentRegistrationForm.Services
{
    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork _uow;
        private readonly FileUploadHelper _fileHelper;

        public StudentService(IUnitOfWork uow, FileUploadHelper fileHelper)
        {
            _uow = uow;
            _fileHelper = fileHelper;
        }

        // Yeh method tere interface mein hai → GetByIdAsync
        public async Task<Student?> GetByIdAsync(Guid id)
        {
            return await _uow.Students.GetStudentWithDetailsAsync(id);
        }

        // Yeh method tere interface mein hai → CreateFromDtoAsync
        public async Task<Student> CreateFromDtoAsync(CreateStudentRequest request)
        {
            var studentId = Guid.NewGuid();

            // Save Base64 images
            var documentInfo = new DocumentInfo
            {
                StudentId = studentId,
                PhotoPath = _fileHelper.SaveBase64Image(request.PhotoBase64, "photos"),
                SignaturePath = _fileHelper.SaveBase64Image(request.SignatureBase64, "signatures"),
                CitizenshipDocumentPath = _fileHelper.SaveBase64Image(request.CitizenshipBase64, "citizenship"),
                CharacterCertificatePath = _fileHelper.SaveBase64Image(request.CharacterCertificateBase64, "certificates"),
                ProvisionalAdmitCardPath = _fileHelper.SaveBase64Image(request.ProvisionalAdmitCardBase64, "provisional")
            };

            // Parse Application Date
            DateOnly applicationDate = DateOnly.MinValue;
            if (!string.IsNullOrWhiteSpace(request.ApplicationDate))
                DateOnly.TryParse(request.ApplicationDate, out applicationDate);

            var student = new Student
            {
                StudentId = studentId,
                ApplicationDate = applicationDate,
                PlaceOfApplication = request.PlaceOfApplication ?? "Not Specified",
                DocumentInfo = documentInfo,

                // Personal Detail
                PersonalDetail = request.PersonalDetail != null ? new PersonalDetail
                {
                    StudentId = studentId,
                    FirstName = request.PersonalDetail.FirstName,
                    MiddleName = request.PersonalDetail.MiddleName,
                    LastName = request.PersonalDetail.LastName,
                    DateOfBirth = DateOnly.TryParse(request.PersonalDetail.DateOfBirth, out var dob)
        ? dob
        : DateOnly.MinValue,
                    PlaceOfBirth = request.PersonalDetail.PlaceOfBirth,
                    Nationality = request.PersonalDetail.Nationality ?? "Nepali",
                    Gender = request.PersonalDetail.Gender,
                    BloodGroup = request.PersonalDetail.BloodGroup,
                    MaritalStatus = request.PersonalDetail.MaritalStatus,
                    Religion = request.PersonalDetail.Religion,
                    DisabilityStatus = request.PersonalDetail.DisabilityStatus,
                    DisabilityType = request.PersonalDetail.DisabilityType,
                    DisabilityPercentage = request.PersonalDetail.DisabilityPercentage,
                    ImagePath = request.PersonalDetail.ImagePath
                } : null,

                // Contact Info
                ContactInfo = request.ContactInfo != null ? new ContactInfo
                {
                    StudentId = studentId,
                    Email = request.ContactInfo.Email,
                    AlternateEmail = request.ContactInfo.AlternateEmail,
                    PrimaryMobile = request.ContactInfo.PrimaryMobile,
                    SecondaryMobile = request.ContactInfo.SecondaryMobile
                } : null,

                // Citizenship
                Citizenship = request.Citizenship != null ? new Citizenship
                {
                    StudentId = studentId,
                    CitizenshipNumber = request.Citizenship.CitizenshipNumber,
                    IssueDate = DateOnly.TryParse(request.Citizenship.IssueDate, out var idate) ? idate : null,
                    IssueDistrict = request.Citizenship.IssueDistrict,
                    CitizenshipCopyPath = request.Citizenship.CitizenshipCopyPath
                } : null,

                // Ethnicity, Financial, Transportation
                EthnicityInfo = request.EthnicityInfo != null ? new EthnicityInfo
                {
                    StudentId = studentId,
                    CasteEthnicity = request.EthnicityInfo.CasteEthnicity,
                    EthnicityType = request.EthnicityInfo.EthnicityType
                } : null,

                Financial = request.Financial != null ? new Financial
                {
                    StudentId = studentId,
                    FeeCategory = request.Financial.FeeCategory,
                    AnnualFamilyIncome = request.Financial.AnnualFamilyIncome,
                    BankAccountHolder = request.Financial.BankAccountHolder,
                    BankName = request.Financial.BankName,
                    AccountNumber = request.Financial.AccountNumber,
                    Branch = request.Financial.Branch
                } : null,

                Transportation = request.Transportation != null ? new Transportation
                {
                    StudentId = studentId,
                    IsHosteller = request.Transportation.IsHosteller,
                    TransportationMethod = request.Transportation.TransportationMethod,
                    CreatedAt = DateTime.UtcNow
                } : null,

                // Direct Lists — No JSON string!
                Addresses = (request.Addresses ?? new List<AddressCreateDto>())
                    .Select(a => new Address
                    {
                        AddressId = Guid.NewGuid(),
                        StudentId = studentId,
                        AddressType = a.AddressType,
                        Province = a.Province,
                        District = a.District,
                        MunicipalityVdc = a.MunicipalityVdc,
                        WardNumber = a.WardNumber,
                        ToleStreet = a.ToleStreet,
                        HouseNumber = a.HouseNumber,
                        IsSameAsPermanent = a.IsSameAsPermanent ?? false,
                        CreatedAt = DateTime.UtcNow
                    }).ToList(),

                Guardians = (request.Guardians ?? new List<GuardianCreateDto>())
                    .Select(g => new Guardian
                    {
                        GuardianId = Guid.NewGuid(),
                        StudentId = studentId,
                        FullName = g.FullName,
                        Relation = g.Relation,
                        Occupation = g.Occupation,
                        Mobile = g.Mobile,
                        Email = g.Email,
                        IsPrimaryContact = g.IsPrimaryContact,
                        CreatedAt = DateTime.UtcNow
                    }).ToList(),

                AcademicHistories = (request.AcademicHistories ?? new List<AcademicHistoryCreateDto>())
                    .Select(ah => new AcademicHistory
                    {
                        AcademicHistoryId = Guid.NewGuid(),
                        StudentId = studentId,
                        Qualification = ah.Qualification,
                        BoardUniversity = ah.BoardUniversity,
                        InstitutionName = ah.InstitutionName,
                        PassedYear = ah.PassedYear,
                        GpaorDivision = ah.GpaorDivision,
                        CreatedAt = DateTime.UtcNow
                    }).ToList(),

                EmergencyContacts = (request.EmergencyContacts ?? new List<EmergencyContactCreateDto>())
                    .Select(ec => new EmergencyContact
                    {
                        EmergencyContactId = Guid.NewGuid(),
                        StudentId = studentId,
                        ContactName = ec.ContactName,
                        Relation = ec.Relation,
                        ContactNumber = ec.ContactNumber,
                        CreatedAt = DateTime.UtcNow
                    }).ToList(),

                Enrollments = (request.Enrollments ?? new List<EnrollmentCreateDto>())
                    .Select(e => new Enrollment
                    {
                        EnrollmentId = Guid.NewGuid(),
                        StudentId = studentId,
                        CurrentProgramEnrollment = e.CurrentProgramEnrollment,
                        Program = e.Program,
                        CourseLevel = e.CourseLevel,
                        AcademicYear = e.AcademicYear,
                        SemesterOrClass = e.SemesterOrClass,
                        Section = e.Section,
                        RollNumber = e.RollNumber,
                        RegistrationNumber = e.RegistrationNumber,
                        EnrollDate = DateOnly.TryParse(e.EnrollDate, out var edate) ? edate : DateOnly.MinValue,
                        AcademicStatus = e.AcademicStatus,
                    
                    }).ToList(),

                Achievements = (request.Achievements ?? new List<AchievementCreateDto>())
                    .Select(a => new Achievement { /* mapping */ }).ToList(),

                Extracurriculars = (request.Extracurriculars ?? new List<ExtracurricularCreateDto>())
                    .Select(e => new Extracurricular { /* mapping */ }).ToList(),

                Scholarships = (request.Scholarships ?? new List<ScholarshipCreateDto>())
                    .Select(s => new Scholarship { /* mapping */ }).ToList()
            };

            await _uow.Students.AddAsync(student);
            await _uow.CommitAsync();

            return student;
        }

        public async Task<CreateStudentRequest> updateStudentAsync(int id,CreateStudentRequest student)
        {
            //return await _uow.Students.
        }
    }
}