using Mt.Utilities.Exceptions;

namespace Mt.Utilities.Extensions;

/// <summary>
/// Методы расширения для кодов ошибок.
/// </summary>
public static class ErrorCodeExtensions
{
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
    /// Получить описание кода ошибки.
    /// </summary>
    /// <param name="code">Код ошибки.</param>
    /// <returns>Текстовое описание.</returns>
    public static string Desc(this ErrorCode code)
    {
        var attr = Attribute<ErrorCodeDescriptionAttribute>(code);
        return attr is null ? code.ToString() : attr.Description;
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
    /// <param name="code">Код ошибки.</param>
    /// <returns>Атрибут.</returns>
    private static T? Attribute<T>(this ErrorCode code) where T : Attribute
    {
        var type = code.GetType();
        var infos = type.GetMember(code.ToString());
        if (infos is null || infos.Length != 1)
        {
            return default;
        }

        var attrs = infos.Single().GetCustomAttributes(typeof(T), false);
        if (attrs is null || attrs.Length != 1)
        {
            return default;
        }
        return (T)attrs.Single();
    }
}