using System;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Hosting.Startup;
using Microsoft.Framework.DependencyInjection;

namespace Microsoft.AspNet.SignalR.Tests
{
    /// <summary>
    /// Summary description for ServiceProviderHelper
    /// </summary>
    public class ServiceProviderHelper
    {
        public static IServiceProvider CreateServiceProvider()
        {
            return CreateServiceProvider(_ => { });
        }

        public static IServiceProvider CreateServiceProvider(Action<IServiceCollection> configure)
        {
            var context = new HostingContext();
            // REVIEW: currently two ways to muck with configureServices (Startup or context.Services)
            context.StartupMethods = new StartupMethods(_ => { }, configureServices: null);
            context.Services.AddSignalR();
            configure(context.Services);
            return HostingEngine.CreateApplicationServices(context);
        }
    }
}