using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DT.Kernel
{
    /// <summary>
    /// Репозиторий получения записей
    /// </summary>
    /// <typeparam name="TAggregate">Агрегат</typeparam>
    /// <typeparam name="TKey">Тип идентификатора</typeparam>
    public interface IGetItem<TAggregate, TKey>
         where TAggregate : class, IAggregateRoot where TKey : notnull 
    {
        /// <summary>
        /// Получение записи по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>Запись</returns>
        TAggregate? GetById(TKey id);

        /// <summary>
        /// Получение записи по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Запись</returns>
        Task<TAggregate?> GetByIdAsync(TKey id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Получение всех записей
        /// </summary>
        /// <returns>Запрос типа <see cref="IQueryable"/></returns>
        IQueryable<TAggregate> GetAll();

        /// <summary>
        /// Получение всех записей
        /// </summary>
        /// <returns>Запрос типа <see cref="IQueryable"/></returns>
        Task<IQueryable<TAggregate>> GetAllAsync(CancellationToken cancellationToken = default);
    }
}
