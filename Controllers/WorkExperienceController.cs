using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JwtAuthDemo.Models;
using JwtAuthDemo.Models.Entities;
using JwtAuthDemo.Models.Info;

namespace JwtAuthDemo.Controllers
{
    public class WorkExperienceController : Controller
    {
        private readonly Appdatacontext _appdatacontext;

        public WorkExperienceController(Appdatacontext context)
        {
            _appdatacontext = context;

        }
        public ActionResult Droptable(WorkExperience model)
        {

            return View();

        }

      
        public ActionResult Index()
        {
            return View(_appdatacontext.WorkExperience.ToList());
        }

        
        public ActionResult Details(int id)
        {
            var workexp = _appdatacontext.WorkExperience.First(a => a.Id == id);
            return View(workexp);
        }

        // GET: Certificationslicenses/Create
        public ActionResult Create()
        {
            var dto = new WorkExperienceDto();
            dto.Employees = _appdatacontext.Employee.ToList();
            dto.WorkExperience = new WorkExperience();
            dto.WorkExperience.Employee = new Employee();

            return View(dto);
        }

        public JsonResult Save(WorkExperience model)
        {
            _appdatacontext.WorkExperience.Add(model);
            var response = _appdatacontext.SaveChanges();

            return Json(model);
        }

        // POST: CertificationsAndlicenses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("CreateWorkExperience")]
        [ValidateAntiForgeryToken]
        public IActionResult CreateWorkExperience(WorkExperienceDto WorkExperienceDto)
        {
            if (WorkExperienceDto.WorkExperience.Id == 0)
            {
                // Handle cases where EmployeeId is null
                // You can either leave it null or set a default EmployeeId if needed
                WorkExperienceDto.WorkExperience.Employee
                = _appdatacontext.Employee.Where(a => a.Id
                == WorkExperienceDto.WorkExperience.Id).FirstOrDefault();
            }


            var workexp = new WorkExperience
            {
                Id = 0,
                PreviousCompanies = WorkExperienceDto.WorkExperience.PreviousCompanies,
                StartDate = WorkExperienceDto.WorkExperience.StartDate,
                EndtDate = WorkExperienceDto.WorkExperience.EndtDate
            };

            // Save to the database
            _appdatacontext.WorkExperience.Add(workexp);
            _appdatacontext.SaveChanges();

            // Redirect to the index or success page
            return RedirectToAction(nameof(Index));


            // Reload employees in case of validation errors
            WorkExperienceDto.Employees = _appdatacontext.Employee.ToList();
            return View(WorkExperienceDto);

        }

        // GET: CertificationsAndlicenses/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_appdatacontext.WorkExperience.First(a => a.Id == id));
        }

        // POST: CertificationsAndlicenses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAsync(WorkExperience model, int id)
        {
            try
            {
                var workEx = _appdatacontext.WorkExperience.FirstOrDefault(a => a.Id == id);
                if (workEx == null)
                    return NotFound();

                workEx = model;
                await _appdatacontext.SaveChangesAsync();

                return RedirectToAction("Confirmation", new { message = "Data Updated successfully!" });
            }
            catch
            {
                return View();
            }
        }

        // GET: CertificationsAndlicenses/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_appdatacontext.WorkExperience.First(a => a.Id == id));
        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, WorkExperience collection)
        {
            try
            {
                var workEx = _appdatacontext.WorkExperience.FirstOrDefault(a => a.Id == id);
                if (workEx == null)
                    return NotFound();
                var response = _appdatacontext.WorkExperience.Remove(workEx);
                return RedirectToAction("Confirmation", new { message = "Data Deleted successfully!" });
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Confirmation(string message)
        {
            return View((object)message);
        }

    }
}