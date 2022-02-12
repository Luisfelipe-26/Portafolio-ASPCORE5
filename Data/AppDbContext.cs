using Microsoft.EntityFrameworkCore;
using Portafolio.Models;

namespace Portafolio.Data

{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options)
        {
            
        }
     public   DbSet<Contact> Contactos{ get; set; }
      public  DbSet<Emaildata> Emaildata1 { get; set; }
    }
}
