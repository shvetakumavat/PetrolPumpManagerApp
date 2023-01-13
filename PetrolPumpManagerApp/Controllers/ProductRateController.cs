using PetrolPumpManagerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static PumpDBLibrary.BusinessLogic.ModelManager;
using static PetrolPumpManagerApp.DataAccess.DataLogic;

namespace PetrolPumpManagerApp.Controllers
{
    public class ProductRateController : Controller
    {
        // GET: ProductRate

        public ActionResult Index()
        {

            var productRateList = RateList();
            List<ProductRate> model = productRateList.Item1;
            return View(model);
        }

      

        // GET: ProductRate/Create
        public ActionResult Create()
        {
            ViewBag.ProductList = ProductList().Item1;
       
            return View(new ProductRate { RateId=0});
        }

        // POST: ProductRate/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductRate model)
        {

            if (ModelState.IsValid)
            {
                int record = CreateAndUpdateProductRate(model.RateId, model.ProductId,model.Date,model.Rate);

                return RedirectToAction("Index");
            }
            ViewBag.ProductList = ProductList().Item1;
            return RedirectToAction("Create");

        }
        // GET: ProductRate/Edit/5
        public ActionResult Edit(int id)
        {
            var productRateList = RateList(id);
            ProductRate model = productRateList.Item2;
            ViewBag.ProductList = ProductList().Item1;
            return View("Create",model);
        }

       
        // GET: ProductRate/Delete/5
        public ActionResult Delete(int id)
        {
            DeleteProductRate(id);
            return RedirectToAction("Index");
        }

      
        
    }
}
