using FlubuCore.Context.FluentInterface.Interfaces;
using FlubuCore.Targeting;

namespace FlubuCore.Context.FluentInterface
{
    public interface IFluentInterfaceFactory
    {
        ITargetFluentInterface GetTargetFluentInterface(ITarget target, ITaskContextInternal taskContext);

        ITaskFluentInterface GetTaskFluentInterface(ITaskContextInternal taskContext);

        ICoreTaskFluentInterface GetCoreTaskFluentInterface(ITaskContextInternal taskContext);
    }
}