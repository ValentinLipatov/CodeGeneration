using System;

namespace CodeGeneration.BusinessObjects
{
    public delegate void ValueChangedEventHandler(IField sender, ValueChangedEventArgs e);

    public class ValueChangedEventArgs : EventArgs
    {
        public ValueChangedEventArgs(object oldValue, object newValue)
        {
            OldValue = oldValue;
            NewValue = newValue;
        }

        /// <summary>
        /// Старое значение
        /// </summary>
        public object OldValue { get; set; }

        /// <summary>
        /// Новое значение
        /// </summary>
        public object NewValue { get; set; }
    }
}