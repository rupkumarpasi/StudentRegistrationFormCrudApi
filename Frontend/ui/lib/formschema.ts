// lib/formSchema.ts
import * as z from "zod";

export const formSchema = z
  .object({
    // ==================== STEP 1: Personal ====================
    photoBase64: z.string().min(1, "Passport Size Photo is required"),
    firstName: z.string().min(1, "First Name is required"),
    middleName: z.string().optional(),
    lastName: z.string().min(1, "Last Name is required"),
    dateOfBirth: z.string().min(1, "Date of Birth is required"),
    placeOfBirth: z.string().optional(),
    nationality: z.string().min(1, "Nationality is required"),
    citizenshipNumber: z.string().min(1, "Citizenship Number is required"),
    citizenshipIssueDate: z.string().min(1, "Citizenship Issue Date is required"),
    citizenshipIssueDistrict: z.string().min(1, "Citizenship Issue District is required"),
    email: z.string().email("Invalid email").min(1, "Email is required"),
    alternateEmail: z.string().email().optional().or(z.literal("")),
    primaryMobile: z.string().min(1, "Primary Mobile is required"),
    secondaryMobile: z.string().optional(),
    emergencyName: z.string().min(1, "Emergency Contact Name is required"),
    emergencyRelation: z.string().min(1, "Emergency Contact Relation is required"),
    emergencyNumber: z.string().min(1, "Emergency Contact Number is required"),
    gender: z.string().min(1, "Gender is required"),
    bloodGroup: z.string().optional(),
    maritalStatus: z.string().optional(),
    religion: z.string().optional(),
    ethnicity: z.string().min(1, "Ethnicity/Caste is required"),
    ethnicityType: z.string().min(1, "Ethnicity Type is required"),
    disabilityStatus: z.string().optional(),
    disabilityType: z.string().optional(),
    // disabilityPercentage: z.number().optional(),

    // ==================== STEP 2: Address ====================
    permanentProvince: z.string().min(1, "Permanent Province is required"),
    permanentDistrict: z.string().min(1, "Permanent District is required"),
    permanentMunicipality: z.string().min(1, "Permanent Municipality/VDC is required"),
    permanentWard: z.string().min(1, "Permanent Ward Number is required"),
    permanentTole: z.string().optional(),
    permanentHouseNo: z.string().optional(),
    sameAsPermanent: z.boolean().default(false),

    temporaryProvince: z.string().optional(),
    temporaryDistrict: z.string().optional(),
    temporaryMunicipality: z.string().optional(),
    temporaryWard: z.string().optional(),
    temporaryTole: z.string().optional(),
    temporaryHouseNo: z.string().optional(),

    // ==================== STEP 3: Guardian ====================
    fatherName: z.string().min(1, "Father's Name is required"),
    fatherOccupation: z.string().optional(),
    fatherMobile: z.string().min(1, "Father's Mobile is required"),
    fatherEmail: z.string().email().optional().or(z.literal("")),

    motherName: z.string().min(1, "Mother's Name is required"),
    motherOccupation: z.string().optional(),
    motherMobile: z.string().min(1, "Mother's Mobile is required"),
    motherEmail: z.string().email().optional().or(z.literal("")),

    primaryContact: z.enum(["Father", "Mother", "Guardian"]).optional(),
    guardianName: z.string().optional(),
    guardianRelation: z.string().optional(),
    guardianMobile: z.string().optional(),
    guardianEmail: z.string().email().optional().or(z.literal("")),

    // ==================== STEP 4: Academic ====================
    faculty: z.string().min(1, "Faculty is required"),
    program: z.string().min(1, "Program is required"),
    level: z.string().min(1, "Level is required"),
    academicYear: z.string().min(1, "Academic Year is required"),
    semester: z.string().min(1, "Semester is required"),
    section: z.string().min(1, "Section is required"),
    rollNo: z.string().min(1, "Roll Number is required"),
    regNo: z.string().min(1, "Registration Number is required"),
    enrollDate: z.string().min(1, "Enroll Date is required"),
    academicStatus: z.string().optional(),

    qualification: z.string().min(1, "Qualification is required"),
    board: z.string().min(1, "Board/University is required"),
    institution: z.string().min(1, "Institution Name is required"),
    // passedYear: z.number().min(1900),
    division: z.string().min(1, "Division/GPA is required"),

    signatureBase64: z.string().min(1, "Signature is required"),
    citizenshipBase64: z.string().min(1, "Citizenship Copy is required"),
    characterCertificateBase64: z.string().optional(),

    // ==================== STEP 5: Financial ====================
    feeCategory: z.string().min(1, "Fee Category is required"),
    scholarshipType: z.string().optional(),
    scholarshipProvider: z.string().optional(),
    scholarshipAmount: z.number().optional(),
    bankAccountHolder: z.string().optional(),
    bankName: z.string().optional(),
    accountNumber: z.string().optional(),
    branch: z.string().optional(),

    // ==================== STEP 6: Extracurricular ====================
    extracurriculars: z.array(z.string()).optional().default([]),

    // YE DO FIELDS PAKKA ADD HAIN — ERROR NAHI AAYEGA!
    achievements: z
      .array(
        z.object({
          awardTitle: z.string(),
          issuingOrganization: z.string(),
          yearReceived: z.number(),
        })
      )
      .optional()
      .default([]),

    scholarships: z
      .array(
        z.object({
          scholarshipType: z.string(),
          providerName: z.string(),
          scholarshipAmount: z.number(),
        })
      )
      .optional()
      .default([]),

    hosteller: z.string().min(1, "Hosteller/Day Scholar is required"),
    transportation: z.string().optional(),
academicHistories: z.array(z.any()).optional().default([]),
    // ==================== STEP 7: Declaration ====================
    declaration: z.boolean(),
    applicationDate: z.string().optional(),
    placeOfApplication: z.string().optional(),
  })
  .superRefine((data, ctx) => {
    // Temporary Address
    if (!data.sameAsPermanent) {
      if (!data.temporaryProvince)
        ctx.addIssue({ code: "custom", message: "Temporary Province is required", path: ["temporaryProvince"] });
      if (!data.temporaryDistrict)
        ctx.addIssue({ code: "custom", message: "Temporary District is required", path: ["temporaryDistrict"] });
      if (!data.temporaryMunicipality)
        ctx.addIssue({ code: "custom", message: "Temporary Municipality is required", path: ["temporaryMunicipality"] });
      if (!data.temporaryWard)
        ctx.addIssue({ code: "custom", message: "Temporary Ward is required", path: ["temporaryWard"] });
    }

    // Disability
    if (data.disabilityStatus && data.disabilityStatus !== "None" && !data.disabilityType) {
      ctx.addIssue({ code: "custom", message: "Disability Type is required", path: ["disabilityType"] });
    }

    // Guardian
    if (data.primaryContact === "Guardian") {
      if (!data.guardianName)
        ctx.addIssue({ code: "custom", message: "Guardian Name is required", path: ["guardianName"] });
      if (!data.guardianMobile)
        ctx.addIssue({ code: "custom", message: "Guardian Mobile is required", path: ["guardianMobile"] });
    }

    // Scholarship
    if (data.feeCategory === "Scholarship" && !data.scholarshipType) {
      ctx.addIssue({ code: "custom", message: "Scholarship Type is required", path: ["scholarshipType"] });
    }

    // Declaration
    if (!data.declaration) {
      ctx.addIssue({ code: "custom", message: "You must accept the declaration", path: ["declaration"] });
    }
  });

export type FormType = z.infer<typeof formSchema>;