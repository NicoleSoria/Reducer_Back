using System;
using System.Collections.Generic;

public class User
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string UserName { get; set; }
    public byte[] passwordHash { get; set; }
    public byte[] passwordSalt { get; set; }

    public ICollection<Item> Item {get; set;}
}
