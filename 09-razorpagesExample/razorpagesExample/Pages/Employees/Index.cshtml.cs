using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using razorpagesExample.Repository;
using razorpagesExample.Models;
using System.Collections.Generic;

namespace razorpagesExample.Pages.Employees
{
    public class IndexModel : PageModel
    {
        private readonly IEmployeeRepository _employeeRepository;

        public IndexModel(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

       
        public IEnumerable<razorpagesExample.Models.Employee> Employees { get; set; } = new List<razorpagesExample.Models.Employee>();

        public void OnGet()
        {
          
            Employees = _employeeRepository.GetAll();
        }
    }
}