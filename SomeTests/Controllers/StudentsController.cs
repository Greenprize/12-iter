using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SomeTests.Models;
using SomeTests.Services;

namespace SomeTests.Controllers
{
    public class StudentsController : Controller
    {
        private readonly StudentService studentService;

        public StudentsController(StudentService studentService)
        {
            this.studentService = studentService;
        }

        // GET: Cars
        public ActionResult Index()
        {
            return View(studentService.Get());
        }

        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = studentService.Get(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                studentService.Create(student);
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = studentService.Get(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // POST: Cars/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, Student student)
        {
            if (id != student.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                studentService.Update(id, student);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(student);
            }
        }

        // GET: Cars/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = studentService.Get(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            try
            {
                var student = studentService.Get(id);

                if (student == null)
                {
                    return NotFound();
                }

                studentService.Remove(student.Id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}