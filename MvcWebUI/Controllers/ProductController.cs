using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using MvcWebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcWebUI.Controllers
{
    public class ProductController : Controller
    {
        readonly private IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public ActionResult Index(int categoryId)
        {
            var model = new ProductListViewModel
            {
                Products = categoryId > 0 ? _productService.GetByCategory(categoryId) : _productService.GetAll()
            };

            return View(model);
        }
    }
}
