using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestASP.Models;
using TestASP.Repository.Base;


namespace TestASP.Controllers
{
    [Authorize(Roles = clsRoles.roleAdmin)]
    public class CategoryController : Controller
    {
        public CategoryController(IUnitOfWork _myunit) 
        { 
             myunit = _myunit;
        }

        //private IRepository<Category> _repository;

        private readonly IUnitOfWork myunit;


        //public IActionResult Index()
        //{
        //    return View(_repository.FindAll());
        //}

        public async Task<IActionResult> Index()
        {
            var oneCat = myunit.categories.SelectOne(x => x.Name == "Computers");

            var allCat = await myunit.categories.FindAllAsync("Items");

            return View(allCat);
        }

        //GET
        public IActionResult New()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult New(Category category)
        {
            if (ModelState.IsValid)
            {
                if (category.clientFile != null)
                {
                    MemoryStream stream = new MemoryStream();
                    category.clientFile.CopyTo(stream);
                    category.dbImage = stream.ToArray();
                }

                myunit.categories.AddOne(category);
                return RedirectToAction("Index");
            }
            else
            {
                return View(category);
            }
        }

        //GET
        public IActionResult Edit(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var category = myunit.categories.FindById(Id.Value);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                myunit.categories.UpdateOne(category);
                return RedirectToAction("Index");
            }
            else
            {
                return View(category);
            }
        }

        //GET
        public IActionResult Delete(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var category = myunit.categories.FindById(Id.Value);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Category category)
        {
            myunit.categories.DeleteOne(category);
            TempData["successData"] = "Category has been deleted successfully";
            return RedirectToAction("Index");
        }

     }
}
