using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TestASP.Data;
using TestASP.Models;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace TestASP.Controllers
{
    [Authorize]
    public class ItemController : Controller
    {
        public ItemController(AppDBcontext db , IHostingEnvironment host)
        {
                _db = db;
            _host = host;
        }

        private readonly IHostingEnvironment _host;
        private readonly AppDBcontext _db;

        public IActionResult Index()
        {
            IEnumerable<Item> Itemslist = _db.Items.Include(c => c.Category).ToList();

            return View(Itemslist);
        }

        //Get for show
        public IActionResult New()
        {
            CreateSelectList();
            return View();
        }

        //post for saving data
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult New(Item item)
        {
            if (ModelState.IsValid)
            {
                string fileName = string.Empty;
                if(item.clientFile != null)
                {
                    string myUpload = Path.Combine(_host.WebRootPath, "image");
                    fileName = item.clientFile.FileName;
                    string fullPath = Path.Combine(myUpload, fileName);
                    item.clientFile.CopyTo(new FileStream(fullPath, FileMode.Create));
                    item.imagePath = fileName;
                }

                _db.Items.Add(item);
                _db.SaveChanges();
                TempData ["SuccessData"] = "Item has been added seccessfly";
                return RedirectToAction("Index");
            }
            else
            {
                return View(item);
            }
            
        }


        public void CreateSelectList(int SelectId=1)
        {
            //List<Category> categories = new List<Category>
            //{
            //    new Category() {Id=0 , Name="Select Category"},
            //    new Category() {Id=1 , Name="Computers"},
            //    new Category() {Id=2 , Name="Phones"},
            //    new Category() {Id=3 , Name="Machines"}
            //};
            List<Category> categories = _db.Categories.ToList();
            SelectList listItems = new SelectList(categories,"Id","Name", SelectId);
            ViewBag.CategoryList = listItems;
        }


        //Get for show
        public IActionResult Edit(int? Id)
        {
            if(Id == null || Id == 0) 
            {
                return NotFound();
            }
            var item = _db.Items.Find(Id);
            if (item == null)
            {
                return NotFound();
            }
            CreateSelectList(item.CategoryId);
            return View(item);
        }

        //post for saving data
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Item item)
        {
            if (ModelState.IsValid)
            {
                _db.Items.Update(item);
                _db.SaveChanges();
                TempData["SuccessData"] = "Item has been edited seccessfly";
                return RedirectToAction("Index");
            }
            else
            {
                return View(item);
            }
          }


        //Get for show
        public IActionResult Delete(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var item = _db.Items.Find(Id);
            if (item == null)
            {
                return NotFound();
            }
            CreateSelectList(item.CategoryId);
            return View(item);
        }

        //post for saving data
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteItem(int? Id)
        {
            var item = _db.Items.Find(Id);

            if (item == null)
                {
                return NotFound();
                }

                _db.Items.Remove(item);
                _db.SaveChanges();
            TempData["SuccessData"] = "Item has been removed seccessfly";
            return RedirectToAction("Index");
        }
    }
    }
