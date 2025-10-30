using MicroRabbit.Banking.Application.Models;
using MicroRabbit.Banking.Domain.Modles;

namespace MicroRabbit.Banking.Application.Interfaces
{
    public interface IAccountService
    {
        IEnumerable<Account> GetAccounts();
        void Transfer(AccountTransfer accountTransfer);
    }
}
