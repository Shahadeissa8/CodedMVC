using CodedMVC.Data;
using CodedMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodedMVC.Controllers
{
    public class EmployeesController : Controller
    {
        private CodedDbContext _context; //whatever name, is an object of the parent class, we use it to reach all the tables, hence why we used it underneeth
        public EmployeesController(CodedDbContext context) //whatever name,, here what we are doing is injecting whats inside codedDbContext into context
        {
            _context = context;
        }
        public IActionResult index()
        {
            return View(_context.Employees.Where
                (x => x.IsDeleted == false && x.IsActive == true));
        }
        public IActionResult AllEmp()
        {
            return View(_context.Employees);
        }
        [HttpGet]
        public IActionResult create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult create(Employee empl)
        {
            _context.Employees.Add(empl);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null) { return RedirectToAction(nameof(index)); }
            var data = _context.Employees.Find(id);
            if (data == null)
            {
                return RedirectToAction(nameof(NoFoundPage));
            }
            return View(data);
        }
        [HttpGet]
        public IActionResult Edit(int? id)//we copied details because we want it to show the same results but we want to add the edit part
        {
            if (id == null) { return RedirectToAction(nameof(index)); }
            var data = _context.Employees.Find(id);
            if (data == null)
            {
                return RedirectToAction(nameof(NoFoundPage));
            }
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(Employee emp)//we copied details because we want it to show the same results but we want to add the edit part
        {
            _context.Employees.Update(emp);
            _context.SaveChanges();
            return RedirectToAction(nameof(index));
        }
        [HttpGet]
        public IActionResult Delete(int? id)//we copied details because we want it to show the same results but we want to add the edit part
        {
            if (id == null) { return RedirectToAction(nameof(index)); }
            var data = _context.Employees.Find(id);
            if (data == null)
            {
                return RedirectToAction(nameof(NoFoundPage));
            }
            return View(data);
        }
        [HttpPost]
        public IActionResult ConfirmDelete(Employee e)
        {
            var data = _context.Employees.Find(e.EmployeeId);
            if (data == null) { return RedirectToAction(nameof(NoFoundPage)); }
            _context.Employees.Remove(data);
            _context.SaveChanges();
            return RedirectToAction(nameof(index));
        }
        public IActionResult NoFoundPage() { return View(); }
        public IActionResult GetData() { return View(); }
        public IActionResult DeletedEmployees()
        {
            return View(_context.Employees.Where(x => x.IsDeleted == true));
        }
        public IActionResult SoftDelete(int? id)
        {
            var softDel = _context.Employees.Find(id);
            softDel.IsDeleted = true;
            _context.SaveChanges();
            return RedirectToAction(nameof(index));
        }
        [HttpGet]
        public IActionResult Restore(int? id)
        {
            var rstr = _context.Employees.Find(id);
            rstr.IsDeleted = false;
            _context.SaveChanges();
            return RedirectToAction(nameof(index));
        }
        public IActionResult EmployeeStatus() { return View(_context.Employees); }
       
    }
}
