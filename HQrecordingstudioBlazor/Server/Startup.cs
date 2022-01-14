using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using Blazorise;
using Blazorise.Bootstrap;
using HQrecordingstudioBlazor.Server.Data;
using HQrecordingstudioBlazor.Server.Models;
using HQrecordingstudioBlazor.Server.Services;
using HQrecordingstudioBlazor.Shared.Models.Configuration;
using HQrecordingstudioBlazor.Shared.Repository;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HQrecordingstudioBlazor.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // Adding Policy
            services.AddCors(policy =>
            {
                policy.AddPolicy("CorsPolicy", opt => opt
                    .AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod());
            });
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddDatabaseDeveloperPageExceptionFilter();





            services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                
                .AddTokenProvider<DataProtectorTokenProvider<ApplicationUser>>(TokenOptions.DefaultProvider);
            //AddIdentity method configures commonly required Identity services with the addition of UI, token providers and cookie authentication
            //ApplicationUser class to register Identity users 

            services.AddIdentity<ApplicationUser, IdentityRole>(options => {
                //configure identity options
                options.SignIn.RequireConfirmedAccount = true;
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 6;
            })
                //AddRoles method includes role service for ASP.NET Core Identity
                .AddRoles<IdentityRole>()
                //ApplicationDbContext class to register EF implementation of Identity stores
                .AddEntityFrameworkStores<ApplicationDbContext>();


            //AddIdentityServer we register the IdentityServer in our app. It does all different registration for us
            //AddApiAuthorization method to configure additional options, we add the role claims to user claims collection for both Identity resources and API resources.
            //We also prevent the default mapping for roles in the JWT token handler
            services.AddIdentityServer()
            .AddApiAuthorization<ApplicationUser, ApplicationDbContext>(opt =>
            {
                opt.IdentityResources["openid"].UserClaims.Add("role");
                opt.ApiResources.Single().UserClaims.Add("role");
            });
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Remove("role");

            //AddAuthentication configures authentication services 
            //AddIdentityServerJwt registers a policy to handle all request routed to any subpath in the /Identity
            services.AddAuthentication()
                .AddIdentityServerJwt()


                //Google method provide configuration option with ClientId, ClientSecret from appsettings file.
                .AddGoogle(o =>
                 {
                     o.ClientId = Configuration["Authentication:Google:ClientId"];
                     o.ClientSecret = Configuration["Authentication:Google:ClientSecret"];
                 })
                .AddFacebook(fo =>
                {
                    fo.AppId = Configuration["Authentication:Facebook:AppId"];
                    fo.AppSecret = Configuration["Authentication:Facebook:AppSecret"];
                });

            //Add EmailSender as a transient service
            //Register the AuthMessageSenderOptions
            services.AddTransient<IEmailSender, EmailSender>();
            services.Configure<AuthMessageSenderOptions>(Configuration);

            services.AddControllersWithViews();
            services.AddRazorPages();

            // Register the Catalogue ServiceS
            services.AddScoped<ICatalogueRepository, CatalogueRepository>();
            // Register the Collection ServiceS
            services.AddScoped<ICollectionRepository, CollectionRepository>();

            //Getting the Dbconnection from DapperContext
            services.AddSingleton<DapperContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            
            app.UseRouting();
            //Important for authentication,authorization and IdentityServer
            app.UseIdentityServer();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("index.html");
            });
        }
    }
}
