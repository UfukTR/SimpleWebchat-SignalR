using SimpleWebchat.BLL.ViewModels;
using SimpleWebchat.DAL.Entities;
using System.Collections.Generic;


namespace SimpleWebchat.BLL.Service
{
    public interface IUserService
    {
        void UserCreate(UserViewmodel _user);
        void UserDelete(UserViewmodel _user);
        User Login(string username, string password);
        List<UserViewmodel> GetAllUser();
    }
}
