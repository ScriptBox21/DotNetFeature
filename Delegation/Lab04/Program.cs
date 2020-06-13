using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Lab04
{
    delegate void doLogWrite(DataSet ds);

    class Program
    {
        static void Main(string[] args)
        {
            doLogWrite log = new doLogWrite(logWrite);
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            string[] id = new string[] {"121", "12121"};
            DataRow dr;

            dt.Columns.Add("ID", Type.GetType("System.String"));

            for (int i = 0; i < id.Length; i++)
            {
                dr = dt.NewRow();
                dr["ID"] = id[i];
                dt.Rows.Add(dr);
            }
            dt.AcceptChanges();

            ds.Merge(dt);

            log.BeginInvoke(ds, null, null);

            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("index ==> {0}", i);
            }
        }

        static void logWrite(DataSet ds)
        {
            ds.WriteXml(string.Format(@"C:\{0}.txt", System.DateTime.Now.Ticks.ToString()));
        }
    }
}
