using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Todo.API.Data
{
    public interface ITodoItem
    {
        Task<TodoItem> Agregar(string TextItem);
        Task<TodoItem> Editar(int Id, string TextItem);
        Task<TodoItem> Eliminar(int Id);
        Task<bool> Completado(int Id);
    }
}
