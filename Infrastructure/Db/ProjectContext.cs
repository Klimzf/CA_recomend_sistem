﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Ca_recomend_sistem.Core;

namespace CA_recomend_sistem.Infrastructure.Db
{
    internal class ProjectContext : DbContext
    {
        class IdConverter() : ValueConverter<Id, Guid>(x => x.Value, x => new Id(x));

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder
                .Properties<Id>()
                .HaveConversion<IdConverter>();
            base.ConfigureConventions(configurationBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var entityTypes = typeof(IEntity).Assembly
                                             .GetTypes()
                                             .Where(x => typeof(IEntity).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract);

            foreach (var entityType in entityTypes)
                modelBuilder.Entity(entityType)
                            .Property(nameof(IEntity.Id))
                            .HasDefaultValueSql("NEWSEQUENTIALID()");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies()
                          .UseSqlServer("Data Source=DREAMBOOK;Integrated Security=True;Encrypt=False;");
            base.OnConfiguring(optionsBuilder);
        }

        public ProjectContext() => Database.Migrate(); // todo shit to fix
    }
}
