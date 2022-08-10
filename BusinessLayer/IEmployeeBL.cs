using DatabaseLayer;
using RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
    public interface IEmployeeBL
    {
        public bool AddEmployee(UserModel user);
        public List<UserModel> GetAllEmployees();
        public bool UpdateEmployee(UserModel employee);
        public bool DeleteEmployee(int? id);
        public UserModel GetEmployeeData(int? id);




    }
}
