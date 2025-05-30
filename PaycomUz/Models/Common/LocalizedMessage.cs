
namespace PaycomUz.Models.Common
{
    /// <summary>
    /// Модель для хранения локализованных сообщений на 3 языках.
    /// Используется в PaymeError.
    /// </summary>
    public class LocalizedMessage
    {
        public string Uz { get; set; } = string.Empty;
        public string Ru { get; set; } = string.Empty;
        public string En { get; set; } = string.Empty;
    }
}
