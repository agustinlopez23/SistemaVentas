using AutoMapper;
using SistemaVenta.BLL.Servicios.Contrato;
using SistemaVenta.DAL.Repositorios.Contrato;
using SistemaVenta.DTO;
using SistemaVenta.Model;

namespace SistemaVenta.BLL.Servicios
{
    public class MenuService :IMenuService
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<MenuRol> _menuRolRepository;
        private readonly IGenericRepository<Usuario> _usuarioRepository;
        private readonly IGenericRepository<Menu> _menuRepository;

        public MenuService(IMapper mapper, IGenericRepository<MenuRol> menuRolRepository, IGenericRepository<Usuario> usuarioRepository, IGenericRepository<Menu> menuRepository)
        {
            _mapper = mapper;
            _menuRolRepository = menuRolRepository;
            _usuarioRepository = usuarioRepository;
            _menuRepository = menuRepository;
        }

        public async Task<List<MenuDTO>> Lista(int IdUsuario)
        {
            IQueryable<Usuario> tbUsuario  = await _usuarioRepository.Consultar(u=>u.IdUsuario==IdUsuario);
            IQueryable<MenuRol> tbMenuRol = await _menuRolRepository.Consultar();
            IQueryable<Menu> tbMenu = await _menuRepository.Consultar();

            try
            {
                IQueryable<Menu> tbresultado = (from u in tbUsuario
                                                join mr in tbMenuRol on u.IdRol equals mr.IdRol
                                                join m in tbMenu on mr.IdMenu equals m.IdMenu
                                                select m).AsQueryable();
                var listaMenus = tbresultado
                    .ToList();
                return _mapper.Map<List<MenuDTO>>(listaMenus);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
