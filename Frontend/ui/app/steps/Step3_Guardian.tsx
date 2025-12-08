// app/steps/Step3_Guardian.tsx
import React from "react";
import Input from "../components/Input";
import Select from "../components/Select";

const primaryContactOptions = [
  { value: "Father", label: "Father" },
  { value: "Mother", label: "Mother" },
  { value: "Guardian", label: "Guardian" },
];

export default function Step3_Guardian({ form }: { form: any }) {
  const { register, watch, formState: { errors } } = form;
  const primaryContact = watch("primaryContact");

  return (
    <div className="space-y-6">
      <h2 className="text-2xl font-semibold">Parent/Guardian Details</h2>

      <h3 className="text-lg font-semibold">Father's Details</h3>
      <div className="grid grid-cols-3 gap-4">
        <Input label="Full Name *" name="fatherName" register={register} error={errors.fatherName?.message} />
        <Input label="Occupation" name="fatherOccupation" register={register} error={errors.fatherOccupation?.message} />
        <Input label="Designation" name="fatherDesignation" register={register} error={errors.fatherDesignation?.message} />
      </div>

      <div className="grid grid-cols-3 gap-4">
        <Input label="Organization" name="fatherOrganization" register={register} error={errors.fatherOrganization?.message} />
        <Input label="Mobile Number *" name="fatherMobile" register={register} error={errors.fatherMobile?.message} />
        <Input label="Email" name="fatherEmail" register={register} error={errors.fatherEmail?.message} />
      </div>

      <h3 className="text-lg font-semibold">Mother's Details</h3>
      <div className="grid grid-cols-3 gap-4">
        <Input label="Full Name *" name="motherName" register={register} error={errors.motherName?.message} />
        <Input label="Occupation" name="motherOccupation" register={register} error={errors.motherOccupation?.message} />
        <Input label="Designation" name="motherDesignation" register={register} error={errors.motherDesignation?.message} />
      </div>

      <div className="grid grid-cols-3 gap-4">
        <Input label="Organization" name="motherOrganization" register={register} error={errors.motherOrganization?.message} />
        <Input label="Mobile Number *" name="motherMobile" register={register} error={errors.motherMobile?.message} />
        <Input label="Email" name="motherEmail" register={register} error={errors.motherEmail?.message} />
      </div>

      <Select label="Primary Contact *" name="primaryContact" register={register} options={primaryContactOptions} error={errors.primaryContact?.message} />

      {primaryContact === "Guardian" && (
        <div>
          <h3 className="text-lg font-semibold">Legal Guardian's Details</h3>
          <div className="grid grid-cols-3 gap-4">
            <Input label="Full Name *" name="guardianName" register={register} error={errors.guardianName?.message} />
            <Input label="Relation *" name="guardianRelation" register={register} error={errors.guardianRelation?.message} />
            <Input label="Occupation" name="guardianOccupation" register={register} error={errors.guardianOccupation?.message} />
          </div>

          <div className="grid grid-cols-3 gap-4">
            <Input label="Mobile Number *" name="guardianMobile" register={register} error={errors.guardianMobile?.message} />
            <Input label="Email" name="guardianEmail" register={register} error={errors.guardianEmail?.message} />
          </div>
        </div>
      )}

      <Select label="Annual Family Income" name="annualFamilyIncome" register={register} options={[
        { value: "<5 Lakh", label: "<5 Lakh" },
        { value: "5-10 Lakh", label: "5-10 Lakh" },
        { value: "10-20 Lakh", label: "10-20 Lakh" },
        { value: ">20 Lakh", label: ">20 Lakh" },
      ]} error={errors.annualFamilyIncome?.message} />
    </div>
  );
}