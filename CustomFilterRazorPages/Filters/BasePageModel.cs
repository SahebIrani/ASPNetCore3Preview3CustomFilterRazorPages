using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CustomFilterRazorPages.Filters
{
	public class BasePageModel : PageModel
	{
		public override void OnPageHandlerSelected(PageHandlerSelectedContext context)
		{
		}
		public override void OnPageHandlerExecuting(PageHandlerExecutingContext context)
		{
		}
	}
}
