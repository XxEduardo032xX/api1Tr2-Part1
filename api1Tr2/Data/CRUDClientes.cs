using api1Tr2.Model;
using Dapper;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;

namespace api1Tr2.Data
{
    public class CRUDClientes : IClientes
    {
        private Configuracion _conexion;

        public CRUDClientes(Configuracion conexion)
        {
            _conexion = conexion;
        }

        protected MySqlConnection Conectar()
        {
            return new MySqlConnection(_conexion.Conectar);
        }

        public async Task<IEnumerable<Clientes>> ListarCliente()
        {
            using (var bd = Conectar())
            {
                string cad_sql = @"select * from clientes";
                return await bd.QueryAsync<Clientes>(cad_sql);
            }
        }

        public async Task<Clientes> MostrarClientes(string codigo)
        {
            using (var bd = Conectar())
            {
                string cad_sql = @"select * from clientes where ID_Cliente = @cod";
                return await bd.QueryFirstAsync<Clientes>(cad_sql, new { cod = codigo });
            }
        }

        public async Task<bool> RegistrarCliente(Clientes Cliente)
        {
            using (var bd = Conectar())
            {
                string cad_sql = @"insert into clientes (Nombre, Apellido, CorreoElectronico, Telefono, Direccion) 
                   values (@Nombre, @Apellido, @CorreoElectronico, @Telefono, @Direccion)";

                int n = await bd.ExecuteAsync(cad_sql, new
                {
                    Nombre = Cliente.Nombre,
                    Apellido = Cliente.Apellido,
                    CorreoElectronico = Cliente.CorreoElectronico,
                    Telefono = Cliente.Telefono,
                    Direccion = Cliente.Direccion
                });
                return n > 0;
            }
        }

        public async Task<bool> ActualizarCliente(Clientes cliente)
        {
            using (var bd = Conectar())
            {
                string cad_sql = @"update clientes set
                           Nombre = @Nombre, Apellido = @Apellido, CorreoElectronico = @CorreoElectronico,
                           Telefono = @Telefono, Direccion = @Direccion
                           where ID_Cliente = @cod";
                int n = await bd.ExecuteAsync(cad_sql, new
                {
                    cod = cliente.ID_Cliente,
                    Nombre = cliente.Nombre,
                    Apellido = cliente.Apellido,
                    CorreoElectronico = cliente.CorreoElectronico,
                    Telefono = cliente.Telefono,
                    Direccion = cliente.Direccion
                });
                return n > 0;
            }
        }


        public async Task<bool> EliminarCliente(string codigo)
        {
            using (var bd = Conectar())
            {
                string cad_sql = @"delete from clientes
                                   where ID_Cliente = @cod";
                int n = await bd.ExecuteAsync(cad_sql, new { cod = codigo });
                return n > 0;
            }
        }


    }
}
