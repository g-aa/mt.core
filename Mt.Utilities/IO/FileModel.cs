using System;
using System.Collections.Generic;
using System.Linq;

namespace Mt.Utilities.IO
{
    /// <summary>
    /// Модель файла данных.
    /// </summary>
    public abstract class FileModel
    {
        /// <summary>
        /// Наименование файла.
        /// </summary>
        public string Title { get; private set; }
        
        /// <summary>
        /// Данные файла в бинарном формате.
        /// </summary>
        public byte[] Bytes { get; private set; }

        /// <summary>
        /// Конструктор по умолчание.
        /// </summary>
        protected FileModel()
        {
            this.Title = "empty.txt";
            this.Bytes =  Array.Empty<byte>();
        }

        /// <summary>
        /// Конструктор с параметрами.
        /// </summary>
        /// <param name="title">Наименование файла.</param>
        /// <param name="bytes">Данные файла в бинарном формате.</param>
        protected FileModel(string title, IEnumerable<byte> bytes) : this()
        {
            if (!string.IsNullOrWhiteSpace(title) && bytes is not null)
            {
                this.Title = title;
                this.Bytes = bytes.ToArray();
            }
        }
    }
}
