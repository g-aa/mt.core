namespace Mt.FluentValidation;

/// <summary>
/// Методы расширения для правил валидации применяемых в МТ.
/// </summary>
public static class ValidationExtensions
{
    /// <summary>
    /// Формат регулярного выражения для e-mail адреса.
    /// </summary>
    private const string EMailFormat = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

    /// <summary>
    /// Правило валидации МТ для атрибута содержащего только цифры.
    /// </summary>
    /// <typeparam name="T">Тип объекта данных.</typeparam>
    /// <param name="ruleBuilder">Rule builder.</param>
    /// <returns>Сформированное правило валидации.</returns>
    public static IRuleBuilderOptions<T, string?> IsDigits<T>(this IRuleBuilder<T, string?> ruleBuilder)
    {
        return ruleBuilder.Matches(@"^[0-9]*$")
            .WithMessage("Значение параметра '{PropertyName}' должно содержать только цифры.");
    }

    /// <summary>
    /// Правило валидации МТ для строк на отсутствие незначащих символов '\s', '\t'.
    /// </summary>
    /// <typeparam name="T">Тип объекта данных.</typeparam>
    /// <param name="ruleBuilder">Rule builder.</param>
    /// <returns>Сформированное правило валидации.</returns>
    public static IRuleBuilderOptions<T, string?> IsTrim<T>(this IRuleBuilder<T, string?> ruleBuilder)
    {
        return ruleBuilder.Must(x => x?.Trim().Length == x?.Length)
            .WithMessage("Значение параметра '{PropertyName}' не должно содержать символы '\\s', '\\t' в начале и конце строки.");
    }

    /// <summary>
    /// Правило валидации МТ для коллекций на наличие только уникальных значений.
    /// </summary>
    /// <typeparam name="T">Тип объекта данных.</typeparam>
    /// <typeparam name="TElement">Тип элемента коллекции.</typeparam>
    /// <param name="ruleBuilder">Rule builder.</param>
    /// <returns>Сформированное правило валидации.</returns>
    public static IRuleBuilderOptions<T, IEnumerable<TElement>?> IsTrim<T, TElement>(this IRuleBuilder<T, IEnumerable<TElement>?> ruleBuilder)
    {
        return ruleBuilder.Must(x => x?.Distinct().Count() == x?.Count())
            .WithMessage("Параметра '{PropertyName}' должен содержать только уникальные значения в коллекции.");
    }

    /// <summary>
    /// Правило валидации МТ для e-mail адреса.
    /// </summary>
    /// <typeparam name="T">Тип объекта данных.</typeparam>
    /// <param name="ruleBuilder">Rule builder.</param>
    /// <returns>Сформированное правило валидации.</returns>
    public static IRuleBuilderOptions<T, string?> IsEMail<T>(this IRuleBuilder<T, string?> ruleBuilder)
    {
        // Регулярное выражение взято из статьи: https://learn.microsoft.com/ru-ru/dotnet/standard/base-types/how-to-verify-that-strings-are-in-valid-email-format.
        return ruleBuilder.Matches(EMailFormat)
            .WithMessage($"Значение параметра '{{PropertyName}}' не соответствует заданному для e-mail формату '{EMailFormat}'.");
    }

    /// <summary>
    /// Правило валидации МТ для децимального номера (ДИВГ).
    /// </summary>
    /// <typeparam name="T">Тип объекта данных.</typeparam>
    /// <param name="ruleBuilder">Rule builder.</param>
    /// <returns>Сформированное правило валидации.</returns>
    public static IRuleBuilderOptions<T, string> IsDIVG<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder.NotEmpty()
            .Matches(StringFormat.DIVG)
            .WithMessage($"Значение параметра '{{PropertyName}}' не соответствует заданному для децимального номера (ДИВГ) формату '{StringFormat.DIVG}'.");
    }

    /// <summary>
    /// Правило валидации МТ для аналогового модуля (БМРЗ-150, БМРЗ-М4).
    /// </summary>
    /// <typeparam name="T">Тип объекта данных.</typeparam>
    /// <param name="ruleBuilder">Rule builder.</param>
    /// <returns>Сформированное правило валидации.</returns>
    public static IRuleBuilderOptions<T, string?> IsAnalogModule<T>(this IRuleBuilder<T, string?> ruleBuilder)
    {
        return ruleBuilder.Matches(StringFormat.AnalogModule)
            .WithMessage($"Значение параметра '{{PropertyName}}' не соответствует заданному для аналогового модуля формату '{StringFormat.AnalogModule}'.");
    }

    /// <summary>
    /// Правило валидации МТ для версии ArmEdit и Cfg-Mt.
    /// </summary>
    /// <typeparam name="T">Тип объекта данных.</typeparam>
    /// <param name="ruleBuilder">Rule builder.</param>
    /// <returns>Сформированное правило валидации.</returns>
    public static IRuleBuilderOptions<T, string?> IsCfgVersion<T>(this IRuleBuilder<T, string?> ruleBuilder)
    {
        return ruleBuilder.Matches(StringFormat.Version)
            .WithMessage($"Значение параметра '{{PropertyName}}' не соответствует заданному для версии ArmEdit и Cfg-Mt формату '{StringFormat.Version}'.");
    }

    /// <summary>
    /// Правило валидации МТ для платформы (БМРЗ-150, БМРЗ-М4).
    /// </summary>
    /// <typeparam name="T">Тип объекта данных.</typeparam>
    /// <param name="ruleBuilder">Rule builder.</param>
    /// <returns>Сформированное правило валидации.</returns>
    public static IRuleBuilderOptions<T, string?> IsPlatform<T>(this IRuleBuilder<T, string?> ruleBuilder)
    {
        return ruleBuilder.Matches(StringFormat.Platform)
            .WithMessage($"Значение параметра '{{PropertyName}}' не соответствует заданному для платформы формату '{StringFormat.Platform}'.");
    }

    /// <summary>
    /// Правило валидации МТ для БФПО (БМРЗ-150, БМРЗ-М4).
    /// </summary>
    /// <typeparam name="T">Тип объекта данных.</typeparam>
    /// <param name="ruleBuilder">Rule builder.</param>
    /// <returns>Сформированное правило валидации.</returns>
    public static IRuleBuilderOptions<T, string?> IsBFPO<T>(this IRuleBuilder<T, string?> ruleBuilder)
    {
        return ruleBuilder.Matches(StringFormat.BFPO)
            .WithMessage($"Значение параметра '{{PropertyName}}' не соответствует заданному для БФПО формату '{StringFormat.BFPO}'.");
    }

    /// <summary>
    /// Правило валидации МТ для ПМК (БМРЗ-150, БМРЗ-М4).
    /// </summary>
    /// <typeparam name="T">Тип объекта данных.</typeparam>
    /// <param name="ruleBuilder">Rule builder.</param>
    /// <returns>Сформированное правило валидации.</returns>
    public static IRuleBuilderOptions<T, string?> IsPMK<T>(this IRuleBuilder<T, string?> ruleBuilder)
    {
        return ruleBuilder.Matches(StringFormat.PMK)
            .WithMessage($"Значение параметра '{{PropertyName}}' не соответствует заданному для ПМК формату '{StringFormat.PMK}'.");
    }
}