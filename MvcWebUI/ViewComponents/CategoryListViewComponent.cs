﻿using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using MvcWebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcWebUI.ViewComponents
{
    public class CategoryListViewComponent : ViewComponent
    {
        private ICategoryService _categoryService;

        public CategoryListViewComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;

        }

        public ViewViewComponentResult Invoke()
        {
            var model = new CategoryListViewModel
            {
                categories = _categoryService.GetAll(),
                currentCategoryId = Convert.ToInt32(HttpContext.Request.Query["categoryId"])
            };

            return View(model);
        }
    }
}