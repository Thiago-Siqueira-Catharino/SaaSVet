using SaaSVet.Contexts.Auth.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SaaSVet.Contexts.Auth.Infrastructure.Persistance;

public class AuthDbContext : IdentityDbContext<Usuario>
{
    public DbSet<Usuario> Usuarios { get; set; }

    public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
    {
    }
}