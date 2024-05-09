using BLL.Interfaces;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ASWAQ.Controllers
{
    public class SectionController : Controller
    {
        private readonly ISectionRepository sectionsRepository;
        private readonly IProductRepository productRepository;
        public SectionController(ISectionRepository _sectionsRepository, IProductRepository _productRepository)
        {
            sectionsRepository = _sectionsRepository;
            productRepository = _productRepository;

        }

        public async Task<IActionResult> Index(string Name)
        {
            Section section = await sectionsRepository.GetSectionWithProductsAsync(Name);

            return View(section);
        }

        public IActionResult Product(string Name)
        {
            Product product = productRepository.GetProductWithSection(Name);

            return View(product);
        }

        public async Task<IActionResult> search(string term)
        {
            List<string> result = new List<string>();

            result.AddRange(await sectionsRepository.GetSectoinsName());
            result.AddRange(await productRepository.GetProductsName());


            return Json(result.Where(r => r.ToLower().Contains(term.ToLower())));
        }


        public async Task<IActionResult> searchResult(string Name)
        {
            if ((await sectionsRepository.GetSectoinsName()).Contains(Name))
            {
                return RedirectToAction(nameof(Index), new { Name });
            }
            else if ((await productRepository.GetProductsName()).Contains(Name))
            {
                return RedirectToAction(nameof(Product), new { Name });
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }


    }
}
