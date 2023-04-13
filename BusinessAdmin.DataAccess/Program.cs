using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BusinessAdmin.DataAccess.Data;

namespace BusinessAdmin.DataAccess
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<AdminContext>(options =>
                options.UseSqlite(builder.Configuration.GetConnectionString("AdminContext") ?? throw new InvalidOperationException("Connection string 'AdminContext' not found.")));
            builder.Services.AddDbContext<TradeInfoContext>(options =>
                options.UseSqlite(builder.Configuration.GetConnectionString("TradeInfoContext") ?? throw new InvalidOperationException("Connection string 'TradeInfoContext' not found.")));
            builder.Services.AddDbContext<TraDataContext>(options =>
                options.UseSqlite(builder.Configuration.GetConnectionString("TraDataContext") ?? throw new InvalidOperationException("Connection string 'TraDataContext' not found.")));
            builder.Services.AddDbContext<TradeListContext>(options =>
                options.UseSqlite(builder.Configuration.GetConnectionString("TradeListContext") ?? throw new InvalidOperationException("Connection string 'TradeListContext' not found.")));
            builder.Services.AddDbContext<StoreManagerContext>(options =>
                options.UseSqlite(builder.Configuration.GetConnectionString("StoreManagerContext") ?? throw new InvalidOperationException("Connection string 'StoreManagerContext' not found.")));
            builder.Services.AddDbContext<OrderFormContext>(options =>
                options.UseSqlite(builder.Configuration.GetConnectionString("OrderFormContext") ?? throw new InvalidOperationException("Connection string 'OrderFormContext' not found.")));
            builder.Services.AddDbContext<ManagerReqListContext>(options =>
                options.UseSqlite(builder.Configuration.GetConnectionString("ManagerReqListContext") ?? throw new InvalidOperationException("Connection string 'ManagerReqListContext' not found.")));
            builder.Services.AddDbContext<ManagerListContext>(options =>
                options.UseSqlite(builder.Configuration.GetConnectionString("ManagerListContext") ?? throw new InvalidOperationException("Connection string 'ManagerListContext' not found.")));
            builder.Services.AddDbContext<GoodContext>(options =>
                options.UseSqlite(builder.Configuration.GetConnectionString("GoodContext") ?? throw new InvalidOperationException("Connection string 'GoodContext' not found.")));

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}