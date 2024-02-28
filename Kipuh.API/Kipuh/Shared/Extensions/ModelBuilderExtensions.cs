using Microsoft.EntityFrameworkCore;

namespace Kipuh.API.Kipuh.Shared.Extensions;

public static class ModelBuilderExtensions
{
    public static void ConvertAllToSnakeCase(this ModelBuilder modelBuilder)
    {
        foreach (var entity in modelBuilder.Model.GetEntityTypes())
        {
            entity.SetTableName(entity.GetTableName()?.ToSnakeCase());
            foreach (var property in entity.GetProperties())
            {
                property.SetColumnName(property.GetColumnName().ToSnakeCase());
            }
            foreach (var primaryKey in entity.GetKeys())
            {
                primaryKey.SetName(primaryKey.GetName()?.ToSnakeCase());
            }
            foreach (var foreignKey in entity.GetForeignKeys())
            {
                foreignKey.SetConstraintName(foreignKey.GetConstraintName()?.ToSnakeCase());
            }

            foreach (var index in entity.GetIndexes())
            {
                index.SetDatabaseName(index.GetDatabaseName().ToSnakeCase());
            }
        }
    }
}