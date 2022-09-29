namespace Mt.Utilities.Exceptions
{
    /// <summary>
    /// Код ошибки МТ.
    /// </summary>
    public enum ErrorCode
    {
        #region [ System errors in logic (0...9) ]

        /// <summary>
        /// Внутренняя ошибка логики приложения.
        /// </summary>
        [ErrorCodeDescription("Внутренняя ошибка логики приложения.", 500)]
        InternalLogic = 0,

        /// <summary>
        /// Ошибка выполнения операции.
        /// </summary>
        [ErrorCodeDescription("Ошибка выполнения операции.", 400)]
        InvalidOperation = 1,

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