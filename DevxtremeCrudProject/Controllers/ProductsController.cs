using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.Helpers; // ✅ Required for DataSourceLoadOptions
using DevxtremeCrudProject.Data;
using DevxtremeCrudProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevxtremeCrudProject.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index() => View();

        [HttpGet]
        public IActionResult GetProducts(DataSourceLoadOptions loadOptions)
        {
            var data = _context.Products;
            return Json(DataSourceLoader.Load(data, loadOptions));
        }

        [HttpPost]
        public IActionResult Insert([FromBody] Product product)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            _context.Products.Add(product);
            _context.SaveChanges();
            return Json(product);
        }

        [HttpPut]
        public IActionResult Update(int key, [FromBody] Product product)
        {
            var existing = _context.Products.Find(key);
            if (existing == null) return NotFound();

            existing.Name = product.Name;
            existing.Price = product.Price;

            _context.SaveChanges();
            return Json(existing);
        }

        [HttpDelete]
        public IActionResult Delete(int key)
        {
            var product = _context.Products.Find(key);
            if (product == null) return NotFound();

            _context.Products.Remove(product);
            _context.SaveChanges();
            return Ok();
        }
    }
}



