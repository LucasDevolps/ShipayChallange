using Microsoft.EntityFrameworkCore;
using ShipayChallange.Domain.Entities;
using ShipayChallange.Entities;

namespace ShipayChallange.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Role> Roles => Set<Role>();
    public DbSet<Claims> Claims => Set<Claims>();
    public DbSet<User> Users => Set<User>();
    public DbSet<UserClaim> UserClaims => Set<UserClaim>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable("roles");
            entity.HasKey(x => x.Id);

            entity.Property(x => x.Id).HasColumnName("id");
            entity.Property(x => x.Description)
                .HasColumnName("description")
                .IsRequired();
        });

        modelBuilder.Entity<Claims>(entity =>
        {
            entity.ToTable("claims");
            entity.HasKey(x => x.Id);

            entity.Property(x => x.Id).HasColumnName("id");
            entity.Property(x => x.Description)
                .HasColumnName("description")
                .IsRequired();
            entity.Property(x => x.Active)
                .HasColumnName("active")
                .IsRequired();
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("users");
            entity.HasKey(x => x.Id);

            entity.Property(x => x.Id).HasColumnName("id");
            entity.Property(x => x.Name).HasColumnName("name").IsRequired();
            entity.Property(x => x.Email).HasColumnName("email").IsRequired();
            entity.Property(x => x.Password).HasColumnName("password").IsRequired();
            entity.Property(x => x.RoleId).HasColumnName("role_id").IsRequired();
            entity.Property(x => x.CreatedAt).HasColumnName("created_at").IsRequired();
            entity.Property(x => x.UpdatedAt).HasColumnName("updated_at");

            entity.HasOne(x => x.Role)
                .WithMany(x => x.Users)
                .HasForeignKey(x => x.RoleId);
        });

        modelBuilder.Entity<UserClaim>(entity =>
        {
            entity.ToTable("user_claims");
            entity.HasKey(x => new { x.UserId, x.ClaimId });

            entity.Property(x => x.UserId).HasColumnName("user_id");
            entity.Property(x => x.ClaimId).HasColumnName("claim_id");

            entity.HasOne(x => x.User)
                .WithMany(x => x.UserClaims)
                .HasForeignKey(x => x.UserId);

            entity.HasOne(x => x.Claim)
                .WithMany(x => x.UserClaims)
                .HasForeignKey(x => x.ClaimId);
        });
    }
}
