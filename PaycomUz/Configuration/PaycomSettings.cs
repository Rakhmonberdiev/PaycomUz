
namespace PaycomUz.Configuration
{
    /// <summary>
    /// Настройки для подключения к Paycom Merchant API.
    /// Подключаются через конфигурацию (например, appsettings.json).
    /// </summary>
    public class PaycomSettings
    {
        /// <summary>
        /// Уникальный идентификатор мерчанта (из кабинета Paycom)
        /// </summary>
        public string MerchantId { get; set; } = null!;

        /// <summary>
        /// Секретный ключ (из настроек кассы)
        /// </summary>
        public string MerchantKey { get; set; } = null!;

        /// <summary>
        /// Разрешённые IP-адреса Paycom
        /// </summary>
        public string[] AllowedIPs { get; set; } = Array.Empty<string>();

        /// <summary>
        /// Логин мерчанта (используется для аутентификации)
        /// </summary>
        public string MerchantLogin { get; set; } = null!;

    }
}
