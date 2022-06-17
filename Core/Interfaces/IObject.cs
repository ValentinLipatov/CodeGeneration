using System;

namespace CodeGeneration
{
    public interface IObject
    {
        /// <summary>
        /// Уникальный идентификатор
        /// </summary>
        Guid Guid { get; set; }

        /// <summary>
        /// Флаг, определяющий будет ли отслеживаться установка значений в свойствах/полях
        /// </summary>
        bool TrackingValueChange { get; set; }

        /// <summary>
        /// Определить устанавливалось ли значение в свойство/поле
        /// </summary>
        /// <param name="propertyName">Название свойства/поля</param>
        /// <returns>true - значение в свойство/поле устанавливалось, false - значение в свойство/поле не устанавливалось</returns>
        bool IsValueChanged(string propertyName);
    }
}