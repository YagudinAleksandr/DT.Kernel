using System.Threading;
using System.Threading.Tasks;

namespace DT.Kernel
{
    /// <summary>
    /// Репозиторий добавления сущности асинхронно
    /// </summary>
    /// <typeparam name="TAggreagate">Агрегат</typeparam>
    public interface IAddItemAsync<TAggreagate>
        where TAggreagate : class, IAggregateRoot
    {
        /// <summary>
        /// Добавление сущности
        /// </summary>
        /// <param name="item">Сущность</param>
        /// <param name="cancellationToken">Токен отмены</param>
        Task AddAsync(TAggreagate item, CancellationToken cancellationToken = default);
    }
}
