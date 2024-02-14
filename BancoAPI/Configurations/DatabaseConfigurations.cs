using BancoAPI.Data;
using BancoAPI.Domain;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace BancoAPI.Configurations
{
    public static class DatabaseConfigurations
    {
        public static void Initialize(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            using (var context = serviceScope.ServiceProvider.GetRequiredService<AppDbContext>())
            {
                // Verifica se o banco de dados existe
                if (context.Database.GetPendingMigrations().Any())
                {
                    try
                    {
                        Console.WriteLine("Trying to create and migrate database");
                        context.Database.Migrate();
                    }
                    catch (SqlException exception) when (exception.Number == 1801)
                    {
                        Console.WriteLine("Database already exists.");
                    }
                }

                // Verifica se a tabela clientes possui algum dado cadastrado
                if (context.Clientes.Any())
                {
                    return;
                }

                List<Cliente> clientes = new()
                {
                    new Cliente(100000, 0),
                    new Cliente(80000, 0),
                    new Cliente(1000000, 0),
                    new Cliente(10000000, 0),
                    new Cliente(500000, 0)
                };
                context.Clientes.AddRange(clientes);

                context.SaveChanges();
            }
        }
    }
}
