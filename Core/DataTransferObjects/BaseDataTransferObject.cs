using CodeGeneration.BusinessObjects;
using System;
using System.Collections.Generic;

namespace CodeGeneration.DataTransferObjects
{
    public abstract class BaseDataTransferObject : IObject
    {
        private Guid _guid;
        /// <summary>
        /// Уникальный идентификатор
        /// </summary>
        public Guid Guid
        {
            get => _guid;
            set => SetValue(nameof(Guid), ref _guid, value);
        }

        /// <summary>
        /// Коллекция, содержащая названия свойств в которых была выполнена установка значения
        /// </summary>
        private HashSet<string> _propertiesWithSetValue = new HashSet<string>();

        /// <summary>
        /// Флаг, определяющий будет ли отслеживаться установка значений в свойствах
        /// </summary>
        public virtual bool TrackingValueChange { get; set; } = true;

        /// <summary>
        /// Метод для установки значения в свойство
        /// Фиксирует факт установки значения в свойство для дальнейшей обработки
        /// </summary>
        /// <typeparam name="T">Тип свойства</typeparam>
        /// <param name="propertyName">Название свойства</param>
        /// <param name="property">Держатель значения свойства</param>
        /// <param name="value">Значение свойства</param>
        protected void SetValue<T>(string propertyName, ref T property, T value)
        {
            if (TrackingValueChange)
                _propertiesWithSetValue.Add(propertyName);

            property = value;
        }

        /// <summary>
        /// Определить устанавливалось ли значение в свойство
        /// </summary>
        /// <param name="propertyName">Название свойства</param>
        /// <returns>true - значение в свойство устанавливалось, false - значение в свойство не устанавливалось</returns>
        public bool IsValueChanged(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName))
            {
                return false;
            }

            return _propertiesWithSetValue.Contains(propertyName);
        }

        /// <summary>
        /// Преобразовать текущий объект для передачи данных в бизнес-объект
        /// </summary>
        /// <returns>Бизнес-объект</returns>
        public abstract IBusinessObject ToBusinessObject();

        /// <summary>
        /// Преобразовать текущий объект для передачи данных в бизнес-объект
        /// </summary>
        /// <param name="businessObject">Бизнес-объект над которым выполняется операция</param>
        /// <returns>Бизнес-объект</returns>
        public virtual IBusinessObject ToBusinessObject(IBusinessObject businessObject)
        {
            return businessObject;
        }
    }
}