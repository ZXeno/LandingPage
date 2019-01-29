using LandingPage.Models;
using System.Collections.Generic;
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

        ProfileModel GetProfile();
        void UpdateProfile(ProfileModel profileData);

        Task<bool> SaveChangesAsync();
    }
}
