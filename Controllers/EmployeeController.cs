using JwtAuthDemo.Helpers;
using JwtAuthDemo.Models;
using JwtAuthDemo.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JwtAuthDemo.Controllers
{
    public class EmployeeController : Controller
    {
        private EmployeeHelper _employeeHelper;

        public EmployeeController(Appdatacontext appdatacontext)
        {
            _employeeHelper = new EmployeeHelper(appdatacontext);
        }

        // GET: EmployeeController
        public async Task<ActionResult> IndexAsync()
        {
            return View(await _employeeHelper.Get());
        }
        
        // GET: EmployeeController/Details/5
        public async Task<ActionResult> DetailsAsync(int id)
        {
            var employee = await _employeeHelper.Get(id);
            return View(employee);
        }

        // GET: EmployeeController/Create
        public ActionResult Create()
        {
            return View();
        }
        public async Task<JsonResult> SaveEmployeeAsync(Employee model)
        {
            var response = await _employeeHelper.Save(model);


            return Json(response);
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(Employee collection)
        {
            try
            {
                var response = await _employeeHelper.Save(collection);
                return RedirectToAction("Confirmation", new { message = "Employee created successfully!" });
                
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Edit/5
        public async Task<ActionResult> EditAsync(int id)
        {
            return View(await _employeeHelper.Get(id));
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(Employee model , int id)
        {
            try
            {
                var response = await _employeeHelper.Update(model, id);
                return RedirectToAction("Confirmation", new { message = "Employee Updated successfully!" });
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_employeeHelper.Get(id));
        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Employee collection)
        {
            try
            {
                var response = _employeeHelper.Delete(id);
                return RedirectToAction("Confirmation", new { message = "Employee Deleted successfully!" });
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Confirmation(string  message)
        {
            return View((object)message);
        }

    }
}