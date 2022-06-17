using System;

namespace CodeGeneration.BusinessObjects
{
    public class Field<T> : Element, IField
    {
        public Field(IBusinessObject businessObject)
        {
            BusinessObject = businessObject;
        }

        public Field(IBusinessObject businessObject, string name, string caption) : this(businessObject)
        {
            Name = name;
            Caption = caption;
        }

        /// <summary>
        /// Флаг, определяющие обязательность поля
        /// </summary>
        public bool IsMandatory { get; set; } = false;

        /// <summary>
        /// Флаг, определяющие установлено ли значение в поле
        /// </summary>
        public bool IsValueSet => Value != null;

        /// <summary>
        /// Флаг, определяющий устанавливалось ли значение в поле
        /// </summary>
        public bool IsValueChanged { get; protected set; } = false;

        /// <summary>
        /// Событие, возникающие при изменении значения поля
        /// </summary>
        public event ValueChangedEventHandler ValueChanged;

        private T _value;
        /// <summary>
        /// Значение поля
        /// </summary>
        public T Value
        {
            get => _value;
            set => SetValue(value, true, true);
        }

        /// <summary>
        /// Значение поля
        /// </summary>
        object IField.Value
        {
            get => Value;
            set => SetValue(value, true, true);
        }

        /// <summary>
        /// Расширенная установка значения поля
        /// </summary>
        /// <param name="value">Новое значение поля</param>
        /// <param name="riseValueChanged">Флаг, определяющий будет ли вызвано событие изменения значения</param>
        /// <param name="trackingValueChange">Флаг, определяющий будет ли отслеживаться установка значения в поле</param>
        public void SetValue(object value, bool riseValueChanged, bool trackingValueChange)
        {
            SetValue((T)value, riseValueChanged, trackingValueChange);
        }

        /// <summary>
        /// Расширенная установка значения поля
        /// </summary>
        /// <param name="value">Новое значение поля</param>
        /// <param name="riseValueChanged">Флаг, определяющий будет ли вызвано событие изменения значения</param>
        /// <param name="trackingValueChange">Флаг, определяющий будет ли отслеживаться установка значения в поле</param>
        private void SetValue(T value, bool riseValueChanged, bool trackingValueChange)
        {
            if (!_value.Equals(value))
            {
                var temp = _value;
                _value = value;

                if (riseValueChanged)
                    ValueChanged?.Invoke(this, new ValueChangedEventArgs(temp, _value));

                if (trackingValueChange && BusinessObject.TrackingValueChange)
                    IsValueChanged = true;
            }
        }

        /// <summary>
        /// Произвести валидацию поля относительно действия
        /// </summary>
        /// <param name="action">Действие</param>
        /// <returns>Результат валидации</returns>
        public IInteractionResult Validate(IAction action)
        {
            return Validate(action, new InteractionResult());
        }

        /// <summary>
        /// Произвести валидацию поля относительно действия
        /// </summary>
        /// <param name="action">Действие</param>
        /// <param name="interactionResult">Промежуточный результат валидации</param>
        /// <returns>Результат валидации</returns>
        public virtual IInteractionResult Validate(IAction action, IInteractionResult interactionResult)
        {
            if (IsMandatory && !IsValueSet)
                interactionResult.AddError(this, "Поле не заполнено");

            return interactionResult;
        }

        /// <summary>
        /// Обновление свойств поля/действия
        /// </summary>
        public override void RefreshProperties()
        {
            base.RefreshProperties();

            Value = Value;
        }
    }
}