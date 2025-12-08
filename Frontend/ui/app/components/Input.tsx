// app/components/Input.tsx
import React from "react";

type Props = {
  label: string;
  name: string;
  register: any;
  error?: string;
  type?: string;
  className?: string;
};

export default function Input({ label, name, register, error, type = "text", className = "" }: Props) {
  return (
    <div className={className}>
      <label className="block mb-1 text-sm font-medium">{label}</label>
      <input
        type={type}
        {...register(name)}
        className="w-full border rounded px-3 py-2 text-sm"
      />
      {error && <p className="text-red-500 text-xs mt-1">{error}</p>}
    </div>
  );
}