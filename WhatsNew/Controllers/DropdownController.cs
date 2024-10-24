using Microsoft.AspNetCore.Mvc;

namespace WhatsNew.Controllers
{
	public class DropdownController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
