using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ComputerStore.Domain.Abstract;
using ComputerStore.Domain.Entities;

namespace ComputerStore.WebUI.Controllers
{
    public class ComputerComponentController : Controller
    {
        private IComputerComponentRepository repository;
        public ComputerComponentController(IComputerComponentRepository repo)
        {
            repository = repo;
        }
        public ViewResult List()
        {
            return View(repository.ComputerComponents);
        }
    }
}
