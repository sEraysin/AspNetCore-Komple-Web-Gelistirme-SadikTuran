using razorpagesExample.Models;

namespace razorpagesExample.Repository
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employeesList;
        public MockEmployeeRepository()
        {
            _employeesList = new List<Employee>()
            {
                 new Employee{Id=1,Name="Eray Güler",Email="gulereray211@gmail.com",Photo="1.jpg",Department="Muhasebe"},
                 new Employee{Id=2,Name="Sadık Güler",Email="sadıkguler@gmail.com",Photo="2.jpg",Department="Muhasebe"},
                 new Employee{Id=3,Name="Burcu Güler",Email="burcuguler@gmail.com",Photo="3.jpg",Department="Muhasebe"},
                 new Employee{Id=4,Name="Göksu Güler",Email="goksuguler@gmail.com",Photo="4.jpg",Department="Muhasebe"},
                 
            };
        }
        public IEnumerable<Employee> GetAll()
        {
            return _employeesList;
        }

        public Employee GetById(int id)
        {
           return _employeesList.FirstOrDefault(i=>i.Id==id);
        }

        public Employee Update(Employee entity)
        {
          Employee employees=_employeesList.FirstOrDefault(i=>i.Id==entity.Id);
            if(employees!=null)
            {
                employees.Name = entity.Name;
                employees.Email = entity.Email;
                employees.Photo = entity.Photo;
                employees.Department = entity.Department;
            }
            return employees;
        }
    }
}
