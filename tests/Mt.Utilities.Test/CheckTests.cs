using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Mt.Utilities.Test
{
    /// <summary>
    /// Набор тестов для базовых проверок.
    /// </summary>
    [TestFixture]
    public sealed class CheckTests
    {
        /// <summary>
        /// Положительные тесты для проверки строки.
        /// </summary>
        /// <param name="value">Строка.</param>
        [Test]
        [TestCase("1234567890")]
        public void NotEmptyStringPositiveTest(string value)
        {
            var result = Check.NotEmpty(value, nameof(value));
            Assert.That(result, Is.EqualTo(value));
        }

        /// <summary>
        /// Отрицательные тесты для проверки строки на ArgumentNullException.
        /// </summary>
        /// <param name="value">Строка.</param>
        /// <param name="parameterName">Наименование параметра.</param>
        /// <param name="message">Сообщение.</param>
        /// <param name="expected">Ожидаемый результат.</param>
        [Test]
        [TestCase(null, null, null, "Checked parameter is null. (Parameter 'parameterName')")]
        [TestCase(null, "value", null, "Checked parameter is null. (Parameter 'value')")]
        [TestCase(null, "value", "", "Checked parameter is null. (Parameter 'value')")]
        [TestCase(null, "value", " ", "Checked parameter is null. (Parameter 'value')")]
        [TestCase(null, "value", "\t", "Checked parameter is null. (Parameter 'value')")]
        [TestCase(null, "value", "Test message.", "Test message. (Parameter 'value')")]
        public void NotEmptyStringArgumentNullExceptionTest(string value, string parameterName, string message, string expected)
        {
            var ex = Assert.Throws<ArgumentNullException>(() => Check.NotEmpty(value, parameterName, message));
            Assert.That(ex.Message, Is.EqualTo(expected));
        }

        /// <summary>
        /// Отрицательные тесты для проверки строки на ArgumentException.
        /// </summary>
        /// <param name="value">Строка.</param>
        /// <param name="parameterName">Наименование параметра.</param>
        /// <param name="message">Сообщение.</param>
        /// <param name="expected">Ожидаемый результат.</param>
        [Test]
        [TestCase("", "value", null, "Checked parameter 'value' is empty.")]
        [TestCase("", "value", "", "Checked parameter 'value' is empty.")]
        [TestCase("", "value", " ", "Checked parameter 'value' is empty.")]
        [TestCase("", "value", "\t", "Checked parameter 'value' is empty.")]
        [TestCase("", "value", "Test message.", "Test message.")]
        [TestCase(" ", "value", null, "Checked parameter 'value' is empty.")]
        [TestCase("\t", "value", null, "Checked parameter 'value' is empty.")]
        public void NotEmptyStringArgumentExceptionTest(string value, string parameterName, string message, string expected)
        {
            var ex = Assert.Throws<ArgumentException>(() => Check.NotEmpty(value, parameterName, message));
            Assert.That(ex.Message, Is.EqualTo(expected));
        }

        /// <summary>
        /// Положительные тесты для проверки коллекции.
        /// </summary>
        /// <param name="value">Коллекция.</param>
        [Test]
        [TestCase(new object[] { "aaa", "bbb", "ccc" })]
        public void NotEmptyEnumerablePositiveTest(object[] value)
        {
            var result = Check.NotEmpty(value, nameof(value));
            Assert.That(result, Is.EqualTo(value));
        }

        /// <summary>
        /// Отрицательные тесты для проверки коллекции на ArgumentNullException. 
        /// </summary>
        /// <param name="value">Коллекция.</param>
        /// <param name="parameterName">Наименование параметра.</param>
        /// <param name="message">Сообщение.</param>
        /// <param name="expected">Ожидаемый результат.</param>
        [Test]
        [TestCase(null, null, null, "Checked parameter is null. (Parameter 'parameterName')")]
        [TestCase(null, "value", null, "Checked parameter is null. (Parameter 'value')")]
        [TestCase(null, "value", "", "Checked parameter is null. (Parameter 'value')")]
        [TestCase(null, "value", " ", "Checked parameter is null. (Parameter 'value')")]
        [TestCase(null, "value", "\t", "Checked parameter is null. (Parameter 'value')")]
        [TestCase(null, "value", "Test message.", "Test message. (Parameter 'value')")]
        public void NotEmptyEnumerableArgumentNullExceptionTest(object[] value, string parameterName, string message, string expected)
        {
            var ex = Assert.Throws<ArgumentNullException>(() => Check.NotEmpty(value, parameterName, message));
            Assert.That(ex.Message, Is.EqualTo(expected));
        }

        /// <summary>
        /// Отрицательные тесты для проверки коллекций на ArgumentException.
        /// </summary>
        /// <param name="value">Коллекция.</param>
        /// <param name="parameterName">Наименование параметра.</param>
        /// <param name="message">Сообщение.</param>
        /// <param name="expected">Ожидаемый результат.</param>
        [Test]
        [TestCase(new object[] { }, "enumerable value", null, "Checked parameter 'enumerable value' is empty.")]
        [TestCase(new object[] { }, "enumerable value", "", "Checked parameter 'enumerable value' is empty.")]
        [TestCase(new object[] { }, "enumerable value", " ", "Checked parameter 'enumerable value' is empty.")]
        [TestCase(new object[] { }, "enumerable value", "\t", "Checked parameter 'enumerable value' is empty.")]
        [TestCase(new object[] { }, "enumerable value", "Test message.", "Test message.")]
        public void NotEmptyEnumerableArgumentExceptionTest(object[] value, string parameterName, string message, string expected)
        {
            var ex = Assert.Throws<ArgumentException>(() => Check.NotEmpty(value, parameterName, message));
            Assert.That(ex.Message, Is.EqualTo(expected));
        }

        /// <summary>
        /// Положительные тесты для проверки значение на null.
        /// </summary>
        /// <param name="value">Параметр.</param>
        [Test]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("\t")]
        [TestCase("QWERTY")]
        [TestCase(typeof(object))]
        [TestCase(typeof(object[]))]
        [TestCase(typeof(double?))]
        [TestCase(typeof(List<int>))]
        public void NotNullPositiveTest(object value)
        {
            var result = Check.NotNull(value, nameof(value));
            Assert.That(result, Is.EqualTo(value));
        }

        /// <summary>
        /// Отрицательные тесты для проверки значения на null.
        /// </summary>
        /// <param name="value">Параметр.</param>
        /// <param name="parameterName">Наименование параметра.</param>
        /// <param name="message">Сообщение.</param>
        /// <param name="expected">Ожидаемый результат.</param>
        [Test]
        [TestCase(null, null, null, "Checked parameter is null. (Parameter 'parameterName')")]
        [TestCase(null, "test parameter", null, "Checked parameter is null. (Parameter 'test parameter')")]
        [TestCase(null, "test parameter", "", "Checked parameter is null. (Parameter 'test parameter')")]
        [TestCase(null, "test parameter", " ", "Checked parameter is null. (Parameter 'test parameter')")]
        [TestCase(null, "test parameter", "\t", "Checked parameter is null. (Parameter 'test parameter')")]
        [TestCase(null, "test parameter", "Test message.", "Test message. (Parameter 'test parameter')")]
        public void NotNullNegativeTest(object value, string parameterName, string message, string expected)
        {
            var ex = Assert.Throws<ArgumentNullException>(() => Check.NotNull(value, parameterName, message));
            Assert.That(ex.Message, Is.EqualTo(expected));
        }

        /// <summary>
        /// Положительные тесты для проверки на значение по умолчанию для структур.
        /// </summary>
        /// <typeparam name="T">Тип параметра.</typeparam>
        /// <param name="value">Параметр.</param>
        [Test]
        [TestCase(-12)]
        [TestCase(2.1)]
        [TestCase('A')]
        [TestCase(23U)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Blocker Code Smell", "S3433:Test method signatures should be correct", Justification = "<Pending>")]
        public void NotZeroPositiveTest<T>(T value) where T : struct
        {
            var result = Check.NotZero(value, nameof(value));
            Assert.That(result, Is.EqualTo(value));
        }

        /// <summary>
        /// Неготивные тесты для проверки на значение по умолчанию для структур.
        /// </summary>
        /// <typeparam name="T">Тип параметра.</typeparam>
        /// <param name="value">Параметр.</param>
        /// <param name="parameterName">Наименование параметра.</param>
        /// <param name="message">Сообщение.</param>
        /// <param name="expected">Ожидаемый результат.</param>
        [Test]
        [TestCase(default(double), "test parameter", null, "Input parameter 'test parameter' is zero value.")]
        [TestCase(default(byte), "test parameter", null, "Input parameter 'test parameter' is zero value.")]
        [TestCase(default(long), "test parameter", null, "Input parameter 'test parameter' is zero value.")]
        [TestCase(default(int), "test parameter", "", "Input parameter 'test parameter' is zero value.")]
        [TestCase(default(uint), "test parameter", " ", "Input parameter 'test parameter' is zero value.")]
        [TestCase(default(char), "test parameter", "\t", "Input parameter 'test parameter' is zero value.")]
        [TestCase(default(bool), "test parameter", "Test message.", "Test message.")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Blocker Code Smell", "S3433:Test method signatures should be correct", Justification = "<Pending>")]
        public void NotZeroNegativeTest<T>(T value, string parameterName, string message, string expected) where T : struct
        {
            var ex = Assert.Throws<ArgumentException>(() => Check.NotZero(value, parameterName, message));
            Assert.That(ex.Message, Is.EqualTo(expected));
        }

        /// <summary>
        /// Положительные тесты для проверки на соответствие параметра интервалу.
        /// </summary>
        /// <param name="min">Минимальное значение.</param>
        /// <param name="value">Параметр.</param>
        /// <param name="max">Максимальное значение.</param>
        [Test]
        [TestCase(int.MinValue, 100, int.MaxValue)]
        [TestCase(0, 200, 300)]
        [TestCase(-300, -100, 0)]
        public void FromIntervalPositiveTest(int min, int value, int max)
        {
            var result = Check.FromInterval(value, nameof(value), min, max);
            Assert.That(result, Is.EqualTo(value));
        }

        /// <summary>
        /// Отрицательные тесты для проверки на соответствие параметра интервалу.
        /// </summary>
        /// <param name="min">Минимальное значение.</param>
        /// <param name="value">Параметр.</param>
        /// <param name="max">Максимальное значение.</param>
        /// <param name="name">Наименование параметра.</param>
        /// <param name="expected">Ожидаемый результат.</param>
        [Test]
        [TestCase(300, 100, 200, "test parameter", "The interval for checking the parameter is set incorrectly [min:300; max:200].")]
        [TestCase(int.MaxValue, 100, int.MinValue, "test parameter", "The interval for checking the parameter is set incorrectly [min:2147483647; max:-2147483648].")]
        [TestCase(100, 300, 200, "test parameter", $"Input parameter 'test parameter':300∉[min:100; max:200].")]
        [TestCase(-300, -100, -200, "test parameter", $"Input parameter 'test parameter':-100∉[min:-300; max:-200].")]
        public void FromIntervalNegativeTest(int min, int value, int max, string name, string expected)
        {
            var ex = Assert.Throws<ArgumentException>(() => Check.FromInterval(value, name, min, max));
            Assert.That(ex.Message, Is.EqualTo(expected));
        }
    }
}