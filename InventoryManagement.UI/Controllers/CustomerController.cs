using InventoryManagement.Application.Services.Interfaces;
using InventoryManagement.Domain.Entities;
using InventoryManagement.UI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace InventoryManagement.UI.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IService<Customer> _service;

        public CustomerController(IService<Customer> service)
            => _service = service;

        [HttpGet]
        public async Task<ActionResult> Lista()
        {
            var customers = await _service.GetAll();
            if (customers == null)
            {
                ViewBag.Erro = "Erro ao recuperar clientes";
                return View();

            }

            return View(customers);
        }

        [HttpGet]
        public async Task<ActionResult> Detalhe(int id)
        {
            var customer = await _service.Get(id);
            return View(customer);
        }

        [HttpGet]
        public ActionResult Cadastrar()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(CustomerViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var customer = new Customer
            {
                CustomerID = 0,
                Name = model.Name,
                ContactName = model.ContactName,
                Address = model.Address,
                City = model.City,
                Phone = model.Phone,
                Orders = new List<Order>()
            };

            _service.Add(customer);

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
        public ActionResult Editar(int id, CustomerViewModel model)
        {
            ViewBag.CustomerId = id;
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var customer = new Customer
            {
                Name = model.Name
            };

            _service.Update(customer);

            return RedirectToAction("Lista");
        }

        //[HttpGet]
        //public ActionResult Delete(int id)
        //{
        //    if (id == null)
        //    {
        //        ViewBag.Erro = "Não foi possível recuperar o cliente";
        //        return View();
        //    }

        //    return View();
        //}


    }
}
