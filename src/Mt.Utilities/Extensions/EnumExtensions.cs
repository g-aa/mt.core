using System.ComponentModel;
using System.Reflection;

using Mt.Utilities.Exceptions;

namespace Mt.Utilities.Extensions;

/// <summary>
/// Методы расширения для <see cref="Enum"/>.
/// </summary>
public static class EnumExtensions
{
    /// <summary>
    /// Получить описание значения перечисляемого типа.
    /// </summary>
    /// <remarks>Описание берется из атрибута <see cref="DescriptionAttribute"/> и его производных классах.</remarks>
    /// <param name="enum">Перечисляемый тип.</param>
    /// <returns>Сообщение.</returns>
    public static string Desc(this Enum @enum)
    {
        var attr = @enum.Attribute<DescriptionAttribute>();
        return attr is null ? @enum.ToString() : attr.Description;
    }

    /// <summary>
    /// Получить текстовый заголовок кода ошибки.
    /// </summary>
    /// <param name="code">Код ошибки.</param>
    /// <returns>Текстовый заголовок.</returns>
    public static string Title(this ErrorCode code)
    {
        return $"MT-E{(int)code:D4}";
    }

    /// <summary>
    /// Подучить статус код протокола http.
    /// </summary>
    /// <param name="code">Код ошибки.</param>
    /// <returns>Http код.</returns>
    public static int HttpStatusCode(this ErrorCode code)
    {
        var attr = Attribute<ErrorCodeDescriptionAttribute>(code);
        return attr is null ? 400 : attr.HttpStatusCode;
    }

    /// <summary>
    /// Получить атрибут кода ошибки.
    /// </summary>
    /// <typeparam name="T">Тип атрибута.</typeparam>
    /// <param name="enum">Перечисляемый тип.</param>
    /// <returns>Атрибут.</returns>
    public static T? Attribute<T>(this Enum @enum)
        where T : Attribute
    {
        var type = @enum.GetType();
        var name = @enum.ToString();
        return type.GetField(name)?.GetCustomAttribute<T>(false);
    }
}