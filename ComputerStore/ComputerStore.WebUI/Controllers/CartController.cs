using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ComputerStore.Domain.Entities;
using ComputerStore.Domain.Abstract;
using ComputerStore.WebUI.Models;

namespace ComputerStore.WebUI.Controllers
{
    public class CartController : Controller
    {


        private IComputerComponentRepository repository;
        private IOrderProcessor orderProcessor;
        public CartController(IComputerComponentRepository repo, IOrderProcessor processor)
        {
            repository = repo;
            orderProcessor = processor;
        }
        public ViewResult Checkout()
        {
            return View(new ShippingDetails());
        }
        [HttpPost]
        public ViewResult Checkout(Cart cart, ShippingDetails shippingDetails)
        {
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry,your cart is empty!");
            }

            if (ModelState.IsValid)
            {
                orderProcessor.ProcessOrder(cart, shippingDetails);
                cart.Clear();
                return View("Completed");
            }
            else
            {
                return View(shippingDetails);
            }
        }
        public ViewResult Index(Cart cart, string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }

        public RedirectToRouteResult AddToCart(Cart cart, int computercomponentId, string returnUrl)
        {
            ComputerComponent component = repository.ComputerComponents
                .FirstOrDefault(g => g.ComputerComponentId == computercomponentId);

            if (component != null)
            {
                cart.AddItem(component, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(Cart cart, int computercomponentId, string returnUrl)
        {
            ComputerComponent component = repository.ComputerComponents
                .FirstOrDefault(g => g.ComputerComponentId == computercomponentId);

            if (component != null)
            {
                cart.RemoveLine(component);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }
       
    }
}