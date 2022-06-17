using System;

namespace CodeGeneration.BusinessObjects
{
    public abstract class Element : IElement
    {
        /// <summary>
        /// Бизнес-объект
        /// </summary>
        public IBusinessObject BusinessObject { get; protected set; }

        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Заголовок
        /// </summary>
        public virtual string Caption { get; set; }

        /// <summary>
        /// Флаг, указывающий, что поле/действие всегда скрыто
        /// </summary>
        public bool AlwaysHide { get; set; } = false;

        /// <summary>
        /// Событие, возникающие при изменении видимости поля/действия
        /// </summary>
        public event VisibleChangedEventHandler VisibleChanged;

        private bool _visible = true;
        /// <summary>
        /// Флаг, определющий видимость поля/действия
        /// </summary>
        public virtual bool Visible
        {
            get => _visible;
            set
            {
                value = value && !AlwaysDisabled;
                if (_visible != value)
                {
                    var temp = _visible;
                    _visible = value;
                    VisibleChanged?.Invoke(this, new VisibleChangedEventArgs(temp, _visible));
                }
            }
        }

        /// <summary>
        /// Флаг, указывающий, что поле/действие всегда заблокировано
        /// </summary>
        public bool AlwaysDisabled { get; set; } = false;

        /// <summary>
        /// Событие, возникающие при изменении возможности редактирования поля/действия
        /// </summary>
        public event EnabledChangedEventHandler EnabledChanged;

        private bool _enabled = true;
        /// <summary>
        /// Флаг, определющий возможность редактирования поля/действия
        /// </summary>
        public virtual bool Enabled
        {
            get => _enabled;
            set
            {
                value = value && !AlwaysDisabled;
                if (_enabled != value)
                {
                    var temp = _enabled;
                    _enabled = value;
                    EnabledChanged?.Invoke(this, new EnabledChangedEventArgs(temp, _enabled));
                }
            }
        }

        /// <summary>
        /// Обновление свойств поля/действия
        /// </summary>
        public virtual void RefreshProperties()
        {
            Enabled = Enabled;
            Visible = Visible;
        }

        /// <summary>
        /// Установить зависимость от поля
        /// </summary>
        /// <typeparam name="T">Тип свойства</typeparam>
        /// <param name="name">Имя свойства</param>
        /// <param name="property">Свойство</param>
        /// <param name="value">Новое значение свойства</param>
        protected void SetDependence<T>(string name, ref T property, T value) where T : IField
        {
            // Удаляем предыдущую зависимость
            BusinessObject.RemoveDependence(this, property);

            property = value;

            // Устанавливаем новую зависимость
            BusinessObject.AddDependence(this, property);
        }
    }
}