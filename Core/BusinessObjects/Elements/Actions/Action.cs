using System;

namespace CodeGeneration.BusinessObjects
{
    public abstract class Action : Element, IAction
    {
        public Action(IBusinessObject businessObject)
        {
            BusinessObject = businessObject;
        }

        public Action(IBusinessObject businessObject, string name, string caption) : this (businessObject)
        {
            Name = name;
            Caption = caption;
        }

        /// <summary>
        /// Произвести валидацию действия
        /// </summary>
        /// <returns>Результат валидации</returns>
        public IInteractionResult Validate()
        {
            return Validate(new InteractionResult());
        }

        /// <summary>
        /// Произвести валидацию действия
        /// </summary>
        /// <param name="interactionResult">Промежуточный результат валидации</param>
        /// <returns>Результат валидации</returns>
        public virtual IInteractionResult Validate(IInteractionResult interactionResult)
        {
            return interactionResult;
        }

        /// <summary>
        /// Исполнить действие
        /// </summary>
        public abstract void Execute();
    }
}