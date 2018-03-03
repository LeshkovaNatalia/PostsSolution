namespace DependencyResolver
{
    using System.Data.Entity;
    using BLL.Interfacies.Services;
    using BLL.Services;
    using DAL.Concrete;
    using DAL.Interfaces.DTO;
    using DAL.Interfaces.Repository;
    using Ninject;
    using Ninject.Web.Common;
    using ORM;

    public static class ResolverModule
    {
        public static void ConfigurateResolverWeb(this IKernel kernel)
        {
            Configure(kernel, true);
        }

        public static void ConfigurateResolverConsole(this IKernel kernel)
        {
            Configure(kernel, false);
        }

        private static void Configure(IKernel kernel, bool isWeb)
        {
            if (isWeb)
            {
                kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();
                kernel.Bind<DbContext>().To<PostModel>().InRequestScope();
            }
            else
            {
                kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InSingletonScope();
                kernel.Bind<DbContext>().To<PostModel>().InSingletonScope();
            }

            kernel.Bind<IPostService>().To<PostService>();
            kernel.Bind<IPostRepository>().To<PostRepository>();

            kernel.Bind<ICommentService>().To<CommentService>();
            kernel.Bind<ICommentRepository>().To<CommentRepository>();
        }
    }
}
