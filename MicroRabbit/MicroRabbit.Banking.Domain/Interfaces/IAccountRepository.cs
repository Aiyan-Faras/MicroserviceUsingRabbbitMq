using MicroRabbit.Banking.Domain.Modles;

namespace MicroRabbit.Banking.Domain.Interfaces
{
    public  interface IAccountRepository
    {
        IEnumerable<Account> GetAccounts();
    }
}
