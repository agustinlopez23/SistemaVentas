using SistemaVenta.DAL.Repositorios.Contrato;
using SistemaVenta.Model;
using SistemaVenta.DAL.DBContext;
using Microsoft.EntityFrameworkCore;


namespace SistemaVenta.DAL.Repositorios
{
   public class VentaRepository :GenericRepository<Venta>,IVentaRepository
    {
        private readonly DbventaContext _dbventaContext;

        public VentaRepository(DbventaContext dbventaContext) : base (dbventaContext)
        {
            _dbventaContext = dbventaContext;
        }

        public async Task<Venta> Resgistrar(Venta modelo)
        {
         
                Venta ventaGenerada = new Venta();

           using(var transaction =await  _dbventaContext.Database.BeginTransactionAsync())
            {
                try
                {
                    foreach (DetalleVenta dv in modelo.DetalleVenta)
                    {
                        Producto producto_encontrado = await _dbventaContext.Productos.Where(p => p.IdProducto == dv.IdProducto).FirstAsync();
                        if (producto_encontrado == null)
                        {
                            throw new Exception($"Producto con Id {dv.IdProducto} no encontrado.");
                        }
                        producto_encontrado.Stock = producto_encontrado.Stock - dv.Cantidad;
                            _dbventaContext.Productos.Update(producto_encontrado);
                        
                    }
                    await _dbventaContext.SaveChangesAsync();
                    NumeroDocumento correlativo = await _dbventaContext.NumeroDocumentos.FirstAsync();
                    correlativo.UltimoNumero = correlativo.UltimoNumero + 1;
                    correlativo.FechaRegistro = DateTime.Now;

                    _dbventaContext.NumeroDocumentos.Update(correlativo);
                    await _dbventaContext.SaveChangesAsync();

                    int CantidadDeDigitos = 4;
                    string ceros = string.Concat(Enumerable.Repeat("0", CantidadDeDigitos));
                    string numeroVenta = ceros + correlativo.UltimoNumero.ToString();

                    numeroVenta = numeroVenta.Substring(numeroVenta.Length - CantidadDeDigitos, CantidadDeDigitos);

                    modelo.NumeroDocumento = numeroVenta;

                    await _dbventaContext.AddAsync(modelo);
                    await _dbventaContext.SaveChangesAsync();

                    ventaGenerada = modelo;

                    await transaction.CommitAsync();
                }
                catch 
                {
                    await transaction.RollbackAsync();
                    throw;
                }
                return ventaGenerada;
            }
        }
    }
}
