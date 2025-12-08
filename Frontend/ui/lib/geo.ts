// lib/geo.ts
export const geo = {
  // Provinces
  provinces: [
    { value: "Koshi", label: "Koshi" },
    { value: "Madhesh", label: "Madhesh" },
    { value: "Bagmati", label: "Bagmati" },
    { value: "Gandaki", label: "Gandaki" },
    { value: "Lumbini", label: "Lumbini" },
    { value: "Karnali", label: "Karnali" },
    { value: "Sudurpaschim", label: "Sudurpaschim" },
  ],

  // Districts by Province
  districts: {
    Koshi: ["Bhojpur", "Dhankuta", "Ilam", "Jhapa", "Morang", "Sunsari"],
    Madhesh: ["Bara", "Dhanusa", "Mahottari", "Parsa", "Rautahat", "Saptari", "Sarlahi", "Siraha"],
    Bagmati: ["Bhaktapur", "Chitwan", "Dhading", "Kathmandu", "Kavrepalanchok", "Lalitpur", "Nuwakot"],
    Gandaki: ["Baglung", "Gorkha", "Kaski", "Lamjung", "Manang", "Mustang", "Nawalpur"],
    Lumbini: ["Arghakhanchi", "Banke", "Bardiya", "Dang", "Gulmi", "Kapilvastu", "Palpa", "Parasi", "Pyuthan", "Rolpa", "Rupandehi", "Rukum East"],
    Karnali: ["Dailekh", "Dolpa", "Humla", "Jumla", "Kalikot", "Mugu", "Rukum West", "Salyan", "Surkhet"],
    Sudurpaschim: ["Achham", "Baitadi", "Bajhang", "Bajura", "Dadeldhura", "Darchula", "Doti", "Kailali", "Kanchanpur"],
  },

  // Municipalities (Few examples — tu aur add kar sakta hai)
  municipalities: {
    Rupandehi: ["Butwal", "Siddharthanagar", "Tilottama", "Devdaha", "Lumbini Sanskritik", "Sainamaina"],
    Banke: ["Nepalgunj", "Kohalpur"],
    Dang: ["Ghorahi", "Tulsipur"],
    Kathmandu: ["Kathmandu Metropolitan", "Lalitpur Metropolitan", "Bhaktapur Municipality"],
    Pokhara: ["Pokhara Metropolitan"],
    Biratnagar: ["Biratnagar Metropolitan"],
    // Add more as needed
  },

  // YE SABSE ZAROORI HAI — FACULTIES AUR PROGRAMS
  faculties: [
    { value: "Science", label: "Science" },
    { value: "Management", label: "Management" },
    { value: "Humanities", label: "Humanities" },
    { value: "Education", label: "Education" },
  ],

  programs: {
    Science: ["BSc.CSIT", "BCA", "B.Sc Physics", "B.Sc Chemistry", "B.Sc Biology"],
    Management: ["BBA", "BBS", "BHM", "BTTM"],
    Humanities: ["BA", "BSW", "B.Ed English"],
    Education: ["B.Ed", "M.Ed"],
  },

  // Course Level, Years, Semesters, etc.
  levels: ["Bachelor", "Master", "+2", "Diploma"],
  academicYears: ["1st Year", "2nd Year", "3rd Year", "4th Year"],
  semesters: ["1st Semester", "2nd Semester", "3rd Semester", "4th Semester", "5th Semester", "6th Semester", "7th Semester", "8th Semester"],
  sections: ["A", "B", "C", "D"],

  // Blood Groups
  bloodGroups: [
    { value: "A+", label: "A+" },
    { value: "A-", label: "A-" },
    { value: "B+", label: "B+" },
    { value: "B-", label: "B-" },
    { value: "O+", label: "O+" },
    { value: "O-", label: "O-" },
    { value: "AB+", label: "AB+" },
    { value: "AB-", label: "AB-" },
  ],

  // Other dropdowns
  hostellerOptions: ["Hosteller", "Day Scholar"],
  transportationOptions: ["Walk", "Bicycle", "Bus", "Private Vehicle"],
  feeCategories: ["Regular", "Self-Financed", "Scholarship", "Quota"],
  scholarshipTypes: ["Government", "Institutional", "Private"],
};