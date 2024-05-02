

using Microsoft.EntityFrameworkCore;
using Omini.Opme.Be.Domain.Entities;
using Omini.Opme.Be.Domain.Repositories;
using Omini.Opme.Be.Infrastructure.Contexts;

namespace Omini.Opme.Be.Infrastructure.Repositories;

internal class QuotationRepository : Repository<Quotation>, IQuotationRepository
{
    public QuotationRepository(OpmeContext context) : base(context)
    {
    }

    public override async Task<List<Quotation>> GetAll()
    {
        return await DbSet.AsNoTracking()
                          .Include(p => p.Items)
                          .ToListAsync();
    }

    public override async Task<Quotation?> GetById(Guid id)
    {
        return await DbSet.Include(p => p.Items)
                          .SingleOrDefaultAsync(p => p.Id == id);
    }
}