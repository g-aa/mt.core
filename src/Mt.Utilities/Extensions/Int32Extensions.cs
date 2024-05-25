namespace Mt.Utilities.Extensions;

/// <summary>
/// Методы расширения для <see cref="int"/>.
/// </summary>
public static class Int32Extensions
{
    /// <summary>
    /// Преобразовать значение типа <see cref="int"/> в конкретный тип <see cref="Enum"/>.
    /// </summary>
    /// <typeparam name="TEnum">Тип перечисления.</typeparam>
    /// <param name="value">Значение.</param>
    /// <returns>Перечисление.</returns>
    public static TEnum ToEnum<TEnum>(this int value)
      where TEnum : Enum
    {
        var type = typeof(TEnum);
        return Enum.IsDefined(type, value)
          ? (TEnum)Enum.ToObject(type, value)
          : throw new InvalidOperationException($"Не удалось преобразовать значение '{value}' к перечислению типа '{type.FullName}'.");
    }
}