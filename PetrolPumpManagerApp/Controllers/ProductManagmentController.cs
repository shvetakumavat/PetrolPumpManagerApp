using PetrolPumpManagerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static PetrolPumpManagerApp.DataAccess.DataLogic;
using static PumpDBLibrary.BusinessLogic.ModelManager;
namespace PetrolPumpManagerApp.Controllers
{




    //TODO-Curd Operation on Pruduct Purchase

 

    //TODO-2. Write curd operation function in Model Managment Class

 

    //TODO-4 write curd Operation for product purchase and product table in ModelManager class

    //TODO-5 create "create" "index" form for product purchase and also product "index" from for product ditails 

    //TODO-

    //TODO-

    //TODO-
    public class ProductManagmentController : Controller
    {


        public void ModelList()
        {
            var productList = ProductList();
            var supplierList = SupplierList();
            var tankerList = TankerList();
            ViewBag.ProductList = productList.Item1;
            ViewBag.SupplierList =supplierList.Item1;
            ViewBag.TankerList = tankerList.Item1;
        }
        // GET: ProductManagment
        public ActionResult Index()
        {
            var list = PurchaseProductsList();
            List<PurchaseProduct> model = list.Item1;
            return View(model);
        }

        // GET: ProductManagment/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductManagment/Create
        public ActionResult Create()
        {

            ModelList();

            return View();
        }

        // POST: ProductManagment/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PurchaseProduct  model, string add)
        {

            ModelList();
            if (add=="Add")
            {
                CreateAndUpdateProduct(model.ProductName);
                return View("Create");
            }
            else  if (ModelState.IsValid)
                {
                        int record = CreateAndUpdateProductPurchase(model.PurchaseId,
                                                                            model.ProductsId,
                                                                            model.SuppliersId,
                                                                            model.TankersId,
                                                                            model.Date,
                                                                            model.Quantity,
                                                                            model.PurchaseAmount);

                        return View("Create");

                    
                }
            ModelList();
            return View("Create"); 

        }
        [HttpPost]
        public ActionResult CreateProduct()
        {
            Product m = new Product();
            return PartialView("_ProductModelPartialView", m);
        }
        // GET: ProductManagment/Edit/5
        public ActionResult Edit(int id)
        {
            ModelList();
            var list = PurchaseProductsList(id);
            PurchaseProduct model = list.Item2;
            return View("Create",model);
        }

     

        // GET: ProductManagment/Delete/5
        public ActionResult Delete(int id)
        {
            DeleteProductPurchase(id);
            return RedirectToAction("Index");
        }

       
    }
}
