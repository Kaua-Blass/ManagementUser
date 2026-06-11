using Microsoft.EntityFrameworkCore;
using ManagementUser.Models;
namespace ManagementUser.Data;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    { }
    public DbSet<User> Users { get; set; }
    public DbSet<Perfil> Perfis { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasOne(u => u.Perfil)
            .WithMany(p => p.Usuarios)
            .HasForeignKey(u => u.PerfilId)
            .OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<Perfil>().HasData(
            new Perfil { Id = 1, Nome = "Admin", Descricao = "Administrador do sistema" },
            new Perfil { Id = 2, Nome = "Cliente", Descricao = "Usuario comum" },
            new Perfil { Id = 3, Nome = "Gerente", Descricao = "Gerente de operacoes" }
        );
    }
}