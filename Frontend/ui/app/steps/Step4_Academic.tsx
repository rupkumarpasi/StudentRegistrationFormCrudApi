// app/steps/Step4_Academic.tsx
import React from "react";
import Input from "../components/Input";
import Select from "@/app/components/Select";
import FileUpload from "@/app/components/FileUpload";
import { geo } from "../../lib/geo";

export default function Step4_Academic({ form }: { form: any }) {
    const { register, watch,setValue, formState: { errors } } = form;
    
          const currentFaculty = watch("faculty") as keyof typeof geo.programs;

    return (
        <div className="space-y-6">
            <h2 className="text-2xl font-semibold">Academic Details</h2>

            <div className="grid grid-cols-3 gap-4">
                <Select label="Faculty/School *" name="faculty" register={register} options={geo.faculties} error={errors.faculty?.message} />

<Select
  label="Program *"
  name="program"
  register={register}
  options={
    currentFaculty && geo.programs[currentFaculty]
      ? geo.programs[currentFaculty].map((p) => ({ value: p, label: p }))
      : []
  }
  error={errors.program?.message}
/>
                <Select label="Course/Level *" name="level" register={register} options={geo.levels.map(l => ({ value: l, label: l }))} error={errors.level?.message} />
            </div>

            <div className="grid grid-cols-3 gap-4">
                <Select label="Academic Year *" name="academicYear" register={register} options={geo.academicYears.map(y => ({ value: y, label: y }))} error={errors.academicYear?.message} />
                <Select label="Semester/Class *" name="semester" register={register} options={geo.semesters.map(s => ({ value: s, label: s }))} error={errors.semester?.message} />
                <Select label="Section *" name="section" register={register} options={geo.sections.map(s => ({ value: s, label: s }))} error={errors.section?.message} />
            </div>

            <div className="grid grid-cols-3 gap-4">
                <Input label="Roll Number *" name="rollNo" register={register} error={errors.rollNo?.message} />
                <Input label="Registration Number *" name="regNo" register={register} error={errors.regNo?.message} />
                <Input type="date" label="Enroll Date *" name="enrollDate" register={register} error={errors.enrollDate?.message} />
            </div>

            <Select label="Academic Status" name="academicStatus" register={register} options={[{ value: "Active", label: "Active" }, { value: "On Hold", label: "On Hold" }]} error={errors.academicStatus?.message} />

            <h3 className="text-lg font-semibold">Previous Academic History</h3>
            <div className="grid grid-cols-3 gap-4">
                <Input label="Qualification *" name="qualification" register={register} error={errors.qualification?.message} />
                <Input label="Board/University *" name="board" register={register} error={errors.board?.message} />
                <Input label="Institution Name *" name="institution" register={register} error={errors.institution?.message} />
            </div>

            <div className="grid grid-cols-3 gap-4">
                <Input type="number" label="Passed Year *" name="passedYear" register={register} error={errors.passedYear?.message} />
                <Input label="Division/GPA *" name="division" register={register} error={errors.division?.message} />
                <FileUpload label="Marksheet Document" name="marksheetBase64" setValue={setValue} error={errors.marksheetBase64?.message} accept="image/png, image/jpeg" />
            </div>

            <h3 className="text-lg font-semibold">Documents</h3>
            <div className="grid grid-cols-3 gap-4">
                <FileUpload label="Signature *" name="signatureBase64" setValue={setValue} error={errors.signatureBase64?.message} accept="image/png, image/jpeg" />
                <FileUpload label="Citizenship Copy *" name="citizenshipBase64" setValue={setValue} error={errors.citizenshipBase64?.message} accept="image/png, image/jpeg, application/pdf" />
                <FileUpload label="Character Certificate" name="characterCertificateBase64" setValue={setValue} error={errors.characterCertificateBase64?.message} accept="application/pdf" />
            </div>
        </div>
    );
}