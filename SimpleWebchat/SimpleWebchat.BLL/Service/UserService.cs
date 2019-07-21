using SimpleWebchat.BLL.ViewModels;
using SimpleWebchat.DAL.Entities;
using SimpleWebchat.DAL.Repository;
using System.Collections.Generic;

namespace SimpleWebchat.BLL.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public void UserCreate(UserViewmodel _user)
        {
            if (_user != null)
            {
                User usr = new User();
                usr.Email = _user.Email;
                usr.Password = _user.Password;
                usr.Username = _user.Username;
                usr.UserRole = _user.UserRole;
                usr.UserVariance = _user.UserVariance;
                _userRepository.Insert(usr);
            }
        }
        public void UserDelete(UserViewmodel _user)
        {
            User user = _userRepository.FirstOrDefault(x=>x.UserID==_user.UserID);
            if (user != null)
            {
                User usr = new User();
                usr.UserID = _user.UserID;
                usr.Email = _user.Email;
                usr.Password = _user.Password;
                usr.Username = _user.Username;
                usr.UserRole = _user.UserRole;
                usr.UserVariance = _user.UserVariance;
                _userRepository.Delete(x => x.UserID == _user.UserID);
            }
        }
        public User Login(string username, string password)
        {
            return _userRepository.FirstOrDefault(x => x.Username == username && x.Password == password);
        }

        public List<UserViewmodel> GetAllUser()
        {
            var users = _userRepository.GetAll();
            List<UserViewmodel> userList = new  List<UserViewmodel>();
            foreach (var item in users)
            {
                UserViewmodel user= new UserViewmodel();
                user.UserID = item.UserID;
                user.Email = item.Email;
                user.Password = item.Password;
                user.Username = item.Username;
                user.UserVariance = item.UserVariance;
                user.UserRole = item.UserRole;
                userList.Add(user);
            }
            return userList;
        }
    }
}
