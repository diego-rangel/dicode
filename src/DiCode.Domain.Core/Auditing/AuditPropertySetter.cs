using DiCode.Core.DependencyInjection;
using DiCode.Core.Reflection;
using DiCode.Core.Timing;
using DiCode.Core.Users;
using DiCode.Domain.Core.Auditing.Contracts;

namespace DiCode.Domain.Core.Auditing;

public class AuditPropertySetter<TUserKey> : IAuditPropertySetter, ITransientDependency
{
    protected ICurrentUser<TUserKey> CurrentUser { get; }
    protected IClock Clock { get; }

    public AuditPropertySetter(
        ICurrentUser<TUserKey> currentUser,
        IClock clock)
    {
        CurrentUser = currentUser;
        Clock = clock;
    }

    public virtual void SetCreationProperties(object targetObject)
    {
        SetCreationTime(targetObject);
        SetCreatorId(targetObject);
    }

    public virtual void SetModificationProperties(object targetObject)
    {
        SetLastModificationTime(targetObject);
        SetLastModifierId(targetObject);
    }

    public virtual void SetDeletionProperties(object targetObject)
    {
        SetDeletionTime(targetObject);
        SetDeleterId(targetObject);
    }

    protected virtual void SetCreationTime(object targetObject)
    {
        if (!(targetObject is IHasCreationTime objectWithCreationTime))
        {
            return;
        }

        if (objectWithCreationTime.CreationTime == default)
        {
            ObjectHelper.TrySetProperty(objectWithCreationTime, x => x.CreationTime, () => Clock.Now);
        }
    }

    protected virtual void SetCreatorId(object targetObject)
    {
        if (CurrentUser.Id == null)
        {
            return;
        }

        if (targetObject is IMustHaveCreator<TUserKey> mustHaveCreatorObject)
        {
            ObjectHelper.TrySetProperty(mustHaveCreatorObject, x => x.CreatorId, () => CurrentUser.Id);
        }
    }

    protected virtual void SetLastModificationTime(object targetObject)
    {
        if (targetObject is IHasModificationTime objectWithModificationTime)
        {
            ObjectHelper.TrySetProperty(objectWithModificationTime, x => x.LastModificationTime, () => Clock.Now);
        }
    }

    protected virtual void SetLastModifierId(object targetObject)
    {
        if (CurrentUser.Id == null)
        {
            return;
        }

        if (targetObject is IMayHaveModifier<TUserKey> modificationAuditedObject)
        {
            ObjectHelper.TrySetProperty(modificationAuditedObject, x => x.ModifierId, () => CurrentUser.Id);
        }
    }

    protected virtual void SetDeletionTime(object targetObject)
    {
        if (targetObject is IHasDeletionTime objectWithDeletionTime)
        {
            if (objectWithDeletionTime.DeletionTime == null)
            {
                ObjectHelper.TrySetProperty(objectWithDeletionTime, x => x.DeletionTime, () => Clock.Now);
            }
        }
    }

    protected virtual void SetDeleterId(object targetObject)
    {
        if (CurrentUser.Id == null)
        {
            return;
        }

        if (!(targetObject is IMayHaveDeleter<TUserKey> deletionAuditedObject) || deletionAuditedObject.DeleterId != null)
        {
            return;
        }

        ObjectHelper.TrySetProperty(deletionAuditedObject, x => x.DeleterId, () => CurrentUser.Id);
    }
}