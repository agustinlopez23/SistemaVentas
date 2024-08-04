using SistemaVenta.DTO;

namespace SistemaVenta.BLL.Servicios.Contrato
{
    public interface IVentaService
    {
        Task<VentaDTO> Registrar(VentaDTO modelo);
        Task<List<VentaDTO>> Historial(string buscarPor,string numeroVenta,string FechaInicio, string FechaFin);
        Task<List<ReporteDTO>> Reporte(string FechaInicio, string FechaFin);

    }
}
