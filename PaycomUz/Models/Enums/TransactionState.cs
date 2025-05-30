

namespace PaycomUz.Models.Enums
{
    /// <summary>
    /// Статусы транзакции по спецификации Paycom:
    /// 2 - успешно оплачено
    /// 1 - ожидает оплаты
    /// -1 - отменено до оплаты
    /// -2 - отменено после оплаты
    /// </summary>
    public class TransactionState
    {
        public const int Paid = 2;
        public const int Pending = 1;
        public const int PendingCanceled = -1;
        public const int PaidCanceled = -2;
    }
}
