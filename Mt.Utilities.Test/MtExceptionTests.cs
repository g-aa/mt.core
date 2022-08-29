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
        /// Настройки.
        /// </summary>
        [SetUp]
        public void Setup()
        {

        }

        /// <summary>
        /// Положительные тесты для исключения.
        /// </summary>
        /// <param name="code">Код ошибки.</param>
        /// <param name="message">Сообщение.</param>
        [Test]
        [TestCase(ErrorCode.ValidationError, null)]
        [TestCase(ErrorCode.InvalidOperationError, "")]
        [TestCase(ErrorCode.InternalServerError, " ")]
        [TestCase(ErrorCode.ValidationError, "Ошибка валидации какого-то параметра.")]
        public void MtExceptionPositiveTest(ErrorCode code, string message)
        {
            var result = new MtException(code, message);

            Assert.That(result.Code, Is.EqualTo(code));
            Assert.That(result.Title, Is.EqualTo(code.Title()));
            if (string.IsNullOrWhiteSpace(message))
            {
                Assert.That(result.Desc, Is.EqualTo(code.Desc()));
                Assert.That(result.Message, Is.EqualTo($"{code.Title()}: {code.Desc()}"));
            }
            else
            {
                Assert.That(result.Desc, Is.EqualTo(message));
                Assert.That(result.Message, Is.EqualTo($"{code.Title()}: {message}"));
            }
        }
    }
}
