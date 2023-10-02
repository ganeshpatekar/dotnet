using DotNetCoreMVCApp.Utility;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DotNetCoreMVCApp.Models
{
    public class Repository
    {
        string connectionString = ConnectionString.CName;
        public IEnumerable<Employee> GetAllEmployee()
        {
            List<Employee> lstEmployee = new List<Employee>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_EmployeeData", con);
                cmd.Parameters.AddWithValue("@Mode", "GetEmpDetails");
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {   
                    Employee employee = new Employee();
                    employee.Id = Convert.ToInt32(rdr["EmpId"]);
                    employee.Name = rdr["EmpName"].ToString();
                    employee.Age = Convert.ToInt32(rdr["Age"]);
                    employee.Salary = Convert.ToDecimal(rdr["Salary"]);
                    employee.Department = rdr["Department"].ToString();
                    employee.Gender = rdr["Gender"].ToString();

                    lstEmployee.Add(employee);
                }
                con.Close();
            }
            return lstEmployee;
        }

        public void Create(Employee employee)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_EmployeeData", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Mode", "InsertData");
                cmd.Parameters.AddWithValue("@EmpName", employee.Name);
                cmd.Parameters.AddWithValue("@Age", employee.Age);
                cmd.Parameters.AddWithValue("@Salary", employee.Salary);
                cmd.Parameters.AddWithValue("@Department", employee.Department);
                cmd.Parameters.AddWithValue("@Gender", employee.Gender);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public Employee GetEmployeeData(int? id)
        {
            Employee employee = new Employee();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_EmployeeData", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Mode", "GetEmpData");
                cmd.Parameters.AddWithValue("@Id", id);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    employee.Id = Convert.ToInt32(rdr["EmpId"]);
                    employee.Name = rdr["EmpName"].ToString();
                    employee.Age = Convert.ToInt32(rdr["Age"]);
                    employee.Salary = Convert.ToDecimal(rdr["Salary"]);
                    employee.Department = rdr["Department"].ToString();
                    employee.Gender = rdr["Gender"].ToString();
                }
                con.Close();

            }
            return employee;
        }
        public void Update(Employee employee)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_EmployeeData", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Mode", "UpdateData");
                cmd.Parameters.AddWithValue("@Id", employee.Id);
                cmd.Parameters.AddWithValue("@EmpName", employee.Name);
                cmd.Parameters.AddWithValue("@Age", employee.Age);
                cmd.Parameters.AddWithValue("@Salary", employee.Salary);
                cmd.Parameters.AddWithValue("@Department", employee.Department);
                cmd.Parameters.AddWithValue("@Gender", employee.Gender);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void Delete(int? id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_EmployeeData", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Mode", "DeleteEmpDetails");
                cmd.Parameters.AddWithValue("@Id", id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }





    }
}
