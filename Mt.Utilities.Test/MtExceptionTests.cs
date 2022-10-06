using Mt.Utilities.Exceptions;
using Mt.Utilities.Extensions;
using NUnit.Framework;

namespace Mt.Utilities.Test
{
    /// <summary>
    /// Набор тестов для MtException.
    /// </summary>
    [TestFixture]
    public sealed class MtExceptionTests
    {
        /// <summary>
        /// Положительные тесты для исключения.
        /// </summary>
        /// <param name="code">Код ошибки.</param>
        /// <param name="message">Сообщение.</param>
        /// <param name="expected">Ожидаемый результат.</param>
        [Test]
        [TestCase(ErrorCode.EntityValidation,    null,      "Ошибка валидации параметров сущности.")]
        [TestCase(ErrorCode.InvalidOperation,    "",        "Ошибка выполнения операции.")]
        [TestCase(ErrorCode.InternalLogicError,  " ",       "Внутренняя ошибка логики приложения.")]
        [TestCase(ErrorCode.EntityAlreadyExists, "\t",      "Сущность уже содержится в последовательности.")]
        [TestCase(ErrorCode.EntityNotFound,      "Ошибка.", "Ошибка.")]
        public void PositiveTest(ErrorCode code, string message, string expected)
        {
            var result = new MtException(code, message);
            Assert.That(result.Code, Is.EqualTo(code));
            Assert.That(result.Title, Is.EqualTo(code.Title()));
            Assert.That(result.Desc, Is.EqualTo(expected));
            Assert.That(result.Message, Is.EqualTo($"{code.Title()}: {expected}"));
        }
    }
}