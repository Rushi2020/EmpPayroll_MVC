using DatabaseLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;

namespace RepositoryLayer
{
    public class EmployeeRL:IEmployeeRL
    {
        string connectionString = "Data Source = (localdb)\\MSSQLLocalDB;Initial Catalog = EmployeePayrollMVC; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        //To View all employees details      
        public List<UserModel> GetAllEmployees()
        {
            List<UserModel> lstemployee = new List<UserModel>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("empGetAllEmployees", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    UserModel employee = new UserModel();
                    employee.EmployeeID = Convert.ToInt32(rdr["EmployeeID"]);
                    employee.EmployeeName = rdr["EmployeeName"].ToString();
                    employee.ProfileImage = rdr["ProfileImage"].ToString();
                    employee.Gender = rdr["Gender"].ToString();
                    employee.Department = rdr["Department"].ToString();
                    employee.Salary = Convert.ToInt32(rdr["Salary"]);
                    employee.StartDate =Convert.ToDateTime(rdr["Startdate"]);
                    employee.Notes = rdr["Notes"].ToString();

                    lstemployee.Add(employee);
                }
                con.Close();
            }
            return lstemployee;
        }
        public bool AddEmployee(UserModel employee)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("AddEmployees", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmployeeName", employee.EmployeeName);
                cmd.Parameters.AddWithValue("@ProfileImage", employee.ProfileImage);
                cmd.Parameters.AddWithValue("@Gender", employee.Gender);
                cmd.Parameters.AddWithValue("@Department", employee.Department);
                cmd.Parameters.AddWithValue("@Salary", employee.Salary);
                cmd.Parameters.AddWithValue("@StartDate", employee.StartDate);
                cmd.Parameters.AddWithValue("@Notes", employee.Notes);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            return true;

        }

        //To Update the records of a particluar employee    
        public bool UpdateEmployee(UserModel employee)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spUpdateEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmployeeID", employee.EmployeeID);
                cmd.Parameters.AddWithValue("@EmployeeName", employee.EmployeeName);
                cmd.Parameters.AddWithValue("@ProfileImage", employee.ProfileImage);
                cmd.Parameters.AddWithValue("@Gender", employee.Gender);
                cmd.Parameters.AddWithValue("@Department", employee.Department);
                cmd.Parameters.AddWithValue("@Salary", employee.Salary);
                cmd.Parameters.AddWithValue("@StartDate", employee.StartDate);
                cmd.Parameters.AddWithValue("@Notes", employee.Notes);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            return true;
        }

        //To Delete the record on a particular employee    
        public bool DeleteEmployee(int? EmployeeID)
        {

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spDeleteEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmployeeID", EmployeeID);
              
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            return true;
        }

        //Get Employee data by ID
        public UserModel GetEmployeeData(int? EmployeeID)
        {
            UserModel employee = new UserModel();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM Employeetable WHERE EmployeeID= " + EmployeeID;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    employee.EmployeeID = Convert.ToInt32(rdr["EmployeeID"]);
                    employee.EmployeeName = rdr["EmployeeName"].ToString();
                    employee.ProfileImage = rdr["ProfileImage"].ToString();
                    employee.Gender = rdr["Gender"].ToString();
                    employee.Department = rdr["Department"].ToString();
                    employee.Salary = Convert.ToInt32(rdr["Salary"]);
                    employee.StartDate = Convert.ToDateTime(rdr["Startdate"]);
                    employee.Notes = rdr["Notes"].ToString();
                }
            }
            return employee;
        }

    }
}
