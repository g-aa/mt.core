using Mt.Utilities.Exceptions;
using Mt.Utilities.Extensions;

namespace Mt.Utilities.Test.Extensions;

/// <summary>
/// Набор тестов для <see cref="Int32Extensions"/>.
/// </summary>
[TestFixture]
public class Int32ExtensionsTest
{
    /// <summary>
    /// Положительный тест для <see cref="Int32Extensions.ToEnum{TEnum}(int)"/>.
    /// </summary>
    /// <param name="value">Значение.</param>
    [TestCase(0)]
    [TestCase(1)]
    [TestCase(2)]
    public void ToEnumPositiveTest(int value)
    {
        // act
        var func = () => value.ToEnum<ErrorCode>();

        // assert
        func.Should().NotThrow();
    }

    /// <summary>
    /// Отрицательный тест для <see cref="Int32Extensions.ToEnum{TEnum}(int)"/>.
    /// </summary>
    /// <param name="value">Значение.</param>
    [TestCase(99)]
    [TestCase(int.MaxValue)]
    public void ToEnumNegativeTest(int value)
    {
        // act
        var func = () => value.ToEnum<ErrorCode>();

        // assert
        func.Should().Throw<InvalidOperationException>();
    }
}