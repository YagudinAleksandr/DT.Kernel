using System.Threading;
using System.Threading.Tasks;

namespace DT.Kernel
{
    /// <summary>
    /// Репозиторий добавления сущности
    /// </summary>
    /// <typeparam name="TAggreagate">Агрегат</typeparam>
    public interface IAddItem<TAggreagate> 
        where TAggreagate : IAggregateRoot
    {
        /// <summary>
        /// Добавление сущности
        /// </summary>
        /// <param name="item">Сущность</param>
        void Add(TAggreagate item);

        /// <summary>
        /// Добавление сущности
        /// </summary>
        /// <param name="item">Сущность</param>
        /// <param name="cancellationToken">Токен отмены</param>
        Task AddAsync(TAggreagate item, CancellationToken cancellationToken = default);
    }
}
