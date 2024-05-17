using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Courier_Application.Models;
using Courier_Application.Utility;
using System.Data.SqlClient;

namespace Courier_Application.Repositories
{
    public class CourierAdminRepository : ICourierAdminRepository
    {
        SqlConnection sqlConnection = null;
        SqlCommand cmd = null;


        public CourierAdminRepository()
        {
            sqlConnection = new SqlConnection(ConnectionUtil.GetConnectionString());
            cmd = new SqlCommand();
        }

        public int AddCourierStaff(Employee employee)
        {
            int newStaffId = 0;
            cmd.Connection = sqlConnection;
            sqlConnection.Open();

            cmd.CommandText = "INSERT INTO Employee OUTPUT INSERTED.EmployeeID VALUES (@EmployeeID,@Name,@Email,@ContactNumber,@Role,@Salary)";
            cmd.Parameters.AddWithValue("@EmployeeID", employee.EmployeeID);
            cmd.Parameters.AddWithValue("@Name", employee.EmployeeName);
            cmd.Parameters.AddWithValue("@ContactNumber", employee.ContactNumber);
            cmd.Parameters.AddWithValue("@Email", employee.Email);
            cmd.Parameters.AddWithValue("@Salary", employee.Salary);
            cmd.Parameters.AddWithValue("@Role", employee.Role); ;

            newStaffId = (int)cmd.ExecuteScalar();

            Console.WriteLine(newStaffId);
            sqlConnection.Close();
            return newStaffId;
        }
    }
}

