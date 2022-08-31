namespace Mt.Utilities.Exceptions
{
    /// <summary>
    /// Код ошибки МТ.
    /// </summary>
    public enum ErrorCode : uint
    {
        /// <summary>
        /// Внутренняя ошибка сервера.
        /// </summary>
        [ErrorCodeDescription("Внутренняя ошибка сервера.", 500)]
        InternalServerError = 0,

        /// <summary>
        /// Ошибка выполнения операции.
        /// </summary>
        [ErrorCodeDescription("Ошибка выполнения операции.", 400)]
        InvalidOperationError = 1,

        /// <summary>
        /// Ошибка валидации параметров.
        /// </summary>
        [ErrorCodeDescription("Ошибка валидации параметров.", 400)]
        ValidationError = 2,

        /// <summary>
        /// Ошибка поиска сущности в последовательности.
        /// </summary>
        [ErrorCodeDescription("Ошибка поиска сущности в последовательности.", 400)]
        EntityNotFoundError = 3,
    }
}
