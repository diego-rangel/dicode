using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modular.Ddd.Domain.Auditing;
using Modular.Ddd.Domain.Entities;

namespace Modular.EntityFramework.Core.Mappings
{
    public abstract class FullAuditedEntityMap<TEntity, TUser, TUserKey> : 
        EntityMap<TEntity>
        where TEntity : FullAuditedEntity<TUser, TUserKey>
        where TUser : Entity<TUserKey>
    {
        public override void ConfigureEntityBuilder(EntityTypeBuilder<TEntity> builder)
        {
            ConfigureFullAuditedEntityBuilder(builder);

            builder.Property(x => x.CreationTime).IsRequired();
            builder.Property(x => x.CreatorId).IsRequired();
            builder.HasOne(x => x.CreatorUser).WithMany().HasForeignKey(x => x.CreatorId);

            builder.Property(x => x.LastModificationTime).IsRequired(false);
            builder.Property(x => x.ModifierId).IsRequired(false);
            builder.HasOne(x => x.ModifierUser).WithMany().HasForeignKey(x => x.ModifierId);

            builder.Property(x => x.DeletionTime).IsRequired(false);
            builder.Property(x => x.DeleterId).IsRequired(false);
            builder.HasOne(x => x.DeleterUser).WithMany().HasForeignKey(x => x.DeleterId);
        }

        public abstract void ConfigureFullAuditedEntityBuilder(EntityTypeBuilder<TEntity> builder);
    }

    public abstract class FullAuditedEntityMap<TEntity, TEntitykey, TUser, TUserKey> :
        EntityMap<TEntity, TEntitykey>
        where TEntity : FullAuditedEntity<TEntitykey, TUser, TUserKey>
        where TUser : Entity<TUserKey>
    {
        public override void ConfigureEntityBuilder(EntityTypeBuilder<TEntity> builder)
        {
            ConfigureFullAuditedEntityBuilder(builder);

            builder.Property(x => x.CreationTime).IsRequired();
            builder.Property(x => x.CreatorId).IsRequired();
            builder.HasOne(x => x.CreatorUser).WithMany().HasForeignKey(x => x.CreatorId);

            builder.Property(x => x.LastModificationTime).IsRequired(false);
            builder.Property(x => x.ModifierId).IsRequired(false);
            builder.HasOne(x => x.ModifierUser).WithMany().HasForeignKey(x => x.ModifierId);

            builder.Property(x => x.DeletionTime).IsRequired(false);
            builder.Property(x => x.DeleterId).IsRequired(false);
            builder.HasOne(x => x.DeleterUser).WithMany().HasForeignKey(x => x.DeleterId);
        }

        public abstract void ConfigureFullAuditedEntityBuilder(EntityTypeBuilder<TEntity> builder);
    }
}