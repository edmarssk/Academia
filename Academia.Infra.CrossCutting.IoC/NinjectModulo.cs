using Academia.Application;
using Academia.Application.Interface;
using Academia.Domain.Interfaces.Repository;
using Academia.Domain.Interfaces.Repository.ReadOnly;
using Academia.Domain.Interfaces.Services;
using Academia.Domain.Services;
using Academia.Infra.Data.Context;
using Academia.Infra.Data.Interface;
using Academia.Infra.Data.Repositories;
using Academia.Infra.Data.Repositories.ReadOnly;
using Academia.Infra.Data.UnitW;
using Ninject.Modules;

namespace Academia.Infra.CrossCutting.IoC
{
    public class NinjectModulo: NinjectModule
    {

        public override void Load()
        {
            // APP
            Bind<IClienteAppService>().To<ClienteAppService>();
            //Domain Services
            Bind<IClienteService>().To<ClienteService>();
            //Data
            Bind(typeof(IBaseRepository<>)).To(typeof(BaseRepository<>));
            Bind<IClienteRepository>().To<ClienteRepository>();
            Bind<IEnderecoRepository>().To<EnderecoRepository>();

            //Data ReadOnly
            Bind<IClienteReadOnlyRepository>().To<ClienteReadOnlyRepository>();

            // Data Config
            Bind<IContextManager>().To<ContextManager>();
            Bind<IUnitOfWork>().To<UnitOfWork>();
        }
    }
}
