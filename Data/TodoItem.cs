using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Todo.API.Data
{
    public class TodoItem : ITodoItem
    {
        public Task<TodoItem> Agregar(string TextItem)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Completado(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<TodoItem> Editar(int Id, string TextItem)
        {
            throw new NotImplementedException();
        }

        public Task<TodoItem> Eliminar(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
