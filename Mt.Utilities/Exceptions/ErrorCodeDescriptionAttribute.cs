using System;
using System.Collections.Generic;
using System.Text;

namespace Mt.Utilities.Exceptions
{
    /// <summary>
    /// Атрибут описание поля МТ.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public class ErrorCodeDescriptionAttribute : Attribute
    {
        /// <summary>
        /// Описание.
        /// </summary>
        public string Message { get; private set; }
        
        /// <summary>
        /// Статус код протокола Http.
        /// </summary>
        public int HttpStatusCode { get; private set; }

        /// <summary>
        /// Инициализация нового экземпляра класса <see cref="ErrorCodeDescriptionAttribute"/>.
        /// </summary>
        /// <param name="message">Описание.</param>
        /// <param name="httpStatusCode">Http статус код.</param>
        public ErrorCodeDescriptionAttribute(string message, int httpStatusCode)
        {
            this.Message = message;
            this.HttpStatusCode = Check.FromInterval(httpStatusCode, nameof(httpStatusCode), 100, 500);
        }
    }
}
