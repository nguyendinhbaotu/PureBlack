using Microsoft.EntityFrameworkCore.Metadata.Conventions.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace TruckWorld.Repository.EFCore
{
    public sealed class DefaultStringLengthConvention : IModelConvention
    {
        internal const int DefaultStringLength = 128;
        internal const string MaxLengthAnnotation = "MaxLength";

        private readonly int _defaultStringLength;

        public DefaultStringLengthConvention(int defaultStringLength = DefaultStringLength)
        {
            this._defaultStringLength = defaultStringLength;
        }

        public InternalModelBuilder Apply(InternalModelBuilder modelBuilder)
        {
            foreach (var entity in modelBuilder.Metadata.GetEntityTypes())
            {
                foreach (var property in entity.GetProperties())
                {
                    if (property.ClrType == typeof(string))
                    {
                        if (property.FindAnnotation(MaxLengthAnnotation) == null)
                        {
                            property.AddAnnotation(MaxLengthAnnotation, this._defaultStringLength);
                        }
                    }
                }
            }

            return modelBuilder;
        }
    }
}
