

using MicroRabbit.Domain.Core.Bus;
using MicroRabbit.Transfer.Domain.Events;

namespace MicroRabbit.Transfer.Domain.EventHandlers
{
    public class TransferEventHandler : IEventHandler<TranferCreatedEvent>
    {
        public TransferEventHandler()
        {
        }

        public Task Handle(TranferCreatedEvent @event)
        {
            return Task.CompletedTask;
        }
    }
}
