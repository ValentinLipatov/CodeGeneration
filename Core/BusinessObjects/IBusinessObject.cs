using CodeGeneration.DataTransferObjects;
using System.Collections.Generic;

namespace CodeGeneration.BusinessObjects
{
    public interface IBusinessObject : IObject
    {
        /// <summary>
        /// Имя
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Заголовок
        /// </summary>
        string Caption { get; }

        /// <summary>
        /// Коллекция полей
        /// </summary>
        IList<IField> Fields { get; }

        /// <summary>
        /// Коллекция действий
        /// </summary>
        IList<IAction> Actions { get; }

        /// <summary>
        /// Коллекция групп
        /// </summary>
        IList<IGroup> Groups { get; }

        /// <summary>
        /// Исполнить действие при успешной валидации бизнес-объекта
        /// </summary>
        /// <param name="action">Действие</param>
        void Execute(IAction action);

        /// <summary>
        /// Событие, возникающее после валидации бизнес-объекта
        /// </summary>
        event ValidatedEventHandler Validated;

        /// <summary>
        /// Произвести валидацию бизнес-объекта относительно действия
        /// </summary>
        /// <param name="action">Действие</param>
        /// <returns>Результат валидации</returns>
        IInteractionResult Validate(IAction action);

        /// <summary>
        /// Преобразовать текущий бизнес-объект в объект для передачи данных
        /// </summary>
        /// <returns>Объект для передачи данных</returns>
        IDataTransferObject ToDataTransferObject();

        /// <summary>
        /// Добавить зависимость от поля
        /// </summary>
        /// <param name="element">Элемент</param>
        /// <param name="field">Поле</param>
        public void AddDependence(IElement element, IField field);

        /// <summary>
        /// Удалить зависимость от поля
        /// </summary>
        /// <param name="element">Элемент</param>
        /// <param name="field">Поле</param>
        public void RemoveDependence(IElement element, IField field);
    }
}