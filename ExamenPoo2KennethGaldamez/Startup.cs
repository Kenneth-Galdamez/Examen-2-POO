using ExamenPoo2KennethGaldamez.Database;
using ExamenPoo2KennethGaldamez.Helpers;
using ExamenPoo2KennethGaldamez.Services;
using ExamenPoo2KennethGaldamez.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ExamenPoo2KennethGaldamez
{
    public class Startup
    {
        private IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            var name = Configuration.GetConnectionString("DefaultConnection");

            // Add DbContext
            services.AddDbContext<Examen2Context>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            // Add custom services
            services.AddTransient<ILoansService, LoansService>();
            services.AddTransient<IAuthService, AuthService>();

            // Add AutoMapper
            services.AddAutoMapper(typeof(AutoMapperProfile));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }

    }
}
