using EmailManage.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmailManage.Data
{
    public class DataContext : DbContext
    {
        // Конструктор класса, принимающий параметры конфигурации для DbContext
        public DataContext(DbContextOptions<DataContext> optionsBuilder) : base(optionsBuilder) { }
        
        // Определение DbSet для работы с коллекцией объектов EmailPersons в базе данных
        public DbSet<EmailPersons> EmailPersons { get; set; }
    }
}
