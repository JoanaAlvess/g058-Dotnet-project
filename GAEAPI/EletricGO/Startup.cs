using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using DDDSample1.Infrastructure;
using DDDSample1.Infrastructure.Categories;
using DDDSample1.Infrastructure.Products;
using DDDSample1.Infrastructure.Families;
using DDDSample1.Infrastructure.Shared;
using DDDSample1.Domain.Shared;
using DDDSample1.Domain.Categories;
using DDDSample1.Domain.Products;
using DDDSample1.Domain.Families;
using DDDSample1.Infrastructure.Entregas;
using DDDSample1.Domain.Entregas;
using System;
using DDDSample1.Domain.Armazens;
using DDDSample1.Infrastructure.Armazens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Threading.Tasks;
using ElettricGO;
using DDDSample1.Infrastructure.Users;
using DDDSample1.Domain.Users;

namespace DDDSample1
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers().AddNewtonsoftJson();
            services.AddCors(options => { options.AddPolicy("AllowAll", builder => { builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); }); });
            
            services.AddDbContext<DDDSample1DbContext>(opt =>
                opt.UseMySql(Configuration.GetConnectionString("Default"),
                        new MySqlServerVersion(new System.Version(10, 4, 17)))
                    .ReplaceService<IValueConverterSelector, StronglyEntityIdValueConverterSelector>()
                   );
            ConfigureMyServices(services);
               //services.AddDbContext<DDDSample1DbContext>(opt =>
              //  opt.UseInMemoryDatabase("DDDSample1DB")
               // .ReplaceService<IValueConverterSelector, StronglyEntityIdValueConverterSelector>());
            ConfigureMyServices(services);
            
            

            services.AddControllers().AddNewtonsoftJson();

            // auth 

            services.Configure<AppSettings>(
    Configuration.GetSection("ApplicationSettings"));

services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddCookie(x =>
{
    x.Cookie.Name = "token";

}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["ApplicationSettings:Secret"])),
        ValidateIssuer = false,
        ValidateAudience = false
    };
    x.Events = new JwtBearerEvents
    {
        OnMessageReceived = context =>
        {
            context.Token = context.Request.Cookies["token"];
            return Task.CompletedTask;
        }
    };

});

services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin", "Gestor Armazem"));
    

   
});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
           if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseCors("AllowAll");
            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        public void ConfigureMyServices(IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork,UnitOfWork>();

            services.AddTransient<ICategoryRepository,CategoryRepository>();
            services.AddTransient<CategoryService>();

            services.AddTransient<IProductRepository,ProductRepository>();
            services.AddTransient<ProductService>();

            services.AddTransient<IFamilyRepository,FamilyRepository>();
            services.AddTransient<FamilyService>();
            
            services.AddTransient<IEntregaRepository,EntregaRepository>();
            services.AddTransient<EntregaService>(); 

            services.AddTransient<IArmazemRepository,ArmazemRepository>();
            services.AddTransient<ArmazemService>();

            services.AddTransient<IUserRepository,UserRepository>();
            services.AddTransient<UserService>();
        }
    }
}
