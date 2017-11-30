using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    public interface IEmployee
    {
        int Id { get; set; }
        string Gender { get; set; }
        string City { get; set; }
        DateTime? DateOfBirth { get; set; }
    }

    [Table("Employee")]
    public class Employee : IEmployee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }
        public DateTime? DateOfBirth { get; set; }

        public bool addEmployee(Employee emp)
        {
            string connStr = ConfigurationManager.ConnectionStrings["employeeContext"].ConnectionString;
            SqlConnection cn = new SqlConnection(connStr);
            
            
                return true;

        }
    }
}