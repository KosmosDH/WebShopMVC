using System.Data;
using System.Data.Common;
using WebShopMVC.Data.Models;

namespace WebShopMVC.Data.Repositories.Implementations
{
    public abstract class Repository<T> : IRepository<T> where T : Entity
    {
        protected readonly IDatabaseContext _databaseContext;

        protected Repository(IDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        protected abstract string GetTableName();
        protected abstract T ReadEntity(DbDataReader reader);

        public IList<T> GetAll()
        {
            IList<T> entities = new List<T>();

            using (DbConnection connection = _databaseContext.CreateConnection())
            {
                connection.Open();

                DbCommand command = connection.CreateCommand();
                command.CommandText = $"SELECT * FROM {GetTableName()}";

                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (!reader.HasRows)
                        return entities;

                    while (reader.Read())
                        entities.Add(ReadEntity(reader));
                }
            }

            return entities;
        }

        public T? GetById(int id)
        {
            using (DbConnection connection = _databaseContext.CreateConnection())
            {
                connection.Open();

                DbCommand command = connection.CreateCommand();
                command.CommandText = $"SELECT * FROM {GetTableName()} WHERE Id = @Id";

                DbParameter entityIdParameter = command.CreateParameter();
                entityIdParameter.ParameterName = "@Id";
                entityIdParameter.DbType = DbType.Int32;
                entityIdParameter.Value = id;

                command.Parameters.Add(entityIdParameter);

                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (!reader.HasRows)
                        return null;

                    reader.Read();
                    
                    return ReadEntity(reader);
                }
            }
        }

        public abstract void Add(T entity);
    }
}
