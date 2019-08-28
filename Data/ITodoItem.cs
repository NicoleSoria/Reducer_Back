using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Todo.API.Data
{
    public interface ITodoItem
    {
        Task<Item> Agregar(Item item);
        Task<Item> Editar(int id, string textItem);
        Task<Item> Eliminar(int id);
        Task<Item> ActualizarEstado(int id);
    }
}
