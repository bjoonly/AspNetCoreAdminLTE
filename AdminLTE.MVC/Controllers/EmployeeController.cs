using AdminLTE.Models;
using AdminLTE.Models.ViewModels;
using AdminLTE.MVC.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AdminLTE.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public EmployeeController(ApplicationDbContext db, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            IEnumerable<Employee> employeeList = _db.Employees.Include(u => u.TerritorialCommunity);

            return View(employeeList);
        }

        public IActionResult Upsert(int? id)
        {
            EmployeeVM employeeVM = new EmployeeVM()
            {
                Employee = new Employee(),
                 TerritorialCommunitySelectList = _db.TerritorialCommunities.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }),
            };

            if (id == null)
            {
                return View(employeeVM);
            }
            else
            {
                employeeVM.Employee = _db.Employees.Find(id);
                if (employeeVM.Employee == null)
                {
                    return NotFound();
                }
                return View(employeeVM);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(EmployeeVM employeeVM)
        {

            if (ModelState.IsValid)
            {
                var files = HttpContext.Request.Form.Files;
                string webRootPath = _webHostEnvironment.WebRootPath;

                if (employeeVM.Employee.Id == 0)
                {
                    string upload = webRootPath + ENV.ImagePath;
                    string filename = Guid.NewGuid().ToString();
                    if (files.Count > 0)
                    {
                        string extentions = Path.GetExtension(files[0].FileName);

                        using (var fileStream = new FileStream(Path.Combine(upload, filename + extentions), FileMode.Create))
                        {
                            files[0].CopyTo(fileStream);
                        }

                        employeeVM.Employee.Photo = filename + extentions;
                    }
                    _db.Employees.Add(employeeVM.Employee);

                }
                else
                {
                    var formObject = _db.Employees.AsNoTracking().FirstOrDefault(u => u.Id == employeeVM.Employee.Id);
                    if (files.Count() > 0)
                    {
                        string upload = webRootPath + ENV.ImagePath;
                        string filename = Guid.NewGuid().ToString();


                        string extentions = Path.GetExtension(files[0].FileName);
                        if (formObject.Photo != null)
                        {
                            var oldFile = Path.Combine(upload, formObject.Photo);
                            if (System.IO.File.Exists(oldFile))
                            {
                                System.IO.File.Delete(oldFile);
                            }
                        }
                        using (var fileStream = new FileStream(Path.Combine(upload, filename + extentions), FileMode.Create))
                        {
                            files[0].CopyTo(fileStream);
                        }
                        employeeVM.Employee.Photo = filename + extentions;

                    }
                    else
                    {
                        employeeVM.Employee.Photo = formObject.Photo;
                    }
                    _db.Employees.Update(employeeVM.Employee);
                }
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            employeeVM.TerritorialCommunitySelectList = _db.TerritorialCommunities.Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });

            return View(employeeVM);
        }



        public IActionResult ConfirmDelete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Employee product = _db.Employees.Include(u => u.TerritorialCommunity).FirstOrDefault(u => u.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        public IActionResult Delete()
        {
            IEnumerable<Employee> employeesList = _db.Employees.Include(u => u.TerritorialCommunity);

            return View(employeesList);
        }

        public IActionResult Edit()
        {
            IEnumerable<Employee> employeesList = _db.Employees.Include(u => u.TerritorialCommunity);

            return View(employeesList);
        }

        [HttpPost, ActionName("ConfirmDelete")]
        [ValidateAntiForgeryToken]
        public IActionResult ConfirmDeletePost(int? id)
        {
            var obj = _db.Employees.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            string upload = _webHostEnvironment.WebRootPath + ENV.ImagePath;
            if (!String.IsNullOrEmpty(obj.Photo))
            {
                var oldFile = Path.Combine(upload, obj.Photo);

                if (System.IO.File.Exists(oldFile))
                {
                    System.IO.File.Delete(oldFile);
                }
            }
            _db.Employees.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");


        }


    }
}

