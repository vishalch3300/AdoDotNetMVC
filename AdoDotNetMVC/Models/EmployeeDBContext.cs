using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace AdoDotNetMVC.Models
{
    public class EmployeeDBContext
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

        public List<Employee> GetEmployees()
        {
            List<Employee> EmployeesList = new List<Employee>();

            SqlConnection con = new SqlConnection(cs);

            ////SQL Server Statement
            //string query = "select id,name,gender,age,salary,city from employee_tbl";
            //SqlCommand cmd = new SqlCommand(query, con);
            ////SqlCommand cmd = new SqlCommand("select id,name,gender,age,salary,city from employee_tbl", con);
            //cmd.CommandType = CommandType.Text;

            //SQL Server stored procedure
            SqlCommand cmd = new SqlCommand("sp_GetEmployees", con);
            cmd.CommandType = CommandType.StoredProcedure;

            con.Open();

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Employee emp = new Employee();

                emp.id = Convert.ToInt32(dr.GetValue(0).ToString());
                emp.name = dr.GetValue(1).ToString();
                emp.gender = dr.GetValue(2).ToString();
                emp.age = Convert.ToInt32(dr.GetValue(3).ToString());
                emp.salary = Convert.ToInt32(dr.GetValue(4).ToString());
                emp.city = dr.GetValue(5).ToString();

                EmployeesList.Add(emp);
            }

            con.Close();

            return EmployeesList;
        }

        public bool AddEmployee(Employee emp)
        {
            SqlConnection con = new SqlConnection(cs);

            ////SQL Server Statement
            //string query = "insert into employee_tbl (name,gender,age,salary,city) values (@name,@gender,@age,@salary,@city)";
            //SqlCommand cmd = new SqlCommand(query, con);
            ////SqlCommand cmd = new SqlCommand("insert into employee_tbl (name,gender,age,salary,city) values (@name,@gender,@age,@salary,@city)", con);
            //cmd.CommandType = CommandType.Text;

            //SQL Server stored procedure
            SqlCommand cmd = new SqlCommand("sp_AddEmployee", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@name", emp.name);
            cmd.Parameters.AddWithValue("@gender", emp.gender);
            cmd.Parameters.AddWithValue("@age", emp.age);
            cmd.Parameters.AddWithValue("@salary", emp.salary);
            cmd.Parameters.AddWithValue("@city", emp.city);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateEmployee(Employee emp)
        {
            SqlConnection con = new SqlConnection(cs);

            ////SQL Server Statement
            //string query = "update employee_tbl set name=@name,gender=@gender,age=@age,salary=@salary,city=@city where id=@id";
            //SqlCommand cmd = new SqlCommand(query, con);
            ////SqlCommand cmd = new SqlCommand("update employee_tbl set name=@name,gender=@gender,age=@age,salary=@salary,city=@city where id=@id", con);
            //cmd.CommandType = CommandType.Text;

            //SQL Server stored procedure
            SqlCommand cmd = new SqlCommand("sp_UpdateEmployee", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@id", emp.id);
            cmd.Parameters.AddWithValue("@name", emp.name);
            cmd.Parameters.AddWithValue("@gender", emp.gender);
            cmd.Parameters.AddWithValue("@age", emp.age);
            cmd.Parameters.AddWithValue("@salary", emp.salary);
            cmd.Parameters.AddWithValue("@city", emp.city);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteEmployee(int id)
        {
            SqlConnection con = new SqlConnection(cs);

            ////SQL Server Statement
            //string query = "delete from employee_tbl where id=@id";
            //SqlCommand cmd = new SqlCommand(query, con);
            ////SqlCommand cmd = new SqlCommand("delete from employee_tbl where id=@id", con);
            //cmd.CommandType = CommandType.Text;

            //SQL Server stored procedure
            SqlCommand cmd = new SqlCommand("sp_DeleteEmployee", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}