using Mt.Utilities.Exceptions;
using Mt.Utilities.Extensions;
using NUnit.Framework;

namespace Mt.Utilities.Test
{
    /// <summary>
    /// Набор тестов для кодов ошибок.
    /// </summary>
    [TestFixture]
    public sealed class ErrorCodeTests
    {
        /// <summary>
        /// Положительные тесты для заголовка.
        /// </summary>
        /// <param name="code">Код ошибки.</param>
        /// <param name="expected">Ожидаемый результат.</param>
        [Test]
        [TestCase(ErrorCode.InternalServerError,    "MT-E0000")]
        [TestCase(ErrorCode.InternalLogicError,     "MT-E0001")]
        [TestCase(ErrorCode.InvalidOperation,       "MT-E0002")]
        [TestCase(ErrorCode.Unauthorized,           "MT-E0003")]
        [TestCase(ErrorCode.EntityValidation,       "MT-E0010")]
        [TestCase(ErrorCode.EntityNotFound,         "MT-E0011")]
        [TestCase(ErrorCode.EntityAlreadyExists,    "MT-E0012")]
        [TestCase(ErrorCode.EntityCannotBeDeleted,  "MT-E0013")]
        [TestCase(ErrorCode.EntityCannotBeModified, "MT-E0014")]
        public void TitlePositiveTest(ErrorCode code, string expected)
        {
            var result = code.Title();
            Assert.That(result, Is.EqualTo(expected));
        }

        /// <summary>
        /// Положительные тесты для описания.
        /// </summary>
        /// <param name="code">Код ошибки.</param>
        /// <param name="expected">Ожидаемый результат.</param>
        [Test]
        [TestCase(ErrorCode.InternalServerError,    "Внутренняя ошибка сервера.")]
        [TestCase(ErrorCode.InternalLogicError,     "Внутренняя ошибка логики приложения.")]
        [TestCase(ErrorCode.InvalidOperation,       "Ошибка выполнения операции.")]
        [TestCase(ErrorCode.Unauthorized,           "Несанкционированный доступ к ресурсу.")]
        [TestCase(ErrorCode.EntityValidation,       "Ошибка валидации параметров сущности.")]
        [TestCase(ErrorCode.EntityNotFound,         "Сущность не найдена в последовательности.")]
        [TestCase(ErrorCode.EntityAlreadyExists,    "Сущность уже содержится в последовательности.")]
        [TestCase(ErrorCode.EntityCannotBeDeleted,  "Сущность не может быть удалена из последовательности.")]
        [TestCase(ErrorCode.EntityCannotBeModified, "Сущность не может быть модифицирована.")]
        public void DescPositiveTest(ErrorCode code, string expected)
        {
            var result = code.Desc();
            Assert.That(result, Is.EqualTo(expected));
        }

        /// <summary>
        /// Положительные тесты для http-статус кода.
        /// </summary>
        /// <param name="code">Код ошибки.</param>
        /// <param name="expected">Ожидаемый результат.</param>
        [Test]
        [TestCase(ErrorCode.InternalServerError,    500)]
        [TestCase(ErrorCode.InternalLogicError,     400)]
        [TestCase(ErrorCode.InvalidOperation,       400)]
        [TestCase(ErrorCode.Unauthorized,           401)]
        [TestCase(ErrorCode.EntityValidation,       400)]
        [TestCase(ErrorCode.EntityNotFound,         400)]
        [TestCase(ErrorCode.EntityAlreadyExists,    400)]
        [TestCase(ErrorCode.EntityCannotBeDeleted,  400)]
        [TestCase(ErrorCode.EntityCannotBeModified, 400)]
        public void HttpStatusCodePositiveTest(ErrorCode code, int expected)
        {
            var result = code.HttpStatusCode();
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}