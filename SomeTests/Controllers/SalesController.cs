using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SomeTests.Models;
using SomeTests.Services;

namespace SomeTests.Controllers
{
    public class SalesController : Controller
    {
        private readonly SaleService saleService;

        public SalesController(SaleService saleService)
        {
            this.saleService = saleService;
        }

        // GET: Cars
        public ActionResult Index()
        {
            return View(saleService.Get());
        }

        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sale = saleService.Get(id);
            if (sale == null)
            {
                return NotFound();
            }
            return View(sale);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Sale sale)
        {
            if (ModelState.IsValid)
            {
                saleService.Create(sale);
                return RedirectToAction(nameof(Index));
            }
            return View(sale);
        }

        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sale = saleService.Get(id);
            if (sale == null)
            {
                return NotFound();
            }
            return View(sale);
        }

        // POST: Cars/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, Sale sale)
        {
            if (id != sale.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                saleService.Update(id, sale);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(sale);
            }
        }

        // GET: Cars/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sale = saleService.Get(id);
            if (sale == null)
            {
                return NotFound();
            }
            return View(sale);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            try
            {
                var sale = saleService.Get(id);

                if (sale == null)
                {
                    return NotFound();
                }

                saleService.Remove(sale.Id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}