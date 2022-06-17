using System;

namespace CodeGeneration.BusinessObjects
{
    public interface IElement
    {
        /// <summary>
        /// Бизнес-объект
        /// </summary>
        IBusinessObject BusinessObject { get; }

        /// <summary>
        /// Имя
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Заголовок
        /// </summary>
        string Caption { get; }

        /// <summary>
        /// Флаг, указывающий, что поле/действие всегда скрыто
        /// </summary>
        bool AlwaysHide { get; set; }

        /// <summary>
        /// Событие, возникающие при изменении видимости поля/действия
        /// </summary>
        event VisibleChangedEventHandler VisibleChanged;

        /// <summary>
        /// Флаг, определющий видимость поля/действия
        /// </summary>
        bool Visible { get; set; }

        /// <summary>
        /// Флаг, указывающий, что поле/действие всегда заблокировано
        /// </summary>
        bool AlwaysDisabled { get; set; }

        /// <summary>
        /// Событие, возникающие при изменении возможности редактирования поля/действия
        /// </summary>
        event EnabledChangedEventHandler EnabledChanged;

        /// <summary>
        /// Флаг, определющий возможность редактирования поля/действия
        /// </summary>
        bool Enabled { get; set; }

        /// <summary>
        /// Обновление свойств поля/действия
        /// </summary>
        void RefreshProperties();
    }
}