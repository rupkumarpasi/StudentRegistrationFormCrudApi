// app/components/Select.tsx
import React from "react";

type Option = { value: string; label: string };

type Props = {
  label: string;
  name: string;
  register: any;
  error?: string;
  options: Option[];
  className?: string;
};

export default function Select({ label, name, register, error, options, className = "" }: Props) {
  return (
    <div className={className}>
      <label className="block mb-1 text-sm font-medium">{label}</label>
      <select {...register(name)} className="w-full border rounded px-3 py-2 text-sm">
        <option value="">Select...</option>
        {options.map((opt) => (
          <option key={opt.value} value={opt.value}>
            {opt.label}
          </option>
        ))}
      </select>
      {error && <p className="text-red-500 text-xs mt-1">{error}</p>}
    </div>
  );
}