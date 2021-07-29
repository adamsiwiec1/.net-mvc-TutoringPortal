using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Fall2020AppGroup12.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Fall2020AppGroup12.Models;
using Fall2020AppGroup12;
using Fall2020AppGroup12.Models.DepartmentModel;
using Fall2020AppGroup12.Models.CourseModel;
using Fall2020AppGroup12.Models.DiscussionModel;
using Fall2020AppGroup12.Models.ResponseModel;
using Fall2020AppGroup12.Models.CommentModel;
using Fall2020AppGroup12.Models.TutorModel;
using Fall2020AppGroup12.Models.StudentModel;
using Fall2020AppGroup12.Models.MajorModel;
using Fall2020AppGroup12.Models.TicketModel;
using Fall2020AppGroup12.Models.TutorCourseModel;
using Microsoft.AspNetCore.Identity.UI.Services;
using Fall2020AppGroup12.GoogleAuth;
using Fall2020AppGroup12.Models.AppUserModel;
using Google.Apis.Auth;
using Fall2020AppGroup12.Services;
using Microsoft.Extensions.FileProviders;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace Fall2020AppGroup12
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<ApplicationUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = true;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireDigit = true;
                options.User.RequireUniqueEmail = true;
            }
        )
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddControllersWithViews();
            services.AddRazorPages();

            //Unresolved service error? This is the issue. It is transient, you dont want it to exist all the time.
            services.AddTransient<IDepartmentRepo,DepartmentRepo>();
            services.AddTransient<ICourseRepo, CourseRepo>();
            services.AddTransient<IDiscussionRepo, DiscussionRepo>();
            services.AddTransient<IResponseRepo, ResponseRepo>();
            services.AddTransient<ICommentRepo, CommentRepo>();
            services.AddTransient<ITutorRepo, TutorRepo>();
            services.AddTransient<IStudentRepo, StudentRepo>();
            services.AddTransient<IMajorRepo, MajorRepo>();
            services.AddTransient<ITicketRepo, TicketRepo>();
            services.AddTransient<ITutorCourseRepo, TutorCourseRepo>();
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddTransient<IApplicationUserRepo, ApplicationUserRepo>();

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.IsEssential = true;

            }
            );

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();

            // For www root directory
            app.UseStaticFiles();

            // adds node modules for development

            //if (env.IsDevelopment())
            //{
            //    app.UseStaticFiles(new StaticFileOptions()
            //    {
            //        FileProvider = new PhysicalFileProvider(
            //          Path.Combine(Directory.GetCurrentDirectory(), @"node_modules")),
            //        RequestPath = new PathString("/vendor")
            //    });
            //}


            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
