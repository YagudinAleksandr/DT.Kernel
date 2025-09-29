using System.Threading;
using System.Threading.Tasks;

namespace DT.Kernel
{
    /// <summary>
    /// Репозиторий удаления сущности асинхронно
    /// </summary>
    /// <typeparam name="TAggreagate">Агрегат</typeparam>
    public interface IDeleteItemAsync<TAggreagate>
        where TAggreagate : IAggregateRoot
    {

        /// <summary>
        /// Удаление сущности
        /// </summary>
        /// <param name="aggreagate">Агрегат</param>
        /// <param name="cancellationToken">Токен отмены</param>
        Task DeleteAsync(TAggreagate aggreagate, CancellationToken cancellationToken = default);
    }
}
