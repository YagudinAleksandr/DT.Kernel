namespace DT.Kernel
{
    /// <summary>
    /// Репозиторий обновления сущности
    /// </summary>
    /// <typeparam name="TAggregate">Агрегат</typeparam>
    public interface IUpdateItem<TAggregate> 
        where TAggregate : IAggregateRoot
    {
        /// <summary>
        /// Обновление агрегата
        /// </summary>
        /// <param name="aggregate">Агрегат</param>
        void Update(TAggregate aggregate);
    }
}
