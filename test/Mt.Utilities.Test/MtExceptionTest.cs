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
    /// Положительный тест для <see cref="MtException(ErrorCode, string)"/>.
    /// </summary>
    /// <param name="code">Код ошибки.</param>
    /// <param name="message">Сообщение.</param>
    /// <param name="expected">Ожидаемый результат.</param>
    [TestCase(ErrorCode.InvalidOperation, "", "Ошибка выполнения операции.")]
    [TestCase(ErrorCode.InternalLogicError, " ", "Внутренняя ошибка логики приложения.")]
    [TestCase(ErrorCode.EntityAlreadyExists, "\t", "Сущность уже содержится в последовательности.")]
    [TestCase(ErrorCode.EntityNotFound, "Ошибка.", "Ошибка.")]
    public void PositiveTest(ErrorCode code, string message, string expected)
    {
        // arrange
        var result = new MtException(code, message);

        // assert
        result.Code.Should().Be(code);
        result.Title.Should().Be(code.Title());
        result.Desc.Should().Be(expected);
        result.Message.Should().Be($"{code.Title()}: {expected}");
    }
}