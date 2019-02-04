using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace LandingPage.DataLayer
{
    public interface IFileManager
    {

        FileStream ImageStream(string image);
        List<string> ListUploadedImages();

        /// <summary>
        /// Uploads and replaces the existing profile image.
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        Task<string> SaveProfileImage(IFormFile image);

        /// <summary>
        /// Uploads an Image to the image upload directory.
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        Task<string> SaveImage(IFormFile image);

        /// <summary>
        /// Uploads a file to the "projectupload" filder.
        /// </summary>
        /// <param name="nonImagefile"></param>
        /// <returns></returns>
        Task<string> UploadProjectFile(IFormFile projectFile);
    }
}
