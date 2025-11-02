using System;

namespace DT.Kernel
{
    /// <summary>
    /// Абстрактное доменное событие
    /// </summary>
    public abstract class DomainEvent : IDomainEvent
    {
        /// <inheritdoc/>
        public Guid EventId => Guid.NewGuid();

        /// <inheritdoc/>
        public DateTimeOffset OccuredOn => DateTimeOffset.Now;
    }
}
