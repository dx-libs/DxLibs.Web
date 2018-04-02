using System;
#if FW
using Microsoft.Owin;
using Owin;
#elif NETCORE 
using Microsoft.AspNetCore.Builder;
//using Microsoft.Extensions.Logging;
#endif
using Microsoft.Extensions.DependencyInjection;

namespace DxLibs.Web
{
    public abstract class Startup : IStartup
    {
#if FW
        public virtual void Configure(IAppBuilder app)
#elif NETCORE
        public virtual void Configure(IApplicationBuilder app)
#endif
        {
            // Para obtener más información sobre cómo configurar la aplicación, visite https://go.microsoft.com/fwlink/?LinkID=316888
            //RegisterServices();
        }

#if FW
        public virtual void Configuration(IAppBuilder app)
        {
            Configure(app);
        }
#endif

        protected virtual void RegisterServices(IServiceCollection services)
        {
        }

        public virtual IServiceProvider ConfigureServices(IServiceCollection services)
        {
            RegisterServices(services);

            return BuildServiceProvider(services);
        }

        protected abstract IServiceProvider BuildServiceProvider(IServiceCollection services);
    }
}