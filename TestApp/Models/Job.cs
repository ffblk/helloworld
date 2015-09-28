using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestApp.Models
{
    public class Job
    {
        public int Id { private set; get; }
        public string Job_nm { private set; get; }
        public Job(int id, string job_nm)
        {
            Id = id;
            Job_nm = job_nm;
        }
    }
}