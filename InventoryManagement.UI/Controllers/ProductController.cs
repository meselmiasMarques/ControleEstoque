using InventoryManagement.Application.Services.Interfaces;
using InventoryManagement.Domain.Entities;
using InventoryManagement.UI.Models.ProductViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.UI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IService<Product> _service;

        public ProductController(IService<Product> service)
            => _service = service;

        // GET: ProductController
        public async Task<ActionResult> Lista()
        {
            var products = await _service.GetAll();
            return View(products);
        }

        // GET: ProductController/Details/5
        public async Task<ActionResult> Detalhe(int id)
        {
            var product = await _service.Get(id);

            return View(product);
        }

        // GET: ProductController/Create
        public ActionResult Cadastro()
        {

            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        public ActionResult Cadastro(ProductCreateViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var product = new Product
                {
                    ProductId = 0,
                    Name = model.Name,
                    Description = model.Description,
                    Price = model.Price,
                    Category = model.Category
                };

                _service.Add(product);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.Erro = "Erro EXC004";
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, ProductCreateViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ViewBag.Erro ="Revise em campos";
                    return View(model);
                }

                var product = new Product()
                {
                    Name = model.Name,
                    Description = model.Description,
                    Price = model.Price,
                    Category = model.Category
                };

               await _service.Update(product);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.Erro = "Erro ao Editar Produto";
                return View(model);
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
