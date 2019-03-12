using CustomFilterRazorPages.Filters;

using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

using System.Threading.Tasks;

namespace CustomFilterRazorPages.Pages
{
	[CustomFilter, AddHeader("Author", new string[] { "SinjulMSBH" })]
	public class TestModel : PageModel
	{
		private readonly ILogger _logger;
		public TestModel(ILogger<TestModel> logger) => _logger = logger;
		public string Message { get; set; }
		public async Task OnGetAsync()
		{
			Message = "Your Test page.";
			_logger.LogDebug("Test/OnGet");
			await Task.CompletedTask;
		}
	}
}