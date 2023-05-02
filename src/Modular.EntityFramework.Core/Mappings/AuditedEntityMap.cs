using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modular.Ddd.Domain.Auditing;
using Modular.Ddd.Domain.Entities;

namespace Modular.EntityFramework.Core.Mappings
{
    public abstract class AuditedEntityMap<TEntity, TUser, TUserKey> :
        EntityMap<TEntity>
        where TEntity : AuditedEntity<TUser, TUserKey>
        where TUser : Entity<TUserKey>
    {
        public override void ConfigureEntityBuilder(EntityTypeBuilder<TEntity> builder)
        {
            ConfigureAuditedEntityBuilder(builder);

            builder.Property(x => x.CreationTime).IsRequired();
            builder.Property(x => x.CreatorId).IsRequired();
            builder.HasOne(x => x.CreatorUser).WithMany().HasForeignKey(x => x.CreatorId);

            builder.Property(x => x.LastModificationTime).IsRequired(false);
            builder.Property(x => x.ModifierId).IsRequired(false);
            builder.HasOne(x => x.ModifierUser).WithMany().HasForeignKey(x => x.ModifierId);
        }

        public abstract void ConfigureAuditedEntityBuilder(EntityTypeBuilder<TEntity> builder);
    }
    
    public abstract class AuditedEntityMap<TEntity, TEntitykey, TUser, TUserKey> :
        EntityMap<TEntity, TEntitykey>
        where TEntity : AuditedEntity<TEntitykey, TUser, TUserKey>
        where TUser : Entity<TUserKey>
    {
        public override void ConfigureEntityBuilder(EntityTypeBuilder<TEntity> builder)
        {
            ConfigureAuditedEntityBuilder(builder);

            builder.Property(x => x.CreationTime).IsRequired();
            builder.Property(x => x.CreatorId).IsRequired();
            builder.HasOne(x => x.CreatorUser).WithMany().HasForeignKey(x => x.CreatorId);

            builder.Property(x => x.LastModificationTime).IsRequired(false);
            builder.Property(x => x.ModifierId).IsRequired(false);
            builder.HasOne(x => x.ModifierUser).WithMany().HasForeignKey(x => x.ModifierId);
        }

        public abstract void ConfigureAuditedEntityBuilder(EntityTypeBuilder<TEntity> builder);
    }
}