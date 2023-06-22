using Microsoft.AspNetCore.Mvc;

namespace MediLab.Controllers
{
	public class MedicalMarketController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
