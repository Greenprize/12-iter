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
    public class ShopsController : Controller
    {
        private readonly ShopService shopService;

        public ShopsController(ShopService shopService)
        {
            this.shopService = shopService;
        }

        // GET: Cars
        public ActionResult Index()
        {
            return View(shopService.Get());
        }

        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shop = shopService.Get(id);
            if (shop == null)
            {
                return NotFound();
            }
            return View(shop);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Shop shop)
        {
            if (ModelState.IsValid)
            {
                shopService.Create(shop);
                return RedirectToAction(nameof(Index));
            }
            return View(shop);
        }

        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shop = shopService.Get(id);
            if (shop == null)
            {
                return NotFound();
            }
            return View(shop);
        }

        // POST: Cars/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, Shop shop)
        {
            if (id != shop.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                shopService.Update(id, shop);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(shop);
            }
        }

        // GET: Cars/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shop = shopService.Get(id);
            if (shop == null)
            {
                return NotFound();
            }
            return View(shop);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            try
            {
                var shop = shopService.Get(id);

                if (shop == null)
                {
                    return NotFound();
                }

                shopService.Remove(shop.Id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}