using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;

namespace TestApp.Models
{
    public class Employees
    {
        const string UpdateSalary = "UPDATE Employees SET [Salary]=@salary WHERE Emp_id=@id";
        private static List<Employee> empList = new List<Employee>();
        const string SelectAll = "SELECT Employees.Emp_id, Employees.First_name, Employees.Last_name"
            +", Employees.Salary, Jobs.Job_id, Jobs.Job_nm"
            +" FROM Jobs INNER JOIN Employees ON Jobs.Job_id = Employees.Job_id; ";
        const string SelectInd = "SELECT Employees.Emp_id, Employees.First_name, Employees.Last_name"
            + ", Employees.Salary, Jobs.Job_id, Jobs.Job_nm"
            + " FROM Jobs INNER JOIN Employees ON Jobs.Job_id = Employees.Job_id WHERE Employees.Job_id=@job_id";
        public static List<Employee> EmpList(int? id = null)
        {
            OleDbConnection conn = MyConnection.GetConnection();
            OleDbCommand cmd;
            if (id != null )
            {
                cmd = new OleDbCommand(SelectInd, conn);
                cmd.Parameters.AddWithValue("@job_id", id);
            }
            else
            {
                cmd = new OleDbCommand(SelectInd, conn);
                cmd.Parameters.AddWithValue("@job_id", 1);
            }
            OleDbDataReader rdr = cmd.ExecuteReader();
            empList.Clear();
            Employee p = null;
            while (rdr.Read())
            {
                p = new Employee(rdr.GetInt32(0), rdr.GetString(1), rdr.GetString(2), rdr.GetDouble(3), rdr.GetInt32(4), rdr.GetString(5));
                empList.Add(p);
            }
            return empList;
        }
        public static void CorrectSalary(int id, double salary)
        {
            OleDbConnection conn = MyConnection.GetConnection();
            OleDbCommand cmd = new OleDbCommand(UpdateSalary, conn);
            cmd.Parameters.AddWithValue("@salary", salary);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }
    }
}