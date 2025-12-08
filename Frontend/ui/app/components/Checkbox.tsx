// app/components/Checkbox.tsx
import React from "react";

type Props = {
  label: string;
  name: string;
  register: any;
  error?: string;
  className?: string;
};

export default function Checkbox({ label, name, register, error, className = "" }: Props) {
  return (
    <div className={className}>
      <label className="flex items-center text-sm">
        <input type="checkbox" {...register(name)} className="mr-2" />
        {label}
      </label>
      {error && <p className="text-red-500 text-xs mt-1">{error}</p>}
    </div>
  );
}