using System;

namespace CodeGeneration.BusinessObjects
{
    public interface IGroup
    {
        /// <summary>
        /// Имя
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Заголовок
        /// </summary>
        string Caption { get; set; }
    }
}