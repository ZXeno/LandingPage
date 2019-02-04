using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace LandingPage.DataLayer
{
    public class FileManager : IFileManager
    {
        const string wwwroot = "wwwroot";
        private readonly string uploadImagePath = string.Empty;
        private readonly string projectUploadPath = string.Empty;
        private readonly string profileImagePath = string.Empty;

        public FileManager(IConfiguration config)
        {
            this.uploadImagePath = config["Path:ImageUploads"];
            this.projectUploadPath = config["Path:ProjectsUpload"];
            this.profileImagePath = "wwwroot" + config["Path:ProfilePicture"];
        }

        public FileStream ImageStream(string image)
        {
            return new FileStream(Path.Combine(uploadImagePath, image), FileMode.Open, FileAccess.Read);
        }

        public List<string> ListUploadedImages()
        {
            string folderPath = Path.Combine(uploadImagePath);
            IEnumerable<string> enumeratedFiles = Directory.EnumerateFiles(folderPath).ToList();
            List<string> files = new List<string>();
            foreach (string file in enumeratedFiles)
            {
                files.Add(Path.GetFileName(file));
            }
            return files;
        }

        public async Task<string> SaveProfileImage(IFormFile image)
        {
            string profileDirectoryPath = Path.GetDirectoryName(profileImagePath);
            string profileImageFullPath = Path.Combine(profileImagePath);
            if (!Directory.Exists(profileDirectoryPath))
            {
                Directory.CreateDirectory(profileDirectoryPath);
            }

            using (FileStream fileStream = new FileStream(profileImageFullPath, FileMode.Create))
            {
                await image.CopyToAsync(fileStream);
            }

            return Path.GetFileName(profileImageFullPath);
        }

        public async Task<string> SaveImage(IFormFile image)
        {
            string directoryPath = Path.Combine(uploadImagePath);
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            string mimeType = image.FileName.Substring(image.FileName.LastIndexOf("."));
            string sourceFileName = image.FileName.Substring(image.FileName.LastIndexOf("\\") + 1);
            sourceFileName = sourceFileName.Remove(sourceFileName.LastIndexOf("."));
            string fileName = $"upld__{DateTime.Now.ToString("yyyy-MM-dd-HH-mm")}__{sourceFileName}{mimeType}";

            using (FileStream fileStream = new FileStream(Path.Combine(directoryPath, fileName), FileMode.Create))
            {
                await image.CopyToAsync(fileStream);
            }

            return fileName;
        }

        public async Task<string> UploadProjectFile(IFormFile projectFile)
        {
            string directoryPath = Path.Combine(projectUploadPath);
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            string mimeType = projectFile.FileName.Substring(projectFile.FileName.LastIndexOf("."));
            string fileName = $"{projectFile.FileName}{mimeType}";
            string fullpath = Path.Combine(directoryPath, fileName);

            if (File.Exists(fullpath))
            {
                File.Move(fullpath, Path.Combine(directoryPath, DateTime.Now.ToString("dd-MM-yyyy-HH-mm-") + "_" + fileName));
            }

            using (FileStream fileStream = new FileStream(fullpath, FileMode.Create))
            {
                await projectFile.CopyToAsync(fileStream);
            }

            return fileName;
        }
    }
}
