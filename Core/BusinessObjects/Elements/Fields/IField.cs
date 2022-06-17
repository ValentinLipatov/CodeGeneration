using System;

namespace CodeGeneration.BusinessObjects
{
    public interface IField : IElement
    {
        /// <summary>
        /// Флаг, определяющие обязательность поля
        /// </summary>
        bool IsMandatory { get; set; }

        /// <summary>
        /// Флаг, определяющие установлено ли значение в поле
        /// </summary>
        bool IsValueSet { get; }

        /// <summary>
        /// Флаг, определяющий устанавливалось ли значение в поле
        /// </summary>
        bool IsValueChanged { get; }

        /// <summary>
        /// Событие, возникающие при изменении значения поля
        /// </summary>
        event ValueChangedEventHandler ValueChanged;

        /// <summary>
        /// Значение поля
        /// </summary>
        object Value { get; set; }

        /// <summary>
        /// Расширенная установка значения поля
        /// </summary>
        /// <param name="value">Новое значение поля</param>
        /// <param name="riseValueChanged">Флаг, определяющий будет ли вызвано событие изменения значения</param>
        /// <param name="trackingValueChange">Флаг, определяющий будет ли отслеживаться установка значения в поле</param>
        void SetValue(object value, bool riseValueChanged, bool trackingValueChange);

        /// <summary>
        /// Произвести валидацию поля относительно действия
        /// </summary>
        /// <param name="action">Действие</param>
        /// <returns>Результат валидации</returns>
        IInteractionResult Validate(IAction action);

        /// <summary>
        /// Произвести валидацию поля относительно действия
        /// </summary>
        /// <param name="action">Действие</param>
        /// <param name="interactionResult">Промежуточный результат валидации</param>
        /// <returns>Результат валидации</returns>
        IInteractionResult Validate(IAction action, IInteractionResult interactionResult);
    }
}