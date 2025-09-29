namespace DT.Kernel
{
    /// <summary>
    /// Репозиторий удаления сущности
    /// </summary>
    /// <typeparam name="TAggreagate">Агрегат</typeparam>
    public interface IDeleteItem<TAggreagate> 
        where TAggreagate : IAggregateRoot
    {
        /// <summary>
        /// Удаление сущности
        /// </summary>
        /// <param name="aggreagate">Агрегат</param>
        void Delete(TAggreagate aggreagate);
    }
}
