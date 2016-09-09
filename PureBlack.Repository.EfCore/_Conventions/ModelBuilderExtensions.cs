using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Internal;
using System.Reflection;
using TruckWorld.Repository.EFCore;

namespace Microsoft.EntityFrameworkCore
{
    public static class ModelBuilderExtensions
    {
        public static ModelBuilder AddConvention(this ModelBuilder modelBuilder, IModelConvention convention)
        {
            var imb = modelBuilder.GetInfrastructure();
            var cd = imb.Metadata.ConventionDispatcher;
            var cs = cd.GetType().GetField("_conventionSet", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(cd) as ConventionSet;

            cs.ModelBuiltConventions.Add(convention);

            return modelBuilder;
        }

        public static ModelBuilder AddConvention<TConvention>(this ModelBuilder modelBuilder) where TConvention : IModelConvention, new()
        {
            return modelBuilder.AddConvention(new TConvention());
        }

        public static ModelBuilder UseDefaultStringLength(this ModelBuilder modelBuilder, int defaultStringLength = DefaultStringLengthConvention.DefaultStringLength)
        {
            modelBuilder.AddConvention(new DefaultStringLengthConvention(defaultStringLength));

            return modelBuilder;
        }

        public static ModelBuilder UseSingularTableNames(this ModelBuilder modelBuilder)
        {
            modelBuilder.AddConvention<SingularizeTableNameConvention>();

            return modelBuilder;
        }
    }
}
