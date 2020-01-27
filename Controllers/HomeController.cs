using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TShirtCompany.Models;
using TShirtCompany.Repos;

namespace TShirtCompany.Controllers
{

    //[Authorize]
    public class HomeController : Controller
    {
        private readonly DBContext db;
        //private readonly IHostingEnvironment hostingEnvironment;

        private readonly IProductRepo productRepo;
        public HomeController(DBContext db, IProductRepo productRepo)
        {
            this.db = db;
            this.productRepo = productRepo;
            //this.hostingEnvironment = hostingEnvironment;
        }
        //[AllowAnonymous]
        public IActionResult Index()
        {
            IEnumerable<Product> model = db.Products.ToList();
            return View(model);
        }
        //[AllowAnonymous]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public IActionResult Women()
        {
            //IEnumerable<Product> WomenCollections = db.Products.Where(p => p.Category == Category.Women).ToList();
            IEnumerable<Product> WomenCollections = productRepo.GetWomenProducts();
            return View(WomenCollections);
        }

        public IActionResult Men()
        {
            IEnumerable<Product> MenCollections = productRepo.GetMenProducts();
            return View(MenCollections);
        }

   
        public IActionResult AllProducts()
        {
            IEnumerable<Product> AllProducts = productRepo.GetAllProducts();
            return View(AllProducts);
        }


        public IActionResult MenBag()
        {
            IEnumerable<Product> BagCollections = productRepo.GetMenBags();
            return View(BagCollections);
        }

        public IActionResult MenWatches()
        {
            IEnumerable<Product> WatchesCollections = productRepo.GetMenWatches();
            return View(WatchesCollections);
        }

        public IActionResult MenShoes()
        {
            IEnumerable<Product> ShoesCollections = productRepo.GetMenShoes();
            return View(ShoesCollections);
        }

        public IActionResult WomenBag()
        {
            IEnumerable<Product> BagCollections = productRepo.GetWomenBags();
            return View(BagCollections);
        }

        public IActionResult WomenWatches()
        {
            IEnumerable<Product> WatchesCollections = productRepo.GetWomenWatches();
            return View(WatchesCollections);
        }

        public IActionResult WomenShoes()
        {
            IEnumerable<Product> ShoesCollections = productRepo.GetWomenShoes();
            return View(ShoesCollections);
        }

        [Authorize]
        public IActionResult MobileAdmin()
        {
            return View();
        }






    }
}