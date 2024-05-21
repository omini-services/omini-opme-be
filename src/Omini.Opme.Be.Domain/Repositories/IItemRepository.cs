using Omini.Opme.Be.Domain.Entities;

namespace Omini.Opme.Be.Domain.Repositories;

public interface IItemRepository : IRepository<Item>
{
    Task<Item?> GetByCode(string code, CancellationToken cancellationToken = default);
}