using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Todo.API.Data;
using Todo.API.Dto;

namespace Todo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        public ITodoItem _repo;
        public TodoController(ITodoItem repo)
        {
            _repo = repo;

        }
        

        [HttpPost("agregar")]
        public async Task<IActionResult> Agregar(DtoItemTodo itemDto){
            
            var agregarItem = new Item {

                NameItem = itemDto.Texto,
                Completado = itemDto.completado,
            };

            var crearItem = await _repo.Agregar(agregarItem);

            return StatusCode(201);
        }

        [HttpPost("actualizarEstado")]
        public async Task<IActionResult> ActualizarEstado(int id){

            var item = await _repo.ActualizarEstado(id);

            return StatusCode(201);
        }

        [HttpPost("editar")]
        public async Task<IActionResult> editar(int id, string textoItem){

            var item = await _repo.Editar(id, textoItem);

            return StatusCode(201);
        }
    }
}