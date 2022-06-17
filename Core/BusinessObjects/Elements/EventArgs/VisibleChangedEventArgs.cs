using System;

namespace CodeGeneration.BusinessObjects
{
    public delegate void VisibleChangedEventHandler(IElement sender, VisibleChangedEventArgs e);

    public class VisibleChangedEventArgs : EventArgs
    {
        public VisibleChangedEventArgs(bool oldValue, bool newValue)
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