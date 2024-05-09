using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ASWAQ.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISectionRepository sectionRepository;
        private readonly IProductRepository productRepository;
        public HomeController(ISectionRepository _sectionRepository, IProductRepository productRepository)
        {
            sectionRepository = _sectionRepository;
            this.productRepository = productRepository;
        }

        public async Task<IActionResult> Index()
        {
            var sections = await sectionRepository.GetAll();

            ViewBag.Products = await productRepository.GetSalesProduct();

            return View(sections);
        }
    }
}
