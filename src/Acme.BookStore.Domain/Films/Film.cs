using System;
using Volo.Abp.Domain.Entities;

namespace Acme.BookStore.Domain.Films
{
    public class Film:Entity<Guid>
    {
        public virtual Guid AuthorId { get; internal set; }
        public string Name { get; set; }
    }
}