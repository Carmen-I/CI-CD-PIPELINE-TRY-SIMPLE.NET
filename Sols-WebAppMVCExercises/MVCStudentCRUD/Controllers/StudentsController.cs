using MVCStudentCRUD.Data;
using MVCStudentCRUD.Models;
using Microsoft.AspNetCore.Mvc;

namespace MVCStudentCRUD.Controllers {
    public class StudentsController : Controller {

        private readonly StudentData _studentAccesss;

        // Constructor
        public StudentsController() {
            _studentAccesss = StudentData.Instance;
        }

        // ../students/index
        public ActionResult Index(Student? inStudent = null) {
            IEnumerable<Student>? foundStudents = _studentAccesss.StudentList;
            if (inStudent != null && inStudent.StudentId > 0) {
                ViewData["newStudent"] = inStudent;
            }
            return View(foundStudents);
        }

        // ../students/details/4
        [HttpGet]
        public ActionResult Details(int id) {
            Student? foundStudent = _studentAccesss.GetStudentById(id);
            return View(foundStudent);
        }

        // ../students/create
        [HttpGet]
        public ActionResult Create() {
            return View();              // Empty form to
        }
        [HttpPost]
        public ActionResult Create(Student inStudent) {     // Filled form from browser
            ActionResult foundRes = RedirectToAction("Index");
            Student? insertedStudent = _studentAccesss.InsertStudent(inStudent);
            if (insertedStudent != null) {
                foundRes = RedirectToAction("Index", insertedStudent);
            }
            return foundRes;
        }


        // ../students/edit/2
        [HttpGet]
        public ActionResult Edit(int id) {
            ActionResult foundResult;
            Student? editStudent = _studentAccesss.GetStudentById(id);
            if (editStudent != null && editStudent.StudentId > 0) {
                foundResult = View(editStudent);    // Filled form (for edit) to browser
            } else {
                TempData["ProcessText"] = "Student with id " + id + " not found!";
                foundResult = RedirectToAction("Index");
            }
            return foundResult;
        }
        [HttpPost]
        public ActionResult Edit(int id, Student inStudent) {   // Modified form from browser
            inStudent.StudentId = id;
            _studentAccesss.UpdateStudent(inStudent);
            return RedirectToAction("Index");
        }

        // .. /Students/Delete/5
        [HttpGet]
        public ActionResult Delete(int id) {
            Student? delStudent = _studentAccesss.GetStudentById(id);
            return View(delStudent);
        }
        // .. /Students/DeleteStudent
        [HttpPost]
        public ActionResult DeleteStudent([FromForm] int id) {
            _studentAccesss.DeleteStudent(id);
            TempData["ProcessText"] = "Student with id " + id + " was deleted!";
            return RedirectToAction("Index");
        }
    }
}
