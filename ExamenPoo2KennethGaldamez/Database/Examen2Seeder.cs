using ExamenPoo2KennethGaldamez.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace ExamenPoo2KennethGaldamez.Database
{
    public class Examen2Seeder
    {
        public static async Task LoadDataAsync(
           Examen2Context context,
            ILoggerFactory loggerFactory
            ) 
        {
            try
            {
                await LoadLoansAsync(loggerFactory, context);
                await LoadProspectsAsync(loggerFactory, context);

            }
            catch (Exception e) 
            {
                var logger = loggerFactory.CreateLogger<Examen2Seeder>();
                logger.LogError(e, "Error inicializando la data del API");
            }
        }

        // TODO: Seed de usuarios

        public static async Task LoadLoansAsync(ILoggerFactory loggerFactory, Examen2Context context) 
        {
            try
            {
                var jsonFilePath = "SeedData/Loan.json";
                var jsonContent = await File.ReadAllTextAsync(jsonFilePath);
                var loans = JsonConvert.DeserializeObject<List<LoanEntity>>(jsonContent);

                if (!await context.Loans.AnyAsync()) 
                {
                    for (int i = 0; i < loans.Count; i++) 
                    {
                        loans[i].CreatedBy = "7fc2cdf1-a339-4c13-88d4-82a32810d5c0";
                        loans[i].CreatedDate = DateTime.Now;
                        loans[i].UpdatedBy = "7fc2cdf1-a339-4c13-88d4-82a32810d5c0";
                        loans[i].UpdatedDate = DateTime.Now;
                    }
                    
                    context.AddRange(loans);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception e) 
            {
                var logger = loggerFactory.CreateLogger<Examen2Seeder>();
                logger.LogError(e, "Error al ejecutar el Seed de categorias");
            }
        }

        public static async Task LoadProspectsAsync(ILoggerFactory loggerFactory, Examen2Context context)
        {
            try
            {
                var jsonFilePath = "SeedData/prospecto.json";
                var jsonContent = await File.ReadAllTextAsync(jsonFilePath);
                var prospects = JsonConvert.DeserializeObject<List<ProspectEntity>>(jsonContent);

                if (!await context.Prospects.AnyAsync())
                {
                    for (int i = 0; i < prospects.Count; i++)
                    {
                        prospects[i].CreatedBy = "7fc2cdf1-a339-4c13-88d4-82a32810d5c0";
                        prospects[i].CreatedDate = DateTime.Now;
                        prospects[i].UpdatedBy = "7fc2cdf1-a339-4c13-88d4-82a32810d5c0";
                        prospects[i].UpdatedDate = DateTime.Now;
                    }

                    context.AddRange(prospects);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                var logger = loggerFactory.CreateLogger<Examen2Seeder>();
                logger.LogError(e, "Error al ejecutar el Seed de Posts");
            }
        }




    }
}
