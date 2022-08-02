using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestBuyBestPractices
{
    internal class DepartmentRepository : IDepartmentRepository
    {
        private readonly IDbConnection _connection;
        
        public DepartmentRepository(IDbConnection connection)
        {
            _connection = connection;
        }





        public IEnumerable<Department> GetAllDepartments()
        {
            return _connection.Query<Department>("SELECT * FROM departments;");
        }

        public void InsertDepartment(string newDepartmentName)
        {
            _connection.Execute("INSERT INTO departments (NAME) VALUES (@name);" , new {name  = newDepartmentName});
        }
    }
}
