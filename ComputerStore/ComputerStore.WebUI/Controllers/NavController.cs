using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ComputerStore.Domain.Abstract;

namespace ComputerStore.WebUI.Controllers
{
    public class NavController : Controller
    {
        private IComputerComponentRepository repository;
        public NavController(IComputerComponentRepository repo)
        {
            repository = repo;
        }
        public PartialViewResult Menu(string category = null)
        {
            ViewBag.SelectedCategory = category;
            IEnumerable<string> categories = repository.ComputerComponents
                .Select(component => component.Category)
                .Distinct()
                .OrderBy(x => x);
           
            return PartialView("FlexibleMenu",categories);
        }
    }
}