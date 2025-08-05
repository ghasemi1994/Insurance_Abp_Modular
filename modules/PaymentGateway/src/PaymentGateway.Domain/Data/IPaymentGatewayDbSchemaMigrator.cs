using System.Threading.Tasks;

namespace Acme.BookStore.Data;

public interface IPaymentGatewayDbSchemaMigrator
{
    Task MigrateAsync();
}
