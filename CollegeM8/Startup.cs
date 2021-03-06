using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace CollegeM8
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  builder =>
                                  {
                                      builder.WithOrigins("*");
                                      builder.WithHeaders("Content-Type");
                                      builder.AllowAnyMethod();
                                  });
            });
            services.AddControllers();
            services.AddMvc()
             .AddJsonOptions(options =>
             {
                 options.JsonSerializerOptions.IgnoreNullValues = true;
             });
            services.AddDbContext<CollegeM8Context>(item => item.UseSqlServer(Configuration.GetConnectionString("constr")));
            services.AddScoped<IUserLogic, UserLogic>();
            services.AddScoped<ISleepLogic, SleepLogic>();
            services.AddScoped<ISchedule, ScheduleService>();
            services.AddScoped<IScheduleItem, ScheduleItemLogic>();
            services.AddScoped<IClass, ClassLogic>();
            services.AddScoped<ITerm, TermLogic>();
            services.AddScoped<IAssignment, AssignmentLogic>();
            services.AddScoped<IExam, ExamLogic>();
        } 

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(MyAllowSpecificOrigins);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
