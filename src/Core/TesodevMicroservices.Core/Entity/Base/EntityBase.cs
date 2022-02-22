using System;

namespace TesodevMicroservices.Core.Entity.Base
{
    public class EntityBase<TId>
    {
        public TId Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public EntityBase()
        {
            this.CreatedAt = UpdatedAt = DateTime.Now;
        }
    }
}