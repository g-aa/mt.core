using Mt.Utilities.Extensions;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace Mt.Utilities.Exceptions;

/// <summary>
/// Исключение МТ.
/// </summary>
[Serializable]
public class MtException : MtBaseException
{
    /// <summary>
    /// Код ошибки.
    /// </summary>
    public ErrorCode Code { get; private set; }

    /// <summary>
    /// Инициализация нового экземпляра класса <see cref="MtException"/>.
    /// </summary>
    /// <param name="innerException">Внутреннее исключение.</param>
    /// <param name="code">Код ошибки.</param>
    /// <param name="message">Текстовое описание ошибки.</param>
    public MtException(Exception? innerException, ErrorCode code, string? message)
        : base(innerException, code.Title(), string.IsNullOrWhiteSpace(message) ? code.Desc() : message)
    {
        this.Code = code;
    }

    /// <summary>
    /// Инициализация нового экземпляра класса <see cref="MtException"/>.
    /// </summary>
    /// <param name="code">Код ошибки.</param>
    /// <param name="message">Текстовое описание ошибки.</param>
    public MtException(ErrorCode code, string message)
        : this(null, code, message)
    {
    }

    /// <summary>
    /// Инициализация нового экземпляра класса <see cref="MtException"/>.
    /// </summary>
    /// <param name="code">Код ошибки.</param>
    public MtException(ErrorCode code)
        : this(null, code, null)
    {
    }

    /// <inheritdoc />
    protected MtException([NotNull] SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
    }
}