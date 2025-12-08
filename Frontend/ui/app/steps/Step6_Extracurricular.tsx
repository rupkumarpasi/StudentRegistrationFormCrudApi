// app/steps/Step6_Extracurricular.tsx
import React from "react";
import Input from "../components/Input";
import Select from "../components/Select";

const hostellerOptions = [
  { value: "Hosteller", label: "Hosteller" },
  { value: "Day Scholar", label: "Day Scholar" },
];

const transportOptions = [
  { value: "Walk", label: "Walk" },
  { value: "Bicycle", label: "Bicycle" },
  { value: "Bus", label: "Public Bus" },
  { value: "Private Vehicle", label: "Private Vehicle" },
];

export default function Step6_Extracurricular({ form }: { form: any }) {
  const { register, watch, setValue, formState: { errors } } = form;

  return (
    <div className="space-y-6">
      <h2 className="text-2xl font-semibold text-indigo-600">Extracurricular & Other Information</h2>

      <div>
        <label className="block text-sm font-medium mb-3">Extracurricular Interests (Select all that apply)</label>
        <div className="grid grid-cols-3 gap-4">
          {["Sports", "Music", "Debate", "Coding", "Volunteering", "Arts", "Other"].map((activity) => (
            <label key={activity} className="flex items-center">
              <input
                type="checkbox"
                value={activity}
                {...register("extracurriculars")}
                className="mr-2"
              />
              <span>{activity}</span>
            </label>
          ))}
        </div>
      </div>

      {watch("extracurriculars")?.includes("Other") && (
        <Input label="Specify Other Activity" name="otherActivity" register={register} error={errors.otherActivity?.message} />
      )}

      <div>
        <h3 className="text-lg font-medium mb-3">Previous Achievements/Awards</h3>
        <div className="space-y-4">
          <div className="grid grid-cols-2 gap-4">
            <Input label="Award Title" name="awardTitle" register={register} />
            <Input label="Issuing Organization" name="issuingOrganization" register={register} />
          </div>
          <Input type="number" label="Year Received" name="yearReceived" register={register} />
        </div>
      </div>

      <Select
        label="Are you Hosteller or Day Scholar? *"
        name="hosteller"
        register={register}
        options={hostellerOptions}
        error={errors.hosteller?.message}
      />

      <Select
        label="Transportation Method"
        name="transportation"
        register={register}
        options={transportOptions}
        error={errors.transportation?.message}
      />
    </div>
  );
}