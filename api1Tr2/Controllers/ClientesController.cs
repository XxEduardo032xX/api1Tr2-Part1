using api1Tr2.Data;
using api1Tr2.Model;
using Microsoft.AspNetCore.Mvc;

namespace api1Tr2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : Controller
    {

        private IClientes _clientes;

        public ClientesController(IClientes clientes)
        {
            _clientes = clientes;
        }

        [HttpGet]
        public async Task<IActionResult> ListarCliente()
        {
            return Ok(await _clientes.ListarCliente());
        }


        [HttpGet("{codigo}")]
        public async Task<IActionResult> MostrarClientes(String codigo)
        {
            return Ok(await _clientes.MostrarClientes(codigo));
        }


        [HttpPost]
        public async Task<IActionResult> RegistrarCliente([FromBody] Clientes Cliente)
        {
            if (Cliente == null) return BadRequest();
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var registro = await _clientes.RegistrarCliente(Cliente);
            return Created("Cliente registrado...", registro);
        }

        [HttpPut]
        public async Task<IActionResult> ActualizarCliente([FromBody] Clientes Cliente)
        {
            if (Cliente == null) return BadRequest();
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var registro = await _clientes.ActualizarCliente(Cliente);
            return Created("Cliente actualizado...", registro);
        }


        [HttpDelete]
        public async Task<IActionResult> EliminarCliente(String codigo)
        {
            var registro = await _clientes.EliminarCliente(codigo);
            return Created("Cliente Eliminado...", registro);
        }

    }
}
