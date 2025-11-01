using MicroRabbit.Transfer.Domain.Modles;

namespace MicroRabbit.Transfer.Domain.Interfaces
{
    public  interface ITransferRepository
    {
        IEnumerable<TransferLog> GetTransferLogs();
    }
}
