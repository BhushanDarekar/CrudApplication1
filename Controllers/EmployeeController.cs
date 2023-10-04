using CrudApplication.Data;
using CrudApplication1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace CrudApplication1.Controllers
{
    public class EmployeeController : Controller
    {
        private ApplicationContext context;
        public EmployeeController(ApplicationContext context)
        {
            this.context = context;
        }
        public IActionResult Index(string sortDirection = "", string sortBy = "", int pg = 1)
        {
            IQueryable<Employee> employees = context.Employees;

            switch (sortBy)
            {
                case "Id":
                    employees = (sortDirection == "asc") ? employees.OrderBy(p => p.Id) : employees.OrderByDescending(p => p.Id);
                    break;

                case "Name":
                    employees = (sortDirection == "asc") ? employees.OrderBy(p => p.Name) : employees.OrderByDescending(p => p.Name);
                    break;

                case "City":
                    employees = (sortDirection == "asc") ? employees.OrderBy(p => p.City) : employees.OrderByDescending(p => p.City);
                    break;

                case "State":
                    employees = (sortDirection == "asc") ? employees.OrderBy(p => p.State) : employees.OrderByDescending(p => p.State);
                    break;
                
                case "Salary":
                    employees = (sortDirection == "asc") ? employees.OrderBy(p => p.Salary) : employees.OrderByDescending(p => p.Salary);
                    break;

                default:
                    employees = employees.OrderBy(p => p.Id);
                    break;
            }

            const int pageSize = 10;

            if (pg < 1)
            {
                pg = 1;
            }

            int resCount = employees.Count();

            var pager = new Pager(resCount, pg, pageSize, sortBy, sortDirection);

            int recSkip = (pg - 1) * pageSize;

            var data = employees.Skip(recSkip).Take(pager.PageSize).ToList();

            this.ViewBag.Pager = pager;

            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee model)
        {
            if (ModelState.IsValid)
            {
                var emp = new Employee()
                {
                   Name=model.Name,
                   City=model.City,
                   State=model.State,
                   Salary=model.Salary
                };
                context.Employees.Add(emp);
                context.SaveChanges();
                TempData["error"] = "Record Saved Successfully";
                return RedirectToAction("Index");
            }
           else
           {
                TempData["error"] = "Empty field cant submit";
                return View(model);

           }
        }
        //[HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var emp = context.Employees.SingleOrDefault(e => e.Id == id);
            context.Employees.Remove(emp);
            context.SaveChanges();
            TempData["error"] = "Record Deleted Successfully";
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var emp = context.Employees.SingleOrDefault(e => e.Id == id);
            var result = new Employee()
            {
                Name = emp.Name,
                City = emp.City,
                State = emp.State,
                Salary = emp.Salary
            };
            return View(result);
        }
        [HttpPost]
        public IActionResult Edit(Employee model)
        {
            var emp = new Employee()
            {
                Id=model.Id,
                Name = model.Name,
                City = model.City,
                State = model.State,
                Salary = model.Salary
            };
            context.Employees.Update(emp);
            context.SaveChanges();
            TempData["error"] = "Record Updated Successfully";
            return RedirectToAction("Index");
        }

    }
}
