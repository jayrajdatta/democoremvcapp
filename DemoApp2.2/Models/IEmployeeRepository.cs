using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoApp2._2.Models
{
    public interface IEmployeeRepository
    {
        Employee GetEmployee(int id);
    }
}
