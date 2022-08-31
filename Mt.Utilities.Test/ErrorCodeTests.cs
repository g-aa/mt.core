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
        /// Настройки.
        /// </summary>
        [SetUp]
        public void Setup()
        {

        }

        /// <summary>
        /// Положительные тесты для заголовка.
        /// </summary>
        /// <param name="code">Код ошибки.</param>
        /// <param name="title">Заголовок.</param>
        [Test]
        [TestCase(ErrorCode.InternalServerError,    "MT-E0000")]
        [TestCase(ErrorCode.InvalidOperationError,  "MT-E0001")]
        [TestCase(ErrorCode.ValidationError,        "MT-E0002")]
        public void ErrorCodeTitlePositiveTest(ErrorCode code, string title)
        {
            var result = code.Title();
            Assert.That(result, Is.EqualTo(title));
        }

        /// <summary>
        /// Положительные тесты для описания.
        /// </summary>
        /// <param name="code">Код ошибки.</param>
        /// <param name="desc">Описание.</param>
        [Test]
        [TestCase(ErrorCode.InvalidOperationError, "Ошибка выполнения операции.")]
        [TestCase(ErrorCode.InternalServerError, "Внутренняя ошибка сервера.")]
        [TestCase(ErrorCode.ValidationError, "Ошибка валидации параметров.")]
        public void ErrorCodeDescPositiveTest(ErrorCode code, string desc)
        {
            var result = code.Desc();
            Assert.That(result, Is.EqualTo(desc));
        }

        /// <summary>
        /// Положительные тесты для http-статус кода.
        /// </summary>
        /// <param name="code">Код ошибки.</param>
        /// <param name="httpStatus">Http-статус код.</param>
        [Test]
        [TestCase(ErrorCode.InvalidOperationError, 400)]
        [TestCase(ErrorCode.InternalServerError, 500)]
        [TestCase(ErrorCode.ValidationError, 400)]
        public void ErrorCodeHttpStatusCodePositiveTest(ErrorCode code, int httpStatus)
        {
            var result = code.HttpStatusCode();
            Assert.That(result, Is.EqualTo(httpStatus));
        }
    }
}