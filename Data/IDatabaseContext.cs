using System.Data;
using System.Data.Common;

namespace WebShopMVC.Data
{
    public interface IDatabaseContext
    {
        DbConnection CreateConnection();
    }
}
