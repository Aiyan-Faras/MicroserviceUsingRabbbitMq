namespace MicroRabbit.Transfer.Domain.Modles
{
    public class TransferLog
    {
        public int Id { get; set; }
        public int FromAccount { get; set; } 
        public int ToAccount { get; set; } 
        public decimal TransferAmmount { get; set; }
    }
}
