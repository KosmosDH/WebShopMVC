using System.Data;
using System.Data.Common;
using WebShopMVC.Data.Models;

namespace WebShopMVC.Data.Repositories.Implementations
{
    public class ReviewRepository : Repository<Review>
    {
        public ReviewRepository(IDatabaseContext databaseContext) : base(databaseContext)
        {
        }

        protected override string GetTableName()
        {
            return "Reviews";
        }

        protected override Review ReadEntity(DbDataReader reader)
        {
            return new Review()
            {
                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                ProductId = reader.GetInt32(reader.GetOrdinal("ProductId")),
                Author = reader.GetString(reader.GetOrdinal("Author")),
                Text = reader.GetString(reader.GetOrdinal("Text")),
                CreatedAt = reader.GetDateTime(reader.GetOrdinal("CreatedAt"))
            };
        }

        public override void Add(Review entity)
        {
            using (DbConnection connection = _databaseContext.CreateConnection())
            {
                connection.Open();

                DbCommand command = connection.CreateCommand();
                command.CommandText = $"INSERT INTO {GetTableName()} (ProductId, Author, Text) VALUES (@ProductId, @Author, @Text)";

                DbParameter productIdParameter = command.CreateParameter();
                productIdParameter.ParameterName = "@ProductId";
                productIdParameter.DbType = DbType.Int32;
                productIdParameter.Value = entity.ProductId;

                command.Parameters.Add(productIdParameter);

                DbParameter authorParameter = command.CreateParameter();
                authorParameter.ParameterName = "@Author";
                authorParameter.DbType = DbType.String;
                authorParameter.Value = entity.Author;

                command.Parameters.Add(authorParameter);

                DbParameter textParameter = command.CreateParameter();
                textParameter.ParameterName = "@Text";
                textParameter.DbType = DbType.String;
                textParameter.Value = entity.Text;

                command.Parameters.Add(textParameter);

                command.ExecuteNonQuery();
            }
        }

        public IList<Review> GetByProductId(int productId)
        {
            IList<Review> reviews = new List<Review>();

            using (DbConnection connection = _databaseContext.CreateConnection())
            {
                connection.Open();

                DbCommand command = connection.CreateCommand();
                command.CommandText = $"SELECT * FROM {GetTableName()} WHERE ProductId = @ProductId";

                DbParameter productIdParameter = command.CreateParameter();
                productIdParameter.ParameterName = "@ProductId";
                productIdParameter.DbType = DbType.Int32;
                productIdParameter.Value = productId;

                command.Parameters.Add(productIdParameter);

                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (!reader.HasRows)
                        return reviews;

                    while (reader.Read())
                        reviews.Add(ReadEntity(reader));
                }
            }

            return reviews;
        }
    }
}
