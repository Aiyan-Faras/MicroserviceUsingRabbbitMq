using MicroRabbit.Banking.Application.Interfaces;
using MicroRabbit.Banking.Application.Models;
using MicroRabbit.Banking.Domain.Commands;
using MicroRabbit.Banking.Domain.Interfaces;
using MicroRabbit.Banking.Domain.Modles;
using MicroRabbit.Domain.Core.Bus;

namespace MicroRabbit.Banking.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IEventBus _eventBus;
        public AccountService(IAccountRepository accountRepository, IEventBus eventBus)
        { 
            _accountRepository = accountRepository;
            _eventBus = eventBus;
        }
        public IEnumerable<Account> GetAccounts()
        {
            return _accountRepository.GetAccounts();
        }

        public void Transfer(AccountTransfer accountTransfer)
        {
            CreateTranferCommand eventMessage = new CreateTranferCommand(
                accountTransfer.FromAccount,
                accountTransfer.ToAccount,
                accountTransfer.TransferAmount
            );

            _eventBus.SendCommand(eventMessage);
        }
    }
}
    