using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestApp.Models
{
    public class Employee
    {        
		public int emp_id {private set; get;}
        public string full_name { private set; get; }
        public double salary { private set; get; }
        public int job_id { private set; get; }
        public string job_nm { private set; get; }
        public Employee()
        {
        }
        public Employee(int emp_id, string first_name, string last_name, double salary, int job_id, string job_nm)
        {
            this.emp_id = emp_id;
            this.full_name = first_name + " " + last_name;
            this.salary = salary;
            this.job_id = job_id;
            this.job_nm = job_nm;
        }
    }
}