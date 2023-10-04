using CrudApplication.Data;
using CrudApplication1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CrudApplication1.Controllers
{
    public class EmpDataController : Controller
    {
        private ApplicationContext context;

        public EmpDataController(ApplicationContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            
            return View();
        }
        public IActionResult Detail(string searchString = "", string searchBy = "") 
        {
                IQueryable<Employee> employees = context.Employees;
                switch (searchBy)
                {
                    case "id":
                    if (decimal.TryParse(searchString, out decimal empId))
                    {
                        employees = employees.Where(p => p.Id == empId);
                    }
                        break;
                    case "name":
                        employees = employees.Where(p => p.Name.Contains(searchString));
                        break;
                    case "city":
                        employees = employees.Where(p => p.City.Contains(searchString));
                        break;
                    case "state":
                        employees = employees.Where(p => p.State.Contains(searchString));
                        break;
                    case "salary":
                        if (decimal.TryParse(searchString, out decimal minSalary))
                        {
                            employees = employees.Where(p => p.Salary >= minSalary);
                        }
                        break;
                    default:
                     employees = employees.Where(p => p.Name.Contains(searchString));
                    break;
                }
               return View(employees.ToList());
         }
        public IActionResult Back()
        {
            return RedirectToAction("Index");
        }

    }
    
}

