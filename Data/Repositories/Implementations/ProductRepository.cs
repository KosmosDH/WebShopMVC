using Microsoft.Data.SqlClient;
using System.Data.Common;
using WebShopMVC.Data.Models;

namespace WebShopMVC.Data.Repositories.Implementations
{
    public class ProductRepository : Repository<Product>
    {
        public ProductRepository(IDatabaseContext databaseContext) : base(databaseContext)
        {
        }

        protected override string GetTableName()
        {
            return "Products";
        }

        protected override Product ReadEntity(DbDataReader reader)
        {
            int descriptionColumnIndex = reader.GetOrdinal("Description");

            return new Product()
            {
                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                Name = reader.GetString(reader.GetOrdinal("Name")),
                Description = !reader.IsDBNull(descriptionColumnIndex) ? reader.GetString(descriptionColumnIndex) : null,
                Price = reader.GetDecimal(reader.GetOrdinal("Price")),
                CreatedAt = reader.GetDateTime(reader.GetOrdinal("CreatedAt"))
            };
        }

        public override void Add(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
