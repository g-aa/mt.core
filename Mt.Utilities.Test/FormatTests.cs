using NUnit.Framework;
using System;
using System.Text.RegularExpressions;

namespace Mt.Utilities.Test
{
    /// <summary>
    /// Набор тестов для регулярных выражений применяемых в Mt. 
    /// </summary>
    [TestFixture]
    public sealed class FormatTests
    {
        /// <summary>
        /// Настройки.
        /// </summary>
        [SetUp]
        public void Setup()
        {

        }

        /// <summary>
        /// Положительные тесты для аналогового модуля.
        /// </summary>
        /// <param name="module">Модуль.</param>
        [Test]
        [TestCase("БМРЗ-000")]
        [TestCase("БМРЗ-999")]
        [TestCase("БМРЗ-ТР")]
        public void AnalogModulePositiveTest(string module)
        {
            Assert.That(Regex.IsMatch(module, Format.AnalogModule, RegexOptions.IgnoreCase, new TimeSpan(1000)), Is.True);
        }

        /// <summary>
        /// Положительные тесты для ДИВГ.
        /// </summary>
        /// <param name="divg">ДИВГ.</param>
        [Test]
        [TestCase("ДИВГ.00000-00")]
        [TestCase("ДИВГ.99999-99")]
        public void DivgPositiveTest(string divg)
        {
            Assert.That(Regex.IsMatch(divg, Format.DIVG, RegexOptions.IgnoreCase, new TimeSpan(1000)), Is.True);
        }

        /// <summary>
        /// Положительные тесты для тока.
        /// </summary>
        /// <param name="current">Ток.</param>
        [Test]
        [TestCase("0A")]
        [TestCase("9A")]
        public void CurrentPositiveTest(string current)
        {
            Assert.That(Regex.IsMatch(current, Format.Current, RegexOptions.IgnoreCase, new TimeSpan(1000)), Is.True);
        }

        /// <summary>
        /// Положительные тесты для напряжения.
        /// </summary>
        /// <param name="voltage">Напряжение.</param>
        [Test]
        [TestCase("0V")]
        [TestCase("9V")]
        public void VoltagePositiveTest(string voltage)
        {
            Assert.That(Regex.IsMatch(voltage, Format.Voltage, RegexOptions.IgnoreCase, new TimeSpan(1000)), Is.True);
        }

        /// <summary>
        /// Положительные тесты для версий.
        /// </summary>
        /// <param name="version">Версия.</param>
        [Test]
        [TestCase("v0.00.00.00")]
        [TestCase("v9.99.99.99")]
        public void VersionPositiveTest(string version)
        {
            Assert.That(Regex.IsMatch(version, Format.Version, RegexOptions.IgnoreCase, new TimeSpan(1000)), Is.True);
        }

        /// <summary>
        /// Положительные тесты для платформы.
        /// </summary>
        /// <param name="platform">Платформа.</param>
        [Test]
        [TestCase("БМРЗ-000")]
        [TestCase("БМРЗ-999")]
        [TestCase("БМРЗ-100M")]
        [TestCase("БМРЗ-100У")]
        [TestCase("БМРЗ-1007")]
        [TestCase("БМРЗ-M4М")]
        public void PlatformPositiveTest(string platform)
        {
            Assert.That(Regex.IsMatch(platform, Format.Platform, RegexOptions.IgnoreCase, new TimeSpan(1000)), Is.True);
        }

        /// <summary>
        /// Положительные тесты для префикса.
        /// </summary>
        /// <param name="prefix">Префикс.</param>
        [Test]
        [TestCase("БФПО")]
        [TestCase("БФПО-000")]
        [TestCase("БФПО-999")]
        public void PrefixPositiveTest(string prefix)
        {
            Assert.That(Regex.IsMatch(prefix, Format.Prefix, RegexOptions.IgnoreCase, new TimeSpan(1000)), Is.True);
        }

        /// <summary>
        /// Положительные тесты для ПМК.
        /// </summary>
        /// <param name="pmk">ПМК.</param>
        [Test]
        [TestCase("ПМК-000-КСЗ-00_00")]
        [TestCase("ПМК-ТР-99_99")]
        [TestCase("ПМК-04ВВ-00_00")]
        public void PmkPositiveTest(string pmk)
        {
            Assert.That(Regex.IsMatch(pmk, Format.PMK, RegexOptions.IgnoreCase, new TimeSpan(1000)), Is.True);
        }

        /// <summary>
        /// Положительные тесты для БФПО.
        /// </summary>
        /// <param name="bfpo">БФПО.</param>
        [Test]
        [TestCase("БФПО-000-КСЗ-00_00")]
        [TestCase("БФПО-ТР-99_99")]
        [TestCase("БФПО-04ВВ-00_00")]
        public void BfpoPmkPositiveTest(string bfpo)
        {
            Assert.That(Regex.IsMatch(bfpo, Format.BFPO, RegexOptions.IgnoreCase, new TimeSpan(1000)), Is.True);
        }
    }
}
