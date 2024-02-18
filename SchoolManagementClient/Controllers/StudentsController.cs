using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolManagementClient.Models;

namespace SchoolManagementClient.Controllers
{
    public class StudentsController : Controller
    {
        private readonly StudentService _studentService;
        private readonly IHttpClientFactory _clientFactory;

        public StudentsController(StudentService studentService, IHttpClientFactory clientFactory)
        {
            _studentService = studentService;
            _clientFactory = clientFactory;
        }

        private async Task<List<Department>> GetAllDepartmentsAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost:5116/api/departments");
            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<List<Department>>();
        }

        public async Task<List<SelectListItem>> GetDepartmentListAsync()
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync("http://localhost:5116/api/departments");
            response.EnsureSuccessStatusCode();
            var departments = await response.Content.ReadAsAsync<List<Department>>();
            return departments.Select(d => new SelectListItem
            {
                Value = d.DepartmentId.ToString(),
                Text = d.DepartmentName
            }).ToList();
        }

        public async Task<IActionResult> Index()
        {
            var students = await _studentService.GetAllStudentsAsync();
            var studentsGroupedByDepartment = students.GroupBy(s => s.DepartmentName)
                                                     .ToDictionary(g => g.Key, g => g.ToList());
            return View(studentsGroupedByDepartment);


        }



        public IActionResult Create()
        {
            var departments = GetAllDepartmentsAsync().GetAwaiter().GetResult();
            ViewData["DepartmentId"] = new SelectList(departments, "DepartmentId", "DepartmentName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Student student)
        {
            if (ModelState.IsValid)
            {
                var createdStudent = await _studentService.CreateStudentAsync(student);
                return RedirectToAction(nameof(Index), new { id = createdStudent.StudentId });
            }
            return View(student);
        }

        public async Task<IActionResult> Edit(long id)
        {
            var student = await _studentService.GetStudentAsync(id);
            ViewBag.DepartmentList = await GetDepartmentListAsync();
            
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, Student student)
        {
            if (id != student.StudentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _studentService.UpdateStudentAsync(id, student);
                return RedirectToAction(nameof(Index), new { id = student.StudentId });
            }

            ViewBag.DepartmentList = await GetDepartmentListAsync();
            return View(student);
        }

        public async Task<IActionResult> Delete(long id)
        {
            var student = await _studentService.GetStudentAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);


        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            await _studentService.DeleteStudentAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
