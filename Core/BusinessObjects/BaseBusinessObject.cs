using CodeGeneration.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeGeneration.BusinessObjects
{
    public abstract class BaseBusinessObject : IBusinessObject
    {
        public BaseBusinessObject(string name, string caption)
        {
            Name = name;
            Caption = caption;

            CreateFields();
            CreateActions();
            CreateGroups();
        }

        private Guid _guid;
        /// <summary>
        /// Уникальный идентификатор
        /// </summary>
        public Guid Guid
        {
            get => _guid;
            set => _guid = value;
        }

        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; protected set; }

        /// <summary>
        /// Заголовок
        /// </summary>
        public string Caption { get; protected set; }

        /// <summary>
        /// Флаг, указывающий отлеживается ли изменение значений полей
        /// </summary>
        public bool TrackingValueChange { get; set; } = true;

        /// <summary>
        /// Коллекция полей
        /// </summary>
        public IList<IField> Fields { get; protected set; } = new List<IField>();

        /// <summary>
        /// Коллекция действий
        /// </summary>
        public IList<IAction> Actions { get; protected set; } = new List<IAction>();

        /// <summary>
        /// Коллекция групп
        /// </summary>
        public IList<IGroup> Groups { get; protected set; } = new List<IGroup>();

        /// <summary>
        /// Создать автоматически сгенерированные поля и заполнить коллекцию
        /// </summary>
        protected virtual void CreateGeneratedFields()
        {

        }

        /// <summary>
        /// Создать поля и заполнить коллекцию
        /// </summary>
        protected virtual void CreateFields()
        {
            CreateGeneratedFields();
        }

        /// <summary>
        /// Добавить поле
        /// </summary>
        /// <typeparam name="T">Тип поля</typeparam>
        /// <param name="field">Поле</param>
        /// <returns>Поле</returns>
        protected T AddField<T>(T field) where T : IField
        {
            field.ValueChanged += OnValueChange;
            Fields.Add(field);
            return field;
        }

        /// <summary>
        /// Создать автоматически сгенерированные действия и заполнить коллекцию
        /// </summary>
        protected virtual void CreateGeneratedActions()
        {

        }

        /// <summary>
        /// Создать действия и заполнить коллекцию
        /// </summary>
        protected virtual void CreateActions()
        {
            CreateGeneratedActions();
        }

        /// <summary>
        /// Добавить действие
        /// </summary>
        /// <typeparam name="T">Тип действия</typeparam>
        /// <param name="action">Действие</param>
        /// <returns>Действие</returns>
        protected T AddAction<T>(T action) where T : IAction
        {
            Actions.Add(action);
            return action;
        }

        /// <summary>
        /// Создать автоматически сгенерированные группы и заполнить коллекцию
        /// </summary>
        protected virtual void CreateGeneratedGroups()
        {

        }

        /// <summary>
        /// Создать группы и заполнить коллекцию
        /// </summary>
        protected virtual void CreateGroups()
        {
            CreateGeneratedGroups();
        }

        /// <summary>
        /// Добавить группу
        /// </summary>
        /// <typeparam name="T">Тип группы</typeparam>
        /// <param name="group">Группа</param>
        /// <returns>Группа</returns>
        protected T AddGroup<T>(T group) where T : IGroup
        {
            Groups.Add(group);
            return group;
        }

        /// <summary>
        /// Исполнить действие при успешной валидации бизнес-объекта
        /// </summary>
        /// <param name="action">Действие</param>
        public void Execute(IAction action)
        {
            if (Validate(action).Success)
                action.Execute();
        }

        /// <summary>
        /// Событие, возникающее после валидации бизнес-объекта
        /// </summary>
        public event ValidatedEventHandler Validated;

        /// <summary>
        /// Произвести валидацию бизнес-объекта относительно действия
        /// </summary>
        /// <param name="action">Действие</param>
        /// <returns>Результат валидации</returns>
        public IInteractionResult Validate(IAction action)
        {
            var result = new InteractionResult();

            action.Validate(result);

            foreach (var field in Fields)
                field.Validate(action, result);

            Validate(action, result);

            Validated?.Invoke(this, new ValidatedEventArgs(result));

            return result;
        }

        /// <summary>
        /// Произвести валидацию бизнес-объекта относительно действия
        /// </summary>
        /// <param name="action">Действие</param>
        /// <param name="interactionResult">Промежуточный результат валидации</param>
        /// <returns>Результат валидации</returns>
        public virtual IInteractionResult Validate(IAction action, IInteractionResult interactionResult)
        {
            return interactionResult;
        }

        /// <summary>
        /// Определить устанавливалось ли значение в поле
        /// </summary>
        /// <param name="propertyName">Название поля</param>
        /// <returns>true - значение в поле устанавливалось, false - значение в поле не устанавливалось</returns>
        public bool IsValueChanged(string fieldName)
        {
            var field = Fields.FirstOrDefault(e => e.Name == fieldName);
            if (field != null)
                return field.IsValueChanged;
            else
                throw new InvalidOperationException();
        }

        /// <summary>
        /// Преобразовать текущий бизнес-объект в объект для передачи данных
        /// </summary>
        /// <returns>Объект для передачи данных</returns>
        public abstract IDataTransferObject ToDataTransferObject();

        /// <summary>
        /// Преобразовать текущий бизнес-объект в объект для передачи данных
        /// </summary>
        /// <param name="dataTransferObject">Объект для передачи данных над которым выполняется операция</param>
        /// <returns>Объект для передачи данных</returns>
        public virtual IDataTransferObject ToDataTransferObject(IDataTransferObject dataTransferObject)
        {
            return dataTransferObject;
        }

        /// <summary>
        /// Словарь зависимостей
        /// </summary>
        public IDictionary<IElement, IList<IField>> Dependencies = new Dictionary<IElement, IList<IField>>();

        /// <summary>
        /// Добавить зависимость от поля
        /// </summary>
        /// <param name="element">Элемент</param>
        /// <param name="field">Поле</param>
        public void AddDependence(IElement element, IField field)
        {
            if (Dependencies.TryGetValue(element, out var dependencies))
                dependencies.Add(field);
            else
                Dependencies.Add(element, new List<IField>());
        }

        /// <summary>
        /// Удалить зависимость от поля
        /// </summary>
        /// <param name="element">Элемент</param>
        /// <param name="field">Поле</param>
        public void RemoveDependence(IElement element, IField field)
        {
            if (Dependencies.TryGetValue(element, out var dependencies))
                dependencies.Remove(field);
        }

        /// <summary>
        /// Получить порядок пересчета элементов относительно поля
        /// </summary>
        /// <param name="field">Поле</param>
        public IList<IElement> GetCalculationOrder(IField field)
        {
            var result = new List<IElement>();
            foreach (var item in Dependencies)
            {
                if (item.Value.Contains(field))
                    result.Add(item.Key);
            }
            return result;
        }

        /// <summary>
        /// Флаг, указывающий, что идет процесс пересчета элементов
        /// </summary>
        protected bool IsCalculationProcess = false;

        /// <summary>
        /// Обработчик события изменения значения поля
        /// </summary>
        /// <param name="field">Поле</param>
        /// <param name="eventArgs">Аргументы события</param>
        public void OnValueChange(IField field, ValueChangedEventArgs eventArgs)
        {
            if (IsCalculationProcess)
                return;

            IsCalculationProcess = true;

            foreach (var item in GetCalculationOrder(field))
                item.RefreshProperties();

            IsCalculationProcess = false;
        }
    }
}