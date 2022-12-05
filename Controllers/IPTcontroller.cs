using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using IPT1.Data;
using IPT1.Models;

using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;


//using Microsoft.AspNetCore.Mvc;

namespace IPT1.Controllers
{
    public class IPTcontroller : Controller
    {

        private readonly IPTDBcontext _context;

        private readonly IWebHostEnvironment _webHost;




        public IPTcontroller(IPTDBcontext context, IWebHostEnvironment webHost)
        {
            _context = context;
            _webHost = webHost;

        }
        public IActionResult Index()
        {
            List<Applicant> applicants;
            applicants = _context.Applicants.ToList();
            return View(applicants);
        }


        [HttpGet]
        public IActionResult Create()
        {
            Applicant applicant = new Applicant();
            applicant.Experiences.Add(new Experience() { ExperienceId = 1 });
            //applicant.Experiences.Add(new Experience() { ExperienceId = 2 });
            //applicant.Experiences.Add(new Experience() { ExperienceId = 3 });
            return View(applicant);
        }

        [HttpPost]
        public IActionResult Create(Applicant applicant)
        {
            applicant.Experiences.RemoveAll(n => n.YearsWorked == 0);


            foreach (Experience experience in applicant.Experiences)
            {
                if (experience.CompanyName == null || experience.CompanyName.Length == 0)
                    applicant.Experiences.Remove(experience);

            }

                //  string uniqueFileName = GetUploadedFileName(applicant);
                // applicant.PhotoUrl = uniqueFileName;

                _context.Add(applicant);
                _context.SaveChanges();
                return RedirectToAction("index");


        }


        public IActionResult Details (int Id)
        {
            Applicant applicant = _context.Applicants
                .Include(e => e.Experiences)
                .Where(a => a.Id == Id).FirstOrDefault();

            return View(applicant);
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            Applicant applicant = _context.Applicants
                .Include(e => e.Experiences)
                .Where(a => a.Id == Id).FirstOrDefault();
            return View(applicant);
        }
        [HttpPost]
        public IActionResult Delete(Applicant applicant)
        {
            _context.Attach(applicant);
            _context.Entry(applicant).State = EntityState.Deleted;
            _context.SaveChanges();
            return RedirectToAction("index");
        }








        [HttpGet]
		public IActionResult Edit(int Id)
		{
			Applicant applicant = _context.Applicants
				.Include(e => e.Experiences)
				.Where(a => a.Id == Id).FirstOrDefault();
          // ViewBag.Gender = GetGender();

			return View(applicant);
		}


		[HttpPost]
		public IActionResult Edit(Applicant applicant)
		{

            List<Experience> expDetails = _context.Experiences.Where(d => d.ApplicantId == applicant.Id).ToList();
            _context.Experiences.RemoveRange(expDetails);
            _context.SaveChanges();


			applicant.Experiences.RemoveAll(n => n.YearsWorked == 0);


			

			//  string uniqueFileName = GetUploadedFileName(applicant);
			// applicant.PhotoUrl = uniqueFileName;

			_context.Attach(applicant);
            _context.Entry(applicant).State=EntityState.Modified;
            _context.Experiences.AddRange(applicant.Experiences);
			_context.SaveChanges();
			return RedirectToAction("index");


		}




		/*
				[HttpPost]
				[ValidateAntiForgeryToken]
				public ActionResult Edit(
			[Bind(Include = "CourseID,Title,Credits,DepartmentID")]
			Course course)
				{
					try
					{
						if (ModelState.IsValid)
						{
							db.Entry(course).State = EntityState.Modified;
							db.SaveChanges();
							return RedirectToAction("Index");
						}

					} 

				*/
		//	catch (DataException /* dex */)
		//	{
		//Log the error (uncomment dex variable name after DataException and add a line here to write a log.)
		//		ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
		//	}
		//	PopulateDepartmentsDropDownList(course.DepartmentID);
		//	return View(course);
		//	}













	}
}
