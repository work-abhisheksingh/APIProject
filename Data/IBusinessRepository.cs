using System.Threading.Tasks;
using MyMvcApiProject.Models;

namespace MyMvcApiProject.Data
{
    public interface IBusinessRepository
    {
        Task<BusinessResponse?> GetBusinessByIdAsync(int businessId);
    }
}