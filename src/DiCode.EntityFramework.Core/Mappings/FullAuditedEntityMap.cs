using DiCode.Domain.Core.Auditing.Contracts;
using DiCode.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiCode.EntityFramework.Core.Mappings
{
    public abstract class FullAuditedEntityMap<TEntity, TEntityKey, TUserKey> : 
        EntityMap<TEntity, TEntityKey>
        where TEntity : Entity<TEntityKey>, IFullAudited<TEntityKey, TUserKey>
        where TUserKey : struct
    {
        public override void ConfigureEntityBuilder(EntityTypeBuilder<TEntity> builder)
        {
            ConfigureFullAuditedEntityBuilder(builder);

            builder.Property(x => x.CreationTime).IsRequired();
            builder.Property(x => x.LastModificationTime).IsRequired(false);
            builder.Property(x => x.DeletionTime).IsRequired(false);
            builder.Property(x => x.CreatorId).IsRequired();
            builder.Property(x => x.ModifierId).IsRequired(false);
            builder.Property(x => x.DeleterId).IsRequired(false);
        }

        public abstract void ConfigureFullAuditedEntityBuilder(EntityTypeBuilder<TEntity> builder);
    }

    public abstract class FullAuditedEntityMap<TEntity, TEntityKey, TUserKey, TUser> : 
        FullAuditedEntityMap<TEntity, TEntityKey, TUserKey>
        where TEntity : Entity<TEntityKey>, IFullAudited<TEntityKey, TUserKey, TUser>
        where TUser : Entity<TUserKey>
        where TUserKey : struct
    {
        public override void ConfigureFullAuditedEntityBuilder(EntityTypeBuilder<TEntity> builder)
        {
            ConfigureFullAuditedEntityWithUserBuilder(builder);

            builder.HasOne(x => x.CreatorUser).WithMany().HasForeignKey(x => x.CreatorId);
            builder.HasOne(x => x.ModifierUser).WithMany().HasForeignKey(x => x.ModifierId);
            builder.HasOne(x => x.DeleterUser).WithMany().HasForeignKey(x => x.DeleterId);
        }

        public abstract void ConfigureFullAuditedEntityWithUserBuilder(EntityTypeBuilder<TEntity> builder);
    }

    public abstract class FullAuditedEntityMap<TEntity> : 
        FullAuditedEntityMap<TEntity, int, int>
        where TEntity : Entity<int>, IFullAudited<int, int>
    {

    }
}