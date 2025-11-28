using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace StudentRegistrationForm.Models;

public partial class StudentRegistrationFormContext : DbContext
{
    public StudentRegistrationFormContext()
    {
    }

    public StudentRegistrationFormContext(DbContextOptions<StudentRegistrationFormContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AcademicHistory> AcademicHistories { get; set; }

    public virtual DbSet<Achievement> Achievements { get; set; }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Citizenship> Citizenships { get; set; }

    public virtual DbSet<ContactInfo> ContactInfos { get; set; }

    public virtual DbSet<DocumentInfo> DocumentInfos { get; set; }

    public virtual DbSet<EmergencyContact> EmergencyContacts { get; set; }

    public virtual DbSet<Enrollment> Enrollments { get; set; }

    public virtual DbSet<EthnicityInfo> EthnicityInfos { get; set; }

    public virtual DbSet<Extracurricular> Extracurriculars { get; set; }

    public virtual DbSet<Faculty> Faculties { get; set; }

    public virtual DbSet<Financial> Financials { get; set; }

    public virtual DbSet<Guardian> Guardians { get; set; }

    public virtual DbSet<PersonalDetail> PersonalDetails { get; set; }

    public virtual DbSet<Scholarship> Scholarships { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Transportation> Transportations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AcademicHistory>(entity =>
        {
            entity.HasKey(e => e.AcademicHistoryId).HasName("PK__Academic__64659444BE37DF1A");

            entity.ToTable("AcademicHistory");

            entity.Property(e => e.AcademicHistoryId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.BoardUniversity)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.GpaorDivision)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("GPAOrDivision");
            entity.Property(e => e.InstitutionName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.MarksheetPath)
                .HasMaxLength(1024)
                .IsUnicode(false);
            entity.Property(e => e.Qualification)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Student).WithMany(p => p.AcademicHistories)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AcademicHistory_Student");
        });

        modelBuilder.Entity<Achievement>(entity =>
        {
            entity.HasKey(e => e.AchievementId).HasName("PK__Achievem__276330C04D509649");

            entity.ToTable("Achievement");

            entity.Property(e => e.AchievementId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.AwardTitle)
                .HasMaxLength(512)
                .IsUnicode(false);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IssuingOrganization)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Student).WithMany(p => p.Achievements)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Achievement_Student");
        });

        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.AddressId).HasName("PK__Address__091C2AFB5C4B9632");

            entity.ToTable("Address");

            entity.Property(e => e.AddressId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.AddressType)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.District)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.HouseNumber)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.IsSameAsPermanent).HasDefaultValue(false);
            entity.Property(e => e.MunicipalityVdc)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("MunicipalityVDC");
            entity.Property(e => e.Province)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.ToleStreet)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.WardNumber)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.Student).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Address_Student");
        });

        modelBuilder.Entity<Citizenship>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__Citizens__32C52B9923F95A42");

            entity.ToTable("Citizenship");

            entity.Property(e => e.StudentId).ValueGeneratedNever();
            entity.Property(e => e.CitizenshipCopyPath)
                .HasMaxLength(1024)
                .IsUnicode(false);
            entity.Property(e => e.CitizenshipNumber)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.IssueDistrict)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Student).WithOne(p => p.Citizenship)
                .HasForeignKey<Citizenship>(d => d.StudentId)
                .HasConstraintName("FK_Citizenship_Student");
        });

        modelBuilder.Entity<ContactInfo>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__ContactI__32C52B99971E39C9");

            entity.ToTable("ContactInfo");

            entity.Property(e => e.StudentId).ValueGeneratedNever();
            entity.Property(e => e.AlternateEmail)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PrimaryMobile)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.SecondaryMobile)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.Student).WithOne(p => p.ContactInfo)
                .HasForeignKey<ContactInfo>(d => d.StudentId)
                .HasConstraintName("FK_ContactInfo_Student");
        });

        modelBuilder.Entity<DocumentInfo>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__Document__32C52B999CA48D0B");

            entity.ToTable("DocumentInfo");

            entity.Property(e => e.StudentId).ValueGeneratedNever();
            entity.Property(e => e.CharacterCertificatePath)
                .HasMaxLength(1024)
                .IsUnicode(false);
            entity.Property(e => e.CitizenshipDocumentPath)
                .HasMaxLength(1024)
                .IsUnicode(false);
            entity.Property(e => e.PhotoPath)
                .HasMaxLength(1024)
                .IsUnicode(false);
            entity.Property(e => e.ProvisionalAdmitCardPath)
                .HasMaxLength(1024)
                .IsUnicode(false);
            entity.Property(e => e.SignaturePath)
                .HasMaxLength(1024)
                .IsUnicode(false);

            entity.HasOne(d => d.Student).WithOne(p => p.DocumentInfo)
                .HasForeignKey<DocumentInfo>(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Document_Student");
        });

        modelBuilder.Entity<EmergencyContact>(entity =>
        {
            entity.HasKey(e => e.EmergencyContactId).HasName("PK__Emergenc__E8A61D8EA5CB0B60");

            entity.ToTable("EmergencyContact");

            entity.Property(e => e.EmergencyContactId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.ContactName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ContactNumber)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Relation)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Student).WithMany(p => p.EmergencyContacts)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmergencyContact_Student");
        });

        modelBuilder.Entity<Enrollment>(entity =>
        {
            entity.HasKey(e => e.EnrollmentId).HasName("PK__Enrollme__7F68771BA5D806FD");

            entity.ToTable("Enrollment");

            entity.Property(e => e.EnrollmentId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.AcademicStatus)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.AcademicYear)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CourseLevel)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CurrentProgramEnrollment)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Program)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.RegistrationNumber)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.RollNumber)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Section)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SemesterOrClass)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Faculty).WithMany(p => p.Enrollments)
                .HasForeignKey(d => d.FacultyId)
                .HasConstraintName("FK_Enrollment_Faculty");

            entity.HasOne(d => d.Student).WithMany(p => p.Enrollments)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Enrollment_Student");
        });

        modelBuilder.Entity<EthnicityInfo>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__Ethnicit__32C52B99D60DCF45");

            entity.ToTable("EthnicityInfo");

            entity.Property(e => e.StudentId).ValueGeneratedNever();
            entity.Property(e => e.CasteEthnicity)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.EthnicityType)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Student).WithOne(p => p.EthnicityInfo)
                .HasForeignKey<EthnicityInfo>(d => d.StudentId)
                .HasConstraintName("FK_Ethnicity_Student");
        });

        modelBuilder.Entity<Extracurricular>(entity =>
        {
            entity.HasKey(e => e.ExtracurricularId).HasName("PK__Extracur__2290BA0FC7952C89");

            entity.ToTable("Extracurricular");

            entity.Property(e => e.ExtracurricularId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.ActivityType)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.OtherDetails)
                .HasMaxLength(512)
                .IsUnicode(false);

            entity.HasOne(d => d.Student).WithMany(p => p.Extracurriculars)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Extracurricular_Student");
        });

        modelBuilder.Entity<Faculty>(entity =>
        {
            entity.HasKey(e => e.FacultyId).HasName("PK__Faculty__306F630EF6498AE1");

            entity.ToTable("Faculty");

            entity.Property(e => e.FacultyId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.FacultyName)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Financial>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__Financia__32C52B99DA16F611");

            entity.ToTable("Financial");

            entity.Property(e => e.StudentId).ValueGeneratedNever();
            entity.Property(e => e.AccountNumber)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.AnnualFamilyIncome)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.BankAccountHolder)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.BankName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Branch)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.FeeCategory)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Student).WithOne(p => p.Financial)
                .HasForeignKey<Financial>(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Financial_Student");
        });

        modelBuilder.Entity<Guardian>(entity =>
        {
            entity.HasKey(e => e.GuardianId).HasName("PK__Guardian__0A5E1A9BF2EC3E1E");

            entity.ToTable("Guardian");

            entity.Property(e => e.GuardianId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Designation)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.FullName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.IsPrimaryContact).HasDefaultValue(false);
            entity.Property(e => e.Mobile)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Occupation)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Organization)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Relation)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Student).WithMany(p => p.Guardians)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Guardian_Student");
        });

        modelBuilder.Entity<PersonalDetail>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__Personal__32C52B99E3EDD719");

            entity.ToTable("PersonalDetail");

            entity.Property(e => e.StudentId).ValueGeneratedNever();
            entity.Property(e => e.BloodGroup)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.DisabilityStatus)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DisabilityType)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Gender)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ImagePath)
                .HasMaxLength(1024)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.MaritalStatus)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.MiddleName)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Nationality)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValue("Nepali");
            entity.Property(e => e.PlaceOfBirth)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Religion)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Student).WithOne(p => p.PersonalDetail)
                .HasForeignKey<PersonalDetail>(d => d.StudentId)
                .HasConstraintName("FK_PersonalDetail_Student");
        });

        modelBuilder.Entity<Scholarship>(entity =>
        {
            entity.HasKey(e => e.ScholarshipId).HasName("PK__Scholars__853EC2FC661C8329");

            entity.ToTable("Scholarship");

            entity.Property(e => e.ScholarshipId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.ProviderName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ScholarshipAmount).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.ScholarshipType)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.FinancialStudent).WithMany(p => p.Scholarships)
                .HasForeignKey(d => d.FinancialStudentId)
                .HasConstraintName("FK_Scholarship_Financial");

            entity.HasOne(d => d.Student).WithMany(p => p.Scholarships)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Scholarship_Student");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__Student__32C52B99884D27B4");

            entity.ToTable("Student");

            entity.Property(e => e.StudentId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.PlaceOfApplication)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<Transportation>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__Transpor__32C52B992586BD3C");

            entity.ToTable("Transportation");

            entity.Property(e => e.StudentId).ValueGeneratedNever();
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsHosteller).HasDefaultValue(false);
            entity.Property(e => e.TransportationMethod)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Student).WithOne(p => p.Transportation)
                .HasForeignKey<Transportation>(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Transportation_Student");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
