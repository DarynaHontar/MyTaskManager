using Microsoft.EntityFrameworkCore;
using MyTaskManager.Services;

namespace MyTaskManager
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<ApplicationDBContext>(options =>
            {
                options.UseSqlServer("Server=.\\SQLExpress;Initial Catalog=MyTasks;Trusted_Connection=Yes;Integrated Security=true;TrustServerCertificate=True");
            });
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<ITaskItemRepository, DBTaskItemRepository>();
            builder.Services.AddTransient<ITaskItemService, TaskItemService>();
            builder.Services.AddScoped<ILifeSphereRepository, DBLifeSphereRepository>();
            builder.Services.AddTransient<ILifeSphereService, LifeSphereService>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

           // app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}