using System.Threading;
using System.Threading.Tasks;

namespace DT.Kernel
{
    /// <summary>
    /// Репозиторий обновления сущности асинхронно
    /// </summary>
    /// <typeparam name="TAggregate">Агрегат</typeparam>
    public interface IUpdateItemAsync<TAggregate>
        where TAggregate : IAggregateRoot
    {

        /// <summary>
        /// Обновление агрегата
        /// </summary>
        /// <param name="aggregate">Агрегат</param>
        /// <param name="cancellationToken">Токен отмены</param>
        Task UpdateAsync(TAggregate aggregate, CancellationToken cancellationToken = default);
    }
}
