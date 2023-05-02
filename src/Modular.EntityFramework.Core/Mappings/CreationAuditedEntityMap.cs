using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modular.Ddd.Domain.Auditing;
using Modular.Ddd.Domain.Entities;

namespace Modular.EntityFramework.Core.Mappings
{
    public abstract class CreationAuditedEntityMap<TEntity, TUser, TUserKey> : 
        EntityMap<TEntity>
        where TEntity : CreationAuditedEntity<TUser, TUserKey>
        where TUser : Entity<TUserKey>
    {
        public override void ConfigureEntityBuilder(EntityTypeBuilder<TEntity> builder)
        {
            ConfigureCreationAuditedEntityBuilder(builder);

            builder.Property(x => x.CreationTime).IsRequired();
            builder.Property(x => x.CreatorId).IsRequired();
            builder.HasOne(x => x.CreatorUser).WithMany().HasForeignKey(x => x.CreatorId);
        }

        public abstract void ConfigureCreationAuditedEntityBuilder(EntityTypeBuilder<TEntity> builder);
    }

    public abstract class CreationAuditedEntityMap<TEntity, TEntitykey, TUser, TUserKey> :
        EntityMap<TEntity, TEntitykey>
        where TEntity : CreationAuditedEntity<TEntitykey, TUser, TUserKey>
        where TUser : Entity<TUserKey>
    {
        public override void ConfigureEntityBuilder(EntityTypeBuilder<TEntity> builder)
        {
            ConfigureCreationAuditedEntityBuilder(builder);

            builder.Property(x => x.CreationTime).IsRequired();
            builder.Property(x => x.CreatorId).IsRequired();
            builder.HasOne(x => x.CreatorUser).WithMany().HasForeignKey(x => x.CreatorId);
        }

        public abstract void ConfigureCreationAuditedEntityBuilder(EntityTypeBuilder<TEntity> builder);
    }
}