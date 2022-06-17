using System;

namespace CodeGeneration.BusinessObjects
{
    public class Group : IGroup
    {
        public Group(string name, string caption)
        {
            Name = name;
            Caption = caption;
        }

        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Заголовок
        /// </summary>
        public string Caption { get; set; }
    }
}