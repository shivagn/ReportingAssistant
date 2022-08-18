using System;

using Unity;
using Reporting.RepositoryContracts;
using Reporting.RepositoryLayer;
using Reporting.ServiceContracts;
using Reporting.ServiceLayer;

namespace ReportingAssistant
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your type's mappings here.
            container.RegisterType<IAspNetUsersRepository, AspNetUserRepository>();
            container.RegisterType<IAspNetRolesRepository, AspNetRoleRepository>();
            container.RegisterType<IAspNetRolesService, AspNetRoleService>();
            container.RegisterType<IAspNetUsersService, AspNetUserService>();
            container.RegisterType<ITasksRepository, TaskRepository>();
            container.RegisterType<ITasksService, TaskService>();
            container.RegisterType<ITasksDoneRepository, TaskDoneRepository>();
            container.RegisterType<ITasksDoneService, TaskDoneService>();
            container.RegisterType<IProjectsRepository, ProjectRepository>();   
            container.RegisterType<IProjectsService, ProjectService>();
            container.RegisterType<IFinalCommentsRepository, FinalCommentRepository>();
            container.RegisterType<IFinalCommentsService, FinalCommentService>();
            container.RegisterType<ICategoriesRepository, CategoryRepository>();
            container.RegisterType<ICategoriesService, CategoryService>();
        }
    }
}