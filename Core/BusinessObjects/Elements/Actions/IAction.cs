using System;

namespace CodeGeneration.BusinessObjects
{
    public interface IAction : IElement
    {
        /// <summary>
        /// Произвести валидацию действия
        /// </summary>
        /// <returns>Результат валидации</returns>
        IInteractionResult Validate();

        /// <summary>
        /// Произвести валидацию действия
        /// </summary>
        /// <param name="interactionResult">Промежуточный результат валидации</param>
        /// <returns>Результат валидации</returns>
        IInteractionResult Validate(IInteractionResult interactionResult);

        /// <summary>
        /// Исполнить действие
        /// </summary>
        void Execute();
    }
}