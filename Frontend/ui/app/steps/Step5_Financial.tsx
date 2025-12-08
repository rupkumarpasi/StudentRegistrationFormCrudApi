// app/steps/Step5_Financial.tsx
import React from "react";
import Input from "../components/Input";
import Select from "../components/Select";

const feeCategories = [
  { value: "Regular", label: "Regular" },
  { value: "Self-Financed", label: "Self-Financed" },
  { value: "Scholarship", label: "Scholarship" },
  { value: "Quota", label: "Quota" },
];

const scholarshipTypes = [
  { value: "Government", label: "Government" },
  { value: "Institutional", label: "Institutional" },
  { value: "Private", label: "Private" },
];

export default function Step5_Financial({ form }: { form: any }) {
  const { register, watch, formState: { errors } } = form;
  const feeCategory = watch("feeCategory");

  return (
    <div className="space-y-6">
      <h2 className="text-2xl font-semibold text-indigo-600">Financial Details</h2>

      <Select
        label="Fee Category *"
        name="feeCategory"
        register={register}
        options={feeCategories}
        error={errors.feeCategory?.message}
      />

      {feeCategory === "Scholarship" && (
        <div className="bg-gray-50 p-6 rounded-lg space-y-4">
          <h3 className="text-lg font-medium">Scholarship Details</h3>
          <Select
            label="Scholarship Type *"
            name="scholarshipType"
            register={register}
            options={scholarshipTypes}
            error={errors.scholarshipType?.message}
          />
          <Input label="Provider Name *" name="scholarshipProvider" register={register} error={errors.scholarshipProvider?.message} />
          <Input type="number" label="Scholarship Amount *" name="scholarshipAmount" register={register} error={errors.scholarshipAmount?.message} />
        </div>
      )}

      <div className="bg-blue-50 p-6 rounded-lg space-y-4">
        <h3 className="text-lg font-medium">Bank Details (for Reimbursement)</h3>
        <div className="grid grid-cols-2 gap-4">
          <Input label="Account Holder Name" name="bankAccountHolder" register={register} error={errors.bankAccountHolder?.message} />
          <Input label="Bank Name" name="bankName" register={register} error={errors.bankName?.message} />
          <Input label="Account Number" name="accountNumber" register={register} error={errors.accountNumber?.message} />
          <Input label="Branch" name="branch" register={register} error={errors.branch?.message} />
        </div>
      </div>
    </div>
  );
}