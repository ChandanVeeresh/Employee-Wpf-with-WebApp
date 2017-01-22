using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFwebApi;

namespace StudentDetailsServiceLayer.Models
{
    public interface IEmployeeRepository
    {
        IEnumerable<DB_Employee> GetAll();
        DB_Employee Get(int id);
        bool Add(DB_Employee employee);
        void Remove(int id);
        bool Update(DB_Employee employee);
    }
}
