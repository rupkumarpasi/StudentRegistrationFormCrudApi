// app/steps/Step7_Declaration.tsx
import React from "react";
import Input from "../components/Input";
import Checkbox from "../components/Checkbox";

export default function Step7_Declaration({ form }: { form: any }) {
  const { register, formState: { errors } } = form;

  return (
    <div className="space-y-8">
      <h2 className="text-2xl font-semibold text-indigo-600">Declaration & Submit</h2>

      <div className="bg-yellow-50 border border-yellow-300 p-6 rounded-lg">
        <h3 className="font-semibold text-lg mb-4">Declaration</h3>
        <p className="text-sm text-gray-700 mb-6">
          I hereby declare that all the information provided above is true and correct to the best of my knowledge.
          I understand that any false information may lead to cancellation of my admission.
        </p>

        <Checkbox
          label="I accept the declaration *"
          name="declaration"
          register={register}
          error={errors.declaration?.message}
        />
      </div>

      <div className="grid grid-cols-2 gap-4">
        <Input
          label="Date of Application"
          name="applicationDate"
          type="date"
          register={register}
          error={errors.applicationDate?.message}
        />
        <Input
          label="Place of Application"
          name="placeOfApplication"
          register={register}
          error={errors.placeOfApplication?.message}
        />
      </div>

   
    </div>
  );
}