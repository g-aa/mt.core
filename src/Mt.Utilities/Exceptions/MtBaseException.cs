using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace Mt.Utilities.Exceptions;

/// <summary>
/// Базовое исключение МТ.
/// </summary>
[Serializable]
public class MtBaseException : Exception
{
    /// <summary>
    /// Номер ошибки (текстовый формат).
    /// </summary>
    [field: NonSerialized]
    public string Title { get; private set; }

    /// <summary>
    /// Текст (описание) ошибки.
    /// </summary>
    public string Desc { get => base.Message; }

    /// <summary>
    /// Текст сообщения исключения.
    /// </summary>
    public override string Message { get => $"{this.Title}: {base.Message}"; }

    /// <summary>
    /// Инициализация нового экземпляра класса <see cref="MtBaseException"/>.
    /// </summary>
    /// <param name="innerException">Внутреннее исключение.</param>
    /// <param name="title">Номер ошибки.</param>
    /// <param name="message">Текстовое описание ошибки.</param>
    public MtBaseException(Exception? innerException, string title, string? message)
        : base(message, innerException)
    {
        this.Title = title;
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

    /// <inheritdoc />
    protected MtBaseException([NotNull] SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
        Check.NotNull(info, nameof(info));
        this.Title = info.GetString(nameof(this.Title));
    }

    /// <inheritdoc />
    [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
    public override void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        base.GetObjectData(info, context);
        info.AddValue(nameof(this.Title), this.Title);
    }
}