// lib/api.ts
import axios from "axios";

const API_URL = "https://localhost:7050/api/Student";

export const submitRegistration = async (formData: any) => {
  // YE SABSE BADA FIX — extracurriculars ko object mein convert kar
  const extracurriculars = Array.isArray(formData.extracurriculars)
    ? formData.extracurriculars.map((item: string) => ({
        activityType: item,
        otherDetails: null,
      }))
    : [];

  const payload = {
    applicationDate: formData.applicationDate || new Date().toISOString().split("T")[0],
    placeOfApplication: formData.placeOfApplication || "Butwal",

    

    personalDetail: {
      firstName: formData.firstName,
      middleName: formData.middleName || null,
      lastName: formData.lastName,
      dateOfBirth: formData.dateOfBirth,
      placeOfBirth: formData.placeOfBirth || null,
      nationality: formData.nationality || "Nepali",
      gender: formData.gender,
      bloodGroup: formData.bloodGroup || null,
      maritalStatus: formData.maritalStatus || "Single",
      religion: formData.religion || null,
      disabilityStatus: formData.disabilityStatus || "None",
      disabilityType: formData.disabilityType || null,
      disabilityPercentage: formData.disabilityPercentage || 0,
    },

    contactInfo: {
      email: formData.email,
      alternateEmail: formData.alternateEmail || null,
      primaryMobile: formData.primaryMobile,
      secondaryMobile: formData.secondaryMobile || null,
    },

    citizenship: {
      citizenshipNumber: formData.citizenshipNumber,
      issueDate: formData.citizenshipIssueDate || null,
      issueDistrict: formData.citizenshipIssueDistrict || null,
    },

    ethnicityInfo: {
      casteEthnicity: formData.ethnicity || null,
      ethnicityType: formData.ethnicityType || null,
    },

    financial: {
      feeCategory: formData.feeCategory || "Regular",
      annualFamilyIncome: formData.annualFamilyIncome || null,
      bankAccountHolder: formData.bankAccountHolder || null,
      bankName: formData.bankName || null,
      accountNumber: formData.accountNumber || null,
      branch: formData.branch || null,
    },

    transportation: {
      isHosteller: formData.hosteller === "Hosteller",
      transportationMethod: formData.transportation || null,
    },

    // Base64 Images
    photoBase64: formData.photoBase64 || null,
    signatureBase64: formData.signatureBase64 || null,
    citizenshipBase64: formData.citizenshipBase64 || null,
    characterCertificateBase64: formData.characterCertificateBase64 || null,
    provisionalAdmitCardBase64: formData.provisionalAdmitCardBase64 || null,

    // Addresses
    addresses: formData.sameAsPermanent
      ? [
          {
            addressType: "Permanent",
            province: formData.permanentProvince,
            district: formData.permanentDistrict,
            municipalityVdc: formData.permanentMunicipality,
            wardNumber: formData.permanentWard,
            toleStreet: formData.permanentTole || null,
            houseNumber: formData.permanentHouseNo || null,
            isSameAsPermanent: true,
          },
        ]
      : [
          {
            addressType: "Permanent",
            province: formData.permanentProvince,
            district: formData.permanentDistrict,
            municipalityVdc: formData.permanentMunicipality,
            wardNumber: formData.permanentWard,
            toleStreet: formData.permanentTole || null,
            houseNumber: formData.permanentHouseNo || null,
            isSameAsPermanent: true,
          },
          {
            addressType: "Temporary",
            province: formData.temporaryProvince || formData.permanentProvince,
            district: formData.temporaryDistrict || formData.permanentDistrict,
            municipalityVdc: formData.temporaryMunicipality || formData.permanentMunicipality,
            wardNumber: formData.temporaryWard || formData.permanentWard,
            toleStreet: formData.temporaryTole || formData.permanentTole,
            houseNumber: formData.temporaryHouseNo || formData.permanentHouseNo,
            isSameAsPermanent: false,
          },
        ],

    // Guardians
    guardians: [
      {
        fullName: formData.fatherName,
        relation: "Father",
        occupation: formData.fatherOccupation || null,
        mobile: formData.fatherMobile,
        email: formData.fatherEmail || null,
        isPrimaryContact: true,
      },
      {
        fullName: formData.motherName,
        relation: "Mother",
        occupation: formData.motherOccupation || null,
        mobile: formData.motherMobile,
        email: formData.motherEmail || null,
        isPrimaryContact: false,
      },
    ].filter(g => g.fullName),

    // Emergency Contact
    emergencyContacts: [
      {
        contactName: formData.emergencyName,
        relation: formData.emergencyRelation,
        contactNumber: formData.emergencyNumber,
      },
    ],

    // Enrollment
    enrollments: [
      {
        currentProgramEnrollment: formData.program,
        program: formData.program,
        courseLevel: formData.level,
        academicYear: formData.academicYear,
        semesterOrClass: formData.semester,
        section: formData.section,
        rollNumber: formData.rollNo,
        registrationNumber: formData.regNo,
        enrollDate: formData.enrollDate,
        academicStatus: formData.academicStatus || "Active",
        facultyId: "3fa85f64-5717-4562-b3fc-2c963f66afa6", // default
      },
    ],

    // YE SABSE BADA FIX — extracurriculars object mein convert
    extracurriculars,

    achievements: formData.awardTitle
    ? [{
        awardTitle: formData.awardTitle,
        issuingOrganization: formData.issuingOrganization || null,
        yearReceived: formData.yearReceived ? Number(formData.yearReceived) : null,
      }]
    : [],

  academicHistories: formData.qualification
    ? [{
        qualification: formData.qualification,
        boardUniversity: formData.board || null,
        institutionName: formData.institution || null,
        passedYear: formData.passedYear ? Number(formData.passedYear) : null,
        gpaorDivision: formData.division || null,
      }]
    : [],
  };

  return axios.post(API_URL, payload, {
    headers: { "Content-Type": "application/json" },
  });
};