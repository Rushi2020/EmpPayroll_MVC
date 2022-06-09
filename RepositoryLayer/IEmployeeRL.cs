using DatabaseLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer
{
    public interface IEmployeeRL
    {
        public bool AddEmployee(UserModel user);
        public List<UserModel> GetAllEmployees();
        public bool UpdateEmployee(UserModel employee);
        public bool DeleteEmployee(int? EmployeeID);
        public UserModel GetEmployeeData(int? id);


    }
}
