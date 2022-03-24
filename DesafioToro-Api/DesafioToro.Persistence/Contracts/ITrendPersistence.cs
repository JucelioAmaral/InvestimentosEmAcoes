using DesafioToro.Domain;
using System.Threading.Tasks;

namespace DesafioToro.Persistence.Contracts
{
    public interface ITrendPersistence
    {
        Task<Trend[]> GetTrends();
        Task<Trend> GetTrendByName(string orderName);
    }
}
