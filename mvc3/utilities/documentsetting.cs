namespace mvc3.utilities
{
    public static class documentsetting
    {
        public static string updatefiles(IFormFile file , string foldername)
        {
            string folderpath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\files", foldername);
            string filename = $"{Guid.NewGuid()}- {file.FileName}";
            string filepath = Path.Combine(folderpath, filename);
            using var Stream = new FileStream(filepath, FileMode.Create);
            file.CopyTo(Stream);
            return filename;
          
        }
        public static void deletefiles(string foldername,string filename)
        {
            string filepath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\files", foldername, filename);
            if (File.Exists(filepath))
            {
                File.Delete(filepath);
            }
        }
    }
}
