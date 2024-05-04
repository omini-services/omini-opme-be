using Microsoft.EntityFrameworkCore;
using Omini.Opme.Be.Domain.Entities;
using Omini.Opme.Be.Domain.Repositories;
using Omini.Opme.Be.Infrastructure.Contexts;

namespace Omini.Opme.Be.Infrastructure.Repositories;

internal class IdentityOpmeUserRepository : IIdentityOpmeUserRepository
{
    private readonly OpmeContext _context;

    public IdentityOpmeUserRepository(OpmeContext context)
    {
        _context = context;
    }

    public async Task Create(IdentityOpmeUser user)
    {
        await _context.IdentityOpmeUsers.AddAsync(user);
    }

    public async Task<IdentityOpmeUser?> FindByEmail(string email)
    {
        return await _context.IdentityOpmeUsers.AsNoTracking().SingleOrDefaultAsync(p=>p.Email == email);
    }
}
