using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace SistemaVenta.DAL.Repositorios.Contrato
{
    public interface IGenericRepository<TModel> where TModel : class
    {
        Task<TModel> Obtener(Expression<Func<TModel,bool>> filtro);
        Task<TModel> Crear(TModel modelo);

        Task<bool> Editar(TModel modelo);

        Task<bool> Delete(TModel modelo);

        Task<IQueryable<TModel>> Consultar(Expression<Func<TModel, bool>> filtro=null);
    }
}
