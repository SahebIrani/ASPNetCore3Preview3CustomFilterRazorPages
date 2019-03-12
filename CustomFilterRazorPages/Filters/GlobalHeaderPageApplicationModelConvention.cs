using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace CustomFilterRazorPages.Filters
{
	public class GlobalHeaderPageApplicationModelConvention : IPageApplicationModelConvention
	{
		public void Apply(PageApplicationModel model)
		{
			model.Filters.Add(new AddHeaderAttribute("GlobalHeader", new string[] { "Global Header Value" }));
		}
	}
}
