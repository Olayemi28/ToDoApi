using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using UniqueTodoApplication.Auth;
using UniqueTodoApplication.BackgroundConfiguration;
using UniqueTodoApplication.BackgroundTask;
using UniqueTodoApplication.Context;
using UniqueTodoApplication.Implementation.Repositries;
using UniqueTodoApplication.Implementation.Service;
using UniqueTodoApplication.Interface.IRespositries;
using UniqueTodoApplication.Interface.IService;
using UniqueTodoApplication.MailFolder;
using UniqueTodoApplication.Settings;

namespace UniqueTodoApplication
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
            services.AddDbContext<UniqueContext>(options => options.UseMySQL(Configuration.GetConnectionString("DefaultConnection")));
            services.AddControllers();

            services.AddScoped<IAdminRepository, AdminRepository>();
            services.AddScoped<IAdminService, AdminService>();

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICategoryService, CategoryService >();

            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ICustomerService, CustomerService>();

            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddScoped<IItemService, ItemService>();

            services.AddScoped<ISubcategoryRepository, SubcategoryRepository>();
            services.AddScoped<ISubcategoryService, SubcategoryService>();

            services.AddScoped<ITodoitemRepository, TodoitemRepository>();
            services.AddScoped<ITodoitemService, TodoitemService>();

            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IRoleService, RoleService>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IReminderRepository, ReminderRepository>();

            services.AddTransient<IMailService, MailService>();

            services.Configure<MailSettings>(Configuration.GetSection("MailSettings"));

            services.Configure<ReminderMailConfiguration>(Configuration.GetSection("ReminderMailsConfig"));

            services.AddHostedService<UniqueBackgroundService>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "UniqueTodoApplication", Version = "v1" });
            });
            

            var key = "This is the key that we are going to be using to authorize our user";
            services.AddSingleton<IJWTAuthenticationManager>(new JWTAuthenticationManager(key));

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };

                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "UniqueTodoApplication v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
