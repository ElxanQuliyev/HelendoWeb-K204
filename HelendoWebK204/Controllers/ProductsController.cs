using HelendoWebK204.Models;
using HelendoWebK204.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace HelendoWebK204.Controllers
{
    public class ProductsController : Controller
    {
        HelendoDB db = new HelendoDB();

        // GET: Products
        public ActionResult Index(string searchBy, int? categoryId, int? sortBy,int? minimumPrice,int? maximumPrice,int? pageNo)
        {
            pageNo = pageNo.HasValue ? pageNo.Value > 0 ? pageNo.Value : 1 : 1;

            int totalCount = SearchProdutsCount(searchBy, categoryId, sortBy, minimumPrice, maximumPrice, pageNo.Value, 5);
            ShopVM vm = new ShopVM()
            {
                Products = SearchProduts(searchBy, categoryId, sortBy, minimumPrice, maximumPrice, pageNo.Value, 5),
                Categories = db.Categories.ToList(),
                SortBy = sortBy,
                CategoryId = categoryId,
                searchTerm = searchBy,
                Pager = new Pager(totalCount, pageNo),
                MaximumPrice=db.Products.Max(x=>x.Price),
                MinimumPrice=db.Products.Min(x=>x.Price)
                
            };
            return View(vm);
        }

        public List<Product> SearchProduts(string searchBy,int? categoryId,int? sortBy,int? maximumPrice,int? minimumPrice,int pageNo,int pageSize)
        {
            var product = db.Products.AsQueryable();
            if (!string.IsNullOrEmpty(searchBy))
            {
                product = product.Where(pr => pr.Name.ToLower().Contains(searchBy.ToLower()) || pr.Category.Name.ToLower().Contains(searchBy.ToLower()));
            }
            if (categoryId.HasValue)
            {
                product = product.Where(x => x.categoryID == categoryId);
            }
            if (minimumPrice.HasValue)
            {
                product = product.Where(x => x.Price >= minimumPrice.Value);

            }
            if (maximumPrice.HasValue)
            {
                product = product.Where(x => x.Price <= maximumPrice.Value);
            }
            if (sortBy.HasValue)
            {
                switch (sortBy)
                {
                    case 2:
                        product = product.OrderByDescending(x => x.ID);
                        break;
                    case 3:
                        product = product.OrderBy(x => x.Price);
                        break;
                    default:
                        product = product.OrderByDescending(x => x.Price);
                        break;
                }
            }
            return product.OrderBy(x=>x.ID).Skip((pageNo-1)*pageSize).Take(pageSize).ToList();

        }

        public int SearchProdutsCount(string searchBy, int? categoryId, int? sortBy, int? maximumPrice, int? minimumPrice, int pageNo, int pageSize)
        {
            var product = db.Products.AsQueryable();
            if (!string.IsNullOrEmpty(searchBy))
            {
                product = product.Where(pr => pr.Name.ToLower().Contains(searchBy.ToLower()) || pr.Category.Name.ToLower().Contains(searchBy.ToLower()));
            }
            if (categoryId.HasValue)
            {
                product = product.Where(x => x.categoryID == categoryId);
            }
            if (minimumPrice.HasValue)
            {
                product = product.Where(x => x.Price >= minimumPrice.Value);

            }
            if (maximumPrice.HasValue)
            {
                product = product.Where(x => x.Price <= maximumPrice.Value);
            }
            if (sortBy.HasValue)
            {
                switch (sortBy)
                {
                    case 2:
                        product = product.OrderByDescending(x => x.ID);
                        break;
                    case 3:
                        product = product.OrderBy(x => x.Price);
                        break;
                    default:
                        product = product.OrderByDescending(x => x.Price);
                        break;
                }
            }
            return product.Count();

        }


        public ActionResult FilterProducts(string searchTerm, int? minimumPrice, int? maximumPrice, int? categoryID, int? sortBy,int? pageNo)
        {
            pageNo = pageNo.HasValue ? pageNo.Value > 0 ? pageNo.Value : 1 : 1;
            int totalCount = SearchProdutsCount(searchTerm, categoryID, sortBy, minimumPrice, maximumPrice, pageNo.Value, 5);

            ShopVM vm = new ShopVM();
            vm.Products = SearchProduts(searchTerm, categoryID, sortBy, maximumPrice, minimumPrice,pageNo.Value,5);
            vm.Pager = new Pager(totalCount, pageNo);
            return PartialView(vm);
        }
        
        public ActionResult Detail (int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Product selectedPro = db.Products.FirstOrDefault(p => p.ID == id);
            if (selectedPro == null)
            {
                return HttpNotFound();
            }
            HomeVM vm = new HomeVM()
            {
                Product = selectedPro,
                Sliders=db.Sliders.ToList()
            };
            return View(vm);
        }

        public ActionResult Test()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ProDetail(int id)
        {
            Product singlePro = db.Products.FirstOrDefault(x => x.ID == id);

            object result = null;
            if (singlePro == null)
            {
                result = new
                {
                    status = 404,
                    message = "id not found",
                    response = ""
                };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
         
            return PartialView("ProductModalPartial", singlePro);
        }

    }
}