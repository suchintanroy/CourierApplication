using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Courier_Application.Models;
using Courier_Application.Repositories;

namespace Courier_Application.Services
{

    internal class CourierAdminService : ICourierAdminService
    {
        readonly ICourierAdminRepository courierAdminRepo;

        public CourierAdminService()
        {
            courierAdminRepo = new CourierAdminRepository();
        }
        public void AddCourierStaff()
        {
            Console.WriteLine("Enter the Employee ID");
            int employeeID = int.Parse(Console.ReadLine());
            Console.Write("Enter the employee name: ");
            string employeeName = Console.ReadLine();
            Console.Write("Enter the email address: ");
            string email = Console.ReadLine();
            Console.Write("Enter the contact number: ");
            string contactNumber = Console.ReadLine();
            Console.Write("Enter the role: ");
            string role = Console.ReadLine();
            Console.Write("Enter the salary: ");
            decimal salary = decimal.Parse(Console.ReadLine());


            Employee emp = new Employee( employeeID,employeeName, email, contactNumber, role, salary);
            int empId = courierAdminRepo.AddCourierStaff(emp);

        }

    }
}
