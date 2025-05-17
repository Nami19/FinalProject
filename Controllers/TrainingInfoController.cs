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
    public class TrainingInfoController : Controller
    {
        private readonly Appdatacontext _appdatacontext;

        public TrainingInfoController(Appdatacontext context)
        {
            _appdatacontext = context;

        }
        public ActionResult Droptable(TrainingInfo model)
        {

            return View();

        }

        // GET: Training Info
        public ActionResult Index()
        {
            return View(_appdatacontext.TrainingInfo.ToList());
        }

        // GET: Training Info/Details/5
        public ActionResult Details(int id)
        {
            var traningIn = _appdatacontext.TrainingInfo.First(a =>a.Id == id);
            return View(traningIn);
        }

        // GET: Training Info/Create
        public ActionResult Create()
        {
            var dto = new TrainingInfoDto();
            dto.Employees = _appdatacontext.Employee.ToList();
            dto.TrainingInfo = new TrainingInfo();
            dto.TrainingInfo.Employee = new Employee();

            return View(dto);
        }

        public JsonResult Save(TrainingInfo model)
        {
            _appdatacontext.TrainingInfo.Add(model);
            var response = _appdatacontext.SaveChanges();

            return Json(model);
        }

        // POST: Training Info/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("CreateTrainingInfo")]
        [ValidateAntiForgeryToken]
        public IActionResult CreateTrainingInfo(TrainingInfoDto TrainingInfoDto)
        {
            if (TrainingInfoDto.TrainingInfo.Id == 0)
            {
                // Handle cases where EmployeeId is null
                // You can either leave it null or set a default EmployeeId if needed
                TrainingInfoDto.TrainingInfo.Employee= _appdatacontext.Employee.Where(a => a.Id== TrainingInfoDto.TrainingInfo.Id).FirstOrDefault();
            }


            var traningIn = new TrainingInfo
            {
                Id = 0,
                RelevantTrainings = TrainingInfoDto.TrainingInfo.RelevantTrainings,
                TrainingDate = TrainingInfoDto.TrainingInfo.TrainingDate,

            };

            // Save to the database
            _appdatacontext.TrainingInfo.Add(traningIn);
            _appdatacontext.SaveChanges();

            // Redirect to the index or success page
            return RedirectToAction(nameof(Index));


            // Reload employees in case of validation errors
            TrainingInfoDto.Employees= _appdatacontext.Employee.ToList();
            return View(TrainingInfoDto);

        }

        // GET: TrainingInfo/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_appdatacontext.TrainingInfo.First(a => a.Id == id));
        }

        // POST: TrainingInfo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAsync(TrainingInfo model, int id)
        {
            try
            {
                var traningIn = _appdatacontext.TrainingInfo.FirstOrDefault(a => a.Id == id);
                if (traningIn == null)
                    return NotFound();

                traningIn = model;
                await _appdatacontext.SaveChangesAsync();

                return RedirectToAction("Confirmation", new { message = "Data Updated successfully!" });
            }
            catch
            {
                return View();
            }
        }

        // GET: TrainingInfo/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_appdatacontext.TrainingInfo.First(a => a.Id == id));
        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, TrainingInfo collection)
        {
            try
            {
                var traningIn = _appdatacontext.TrainingInfo.FirstOrDefault(a => a.Id == id);
                if (traningIn == null)
                    return NotFound();
                var response = _appdatacontext.TrainingInfo.Remove(traningIn);
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