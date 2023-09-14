using ABCOnlinePublications.Factories;
using ABCOnlinePublications.ViewModels;
using Newtonsoft.Json;

namespace ABCOnlinePublications
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            // Read JSON content and deserialize 
            var jsonPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Publications", "the-adventures-of-sherlock-holmes-sample.json");
            var jsonContent = File.ReadAllText(jsonPath);
            var sections = JsonConvert.DeserializeObject<Dictionary<string, SectionViewModels>>(jsonContent);

            // Register dependencies
            services.AddSingleton(sections);
            services.AddSingleton<SectionFactory>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
