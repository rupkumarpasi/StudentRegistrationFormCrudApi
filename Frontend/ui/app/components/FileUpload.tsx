// app/components/FileUpload.tsx
import React, { useState } from "react";

type Props = {
  label: string;
  name: string;
  setValue: any;
  error?: string;
  accept?: string;
  maxSizeInMB?: number;
  className?: string;
};

export default function FileUpload({
  label,
  name,
  setValue,
  error,
  accept = "image/*",
  maxSizeInMB = 5,
  className = "",
}: Props) {
  const [preview, setPreview] = useState<string | null>(null);
  const maxSizeInBytes = maxSizeInMB * 1024 * 1024;

  const handleFileChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const file = e.target.files?.[0];
    if (!file) {
      setValue(name, null);
      setPreview(null);
      return;
    }

    if (file.size > maxSizeInBytes) {
      alert(`File size must be less than ${maxSizeInMB}MB`);
      e.target.value = "";
      return;
    }

    const reader = new FileReader();
    reader.onloadend = () => {
      const base64 = reader.result as string;
      setValue(name, base64, { shouldValidate: true });
      setPreview(base64);
    };
    reader.readAsDataURL(file);
  };

  return (
    <div className={`space-y-2 ${className}`}>
      <label className="block text-sm font-medium text-gray-700">{label}</label>
      <input
        type="file"
        accept={accept}
        onChange={handleFileChange}
        className="block w-full text-sm text-gray-500 file:mr-4 file:py-2 file:px-4 file:rounded-lg file:border-0 file:text-sm file:font-semibold file:bg-indigo-50 file:text-indigo-700 hover:file:bg-indigo-100"
      />
      {preview && (
        <div className="mt-3">
          <img src={preview} alt="Preview" className="w-40 h-40 object-cover rounded-lg border shadow" />
        </div>
      )}
      {error && <p className="text-red-500 text-xs">{error}</p>}
    </div>
  );
}