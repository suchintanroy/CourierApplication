using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Courier_Application.Models;

namespace Courier_Application.Repositories
{
    public interface ICourierAdminRepository
    {
        int AddCourierStaff(Employee employee);
    }
}
