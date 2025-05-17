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
    public class CertificationsAndLicensesController : Controller
    {
        private readonly Appdatacontext _appdatacontext;

        public CertificationsAndLicensesController(Appdatacontext context)
        {
            _appdatacontext = context;

        }
        public ActionResult Droptable(CertificationsLicensces model)
        {

            return View();

        }

        // GET: Certificationslicenses
        public ActionResult Index()
        {
            return View(_appdatacontext.CertificationsLicenses.ToList());
        }

        // GET: Certificationslicenses/Details/5
        public ActionResult Details(int id)
        {
            var certificate = _appdatacontext.CertificationsLicenses.First(a=>a.Id == id);
            return View(certificate);
        }

        // GET: Certificationslicenses/Create
        public ActionResult Create()
        {
            var dto = new CertificationsAndLisencesDto();
            dto.Employees = _appdatacontext.Employee.ToList();
            dto.CertificationsAndlicenses = new CertificationsLicensces();
            dto.CertificationsAndlicenses.Employee = new Employee();

            return View(dto);
        }

        public JsonResult Save(CertificationsLicensces model)
        {
            _appdatacontext.CertificationsLicenses.Add(model);
            var response = _appdatacontext.SaveChanges();

            return Json(model);
        }

        // POST: CertificationsAndlicenses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("CreateCertificationsAndlicenses")]
        [ValidateAntiForgeryToken]
        public IActionResult CreateCertificationsAndlicenses(CertificationsAndLisencesDto CertificationsAndlicensesDto)
        {
            if (CertificationsAndlicensesDto.CertificationsAndlicenses.Id == 0)
            {
                // Handle cases where EmployeeId is null
                // You can either leave it null or set a default EmployeeId if needed
                CertificationsAndlicensesDto.CertificationsAndlicenses.Employee
                = _appdatacontext.Employee.Where(a => a.Id
                == CertificationsAndlicensesDto.CertificationsAndlicenses.Id).FirstOrDefault();
            }


            var certificate = new CertificationsLicensces
            {
                Id = 0,
                PRCLicense = CertificationsAndlicensesDto.CertificationsAndlicenses.PRCLicense,
                StartDate = CertificationsAndlicensesDto.CertificationsAndlicenses.StartDate,
                OtherCertification = CertificationsAndlicensesDto.CertificationsAndlicenses.OtherCertification

            };

            // Save to the database
            _appdatacontext.CertificationsLicenses.Add(certificate);
            _appdatacontext.SaveChanges();

            // Redirect to the index or success page
            return RedirectToAction(nameof(Index));


            // Reload employees in case of validation errors
            CertificationsAndlicensesDto.Employees = _appdatacontext.Employee.ToList();
            return View(CertificationsAndlicensesDto);

        }

        // GET: CertificationsAndlicenses/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_appdatacontext.CertificationsLicenses.First(a=>a.Id == id));
        }

        // POST: CertificationsAndlicenses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAsync(CertificationsLicensces model, int id)
        {
            try
            {
                var certLicense = _appdatacontext.CertificationsLicenses.FirstOrDefault(a => a.Id == id);
                if (certLicense == null)
                    return NotFound();

                certLicense = model;
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
            return View(_appdatacontext.CertificationsLicenses.First(a=>a.Id == id));
        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, CertificationsLicensces collection)
        {
            try
            {
                var cert = _appdatacontext.CertificationsLicenses.FirstOrDefault(a => a.Id == id);
                if (cert == null)
                    return NotFound();
                var response = _appdatacontext.CertificationsLicenses.Remove(cert);
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