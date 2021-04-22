using ONC.RESTful.Services.Model;
using System.Threading.Tasks;

namespace ONC.RESTful.Services.Contracts
{
    public interface IFrenteObraService
    {
        Task<bool> UpdateAsync(FrenteObraEstadoNumero model);

        Task<bool> DeleteAsync(string id);

        Task<FrenteObraEstadoNumero> GetAsync(int estado, string numero);
    }
}
