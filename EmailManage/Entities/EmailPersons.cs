namespace EmailManage.Entities
{
    public class EmailPersons
    {
        // Уникальный идентификатор сообщения
        public int Id { get; set; }

        // Тема сообщения, обязательное поле
        public required string Title { get; set; }

        // Дата отправки сообщения
        public DateTime DateSent { get; set; }

        // Получатель сообщения (по умолчанию пустая строка)
        public string Recipient { get; set; } = string.Empty;

        // Отправитель сообщения (по умолчанию пустая строка)
        public string Sender { get; set; } = string.Empty;

        // Содержимое сообщения (по умолчанию пустая строка)
        public string Content { get; set; } = string.Empty;

    }
}
