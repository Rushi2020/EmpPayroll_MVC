using DatabaseLayer;
using RepositoryLayer;
using System;
using System.Collections.Generic;

namespace BusinessLayer
{
    public class EmployeeBL:IEmployeeBL
    {

        IEmployeeRL employeeRL;
        public EmployeeBL(IEmployeeRL employeeRL)
        {
            this.employeeRL = employeeRL;
        }

        public bool AddEmployee(UserModel user)
        {
            try
            {
              return this.employeeRL.AddEmployee(user);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public List<UserModel> GetAllEmployees()
        {
            try
            {
                return this.employeeRL.GetAllEmployees();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateEmployee(UserModel user)
        {
            try
            {
                return this.employeeRL.UpdateEmployee(user);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DeleteEmployee(int? EmployeeID)
        {
                try
                {
                    return this.employeeRL.DeleteEmployee(EmployeeID);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
        }
        public UserModel GetEmployeeData(int? EmployeeID)
        {
                try
                {
                    return this.employeeRL.GetEmployeeData(EmployeeID);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
        }

        //bool IEmployeeBL.GetEmployeeData(int? id)
        //{
         //   throw new NotImplementedException();
       // }
    }
}
