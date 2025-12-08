// app/steps/Step2_Address.tsx
import React from "react";
import Input from "../components/Input";
import Select from "../components/Select";
import Checkbox from "../components/Checkbox";
import { geo } from "../../lib/geo";

export default function Step2_Address({ form }: { form: any }) {
  const { register, watch, formState: { errors } } = form;
  const sameAsPermanent = watch("sameAsPermanent");

  // Permanent Address
  const permanentProvince = watch("permanentProvince");
  const permanentDistrict = watch("permanentDistrict");

  // Temporary Address
  const temporaryProvince = watch("temporaryProvince");
  const temporaryDistrict = watch("temporaryDistrict");

  return (
    <div className="space-y-8">
      <h2 className="text-2xl font-bold text-indigo-700">Address Details</h2>

      {/* Permanent Address */}
      <div className="bg-white p-6 rounded-lg shadow">
        <h3 className="text-xl font-semibold mb-4 text-gray-800">Permanent Address</h3>
        <div className="grid grid-cols-1 md:grid-cols-3 gap-4">
          <Select
            label="Province *"
            name="permanentProvince"
            register={register}
            options={geo.provinces}
            error={errors.permanentProvince?.message}
          />
          <Select
            label="District *"
            name="permanentDistrict"
            register={register}
            options={
              permanentProvince
                ? (geo.districts[permanentProvince as keyof typeof geo.districts] || [])
                    .map((d: string) => ({ value: d, label: d }))
                : []
            }
            error={errors.permanentDistrict?.message}
          />
          <Select
            label="Municipality/VDC *"
            name="permanentMunicipality"
            register={register}
            options={
              permanentDistrict
                ? (geo.municipalities?.[permanentDistrict as keyof typeof geo.municipalities] || [])
                    .map((d: string) => ({ value: d, label: d }))
                : []
            }
            error={errors.permanentMunicipality?.message}
          />
        </div>

        <div className="grid grid-cols-1 md:grid-cols-3 gap-4 mt-4">
          <Input label="Ward Number *" name="permanentWard" register={register} error={errors.permanentWard?.message} />
          <Input label="Tole/Street" name="permanentTole" register={register} error={errors.permanentTole?.message} />
          <Input label="House Number" name="permanentHouseNo" register={register} error={errors.permanentHouseNo?.message} />
        </div>
      </div>

      {/* Same as Permanent Checkbox */}
      <Checkbox
        label="Temporary Address same as Permanent Address?"
        name="sameAsPermanent"
        register={register}
        error={errors.sameAsPermanent?.message}
      />

      {/* Temporary Address */}
      {!sameAsPermanent && (
        <div className="bg-blue-50 p-6 rounded-lg shadow">
          <h3 className="text-xl font-semibold mb-4 text-gray-800">Temporary Address</h3>
          <div className="grid grid-cols-1 md:grid-cols-3 gap-4">
            <Select
              label="Province"
              name="temporaryProvince"
              register={register}
              options={geo.provinces}
              error={errors.temporaryProvince?.message}
            />
            <Select
              label="District"
              name="temporaryDistrict"
              register={register}
              options={
                temporaryProvince
                  ? (geo.districts[temporaryProvince as keyof typeof geo.districts] || [])
                      .map((d: string) => ({ value: d, label: d }))
                  : []
              }
              error={errors.temporaryDistrict?.message}
            />
            <Select
              label="Municipality/VDC"
              name="temporaryMunicipality"
              register={register}
              options={
                temporaryDistrict
                  ? (geo.municipalities?.[temporaryDistrict as keyof typeof geo.municipalities] || [])
                      .map((d: string) => ({ value: d, label: d }))
                  : []
              }
              error={errors.temporaryMunicipality?.message}
            />
          </div>

          <div className="grid grid-cols-1 md:grid-cols-3 gap-4 mt-4">
            <Input label="Ward Number" name="temporaryWard" register={register} error={errors.temporaryWard?.message} />
            <Input label="Tole/Street" name="temporaryTole" register={register} error={errors.temporaryTole?.message} />
            <Input label="House Number" name="temporaryHouseNo" register={register} error={errors.temporaryHouseNo?.message} />
          </div>
        </div>
      )}
    </div>
  );
}