using api1Tr2.Model;

namespace api1Tr2.Data
{
    public interface IClientes
    {

        Task<IEnumerable<Clientes>> ListarCliente();
        Task<Clientes> MostrarClientes(String codigo);
        Task<bool> RegistrarCliente(Clientes Cliente);
        Task<bool> ActualizarCliente(Clientes Cliente);
        Task<bool> EliminarCliente(String codigo);

    }
}
