﻿using Business.Abstract;
using Entities.Concrete;
using Entities.DomainModels;
using Microsoft.AspNetCore.Mvc;
using MvcWebUI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcWebUI.Controllers
{
    public class CartController : Controller
    {
        private ICartService _cartService;
        private ICartSessionHelper _cartSessionHelper;
        private IProductService _productService;

        public CartController(ICartService cartService, ICartSessionHelper cartSessionHelper, IProductService productService)
        {
            _cartService = cartService;
            _cartSessionHelper = cartSessionHelper;
            _productService = productService;
        }

        public IActionResult AddToCart(int productId)
        {
            Product product = _productService.GetById(productId);

            Cart cart = _cartSessionHelper.GetCart("cart");

            _cartService.AddToCart(cart, product);

            _cartSessionHelper.SetCart("cart", cart);

            return RedirectToAction("Index", "Product");
        }

        public IActionResult RemoveFromCart(int productId)
        {
            Product product = _productService.GetById(productId);

            Cart cart = _cartSessionHelper.GetCart("cart");

            _cartService.RemoveFromCart(cart, productId);

            _cartSessionHelper.SetCart("cart", cart);

            return RedirectToAction("Index", "Product");
        }

    }
}