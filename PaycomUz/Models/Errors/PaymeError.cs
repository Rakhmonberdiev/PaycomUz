
using PaycomUz.Models.Common;

namespace PaycomUz.Models.Errors
{
    /// <summary>
    /// Модель ошибок, соответствующая документации Payme.
    /// Содержит предопределённые ошибки с кодами и сообщениями на 3 языках.
    /// </summary>
    public class PaymeError
    {
        public string Name { get; set; } = string.Empty;
        public int Code { get; set; }
        public LocalizedMessage Message { get; set; } = new();

        public static PaymeError InvalidAmount => new()
        {
            Name = "InvalidAmount",
            Code = -31001,
            Message = new LocalizedMessage
            {
                Uz = "Noto'g'ri summa",
                Ru = "Недопустимая сумма",
                En = "Invalid amount"
            }
        };
        public static PaymeError CantDoOperation => new()
        {
            Name = "CantDoOperation",
            Code = -31008,
            Message = new LocalizedMessage
            {
                Uz = "Biz operatsiyani bajara olmaymiz",
                Ru = "Мы не можем сделать операцию",
                En = "We can't do operation"
            }
        };

        public static PaymeError TransactionNotFound => new()
        {
            Name = "TransactionNotFound",
            Code = -31003,
            Message = new LocalizedMessage
            {
                Uz = "Tranzaktsiya topilmadi",
                Ru = "Транзакция не найдена",
                En = "Transaction not found"
            }
        };
        public static PaymeError Pending => new()
        {
            Name = "Pending",
            Code = -31050,
            Message = new LocalizedMessage
            {
                Uz = "To'lov kutilayapti",
                Ru = "Ожидается оплата",
                En = "Payment is pending"
            }
        };
        public static PaymeError InvalidAuthorization => new()
        {
            Name = "InvalidAuthorization",
            Code = -32504,
            Message = new LocalizedMessage
            {
                Uz = "Avtorizatsiya yaroqsiz",
                Ru = "Авторизация недействительна",
                En = "Authorization invalid"
            }
        };
    }
}
