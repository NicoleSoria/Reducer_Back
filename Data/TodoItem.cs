using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Todo.API.Data
{
    public class TodoItem : ITodoItem
    {
        private readonly DataContext _context;
        public TodoItem(DataContext context)
        {
            _context = context;

        }

        public async Task<Item> Agregar(Item item)
        {
           await _context.TodoItems.AddAsync(item);
           await _context.SaveChangesAsync();

           return item;
        }

        public async Task<Item> ActualizarEstado(int id)
        {
            var item = await _context.TodoItems.FirstOrDefaultAsync(x => x.Id == id);

            item.Completado = item.Completado ? true : false;

            await _context.SaveChangesAsync();
            
            return item;
        }

        public async Task<Item> Editar(int id, string textItem)
        {
            var item = await _context.TodoItems.FirstOrDefaultAsync(x => x.Id == id);

            item.NameItem = textItem;

            await _context.SaveChangesAsync();

            return item;
        }

        public Task<Item> Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Item> GetAll()
        {
            throw new NotImplementedException();
        }

        // public Task<Item> GetAll()
        // {
        //     var items = "";
        //     return  items;
        // }
    }
}
