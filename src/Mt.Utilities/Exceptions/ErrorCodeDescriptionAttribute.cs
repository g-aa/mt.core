using System.ComponentModel;

namespace Mt.Utilities.Exceptions;

/// <summary>
/// Атрибут описание поля МТ.
/// </summary>
[AttributeUsage(AttributeTargets.Field)]
public sealed class ErrorCodeDescriptionAttribute : DescriptionAttribute
{
    /// <summary>
    /// Статус код протокола Http.
    /// </summary>
    public int HttpStatusCode { get; private set; }

    /// <summary>
    /// Инициализация нового экземпляра класса <see cref="ErrorCodeDescriptionAttribute"/>.
    /// </summary>
    /// <param name="httpStatusCode">Http статус код.</param>
    /// <param name="description">Описание.</param>
    public ErrorCodeDescriptionAttribute(int httpStatusCode, string description)
        : base(description)
    {
        this.HttpStatusCode = Check.FromInterval(httpStatusCode, nameof(httpStatusCode), 100, 500);
    }
}