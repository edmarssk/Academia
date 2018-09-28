[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Academia.Mvc.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Academia.Mvc.App_Start.NinjectWebCommon), "Stop")]

namespace Academia.Mvc.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Web.Common.WebHost;
    using Infra.CrossCutting.IoC;

    //using Infra.CrossCutting.IoC;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = RegisterServices();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                //RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// eu poderia fazer isso, mas n�o � o correto
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        //private static void RegisterServices(IKernel kernel)
        //{
        //    //Aqui voc� teria que colocar todas as suas inje���es de dependencias no projeto Presention, mas n�o fica legal
        //    kernel.Bind<IClienteAppService>.To<ClienteAppService>();
        //}


        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static StandardKernel RegisterServices()
        {
            
            return new Container().GetModule();
        }
    }
}
