using InventoryManagement.Application.Services.Interfaces;
using InventoryManagement.Domain.Entities;
using InventoryManagement.UI.Models.SupplierCreateViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.UI.Controllers
{
    public class SupplierController : Controller
    {
        private readonly IService<Supplier> _service;
        // 
        public SupplierController(IService<Supplier> service)
            => _service = service;
        public async Task<ActionResult> Listar()
        {
            try
            {
                var suppliers = await _service.GetAll();
                return View(suppliers);

            }
            catch
            {
                ViewBag.Erro = "Erro ao carregar Fornecedores";
                return View();
            }
        }

        // GET: SupplierController/Details/5
        public async Task<ActionResult> Detalhes(int id)
        {
            try
            {
                if (id != 0)
                {
                    var supplier = await _service.Get(id);
                    return View(supplier);

                }
            }
            catch
            {
                ViewBag.Erro = "Erro ao carregar Fornecedores";
                return View();

            }

            return View();
        }

        // GET: SupplierController/Create
        public ActionResult Cadastrar()
        {
            return View();
        }

        // POST: SupplierController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Cadastrar(SupplierCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Erro = "Erro, Revise os dados ";
                return View(model);
            }

            var supplier = new Supplier()
            {
                Name = model.Name,
                ContactName = model.ContactName,
                Address = model.Address,
                City = model.City,
                Phone = model.Phone
            };

            await _service.Add(supplier);
            return RedirectToAction("Listar");
        }

        // GET: SupplierController/Edit/5
        public async  Task<ActionResult> Editar(int id)
        {
            if (id != 0)
            {
                return View(await _service.Get(id));
            }

            ViewBag.Erro = "Erro ao recuperar Dados ";
            return View();
        }

        // POST: SupplierController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Editar(int id, SupplierCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Erro = "Erro, Revise os dados ";
                return View();
            }

            var supplier = new Supplier()
            {
                Name = model.Name,
                ContactName = model.ContactName,
                Address = model.Address,
                City = model.City,
                Phone = model.Phone
            };

            await _service.Update(supplier);
            return RedirectToAction("Listar");
        }

        // GET: SupplierController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SupplierController/Delete/5
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
