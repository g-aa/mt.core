namespace Mt.Utilities.Exceptions
{
    /// <summary>
    /// Код ошибки МТ.
    /// </summary>
    public enum ErrorCode
    {
        #region [ System errors in logic (0...9) ]

        /// <summary>
        /// Внутренняя ошибка сервера.
        /// </summary>
        [ErrorCodeDescription("Внутренняя ошибка сервера.", 500)]
        InternalServerError = 0,

        /// <summary>
        /// Внутренняя ошибка логики приложения.
        /// </summary>
        [ErrorCodeDescription("Внутренняя ошибка логики приложения.", 400)]
        InternalLogic = 1,

        /// <summary>
        /// Ошибка выполнения операции.
        /// </summary>
        [ErrorCodeDescription("Ошибка выполнения операции.", 400)]
        InvalidOperation = 2,

        /// <summary>
        /// Несанкционированный доступ к ресурсу.
        /// </summary>
        [ErrorCodeDescription("Несанкционированный доступ к ресурсу.", 401)]
        Unauthorized = 3,

        #endregion

        #region [ Entity errors (10...19) ]

        /// <summary>
        /// Ошибка валидации параметров сущности.
        /// </summary>
        [ErrorCodeDescription("Ошибка валидации параметров сущности.", 400)]
        EntityValidation = 10,

        /// <summary>
        /// Ошибка поиска сущности в последовательности.
        /// </summary>
        [ErrorCodeDescription("Сущность не найдена в последовательности.", 400)]
        EntityNotFound = 11,

        /// <summary>
        /// Ошибка добавления сущности в последовательности.
        /// </summary>
        [ErrorCodeDescription("Сущность уже содержится в последовательности.", 400)]
        EntityAlreadyExists = 12,

        /// <summary>
        /// Ошибка удаления сущности из последовательности.
        /// </summary>
        [ErrorCodeDescription("Сущность не может быть удалена из последовательности.", 400)]
        EntityCannotBeDeleted = 13,

        /// <summary>
        /// Ошибка модификации сущности в последовательности.
        /// </summary>
        [ErrorCodeDescription("Сущность не может быть модифицирована.", 400)]
        EntityCannotBeModified = 14,

        #endregion
    }
}