using CustomFilterRazorPages.Filters;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CustomFilterRazorPages
{
	public class Startup
	{
		public Startup(IConfiguration configuration) => Configuration = configuration;
		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.Configure<CookiePolicyOptions>(options =>
			{
				// This lambda determines whether user consent for non-essential cookies is needed for a given request.
				options.CheckConsentNeeded = context => true;
				options.MinimumSameSitePolicy = SameSiteMode.None;
			});

			ILoggerFactory loggerService = services.BuildServiceProvider().GetService<ILoggerFactory>();
			ILogger logger = loggerService.CreateLogger<GlobalFiltersLogger>();

			services.AddMvc(options =>
			{
				options.Filters.Add(new SampleAsyncPageFilter(logger));
			})
			.AddRazorPagesOptions(options =>
			{
				options.Conventions.AddFolderApplicationModelConvention("/MyDir",
					model => model.Filters.Add(new SamplePageFilter(logger)));
			})
			.AddNewtonsoftJson();
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
				app.UseExceptionHandler("/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting(routes =>
			{
				routes.MapRazorPages();
			});

			app.UseCookiePolicy();

			app.UseAuthorization();
		}
	}
}
