using EmailManage.Data;
using Microsoft.EntityFrameworkCore;

namespace EmailManage
{
    public class Startup
    {
        // Метод, используемый для конфигурации сервисов в приложении
        public void ConfigureServices(IServiceCollection services)
        {
            // Добавление поддержки контроллеров в приложении
            services.AddControllers();

            // Конфигурация DbContext для взаимодействия с базой данных
            services.AddDbContext<DataContext>(options => options.UseSqlServer("name=ConnectionStrings:DefaultConnection"));
        }
    }
}
