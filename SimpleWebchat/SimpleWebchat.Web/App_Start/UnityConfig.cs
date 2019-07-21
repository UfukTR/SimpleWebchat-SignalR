using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc5;
using SimpleWebchat.BLL.Service;
using SimpleWebchat.DAL.Repository;

namespace SimpleWebchat.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            // register all your components with the container here
            // it is NOT necessary to register your controllers
             // e.g. container.RegisterType<ITestService, TestService>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            container.RegisterType<IUserRepository, UserRepository>();
            container.RegisterType<IUserService, UserService>();

            container.RegisterType<IMessageRepository, MessageRepository>();
            container.RegisterType<IMessageService, MessageService>();
        }
    }
}