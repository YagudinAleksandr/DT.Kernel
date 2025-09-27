using System.Threading;
using System.Threading.Tasks;

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

        /// <summary>
        /// Удаление сущности
        /// </summary>
        /// <param name="aggreagate">Агрегат</param>
        /// <param name="cancellationToken">Токен отмены</param>
        Task DeleteAsync(TAggreagate aggreagate, CancellationToken cancellationToken = default);
    }
}
