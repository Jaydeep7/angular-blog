using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Configuration;
using System.Data.SqlClient;

namespace WebApplication4.Models
{
    public class EmployeeContext : DbContext
    { 
        public DbSet<Employee> employees { get; set; }

        public bool addEmployee(Employee employee)
        {
            var connStr = ConfigurationManager.ConnectionStrings["employeeContext"].ConnectionString;
            using (var cn = new SqlConnection(connStr))
            {
                var cm = new SqlCommand("addEmployee");
                cm.CommandType = System.Data.CommandType.StoredProcedure;
                cm.Parameters.AddWithValue("@Name", employee.Name);
                cm.Parameters.AddWithValue("@Id", employee.Id);
                cm.Parameters.AddWithValue("@Gender", employee.Gender);
                cm.Parameters.AddWithValue("@City", employee.City);
                cm.Parameters.AddWithValue("@DateOfBirth", employee.DateOfBirth);
                cm.Connection = cn;
                cn.Open();
                cm.ExecuteNonQuery();
                return true;
            }
        }

        public void  updateEmployee(Employee employee)
        {
            try
            {
                var connStr = ConfigurationManager.ConnectionStrings["employeeContext"].ConnectionString;
                using (var cn = new SqlConnection(connStr))
                {
                    var cm = new SqlCommand("spUpdateEmployee");
                    cm.CommandType = System.Data.CommandType.StoredProcedure;
                    cm.Parameters.AddWithValue("@Name", employee.Name);
                    cm.Parameters.AddWithValue("@Id", employee.Id);
                    cm.Parameters.AddWithValue("@Gender", employee.Gender);
                    cm.Parameters.AddWithValue("@City", employee.City);
                    cm.Parameters.AddWithValue("@DateOfBirth", employee.DateOfBirth);
                    cm.Connection = cn;
                    cn.Open();
                    cm.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                var str = ex.Message;
            }
        }

        public void deleteEmployee(Employee employee)
        {
            try
            {
                var connStr = ConfigurationManager.ConnectionStrings["employeeContext"].ConnectionString;
                using (var cn = new SqlConnection(connStr))
                {
                    var cm = new SqlCommand("spDeleteEmployee");
                    cm.CommandType = System.Data.CommandType.StoredProcedure;
                    cm.Parameters.AddWithValue("@Id", employee.Id);
                    cm.Connection = cn;
                    cn.Open();
                    cm.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                var str = ex.Message;
            }
        }
    }


}