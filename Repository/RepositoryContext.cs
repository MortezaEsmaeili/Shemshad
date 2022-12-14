using Entities.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Repository.Configuration;

namespace Repository;

public class RepositoryContext : IdentityDbContext<User>
{
	public RepositoryContext(DbContextOptions options)
		: base(options)
	{
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);
		
		modelBuilder.ApplyConfiguration(new SchoolConfiguration());
		modelBuilder.ApplyConfiguration(new StudentConfiguration());
		modelBuilder.ApplyConfiguration(new RoleConfiguration());
		
	}

	public DbSet<School>? Schools { get; set; }
	public DbSet<Student>? Students { get; set; }
}
