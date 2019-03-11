using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;

using System.Threading.Tasks;

namespace CustomFilterRazorPages.Filters
{
	public class CustomFilterAttribute : ResultFilterAttribute
	{
		public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
		{
			//var getService = context.HttpContext.RequestServices.GetService<IService>();
			var ipAddress = context.HttpContext.Request.Host.ToString();
			var result = (PageResult)context.Result;
			result.ViewData["ipAddress"] = ipAddress;
			await next.Invoke();
		}
	}
}
