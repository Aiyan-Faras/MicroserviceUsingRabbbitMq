using MediatR;
using MicroRabbit.Banking.Domain.Commands;
using MicroRabbit.Banking.Domain.Events;
using MicroRabbit.Domain.Core.Bus;

namespace MicroRabbit.Banking.Domain.CommandHandlers
{
    public class TransferCommandHandler : IRequestHandler<CreateTranferCommand, bool>
    {
        private readonly IEventBus _eventBus;

        public TransferCommandHandler(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }
        public Task<bool> Handle(CreateTranferCommand request, CancellationToken cancellationToken)
        {
            //publish event to RabbitMQ via bus
            _eventBus.Publish(new TranferCreatedEvent(request.From, request.To, request.Amount));

            return Task.FromResult(true);
        }
    }
}
