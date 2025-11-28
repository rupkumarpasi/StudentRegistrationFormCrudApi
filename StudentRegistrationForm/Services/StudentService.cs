using StudentRegistrationForm.Models;
using StudentRegistrationForm.Models.DTOs;
using StudentRegistrationForm.Repositories;

namespace StudentRegistrationForm.Services
{
    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork _uow;

        public StudentService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<IEnumerable<Student>> GetAllAsync() =>
            await _uow.Students.GetAllAsync();

        public async Task<Student?> GetByIdAsync(Guid id) =>
            await _uow.Students.GetByIdAsync(id);

        public async Task<Student> CreateFromDtoAsync(StudentCreateDto dto)
        {
            var studentId = Guid.NewGuid();

            var student = new Student
            {
                StudentId = studentId,
                ApplicationDate = DateOnly.FromDateTime(
                    DateTime.TryParse(dto.ApplicationDate, out var appDate)
                        ? appDate
                        : DateTime.Today
                ),
                PlaceOfApplication = dto.PlaceOfApplication,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,

                // One-to-One
                PersonalDetail = dto.PersonalDetail,
                ContactInfo = dto.ContactInfo,
                Citizenship = dto.Citizenship,
                EthnicityInfo = dto.EthnicityInfo,
                Financial = dto.Financial,
                Transportation = dto.Transportation,

                // DocumentInfo – DTO se Entity mein convert karo
                DocumentInfo = dto.DocumentInfo != null ? new DocumentInfo
                {
                    StudentId = studentId,
                    PhotoPath = dto.DocumentInfo.PhotoPath,
                    SignaturePath = dto.DocumentInfo.SignaturePath,
                    CitizenshipDocumentPath = dto.DocumentInfo.CitizenshipDocumentPath,
                    CharacterCertificatePath = dto.DocumentInfo.CharacterCertificatePath,
                    ProvisionalAdmitCardPath = dto.DocumentInfo.ProvisionalAdmitCardPath
                } : null,

                // Collections
                Addresses = dto.Addresses.Select(a => new Address
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
                    IsSameAsPermanent = a.IsSameAsPermanent,
                    CreatedAt = DateTime.UtcNow
                }).ToList(),

                Guardians = dto.Guardians.Select(g => new Guardian
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

                AcademicHistories = dto.AcademicHistories.Select(ah => new AcademicHistory
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

                Enrollments = dto.Enrollments.Select(e => new Enrollment
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
                    EnrollDate = DateOnly.FromDateTime(DateTime.Parse(e.EnrollDate)),
                    AcademicStatus = e.AcademicStatus,
                    FacultyId = e.FacultyId
                }).ToList(),

                EmergencyContacts = dto.EmergencyContacts.Select(ec => new EmergencyContact
                {
                    EmergencyContactId = Guid.NewGuid(),
                    StudentId = studentId,
                    ContactName = ec.ContactName,
                    Relation = ec.Relation,
                    ContactNumber = ec.ContactNumber,
                    CreatedAt = DateTime.UtcNow
                }).ToList(),

                // Missing Collections – ab perfectly add ho gaye!
                Achievements = dto.Achievements.Select(a => new Achievement
                {
                    AchievementId = Guid.NewGuid(),
                    StudentId = studentId,
                    AwardTitle = a.AwardTitle,
                    IssuingOrganization = a.IssuingOrganization,
                    YearReceived = a.YearReceived,
                    CreatedAt = DateTime.UtcNow
                }).ToList(),

                Extracurriculars = dto.Extracurriculars.Select(e => new Extracurricular
                {
                    ExtracurricularId = Guid.NewGuid(),
                    StudentId = studentId,
                    ActivityType = e.ActivityType,
                    OtherDetails = e.OtherDetails,
                    CreatedAt = DateTime.UtcNow
                }).ToList(),

                Scholarships = dto.Scholarships.Select(s => new Scholarship
                {
                    ScholarshipId = Guid.NewGuid(),
                    StudentId = studentId,
                    ScholarshipType = s.ScholarshipType,
                    ProviderName = s.ProviderName,
                    ScholarshipAmount = s.ScholarshipAmount,
                    FinancialStudentId = studentId
                }).ToList()
            };

            // Fix 1: AddAsync → Add (agar sync hai) ya await AddAsync
            _uow.Students.AddAsync(student);  // Agar Add sync hai
            // Ya agar AddAsync hai toh: await _uow.Students.AddAsync(student);

            // Fix 2: CommitAsync await karo
            await _uow.CommitAsync();

            return student;
        }

        public async Task<bool> UpdateAsync(Guid id, Student student)
        {
            var existing = await _uow.Students.GetByIdAsync(id);
            if (existing == null) return false;

            // Yahan proper mapping karna chahiye (future mein AutoMapper use karna)
            _uow.Students.Update(existing);
            await _uow.CommitAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var existing = await _uow.Students.GetByIdAsync(id);
            if (existing == null) return false;

            _uow.Students.Delete(existing);
            await _uow.CommitAsync();
            return true;
        }
    }
}