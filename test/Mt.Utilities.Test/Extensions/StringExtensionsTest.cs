using Mt.Utilities.Extensions;

namespace Mt.Utilities.Test.Extensions;

/// <summary>
/// Набор тестов для <see cref="StringExtensions"/>.
/// </summary>
[TestFixture]
public sealed class StringExtensionsTest
{
    /// <summary>
    /// Положительный тест для <see cref="StringExtensions.Ru2Eng(string)"/>.
    /// </summary>
    /// <param name="ruString">Строка.</param>
    /// <param name="expected">Ожидаемый результат.</param>
    [TestCase("", "")]
    [TestCase(" ", " ")]
    [TestCase("\t", "\t")]
    [TestCase("1234567890-=!@#$%^&*()_+qwertyuiop{}ASDFGHJKL;'zxcvbnm,.", "1234567890-=!@#$%^&*()_+qwertyuiop{}ASDFGHJKL;'zxcvbnm,.")]
    [TestCase("а-Б-в-Г-д-Е-ё-Ж-з-И-й-К-л-М-н-О-п-Р-с-Т-у-Ф-х-Ц-ч-Ш-щ-Ъ-ы-Ь-э-Ю-я", "a-B-v-G-d-E-yo-ZH-z-I-j-K-l-M-n-O-p-R-s-T-u-F-x-CZ-ch-SH-shh--y--e-YU-ya")]
    public void Ru2EngPositiveTest(string ruString, string expected)
    {
        // act
        var result = ruString.Ru2Eng();

        // assert
        result.Should().Be(expected);
    }
}