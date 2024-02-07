namespace Mt.Utilities.Exceptions;

/// <summary>
/// Базовое исключение МТ.
/// </summary>
public class MtBaseException : Exception
{
    /// <summary>
    /// Инициализация нового экземпляра класса <see cref="MtBaseException"/>.
    /// </summary>
    /// <param name="innerException">Внутреннее исключение.</param>
    /// <param name="title">Номер ошибки.</param>
    /// <param name="message">Текстовое описание ошибки.</param>
    public MtBaseException(Exception? innerException, string title, string? message)
        : base(message, innerException)
    {
        Title = title;
    }

    /// <summary>
    /// Инициализация нового экземпляра класса <see cref="MtBaseException"/>.
    /// </summary>
    /// <param name="title">Номер ошибки.</param>
    /// <param name="message">Текстовое описание ошибки.</param>
    public MtBaseException(string title, string message)
        : this(null, title, message)
    {
    }

    /// <summary>
    /// Инициализация нового экземпляра класса <see cref="MtBaseException"/>.
    /// </summary>
    /// <param name="title">Номер ошибки.</param>
    public MtBaseException(string title)
        : this(null, title, null)
    {
    }

    /// <summary>
    /// Номер ошибки (текстовый формат).
    /// </summary>
    public string Title { get; private set; }

    /// <summary>
    /// Текст (описание) ошибки.
    /// </summary>
    public string Desc => base.Message;

    /// <summary>
    /// Текст сообщения исключения.
    /// </summary>
    public override string Message => $"{Title}: {base.Message}";
}