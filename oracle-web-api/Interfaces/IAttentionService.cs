using oracle_web_api.Models;

namespace oracle_web_api.Interfaces
{
    public interface IAttentionService
    {
        Task<Attention?> GetAttentionByIdAsync(int id);
    }
}
