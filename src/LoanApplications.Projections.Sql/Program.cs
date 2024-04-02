using Autofac;
using Autofac.Extensions.DependencyInjection;
using Framework.Core;
using Framework.Persistence.ES;
using LoanApplications.Projections.Sql;

IHost host = Host.CreateDefaultBuilder(args)
    .UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(autofac =>
    {
        autofac.RegisterModule<ProjectionModule>();
    })
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
    })
    
    .Build();

host.Run();
