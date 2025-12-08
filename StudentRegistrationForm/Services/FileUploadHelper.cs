using System.Text.RegularExpressions;

namespace StudentRegistrationForm.Services
{
    public class FileUploadHelper
    {
        private readonly IWebHostEnvironment _env;

        public FileUploadHelper(IWebHostEnvironment env)
        {
            _env = env;
        }

        public string? SaveBase64Image(string? base64String, string folder)
        {
            if (string.IsNullOrWhiteSpace(base64String))
                return null;

            // "data:image/jpeg;base64," wala part hatao
            var match = Regex.Match(base64String.Trim(),
                @"^data:(image|application)/(png|jpeg|jpg|gif|webp|pdf);base64,(.*)$",
                RegexOptions.IgnoreCase);

            if (!match.Success)
                return null; // Invalid format

            var base64Data = match.Groups[3].Value;
            var extension = match.Groups[2].Value.ToLower() switch
            {
                "png" => ".png",
                "jpeg" or "jpg" => ".jpg",
                "gif" => ".gif",
                "webp" => ".webp",
                "pdf" => ".pdf",
                _ => ".jpg"
            };

            try
            {
                var bytes = Convert.FromBase64String(base64Data);

                var folderPath = Path.Combine(_env.WebRootPath, "uploads", folder);
                Directory.CreateDirectory(folderPath);

                var fileName = $"{Guid.NewGuid()}{extension}";
                var filePath = Path.Combine(folderPath, fileName);

                File.WriteAllBytes(filePath, bytes);

                // Return URL jo browser mein open ho sake
                return $"/uploads/{folder}/{fileName}";
            }
            catch
            {
                return null; // Galat base64
            }
        }
    }
}