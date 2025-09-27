using System.Collections.Generic;

namespace DT.Kernel
{
    /// <summary>
    /// Интерфейс корня агрегата
    /// </summary>
    public interface IAggregateRoot
    {
        /// <summary>
        /// Коллекция доменных событий
        /// </summary>
        IReadOnlyCollection<IDomainEvent> DomainEvents { get; }

        /// <summary>
        /// Очистка доменных событий
        /// </summary>
        void ClearDomainEvents();

        /// <summary>
        /// Добавление доменных событий
        /// </summary>
        /// <param name="domainEvent">Доменное событие</param>
        void AddDomainEvent(IDomainEvent domainEvent);
    }
}
