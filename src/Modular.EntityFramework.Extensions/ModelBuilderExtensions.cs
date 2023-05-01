using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace Modular.EntityFramework.Extensions;

public static class ModelBuilderExtensions
{
    public static void AutoApplyMappings(this ModelBuilder modelBuilder, Assembly assembly)
    {
        var applyGenericMethods = typeof(ModelBuilder).GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.FlattenHierarchy);
        var applyGenericApplyConfigurationMethods = applyGenericMethods.Where(m => m.IsGenericMethod && m.Name.Equals("ApplyConfiguration", StringComparison.OrdinalIgnoreCase));
        var applyGenericMethod = applyGenericApplyConfigurationMethods.FirstOrDefault(m => m.GetParameters().FirstOrDefault()?.ParameterType.Name == "IEntityTypeConfiguration`1");
        var mappingClasses = assembly.GetTypes()
            .Where(c => c.IsClass
                        && !c.IsAbstract
                        && !c.ContainsGenericParameters
                        && c.GetInterfaces().Any(i => i.IsConstructedGenericType
                                                      && i.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>)))
            .ToList();

        foreach (var type in mappingClasses)
        {
            var interfaceType = type.GetInterfaces()
                .FirstOrDefault(i => i.IsConstructedGenericType
                            && i.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>));

            if (interfaceType == null) continue;
            var applyConcreteMethod = applyGenericMethod?.MakeGenericMethod(interfaceType.GenericTypeArguments[0]);
            applyConcreteMethod?.Invoke(modelBuilder, new[] { Activator.CreateInstance(type) });
        }
    }

    public static void SetCascadeDeleteBehavior(this ModelBuilder modelBuilder, DeleteBehavior deleteBehavior = DeleteBehavior.Restrict)
    {
        var cascadeFKs = modelBuilder.Model.GetEntityTypes()
            .SelectMany(t => t.GetForeignKeys())
            .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

        foreach (var fk in cascadeFKs)
            fk.DeleteBehavior = deleteBehavior;
    }
}