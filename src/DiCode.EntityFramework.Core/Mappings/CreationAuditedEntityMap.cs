using DiCode.Domain.Core.Auditing.Contracts;
using DiCode.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiCode.EntityFramework.Core.Mappings
{
    public abstract class CreationAuditedEntityMap<TEntity, TEntityKey, TUserKey> : EntityMap<TEntity, TEntityKey>
        where TEntity : Entity<TEntityKey>, ICreationAudited<TEntityKey, TUserKey>
        where TUserKey : struct
    {
        public override void ConfigureEntityBuilder(EntityTypeBuilder<TEntity> builder)
        {
            ConfigureCreationAuditedEntityBuilder(builder);

            builder.Property(x => x.CreationTime).IsRequired();
            builder.Property(x => x.CreatorId).IsRequired();
        }

        public abstract void ConfigureCreationAuditedEntityBuilder(EntityTypeBuilder<TEntity> builder);
    }
    
    public abstract class CreationAuditedEntityMap<TEntity, TEntityKey, TUserKey, TUser> : CreationAuditedEntityMap<TEntity, TEntityKey, TUserKey>
        where TEntity : Entity<TEntityKey>, ICreationAudited<TEntityKey, TUserKey, TUser>
        where TUser : Entity<TUserKey>
        where TUserKey : struct
    {
        public override void ConfigureCreationAuditedEntityBuilder(EntityTypeBuilder<TEntity> builder)
        {
            ConfigureCreationAuditedEntityWithUserBuilder(builder);

            builder.HasOne(x => x.CreatorUser).WithMany().HasForeignKey(x => x.CreatorId);
        }

        public abstract void ConfigureCreationAuditedEntityWithUserBuilder(EntityTypeBuilder<TEntity> builder);
    }

    public abstract class CreationAuditedEntityMap<TEntity> : CreationAuditedEntityMap<TEntity, int, int>
        where TEntity : Entity<int>, ICreationAudited<int, int>
    {

    }
}