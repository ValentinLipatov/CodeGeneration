using System;

namespace CodeGeneration.BusinessObjects
{
    public delegate void EnabledChangedEventHandler(IElement sender, EnabledChangedEventArgs e);

    public class EnabledChangedEventArgs : EventArgs
    {
        public EnabledChangedEventArgs(bool oldValue, bool newValue)
        {
            OldValue = oldValue;
            NewValue = newValue;
        }

        /// <summary>
        /// Старое значение
        /// </summary>
        public bool OldValue { get; set; }

        /// <summary>
        /// Новое значение
        /// </summary>
        public bool NewValue { get; set; }
    }
}