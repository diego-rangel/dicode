using DiCode.Domain.Core.Auditing.Contracts;
using DiCode.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiCode.EntityFramework.Core.Mappings
{
    public abstract class AuditedEntityMap<TEntity, TEntityKey, TUserKey> : EntityMap<TEntity, TEntityKey>
        where TEntity : Entity<TEntityKey>, IAudited<TEntityKey, TUserKey>
        where TUserKey : struct
    {
        public override void ConfigureEntityBuilder(EntityTypeBuilder<TEntity> builder)
        {
            ConfigureAuditedEntityBuilder(builder);

            builder.Property(x => x.CreationTime).IsRequired();
            builder.Property(x => x.LastModificationTime).IsRequired(false);
            builder.Property(x => x.CreatorId).IsRequired();
            builder.Property(x => x.ModifierId).IsRequired(false);
        }

        public abstract void ConfigureAuditedEntityBuilder(EntityTypeBuilder<TEntity> builder);
    }
    
    public abstract class AuditedEntityMap<TEntity, TEntityKey, TUserKey, TUser> : AuditedEntityMap<TEntity, TEntityKey, TUserKey>
        where TEntity : Entity<TEntityKey>, IAudited<TEntityKey, TUserKey, TUser>
        where TUser : Entity<TUserKey>
        where TUserKey : struct
    {
        public override void ConfigureAuditedEntityBuilder(EntityTypeBuilder<TEntity> builder)
        {
            ConfigureAuditedEntityWithUserBuilder(builder);

            builder.HasOne(x => x.CreatorUser).WithMany().HasForeignKey(x => x.CreatorId);
            builder.HasOne(x => x.ModifierUser).WithMany().HasForeignKey(x => x.ModifierId);
        }

        public abstract void ConfigureAuditedEntityWithUserBuilder(EntityTypeBuilder<TEntity> builder);
    }

    public abstract class AuditedEntityMap<TEntity> : AuditedEntityMap<TEntity, int, int>
        where TEntity : Entity<int>, IAudited<int, int>
    {

    }
}