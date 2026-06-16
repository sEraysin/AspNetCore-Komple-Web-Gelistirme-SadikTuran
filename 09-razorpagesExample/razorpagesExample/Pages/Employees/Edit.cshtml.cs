using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using razorpagesExample.Repository;

namespace razorpagesExample.Pages.Employees
{
    public class EditModel : PageModel
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EditModel(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [BindProperty]
        public razorpagesExample.Models.Employee Employee { get; set; } = null!;

        public void OnGet(int id)
        {
            Employee = _employeeRepository.GetById(id);
        }

    
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _employeeRepository.Update(Employee);

         
            return RedirectToPage("Index");
        }
    }
}