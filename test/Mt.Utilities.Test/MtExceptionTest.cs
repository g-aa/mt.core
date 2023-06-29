using Mt.Utilities.Exceptions;
using Mt.Utilities.Extensions;

namespace Mt.Utilities.Test;

/// <summary>
/// Набор тестов для <see cref="MtException"/>.
/// </summary>
[TestFixture]
public sealed class MtExceptionTest
{
    /// <summary>
    /// Положительный тест для <see cref="MtException.MtException(ErrorCode, string)"/>.
    /// </summary>
    /// <param name="code">Код ошибки.</param>
    /// <param name="message">Сообщение.</param>
    /// <param name="expected">Ожидаемый результат.</param>
    [TestCase(ErrorCode.EntityValidation, null, "Ошибка валидации параметров сущности.")]
    [TestCase(ErrorCode.InvalidOperation, "", "Ошибка выполнения операции.")]
    [TestCase(ErrorCode.InternalLogicError, " ", "Внутренняя ошибка логики приложения.")]
    [TestCase(ErrorCode.EntityAlreadyExists, "\t", "Сущность уже содержится в последовательности.")]
    [TestCase(ErrorCode.EntityNotFound, "Ошибка.", "Ошибка.")]
    public void PositiveTest(ErrorCode code, string message, string expected)
    {
        // arrange
        var result = new MtException(code, message);

        // assert
        Assert.Multiple(() =>
        {
            Assert.That(result.Code, Is.EqualTo(code));
            Assert.That(result.Title, Is.EqualTo(code.Title()));
            Assert.That(result.Desc, Is.EqualTo(expected));
            Assert.That(result.Message, Is.EqualTo($"{code.Title()}: {expected}"));
        });
    }
}