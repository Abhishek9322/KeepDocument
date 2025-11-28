namespace KeepDocument.Helpers.DocumentHelper
{
    public static class FileHelper
    {
        public static async Task<string> SaveFile(IFormFile file,string rootPath)
        {
            var folderPath=Path.Combine(rootPath, "Documents");
            if(!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
            var filePath=Path.Combine(folderPath, fileName);

            using(var stream=new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return $"documents/{fileName}"; //relative path

        }


    }
}
