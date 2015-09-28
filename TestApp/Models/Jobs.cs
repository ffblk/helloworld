using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;

namespace TestApp.Models
{
    public class Jobs
    {
        private static List<Job> jobList = new List<Job>();
        const string SelectAll = "SELECT Job_id, Job_nm FROM Jobs ;";
        public static List<Job> JobList(int? id = null)
        {
            OleDbConnection conn = MyConnection.GetConnection();
            OleDbCommand cmd = new OleDbCommand(SelectAll, conn);
            OleDbDataReader rdr = cmd.ExecuteReader();
            jobList.Clear();
            Job p = null;
            while (rdr.Read())
            {
                p = new Job(rdr.GetInt32(0), rdr.GetString(1));
                jobList.Add(p);
            }
            return jobList;
        }
    }
}