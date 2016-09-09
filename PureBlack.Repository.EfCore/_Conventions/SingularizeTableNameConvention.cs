using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq;

namespace TruckWorld.Repository.EFCore
{
    public sealed class SingularizeTableNameConvention : IModelConvention
    {
        public InternalModelBuilder Apply(InternalModelBuilder modelBuilder)
        {
            foreach (var entity in modelBuilder.Metadata.GetEntityTypes())
            {
                if (entity.FindAnnotation(RelationalAnnotationNames.TableName) == null)
                {
                    entity.Relational().TableName = entity.Name.Split('.').Last();
                }
            }

            return modelBuilder;
        }
    }
}
