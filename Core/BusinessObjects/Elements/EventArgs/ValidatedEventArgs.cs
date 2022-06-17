using System;

namespace CodeGeneration.BusinessObjects
{
    public delegate void ValidatedEventHandler(IBusinessObject sender, ValidatedEventArgs e);

    public class ValidatedEventArgs : EventArgs
    {
        public ValidatedEventArgs(IInteractionResult interactionResult)
        {
            InteractionResult = interactionResult;
        }

        /// <summary>
        /// Результат валидации
        /// </summary>
        public IInteractionResult InteractionResult { get; set; }
    }
}