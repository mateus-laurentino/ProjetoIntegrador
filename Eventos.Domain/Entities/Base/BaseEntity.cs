namespace Eventos.Domain.Entities.Base
{
    public abstract class BaseEntity<TPK>
    {
        public TPK Id { get; protected set; }
    }
}
