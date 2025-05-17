using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JwtAuthDemo.Models;
using JwtAuthDemo.Models.Info;
using JwtAuthDemo.Models.Entities;
using JwtAuthDemo.Helpers;


namespace JwtAuthDemo.Controllers
{
    public class PersonalInfomationController : Controller
    {
        private readonly PersonalInformationsHelper _context;
        private Appdatacontext _appdatacontext;

        public PersonalInfomationController(Appdatacontext context)
        {
            _context = new PersonalInformationsHelper(context);
            _appdatacontext = context;
        }

        public ActionResult Droptable(PersonalInformation model)
        {
            return View(model);
        }


        // GET: PersonalInfomationController
        public ActionResult Index()
        {
            return View(_context.Get());
        }

        // GET: PersonalInfomation/Details/5
        public ActionResult Details(int id)
        {
            var personal = _context.Get(id);
            return View(personal);
        }

        // GET: PersonalInfomation/Create
        public ActionResult Create()
        {
            var dto = new PersonalInfomationDto();
            dto.Employees = _appdatacontext.Employee.ToList();
            dto.PersonalInfomation = new PersonalInformation();
            dto.PersonalInfomation.Employee = new Employee();
            return View(dto);
        }
        public async Task<JsonResult> SaveEmployeeAsync(PersonalInformation model)
        {
            var response = await _context.Save(model);


            return Json(response);
        }

        // POST: EmployeeController/Create
        [HttpPost("CreatePersonalInfomation")]
        [ValidateAntiForgeryToken]
        public IActionResult CreatePersonalInfomation(PersonalInfomationDto personalInfomationDto)
        {
            personalInfomationDto.PersonalInfomation.Employee
                = _appdatacontext.Employee.Where(a => a.Id
                == personalInfomationDto.PersonalInfomation.Id).FirstOrDefault();
            // Map DTO to the actual model entity
            var personal = new PersonalInformation
            {
                Id = 0,
                PositionDesired = personalInfomationDto.PersonalInfomation.PositionDesired,
                DateApplied = personalInfomationDto.PersonalInfomation.DateApplied,
                LastName = personalInfomationDto.PersonalInfomation.LastName,
                FirstName = personalInfomationDto.PersonalInfomation.FirstName,
                MiddleName = personalInfomationDto.PersonalInfomation.MiddleName,
                Sex = personalInfomationDto.PersonalInfomation.Sex,
                BirthDate = personalInfomationDto.PersonalInfomation.BirthDate,
                BirthPlace = personalInfomationDto.PersonalInfomation.BirthPlace,
                EmailAddress = personalInfomationDto.PersonalInfomation.EmailAddress,
                PhoneNumber = personalInfomationDto.PersonalInfomation.PhoneNumber,
                CivilStatus = personalInfomationDto.PersonalInfomation.CivilStatus,
                Religion = personalInfomationDto.PersonalInfomation.Religion,
                Citizenship = personalInfomationDto.PersonalInfomation.Citizenship,
                PresentAddress = personalInfomationDto.PersonalInfomation.PresentAddress,
                PermanentAddress = personalInfomationDto.PersonalInfomation.PermanentAddress,
                Height = personalInfomationDto.PersonalInfomation.Height,
                Weight = personalInfomationDto.PersonalInfomation.Weight,
                BloodType = personalInfomationDto.PersonalInfomation.BloodType,
                FathersOccupation = personalInfomationDto.PersonalInfomation.FathersOccupation,
                MothersName = personalInfomationDto.PersonalInfomation.MothersName,
                MothersOccupation = personalInfomationDto.PersonalInfomation.MothersOccupation,
                PersonContactedInCaseOfEmergency = personalInfomationDto.PersonalInfomation.PersonContactedInCaseOfEmergency,
                Relationship = personalInfomationDto.PersonalInfomation.Relationship,
                ContactNumber = personalInfomationDto.PersonalInfomation.ContactNumber
            };

            // Save to the database
            _appdatacontext.PersonalInformation.Add(personal);
            _appdatacontext.SaveChanges();

            // Redirect to the index or success page
            return RedirectToAction(nameof(Index));


            // Reload employees in case of validation errors
            personalInfomationDto.Employees = _appdatacontext.Employee.ToList();
            return View(personalInfomationDto);
        }

        // GET: PersonalInfomation/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_context.Get(id));
        }

        // POST: PersonalInfomation/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PersonalInformation model, int id)
        {
            try
            {
                var response = _context.Update(model, id);
                return RedirectToAction("Confirmation", new { message = "Data Updated successfully!" });

            }
            catch
            {
                return View();
            }
        }

        // GET: PerosonalInfomations/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_context.Get(id));
        }

        // POST: PersonalInfomation/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, PersonalInformation collection)
        {
            try
            {
                var response = _context.Delete(id);
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