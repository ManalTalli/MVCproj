namespace Ecommerce.Data
{
    using Ecommerce.Models;
    using Microsoft.EntityFrameworkCore;
    using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
    using static System.Net.Mime.MediaTypeNames;

    public class ApplicationDBContext : DbContext
    {
        public DbSet<Category> Categories {  get; set; }
        public DbSet<Products> Products { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source =.;Database=Ecommerce; Integrated Security = True; Connect Timeout = 30; Encrypt = True; Trust Server Certificate = True; Application Intent = ReadWrite; Multi Subnet Failover = False; Command Timeout = 30");
        }
    }
}
