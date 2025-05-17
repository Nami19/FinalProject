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
    public class GovernmentInfoController : Controller
    {
        private readonly Appdatacontext _appdatacontext;

        public GovernmentInfoController(Appdatacontext context)
        {
            _appdatacontext = context;

        }
        public ActionResult Droptable(GovernmentInfo model)
        {

            return View();

        }

        // GET: GovernmentInfo
        public ActionResult Index()
        {
            return View(_appdatacontext.GovernmentInfo.ToList());
        }

        // GET: GovernmentInfo/Details/5
        public ActionResult Details(int id)
        {
            var government = _appdatacontext.GovernmentInfo.First(a => a.Id == id);
            return View(government);
        }

        // GET: GovernmentInfo/Create
        public ActionResult Create()
        {
            var dto = new GovernmentInfoDto();
            dto.Employees = _appdatacontext.Employee.ToList();
            dto.GovernmentInfo = new GovernmentInfo();
            dto.GovernmentInfo.Employee = new Employee();

            return View(dto);
        }

        public JsonResult Save(GovernmentInfo model)
        {
            _appdatacontext.GovernmentInfo.Add(model);
            var response = _appdatacontext.SaveChanges();

            return Json(model);
        }

        // POST: CertificationsAndlicenses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("CreateGovernmentInfo")]
        [ValidateAntiForgeryToken]
        public IActionResult CreateGovernmentInfo(GovernmentInfoDto GovernmentInfoDto)
        {
            if (GovernmentInfoDto.GovernmentInfo.Id == 0)
            {
                // Handle cases where EmployeeId is null
                // You can either leave it null or set a default EmployeeId if needed
                GovernmentInfoDto.GovernmentInfo.Employee
                = _appdatacontext.Employee.Where(a => a.Id
                == GovernmentInfoDto.GovernmentInfo.Id).FirstOrDefault();
            }


            var government = new GovernmentInfo
            {
                Id = 0,
                SSS = GovernmentInfoDto.GovernmentInfo.SSS,
                PhilHealth = GovernmentInfoDto.GovernmentInfo.PhilHealth,
                PagIbig = GovernmentInfoDto.GovernmentInfo.PagIbig,
                TinID = GovernmentInfoDto.GovernmentInfo.TinID

            };

            // Save to the database
            _appdatacontext.GovernmentInfo.Add(government);
            _appdatacontext.SaveChanges();

            // Redirect to the index or success page
            return RedirectToAction(nameof(Index));


            // Reload employees in case of validation errors
            GovernmentInfoDto.Employees = _appdatacontext.Employee.ToList();
            return View(GovernmentInfoDto);

        }

        // GET: CertificationsAndlicenses/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_appdatacontext.GovernmentInfo.First(a => a.Id == id));
        }

        // POST: CertificationsAndlicenses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAsync(GovernmentInfo model, int id)
        {
            try
            {
                var govenInfo = _appdatacontext.GovernmentInfo.FirstOrDefault(a => a.Id == id);
                if (govenInfo == null)
                    return NotFound();

                govenInfo = model;
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
            return View(_appdatacontext.GovernmentInfo.First(a => a.Id == id));
        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, GovernmentInfo collection)
        {
            try
            {
                var govern = _appdatacontext.GovernmentInfo.FirstOrDefault(a => a.Id == id);
                if (govern == null)
                    return NotFound();
                var response = _appdatacontext.GovernmentInfo.Remove(govern);
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