namespace Mt.Utilities.Exceptions;

/// <summary>
/// Код ошибки МТ.
/// </summary>
public enum ErrorCode
{
    #region [ System errors in logic (0...9) ]

    /// <summary>
    /// Внутренняя ошибка сервера.
    /// </summary>
    [ErrorCodeDescription(500, "Внутренняя ошибка сервера.")]
    InternalServerError = 0,

    /// <summary>
    /// Внутренняя ошибка логики приложения.
    /// </summary>
    [ErrorCodeDescription(400, "Внутренняя ошибка логики приложения.")]
    InternalLogicError = 1,

    /// <summary>
    /// Ошибка выполнения операции.
    /// </summary>
    [ErrorCodeDescription(400, "Ошибка выполнения операции.")]
    InvalidOperation = 2,

    /// <summary>
    /// Несанкционированный доступ к ресурсу.
    /// </summary>
    [ErrorCodeDescription(401, "Несанкционированный доступ к ресурсу.")]
    Unauthorized = 3,

    #endregion

    #region [ Entity errors (10...19) ]

    /// <summary>
    /// Ошибка валидации параметров сущности.
    /// </summary>
    [ErrorCodeDescription(400, "Ошибка валидации параметров сущности.")]
    EntityValidation = 10,

    /// <summary>
    /// Ошибка поиска сущности в последовательности.
    /// </summary>
    [ErrorCodeDescription(400, "Сущность не найдена в последовательности.")]
    EntityNotFound = 11,

    /// <summary>
    /// Ошибка добавления сущности в последовательности.
    /// </summary>
    [ErrorCodeDescription(400, "Сущность уже содержится в последовательности.")]
    EntityAlreadyExists = 12,

    /// <summary>
    /// Ошибка удаления сущности из последовательности.
    /// </summary>
    [ErrorCodeDescription(400, "Сущность не может быть удалена из последовательности.")]
    EntityCannotBeDeleted = 13,

    /// <summary>
    /// Ошибка модификации сущности в последовательности.
    /// </summary>
    [ErrorCodeDescription(400, "Сущность не может быть модифицирована.")]
    EntityCannotBeModified = 14,

    #endregion
}