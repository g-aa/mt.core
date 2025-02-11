namespace Mt.FluentValidation.Test;

/// <summary>
/// Набор тестов для методов расширена <see cref="IRuleBuilder{T, TProperty}"/> используемых в МТ.
/// </summary>
[TestFixture]
public sealed class ValidationExtensionsTest
{
    private InlineValidator<TestModel> _validator;

    /// <summary>
    /// Настройка.
    /// </summary>
    [OneTimeSetUp]
    public void Setup()
    {
        _validator = new InlineValidator<TestModel>();
        _validator.RuleSet("default", () =>
        {
            _validator.RuleFor(x => x.Digits).IsDigits();
            _validator.RuleFor(x => x.Message).IsTrim();
            _validator.RuleFor(x => x.EMail).IsEMail();
            _validator.RuleFor(x => x.DIVG).IsDIVG();
            _validator.RuleFor(x => x.AnalogModule).IsAnalogModule();
            _validator.RuleFor(x => x.Version).IsCfgVersion();
            _validator.RuleFor(x => x.Platform).IsPlatform();
            _validator.RuleFor(x => x.BFPO).IsBFPO();
            _validator.RuleFor(x => x.PMK).IsPMK();
        });
    }

    /// <summary>
    /// Положительный тест для <see cref="ValidationExtensions.IsDigits{T}(IRuleBuilder{T, string?})"/>.
    /// </summary>
    /// <param name="digits">Сообщение с цифрами.</param>
    [TestCase(null)]
    [TestCase("")]
    [TestCase("1234567890")]
    public void DigitsPositiveTest(string? digits)
    {
        // arrange
        var model = new TestModel
        {
            Digits = digits,
        };

        // act
        var result = _validator.TestValidate(model);

        // assert
        result.ShouldNotHaveValidationErrorFor(m => m.Digits);
    }

    /// <summary>
    /// Отрицательный тест для <see cref="ValidationExtensions.IsDigits{T}(IRuleBuilder{T, string?})"/>.
    /// </summary>
    /// <param name="digits">Сообщение с цифрами.</param>
    [TestCase(" ")]
    [TestCase("\t")]
    [TestCase("A234567890")]
    [TestCase("123-456-789")]
    public void DigitsNegativeTest(string? digits)
    {
        // arrange
        var model = new TestModel
        {
            Digits = digits,
        };

        // act
        var result = _validator.TestValidate(model);

        // assert
        result.ShouldHaveValidationErrorFor(m => m.Digits);
    }

    /// <summary>
    /// Положительный тест для <see cref="ValidationExtensions.IsTrim{T}(IRuleBuilder{T, string?})"/>.
    /// </summary>
    /// <param name="message">Сообщение.</param>
    [TestCase(null)]
    [TestCase("")]
    [TestCase("Test message.")]
    public void TrimPositiveTest(string? message)
    {
        // arrange
        var model = new TestModel
        {
            Message = message,
        };

        // act
        var result = _validator.TestValidate(model);

        // assert
        result.ShouldNotHaveValidationErrorFor(m => m.Message);
    }

    /// <summary>
    /// Отрицательный тест для <see cref="ValidationExtensions.IsTrim{T}(IRuleBuilder{T, string?})"/>.
    /// </summary>
    /// <param name="message">Сообщение.</param>
    [TestCase(" ")]
    [TestCase("\t")]
    [TestCase(" Test message.\t")]
    public void TrimNegativeTest(string? message)
    {
        // arrange
        var model = new TestModel
        {
            Message = message,
        };

        // act
        var result = _validator.TestValidate(model);

        // assert
        result.ShouldHaveValidationErrorFor(m => m.Message);
    }

    /// <summary>
    /// Положительный тест для <see cref="ValidationExtensions.IsDIVG{T}(IRuleBuilder{T, string})"/>.
    /// </summary>
    /// <param name="divg">ДИВГ.</param>
    [TestCase("ДИВГ.00000-00")]
    [TestCase("ДИВГ.12345-67")]
    [TestCase("ДИВГ.99999-99")]
    public void DIVGPositiveTest(string divg)
    {
        // arrange
        var model = new TestModel
        {
            DIVG = divg,
        };

        // act
        var result = _validator.TestValidate(model);

        // assert
        result.ShouldNotHaveValidationErrorFor(m => m.DIVG);
    }

    /// <summary>
    /// Отрицательный тест для <see cref="ValidationExtensions.IsDIVG{T}(IRuleBuilder{T, string})"/>.
    /// </summary>
    /// <param name="divg">ДИВГ.</param>
    [TestCase("")]
    [TestCase(" ")]
    [TestCase("\t")]
    [TestCase("дивг.00000-00")]
    [TestCase("ДИВГ.0000-000")]
    [TestCase("ДИВГ.00000-000")]
    [TestCase(" ДИВГ.00000-00\t")]
    public void DIVGNegativeTest(string divg)
    {
        // arrange
        var model = new TestModel
        {
            DIVG = divg,
        };

        // act
        var result = _validator.TestValidate(model);

        // assert
        result.ShouldHaveValidationErrorFor(m => m.DIVG);
    }

    /// <summary>
    /// Положительный тест для <see cref="ValidationExtensions.IsEMail{T}(IRuleBuilder{T, string?})"/>.
    /// </summary>
    /// <param name="email">E-Mail.</param>
    [TestCase(null)]
    [TestCase("abc@def.ru")]
    public void EMailPositiveTest(string? email)
    {
        // arrange
        var model = new TestModel
        {
            EMail = email,
        };

        // act
        var result = _validator.TestValidate(model);

        // assert
        result.ShouldNotHaveValidationErrorFor(m => m.EMail);
    }

    /// <summary>
    /// Отрицательный тест для <see cref="ValidationExtensions.IsEMail{T}(IRuleBuilder{T, string?})"/>.
    /// </summary>
    /// <param name="email">E-Mail.</param>
    [TestCase("")]
    [TestCase(" ")]
    [TestCase("\t")]
    [TestCase("abc")]
    [TestCase("abc@")]
    [TestCase("abc@def")]
    [TestCase("abc@def.")]
    [TestCase(" abc@def.ru\t")]
    public void EMailNegativeTest(string? email)
    {
        // arrange
        var model = new TestModel
        {
            EMail = email,
        };

        // act
        var result = _validator.TestValidate(model);

        // assert
        result.ShouldHaveValidationErrorFor(m => m.EMail);
    }

    /// <summary>
    /// Положительный тест для <see cref="ValidationExtensions.IsAnalogModule{T}(IRuleBuilder{T, string?})"/>.
    /// </summary>
    /// <param name="module">Модуль.</param>
    [TestCase(null)]
    [TestCase("БМРЗ-000")]
    [TestCase("БМРЗ-123")]
    [TestCase("БМРЗ-999")]
    [TestCase("БМРЗ-ТР")]
    public void AnalogModulePositiveTest(string? module)
    {
        // arrange
        var model = new TestModel
        {
            AnalogModule = module,
        };

        // act
        var result = _validator.TestValidate(model);

        // assert
        result.ShouldNotHaveValidationErrorFor(m => m.AnalogModule);
    }

    /// <summary>
    /// Отрицательный тест для <see cref="ValidationExtensions.IsAnalogModule{T}(IRuleBuilder{T, string?})"/>.
    /// </summary>
    /// <param name="module">Модуль.</param>
    [TestCase("")]
    [TestCase(" ")]
    [TestCase("\t")]
    [TestCase(" БМРЗ-123\t")]
    public void AnalogModuleNegativeTest(string? module)
    {
        // arrange
        var model = new TestModel
        {
            AnalogModule = module,
        };

        // act
        var result = _validator.TestValidate(model);

        // assert
        result.ShouldHaveValidationErrorFor(m => m.AnalogModule);
    }

    /// <summary>
    /// Положительный тест для <see cref="ValidationExtensions.IsCfgVersion{T}(IRuleBuilder{T, string?})"/>.
    /// </summary>
    /// <param name="version">Версия.</param>
    [TestCase(null)]
    [TestCase("v0.00.00.00")]
    [TestCase("v1.23.45.67")]
    [TestCase("v9.99.99.99")]
    public void VersionPositiveTest(string? version)
    {
        // arrange
        var model = new TestModel
        {
            Version = version,
        };

        // act
        var result = _validator.TestValidate(model);

        // assert
        result.ShouldNotHaveValidationErrorFor(m => m.Version);
    }

    /// <summary>
    /// Отрицательный тест для <see cref="ValidationExtensions.IsCfgVersion{T}(IRuleBuilder{T, string?})"/>.
    /// </summary>
    /// <param name="version">Версия.</param>
    [TestCase("")]
    [TestCase(" ")]
    [TestCase("\t")]
    [TestCase(" v1.23.45.67\t")]
    public void VersionNegativeTest(string? version)
    {
        // arrange
        var model = new TestModel
        {
            Version = version,
        };

        // act
        var result = _validator.TestValidate(model);

        // assert
        result.ShouldHaveValidationErrorFor(m => m.Version);
    }

    /// <summary>
    /// Положительный тест для <see cref="ValidationExtensions.IsPlatform{T}(IRuleBuilder{T, string?})"/>.
    /// </summary>
    /// <param name="platform">Платформа.</param>
    [TestCase(null)]
    [TestCase("БМРЗ-000")]
    [TestCase("БМРЗ-999")]
    [TestCase("БМРЗ-100M")]
    [TestCase("БМРЗ-100У")]
    [TestCase("БМРЗ-1007")]
    [TestCase("БМРЗ-M4М")]
    public void PlatformPositiveTest(string? platform)
    {
        // arrange
        var model = new TestModel
        {
            Platform = platform,
        };

        // act
        var result = _validator.TestValidate(model);

        // assert
        result.ShouldNotHaveValidationErrorFor(m => m.Platform);
    }

    /// <summary>
    /// Отрицательный тест для <see cref="ValidationExtensions.IsPlatform{T}(IRuleBuilder{T, string?})"/>.
    /// </summary>
    /// <param name="platform">Платформа.</param>
    [TestCase("")]
    [TestCase(" ")]
    [TestCase("\t")]
    [TestCase(" БМРЗ-123\t")]
    public void PlatformNegativeTest(string? platform)
    {
        // arrange
        var model = new TestModel
        {
            Platform = platform,
        };

        // act
        var result = _validator.TestValidate(model);

        // assert
        result.ShouldHaveValidationErrorFor(m => m.Platform);
    }

    /// <summary>
    /// Положительный тест для <see cref="ValidationExtensions.IsBFPO{T}(IRuleBuilder{T, string?})"/>.
    /// </summary>
    /// <param name="bfpo">БФПО.</param>
    [TestCase(null)]
    [TestCase("БФПО-000-КСЗ-00_00")]
    [TestCase("БФПО-ТР-99_99")]
    [TestCase("БФПО-04ВВ-00_00")]
    public void BFPOPositiveTest(string? bfpo)
    {
        // arrange
        var model = new TestModel
        {
            BFPO = bfpo,
        };

        // act
        var result = _validator.TestValidate(model);

        // assert
        result.ShouldNotHaveValidationErrorFor(m => m.BFPO);
    }

    /// <summary>
    /// Отрицательный тест для <see cref="ValidationExtensions.IsBFPO{T}(IRuleBuilder{T, string?})"/>.
    /// </summary>
    /// <param name="bfpo">БФПО.</param>
    [TestCase("")]
    [TestCase(" ")]
    [TestCase("\t")]
    [TestCase(" БФПО-123-КСЗ-45_67\t")]
    public void BFPONegativeTest(string? bfpo)
    {
        // arrange
        var model = new TestModel
        {
            BFPO = bfpo,
        };

        // act
        var result = _validator.TestValidate(model);

        // assert
        result.ShouldHaveValidationErrorFor(m => m.BFPO);
    }

    /// <summary>
    /// Положительный тест для <see cref="ValidationExtensions.IsPMK{T}(IRuleBuilder{T, string?})"/>.
    /// </summary>
    /// <param name="pmk">ПМК.</param>
    [TestCase(null)]
    [TestCase("ПМК-000-КСЗ-00_00")]
    [TestCase("ПМК-ТР-99_99")]
    [TestCase("ПМК-04ВВ-00_00")]
    public void PMKPositiveTest(string? pmk)
    {
        // arrange
        var model = new TestModel
        {
            PMK = pmk,
        };

        // act
        var result = _validator.TestValidate(model);

        // assert
        result.ShouldNotHaveValidationErrorFor(m => m.PMK);
    }

    /// <summary>
    /// Отрицательный тест для <see cref="ValidationExtensions.IsPMK{T}(IRuleBuilder{T, string?})"/>.
    /// </summary>
    /// <param name="pmk">ПМК.</param>
    [TestCase("")]
    [TestCase(" ")]
    [TestCase("\t")]
    [TestCase(" ПМК-123-КСЗ-45_67\t")]
    public void PMKNegativeTest(string? pmk)
    {
        // arrange
        var model = new TestModel
        {
            PMK = pmk,
        };

        // act
        var result = _validator.TestValidate(model);

        // assert
        result.ShouldHaveValidationErrorFor(m => m.PMK);
    }

    /// <summary>
    /// Тестовая модель данных.
    /// </summary>
    private sealed class TestModel
    {
        /// <summary>
        /// Инициализатор нового экземпляра класса <see cref="TestModel"/>.
        /// </summary>
        public TestModel()
        {
            DIVG = string.Empty;
        }

        /// <summary>
        /// Только цифры.
        /// </summary>
        public string? Digits { get; init; }

        /// <summary>
        /// Сообщение.
        /// </summary>
        public string? Message { get; init; }

        /// <summary>
        /// E-Mail адрес.
        /// </summary>
        public string? EMail { get; init; }

        /// <summary>
        /// ДИВГ.
        /// </summary>
        public string DIVG { get; init; }

        /// <summary>
        /// Аналоговый модуль.
        /// </summary>
        public string? AnalogModule { get; init; }

        /// <summary>
        /// Версия.
        /// </summary>
        public string? Version { get; init; }

        /// <summary>
        /// Платформа.
        /// </summary>
        public string? Platform { get; init; }

        /// <summary>
        /// БФПО.
        /// </summary>
        public string? BFPO { get; init; }

        /// <summary>
        /// ПМК.
        /// </summary>
        public string? PMK { get; init; }
    }
}