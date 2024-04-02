using Autofac;
using Framework.Core;
using Framework.Core.Events;
using Framework.Persistence.ES;
using LoanApplications.Projections.Sql.Framework;
using Microsoft.Extensions.Options;

namespace LoanApplications.Projections.Sql
{
    public class ProjectionModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<FakeEventBus>().As<IEventBus>();
            builder.RegisterType<FakeCursor>().As<ICursor>();
            builder.RegisterType<EventTypeResolver>().As<IEventTypeResolver>();

           

            base.Load(builder);
        }
    }
}
