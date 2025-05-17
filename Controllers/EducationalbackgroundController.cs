using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JwtAuthDemo.Models;
using JwtAuthDemo.Models.Entities;
using JwtAuthDemo.Helpers;
using JwtAuthDemo.Models.Info;


namespace JwtAuthDemo.Controllers
{
    public class EducationalInformationsController : Controller
    {
        private readonly EducationalInformationHelper _context;
        private readonly Appdatacontext _appdatacontext;

        public EducationalInformationsController(Appdatacontext context)
        {
            _context = new EducationalInformationHelper(context);
            _appdatacontext = context;
        }

        public ActionResult Droptable(Educationalbackground model)
        {

            return View();

        }


        // GET: EmployeeController
        public async Task<ActionResult> IndexAsync(int id)
        {
            return View(await _context.Get(id));
        }

        // GET: EmployeeController/Details/5
        public async Task<ActionResult> DetailsAsync(int id)
        {
            var employee = await _context.Get(id);
            return View(employee.FirstOrDefault());
        }

        // GET: EmployeeController/Create
        public ActionResult Create()
        {
            var dto = new EducationalbackgroundDto();
            dto.Employees = _appdatacontext.Employee.ToList();
            dto.Educationalbackground = new Educationalbackground();
            dto.Educationalbackground.Employee = new Employee();
            return View(dto);
        }
        public async Task<JsonResult> SaveEmployeeAsync(Educationalbackground model)
        {
            var response = await _context.Save(model);

            return Json(response);
        }

        // POST: EmployeeController/Create
        [HttpPost("CreateEducationalInformation")]
        [ValidateAntiForgeryToken]
        public IActionResult CreateEducationalInformation(EducationalbackgroundDto educationalInformationDto)
        {
            educationalInformationDto.Educationalbackground.Employee
                = _appdatacontext.Employee.Where(a => a.Id
                == educationalInformationDto.Educationalbackground.Employee.Id).FirstOrDefault();
            // Map DTO to the actual model entity
            var educationalInformation = new Educationalbackground
            {
                Id = 0,
                ElementarySchool = educationalInformationDto.Educationalbackground.ElementarySchool,
                ElementaryYearAttended = educationalInformationDto.Educationalbackground.ElementaryYearAttended,
                HighSchool = educationalInformationDto.Educationalbackground.HighSchool,
                HighSchoolYearAttended = educationalInformationDto.Educationalbackground.HighSchoolYearAttended,
                CollegeSchool = educationalInformationDto.Educationalbackground.CollegeSchool,
                CollegeYearAttended2 = educationalInformationDto.Educationalbackground.CollegeYearAttended2,
                DegreeReceived = educationalInformationDto.Educationalbackground.DegreeReceived,
                SpecialSkills = educationalInformationDto.Educationalbackground.SpecialSkills,
                Others = educationalInformationDto.Educationalbackground.Others,
                Employee = educationalInformationDto.Educationalbackground.Employee
            };

            // Save to the database
            _appdatacontext.Educationalbackground.Add(educationalInformation);
            _appdatacontext.SaveChanges();

            // Redirect to the index or success page
            return RedirectToAction(nameof(IndexAsync));


            // Reload employees in case of validation errors
            educationalInformationDto.Employees = _appdatacontext.Employee.ToList();
            return View(educationalInformationDto);
        }

        // GET: EmployeeController/Edit/5
        public IActionResult Edit(EducationalbackgroundDto educationalInformationDto)
        {
            educationalInformationDto.Educationalbackground.Employee
               = _appdatacontext.Employee.Where(a => a.Id
               == educationalInformationDto.Educationalbackground.Employee.Id).FirstOrDefault();
            // Map DTO to the actual model entity
            var educationalInformation = new Educationalbackground
            {
                Id = 1,
                ElementarySchool = educationalInformationDto.Educationalbackground.ElementarySchool,
                ElementaryYearAttended = educationalInformationDto.Educationalbackground.ElementaryYearAttended,
                HighSchool = educationalInformationDto.Educationalbackground.HighSchool,
                HighSchoolYearAttended = educationalInformationDto.Educationalbackground.HighSchoolYearAttended,
                CollegeSchool = educationalInformationDto.Educationalbackground.CollegeSchool,
                CollegeYearAttended2 = educationalInformationDto.Educationalbackground.CollegeYearAttended2,
                DegreeReceived = educationalInformationDto.Educationalbackground.DegreeReceived,
                SpecialSkills = educationalInformationDto.Educationalbackground.SpecialSkills,
                Others = educationalInformationDto.Educationalbackground.Others,
                Employee = educationalInformationDto.Educationalbackground.Employee
            };

            // Save to the database
            _appdatacontext.Educationalbackground.Add(educationalInformation);
            _appdatacontext.SaveChanges();

            // Redirect to the index or success page
            return RedirectToAction(nameof(IndexAsync));


            // Reload employees in case of validation errors
            educationalInformationDto.Employees = _appdatacontext.Employee.ToList();
            return View(educationalInformationDto);
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Educationalbackground model, int id)
        {
            try
            {
                var response = _context.Update(model, id);
                return RedirectToAction("Confirmation", new { message = "Employee Updated successfully!" });
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Delete/5
        public async Task<ActionResult> DeleteAsync(int id)
        {
            return View((await _context.Get(id)).FirstOrDefault());
        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Employee collection)
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