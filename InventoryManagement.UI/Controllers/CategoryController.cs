using InventoryManagement.Application.Services.Interfaces;
using InventoryManagement.Domain.Entities;
using InventoryManagement.UI.Models.CategoryViewModel;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.UI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IService<Category> _service;

        public CategoryController(IService<Category> service)
            => _service = service;
        
        [HttpGet]
        public async Task<ActionResult> Lista()
        {
            var categories = await _service.GetAll();

            return View(categories);
        }

        [HttpGet]
        public async Task<ActionResult> Detalhe(int id)
        {
            var category = await _service.Get(id);
            return View(category);
        }

        [HttpGet]
        public ActionResult Cadastrar()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Cadastrar(CategoryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var category = new Category
            {
                Name = model.Name
            };

           await _service.Add(category);

            return RedirectToAction("Lista");
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {
            return View();
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(int id, CategoryViewModel model)
        {
            ViewBag.CategoryId = id;
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var category = new Category
            {
                Name = model.Name
            };

            _service.Update(category);

            return RedirectToAction("Lista");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            // if (id == null)
            // {
            //     ViewBag.Erro = "Não foi possível recuperar a Categoria";
            //     return View();
            // }

            return View();
        }

        
    }
}
