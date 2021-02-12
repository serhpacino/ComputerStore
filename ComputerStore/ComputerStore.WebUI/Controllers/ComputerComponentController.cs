using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ComputerStore.Domain.Abstract;
using ComputerStore.Domain.Entities;
using ComputerStore.WebUI.Models;


namespace ComputerStore.WebUI.Controllers
{
    public class ComputerComponentController : Controller
    {
        private IComputerComponentRepository repository;
        public int pageSize = 4;
        public ComputerComponentController(IComputerComponentRepository repo)
        {
            repository = repo;
        }
        public ViewResult List(string category,int page = 1)
        {
            ComponentListViewModel model = new ComponentListViewModel
            {
                ComputerComponents = repository.ComputerComponents
            .Where(p => category == null || p.Category == category)
            .OrderBy(component => component.ComputerComponentId)
            .Skip((page - 1) * pageSize)
            .Take(pageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = category == null ?
                    repository.ComputerComponents.Count():
                    repository.ComputerComponents.Where(component=>component.Category==category).Count()
                },
                CurrentCategory = category
            };
            return View(model);
        }
        public FileContentResult GetImage(int computercomponentId)
        {
            ComputerComponent computercomponent = repository.ComputerComponents
                .FirstOrDefault(g => g.ComputerComponentId == computercomponentId);

            if (computercomponent != null)
            {
                return File(computercomponent.ImageData, computercomponent.ImageMimeType);
            }
            else
            {
                return null;
            }
        }
    }
}
