using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace CustomFilterRazorPages.Pages
{
	public class IndexModel : PageModel
	{

		private readonly ILogger _logger;
		public IndexModel(ILogger<IndexModel> logger) => _logger = logger;

		public string Message { get; set; }

		public void OnGet() => _logger.LogDebug("IndexModel/OnGet");

		public override void OnPageHandlerSelected(PageHandlerSelectedContext context)
		{
			if (context.HandlerMethod.MethodInfo.Name == nameof(OnGet))
				_logger.LogDebug("IndexModel/OnPageHandlerSelected");
		}

		public override void OnPageHandlerExecuting(PageHandlerExecutingContext context)
		{
			Message = "Message set in handler executing";
			_logger.LogDebug("IndexModel/OnPageHandlerExecuting");
		}

		public override void OnPageHandlerExecuted(PageHandlerExecutedContext context)
		{
			if (context.Exception != null)
			{
				_logger.LogDebug("IndexModel/OnPageHandlerExecuted");
				context.ExceptionHandled = true;
			}
		}
	}
}
