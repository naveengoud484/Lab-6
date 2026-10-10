using productcatalog.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ProductCatalogApplication.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        /// <summary>
        /// Product List View   
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            List<Product> P = new List<Product>();

            P = GetProducts();

            return View(P);
        }

        public ActionResult Details(int? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            List<Product> PALL = GetProducts();

            Product P1 = PALL.FirstOrDefault(p => p.ProductId == id.Value);

            if (P1 == null)
            {
                return HttpNotFound();
            }

            return View(P1);
        }


        private List<Product> GetProducts()
        {
            return new List<Product>
            {
                new Product
                {
                    ProductId = 1,
                    ProductName = "Laptop",
                    Description = "Dell Laptop",
                    Price = 55000,
                    Category = "Electronics"
                },

                new Product
                {
                    ProductId = 2,
                    ProductName = "Mobile",
                    Description = "Samsung Mobile",
                    Price = 25000,
                    Category = "Electronics"
                },

                new Product
                {
                    ProductId = 3,
                    ProductName = "Headphones",
                    Description = "Wireless Headphones",
                    Price = 3000,
                    Category = "Accessories"
                }
            };
        }
    }
}