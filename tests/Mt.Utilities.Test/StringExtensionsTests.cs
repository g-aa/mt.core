using Mt.Utilities.Extensions;
using NUnit.Framework;
using System;

namespace Mt.Utilities.Test
{
    /// <summary>
    /// Набор тестов для методов расширения строк.
    /// </summary>
    [TestFixture]
    public sealed class StringExtensionsTests
    {
        /// <summary>
        /// Положительные тесты для транслитерации.
        /// </summary>
        /// <param name="ruString">Строка.</param>
        /// <param name="expected">Ожидаемый результат.</param>
        [Test]
        [TestCase("", "")]
        [TestCase(" ", " ")]
        [TestCase("\t", "\t")]
        [TestCase("1234567890-=!@#$%^&*()_+qwertyuiop{}ASDFGHJKL;'zxcvbnm,.", "1234567890-=!@#$%^&*()_+qwertyuiop{}ASDFGHJKL;'zxcvbnm,.")]
        [TestCase("а-Б-в-Г-д-Е-ё-Ж-з-И-й-К-л-М-н-О-п-Р-с-Т-у-Ф-х-Ц-ч-Ш-щ-Ъ-ы-Ь-э-Ю-я", "a-B-v-G-d-E-yo-ZH-z-I-j-K-l-M-n-O-p-R-s-T-u-F-x-CZ-ch-SH-shh--y--e-YU-ya")]
        public void Ru2EngPositiveTest(string ruString, string expected)
        {
            var result = ruString.Ru2Eng();
            Assert.That(result, Is.EqualTo(expected));
        }

        /// <summary>
        /// Отрицательные тесты для транслитерации.
        /// </summary>
        /// <param name="ruString"></param>
        /// <param name="expected"></param>
        [Test]
        [TestCase(null, "Checked parameter is null. (Parameter 'str')")]
        public void Ru2EngNegativeTest(string ruString, string expected)
        {
            var ex = Assert.Throws<ArgumentNullException>(() => ruString.Ru2Eng());
            Assert.That(ex.Message, Is.EqualTo(expected));
        }
    }
}