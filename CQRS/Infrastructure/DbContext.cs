using System;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CQRS.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public RegistrationFlowContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<RedBetCustomer> ExampleEntities { get; set; }        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var infrastructureAssembly = Assembly.GetAssembly(typeof(EntityConfiguration));

            if (infrastructureAssembly != null)
            {
                modelBuilder.ApplyConfigurationsFromAssembly(infrastructureAssembly);
            }
        }
    }

    internal class EntityConfiguration : IEntityTypeConfiguration<ExampleEntity>
    {
        public void Configure(EntityTypeBuilder<ExampleEntity> builder)
        {
            builder.HasKey(i => i.Id);
        }
    }

    public class ExampleEntity 
    {
        public int Id { get; set; }
    }
}