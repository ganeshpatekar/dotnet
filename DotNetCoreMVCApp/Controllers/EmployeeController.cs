using DotNetCoreMVCApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreMVCApp.Controllers
{
    public class EmployeeController : Controller
    {
        Repository obj=new Repository();
        public IActionResult Index()
        {
            try
            {
                IEnumerable<Employee> employees = obj.GetAllEmployee();
                return View(employees);
            }
            catch (Exception ex)
            {

                throw;
            }           
            
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if(ModelState.IsValid)
            {
                obj.Create(employee);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
            
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            Employee employee = obj.GetEmployeeData(id);
            return View(employee);
        }

        [HttpPost]
       
        public IActionResult Update(Employee employee)
        {
            try
            {
                obj.Update(employee);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

     
        public ActionResult Delete(int id)
        {
            Employee employee = obj.GetEmployeeData(id);
            return View(employee);
        }

        [HttpPost]
        
        public IActionResult Delete(Employee employee)
        {
            try
            {                 
                obj.Delete(employee.Id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


    }
}
