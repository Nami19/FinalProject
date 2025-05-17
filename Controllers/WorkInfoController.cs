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
    public class WorkInfoController : Controller
    {
        private readonly Appdatacontext _appdatacontext;

        public WorkInfoController(Appdatacontext context)
        {
            _appdatacontext = context;

        }
        public ActionResult Droptable(WorkInfo model)
        {

            return View();

        }

        // GET: WorkInfo 
        public ActionResult Index()
        {
            return View(_appdatacontext.WorkInfo.ToList());
        }

        // GET: Certificationslicenses/Details/5
        public ActionResult Details(int id)
        {
            var workin = _appdatacontext.WorkInfo.First(a => a.Id == id);
            return View(workin);
        }

        // GET: Certificationslicenses/Create
        public ActionResult Create()
        {
            var dto = new WorkInfoDto();
            dto.Employees = _appdatacontext.Employee.ToList();
            dto.WorkInfo = new WorkInfo();
            dto.WorkInfo.Employee = new Employee();

            return View(dto);
        }

        public JsonResult Save(WorkInfo model)
        {
            _appdatacontext.WorkInfo.Add(model);
            var response = _appdatacontext.SaveChanges();

            return Json(model);
        }

        // POST: CertificationsAndlicenses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("CreateWorkInfo")]
        [ValidateAntiForgeryToken]
        public IActionResult CreateWorkInfo(WorkInfoDto WorkInfoDto)
        {
            if (WorkInfoDto.WorkInfo.Id == 0)
            {
                // Handle cases where EmployeeId is null
                // You can either leave it null or set a default EmployeeId if needed
                WorkInfoDto.WorkInfo.Employee
                = _appdatacontext.Employee.Where(a => a.Id
                == WorkInfoDto.WorkInfo.Id).FirstOrDefault();
            }


            var workin = new WorkInfo
            {
                Id = 0,
                Employmentstatus= WorkInfoDto.WorkInfo.Employmentstatus,
                DateHired = WorkInfoDto.WorkInfo.DateHired,
                Position = WorkInfoDto.WorkInfo.Position,
                Reportorial = WorkInfoDto.WorkInfo.Reportorial
            };

            // Save to the database
            _appdatacontext.WorkInfo.Add(workin);
            _appdatacontext.SaveChanges();

            // Redirect to the index or success page
            return RedirectToAction(nameof(Index));


            // Reload employees in case of validation errors
            WorkInfoDto.Employees = _appdatacontext.Employee.ToList();
            return View(WorkInfoDto);

        }

        // GET: CertificationsAndlicenses/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_appdatacontext.WorkInfo.First(a => a.Id == id));
        }

        // POST: CertificationsAndlicenses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAsync(WorkInfo model, int id)
        {
            try
            {
                var WoIn = _appdatacontext.WorkInfo.FirstOrDefault(a => a.Id == id);
                if (WoIn == null)
                    return NotFound();

                WoIn = model;
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
            return View(_appdatacontext.WorkInfo.First(a => a.Id == id));
        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, WorkInfo collection)
        {
            try
            {
                var WorkIn = _appdatacontext.WorkInfo.FirstOrDefault(a => a.Id == id);
                if (WorkIn == null)
                    return NotFound();
                var response = _appdatacontext.WorkInfo.Remove(WorkIn);
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