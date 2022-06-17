using CodeGeneration.BusinessObjects;

namespace CodeGeneration.DataTransferObjects
{
    public interface IDataTransferObject : IObject
    {
        /// <summary>
        /// Преобразовать текущий объект для передачи данных в бизнес-объект
        /// </summary>
        /// <returns>Бизнес-объект</returns>
        IBusinessObject ToBusinessObject();
    }
}