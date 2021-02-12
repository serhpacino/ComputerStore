using System.Web.Mvc;
using ComputerStore.Domain.Abstract;
using ComputerStore.Domain.Entities;
using System.Linq;
using System.Web;

namespace ComputerStore.WebUI.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        IComputerComponentRepository repository;

        public AdminController(IComputerComponentRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index()
        {
            return View(repository.ComputerComponents);
        }

        public ViewResult Edit(int computercomponentId)
        {
            ComputerComponent computercomponent = repository.ComputerComponents
                .FirstOrDefault(g => g.ComputerComponentId == computercomponentId);
            return View(computercomponent);
        }

        [HttpPost]
        public ActionResult Edit(ComputerComponent computercomponent, HttpPostedFileBase image = null)
        {
            if (ModelState.IsValid)
            {
                if(image != null)
                {
                    computercomponent.ImageMimeType = image.ContentType;
                    computercomponent.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(computercomponent.ImageData, 0, image.ContentLength);
                }
                repository.SaveProduct(computercomponent);
                TempData["message"] = string.Format("Changes in product \"{0}\" were saved", computercomponent.Name);
                return RedirectToAction("Index");
            }
            else
            {
                // Smth wrong with data
                return View(computercomponent);
            }
        }

        public ViewResult Create()
        {
            return View("Edit", new ComputerComponent());
        }

        [HttpPost]
        public ActionResult DeleteProduct(int computercomponentId)
        {
            ComputerComponent deletedProduct = repository.DeleteProduct(computercomponentId);
            if (deletedProduct != null)
            {
                TempData["message"] = string.Format("Product \"{0}\" was deleted",
                    deletedProduct.Name);
            }
            return RedirectToAction("Index");
        }
    }
}