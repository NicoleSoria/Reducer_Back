using System;
using Microsoft.EntityFrameworkCore;

public class DataContext: DbContext
{
	public DataContext()
	{
       
	}

    public DataContext(DbContextOptions<DataContext> options): base(options) { }

    public DbSet<TodoItem> TodoItems { get; set; }
    public DbSet<User> Users { get; set; }
}
