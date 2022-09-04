namespace Mt.Utilities
{
    /// <summary>
    /// Форматы регулярных выражений основных сущностей в МТ.
    /// </summary>
    public static class StringFormat
    {
        /// <summary>
        /// Формат регулярного выражения для аналоговых модулей (БМРЗ-150, БМРЗ-М4).
        /// </summary>
        public const string AnalogModule = "^БМРЗ-[0-9 A-Z А-Я]{2,4}$";

        /// <summary>
        /// Формат регулярного выражения для ДИВГ.
        /// </summary>
        public const string DIVG = "^ДИВГ.[0-9]{5}-[0-9]{2}$";

        /// <summary>
        /// Формат регулярного выражения для тока.
        /// </summary>
        public const string Current = "^[0-9]{1}A$";

        /// <summary>
        /// Формат регулярного выражения для напряжения.
        /// </summary>
        public const string Voltage = "^[0-9]{1}V$";

        /// <summary>
        /// Формат регулярного выражения для версии ArmEdit и Cfg-Mt.
        /// </summary>
        public const string Version = "^v[0-9]{1}.[0-9]{2}.[0-9]{2}.[0-9]{2}$";

        /// <summary>
        /// Формат регулярного выражения для платформы (БМРЗ-150, БМРЗ-М4).
        /// </summary>
        public const string Platform = "^БМРЗ-[0-9 A-Z А-Я]{2,5}$";

        /// <summary>
        /// Формат регулярного выражения для префикса версии/редакции БФПО (БМРЗ-150, БМРЗ-М4).
        /// </summary>
        public const string Prefix = "^(БФПО(-[0-9]{3})?)?$";

        /// <summary>
        /// Формат регулярного выражения для ПМК (БМРЗ-150, БМРЗ-М4). 
        /// </summary>
        public const string PMK = "^(ПМК(-[0-9]{3})?)?-[0-9 а-я А-Я a-z A-Z]{2,5}-[0-9]{2}_[0-9]{2}$";

        /// <summary>
        /// Формат регулярного выражения для БФПО (БМРЗ-150, БМРЗ-М4). 
        /// </summary>
        public const string BFPO = "^(БФПО(-[0-9]{3})?)?-[0-9 а-я А-Я a-z A-Z]{2,5}-[0-9]{2}_[0-9]{2}$";
    }
}