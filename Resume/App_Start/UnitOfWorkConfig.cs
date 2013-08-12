//using Ninject;
//using Resume.Core.Interfaces;
//using Resume.Infrastructure.EntityFramework;
//using Resume.Infrastructure.Repositories;

//namespace Resume.Web
//{
//    public class UnitOfworkConfig
//    {
//        public static void RegisterUnitOfWork()
//        {
//            var kernel = new StandardKernel();
//            kernel.Bind<IUnitOfWork>().To<SimpleUnitOfWork>();
//            kernel.Bind<IRepository<T>>().To<Repository<T>>();
//        }
//    }
//}