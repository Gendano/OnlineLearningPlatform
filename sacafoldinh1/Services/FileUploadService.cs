
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Threading.Tasks;
namespace sacafoldinh1.Services;
public class FileUploadService
{
    private readonly string _uploadFolder;

    public FileUploadService(IWebHostEnvironment environment)
    {
        // تحديد مجلد التخزين
        _uploadFolder = Path.Combine(environment.WebRootPath, "uploads");

        // إنشاء المجلد إذا لم يكن موجودًا
        if (!Directory.Exists(_uploadFolder))
        {
            Directory.CreateDirectory(_uploadFolder);
        }
    }

    public async Task<string> UploadFileAsync(IFormFile file)
    {
        if (file == null || file.Length == 0) return null;

        // توليد اسم فريد للملف باستخدام GUID
        var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
        var filePath = Path.Combine(_uploadFolder, fileName);

        // حفظ الملف في المجلد
        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        // إرجاع مسار الملف
        return $"/uploads/{fileName}";
    }
}
