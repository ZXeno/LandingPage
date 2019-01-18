using LandingPage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandingPage.DataLayer.Repository
{
    public interface IRepository
    {
        PostModel GetPost(int id);
        List<PostModel> GetAllPosts();
        void AddPost(PostModel post);
        void UpdatePost(PostModel post);
        void RemovePost(int id);
        Task<bool> SaveChangesAsync();
    }
}
