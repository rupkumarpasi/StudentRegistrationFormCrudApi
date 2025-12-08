// app/register/page.tsx
"use client";

import React, { useState } from "react";
import { useForm, FormProvider } from "react-hook-form";
import { zodResolver } from "@hookform/resolvers/zod";
import { formSchema } from "@/lib/formschema";
import { submitRegistration } from "@/lib/api";

import Step1_Personal from "../steps/Step1_Personal";
import Step2_Address from "../steps/Step2_Address";
import Step3_Guardian from "../steps/Step3_Guardian";
import Step4_Academic from "../steps/Step4_Academic";
import Step5_Financial from "../steps/Step5_Financial";
import Step6_Extracurricular from "../steps/Step6_Extracurricular";
import Step7_Declaration from "../steps/Step7_Declaration";

const steps = [
  "Personal Details",
  "Address",
  "Guardian",
  "Academic",
  "Financial",
  "Extracurricular",
  "Declaration",
] as const;

export default function RegisterPage() {
  const [currentStep, setCurrentStep] = useState(0);
  const [isSubmitting, setIsSubmitting] = useState(false);

  const methods = useForm({
    resolver: zodResolver(formSchema),
    mode: "onBlur",
    defaultValues: {
      applicationDate: new Date().toISOString().split("T")[0],
      placeOfApplication: "Butwal",
      nationality: "Nepali",
      gender: "",
      bloodGroup: "",
      maritalStatus: "Single",
      disabilityStatus: "None",
      sameAsPermanent: false,
      hosteller: "Day Scholar",
      declaration: false,
      extracurriculars: [],
      achievements: [],
      scholarships: [],
      academicHistories: [],
    },
  });

  const { handleSubmit, trigger, watch } = methods;
  const declaration = watch("declaration");

  // YE FUNCTION SABSE ZAROORI HAI — STEP KE HISAAB SE FIELDS VALIDATE KAREGA
  const getFieldsForStep = (step: number): (string | string[])[] => {
    switch (step) {
      case 0:
        return [
          "photoBase64", "firstName", "lastName", "dateOfBirth", "nationality",
          "citizenshipNumber", "citizenshipIssueDate", "citizenshipIssueDistrict",
          "email", "primaryMobile", "emergencyName", "emergencyRelation", "emergencyNumber",
          "gender", "ethnicity", "ethnicityType"
        ];
      case 1:
        return [
          "permanentProvince", "permanentDistrict", "permanentMunicipality", "permanentWard"
        ];
      case 2:
        return ["fatherName", "fatherMobile", "motherName", "motherMobile"];
      case 3:
        return ["faculty", "program", "level", "academicYear", "semester", "section", "rollNo", "regNo", "enrollDate"];
      case 4:
        return ["feeCategory"];
      case 5:
        return ["hosteller"];
      case 6:
        return ["declaration"];
      default:
        return [];
    }
  };

  const nextStep = async () => {
    const fields = getFieldsForStep(currentStep);
    const isValid = await trigger(fields as any);

    if (isValid) {
      setCurrentStep((prev) => Math.min(prev + 1, steps.length - 1));
    } else {
      alert("Please fill all required fields before proceeding!");
    }
  };

  const prevStep = () => {
    setCurrentStep((prev) => Math.max(prev - 1, 0));
  };

  const onSubmit = async (data: any) => {
    if (currentStep !== steps.length - 1) return;

    setIsSubmitting(true);
    try {
      await submitRegistration(data);
      alert("Registration Successful! Student Created.");
      console.log("Submitted Data:", data);
    } catch (error) {
      alert("Registration Failed. Check console.");
      console.error(error);
    } finally {
      setIsSubmitting(false);
    }
  };

  const renderStep = () => {
    switch (currentStep) {
      case 0: return <Step1_Personal form={methods} />;
      case 1: return <Step2_Address form={methods} />;
      case 2: return <Step3_Guardian form={methods} />;
      case 3: return <Step4_Academic form={methods} />;
      case 4: return <Step5_Financial form={methods} />;
      case 5: return <Step6_Extracurricular form={methods} />;
      case 6: return <Step7_Declaration form={methods} />;
      default: return null;
    }
  };

  return (
    <div className="min-h-screen bg-gray-50 py-12">
      <div className="max-w-7xl mx-auto bg-white shadow-2xl rounded-xl p-10">
        <h1 className="text-4xl font-bold text-center text-indigo-700 mb-10">
          Student Registration Form
        </h1>

        {/* Progress Bar */}
        <div className="mb-12">
          <div className="flex justify-between items-center">
            {steps.map((step, index) => (
              <div key={index} className="flex items-center">
                <div className={`w-12 h-12 rounded-full flex items-center justify-center font-bold text-white transition-all ${index <= currentStep ? "bg-indigo-600 scale-110" : "bg-gray-300"}`}>
                  {index + 1}
                </div>
                {index < steps.length - 1 && (
                  <div className={`w-32 h-1 mx-2 transition-all ${index < currentStep ? "bg-indigo-600" : "bg-gray-300"}`} />
                )}
              </div>
            ))}
          </div>
          <p className="text-center mt-6 text-xl font-semibold text-indigo-700">
            Step {currentStep + 1}: {steps[currentStep]}
          </p>
        </div>

        <FormProvider {...methods}>
          <form onSubmit={handleSubmit(onSubmit)} className="space-y-12">
            {renderStep()}

            {/* Navigation */}
            <div className="flex justify-between items-center pt-10 border-t-2 border-gray-200">
              <button
                type="button"
                onClick={prevStep}
                disabled={currentStep === 0}
                className={`px-10 py-4 rounded-lg font-bold text-lg transition-all ${
                  currentStep === 0
                    ? "bg-gray-300 text-gray-500 cursor-not-allowed"
                    : "bg-gray-600 text-white hover:bg-gray-700"
                }`}
              >
                Previous
              </button>

              {currentStep === steps.length - 1 ? (
                <button
                  type="submit"
                  disabled={isSubmitting || !declaration}
                  className={`px-16 py-5 rounded-lg font-bold text-xl text-white transition-all ${
                    isSubmitting || !declaration
                      ? "bg-gray-400 cursor-not-allowed"
                      : "bg-green-600 hover:bg-green-700 shadow-lg"
                  }`}
                >
                  {isSubmitting ? "Submitting..." : "Submit Registration"}
                </button>
              ) : (
                <button
                  type="button"
                  onClick={nextStep}
                  className="px-16 py-5 bg-indigo-600 text-white rounded-lg font-bold text-xl hover:bg-indigo-700 shadow-lg transition-all"
                >
                  Next →
                </button>
              )}
            </div>
          </form>
        </FormProvider>
      </div>
    </div>
  );
}