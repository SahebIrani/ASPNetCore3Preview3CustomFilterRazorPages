using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace CustomFilterRazorPages.Filters
{
	public class GlobalPageHandlerModelConvention : IPageHandlerModelConvention
	{
		public void Apply(PageHandlerModel model)
		{
			// Access the PageHandlerModel
		}
	}
}
