using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Oracle.DataAccess.Client;

namespace Lab06_DataSet
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //DataSet ds = new DataSet();
            //OracleConnection conn = new OracleConnection();
            //conn.ConnectionString = "Data Source=BCEDW;user id=bcdev;password=bcdev";
            //conn.Open();

            //OracleCommand cmd = new OracleCommand();
            //cmd.Connection = conn;
            //cmd.CommandType = CommandType.Text;
            //cmd.CommandText = "select * from bc_config_resource_t";

            //OracleDataAdapter adp = new OracleDataAdapter();
            //adp.SelectCommand = cmd;
            //adp.UpdateCommand = 
            //adp.Fill(ds);

            //dataGridView1.DataSource = ds.Tables[0];

            //if (conn != null) { conn.Close(); conn = null; }
            DataSet ds = new DataSet();

            DataTable dt = new DataTable("Employeee");

            DataColumn col = new DataColumn("emp_no", Type.GetType("System.String"));
            dt.Columns.Add(col);

            dt.Columns.Add(new DataColumn("emp_name", Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("dept_no", Type.GetType("System.String")));

            dt.PrimaryKey = new DataColumn[] { dt.Columns["emp_no"] };

            DataRow row = dt.NewRow();
            row["emp_no"] = "1";
            row["emp_name"] = "sypark";
            row["dept_no"] = "100";
            dt.Rows.Add(row);

            row = dt.NewRow();
            row["emp_no"] = "2";
            row["emp_name"] = "milove";
            row["dept_no"] = "100";
            dt.Rows.Add(row);

            dt.AcceptChanges();

            ds.Tables.Add(dt);

            dt = new DataTable("Deptpartment");
            dt.Columns.Add(new DataColumn("dept_no", Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("dept_name", Type.GetType("System.String")));

            row = dt.NewRow();
            row["dept_no"] = "100";
            row["dept_name"] = "닷넷컨설팅사업부";
            dt.Rows.Add(row);

            dt.AcceptChanges();
            ds.Tables.Add(dt);

            ds.Relations.Add("R1", ds.Tables["Deptpartment"].Columns["dept_no"], ds.Tables["Employeee"].Columns["dept_no"]);


            DataRow[] rows = ds.Tables[0].Select("dept_no = '100'", "emp_name");
            DataView view = new DataView(ds.Tables[0], "emp_no = '1'", null, DataViewRowState.Unchanged);

            MessageBox.Show(rows.Length.ToString());


            dataGridView1.DataSource = view;





        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();

            DataTable dt = new DataTable("Table1");

            DataColumn col = new DataColumn("emp_no", Type.GetType("System.String"));
            dt.Columns.Add(col);

            dt.Columns.Add(new DataColumn("emp_name", Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("dept_no", Type.GetType("System.String")));

            DataRow row = dt.NewRow();
            row["emp_no"] = "1";
            row["emp_name"] = "sypark";
            row["dept_no"] = "100";
            dt.Rows.Add(row);

            row = dt.NewRow();
            row["emp_no"] = "2";
            row["emp_name"] = "milove";
            row["dept_no"] = "100";
            dt.Rows.Add(row);

            dt.AcceptChanges();

            ds.Merge(dt);

            dt = new DataTable("Table1");
            dt.Columns.Add(new DataColumn("dept_no", Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("dept_name", Type.GetType("System.String")));

            row = dt.NewRow();
            row["dept_no"] = "100";
            row["dept_name"] = "닷넷컨설팅사업부";
            dt.Rows.Add(row);

            dt.AcceptChanges();
            ds.Merge(dt);

            dt = new DataTable("Table1");
            dt.Columns.Add(new DataColumn("emp_no", Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("dept_no", Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("dept_name", Type.GetType("System.String")));

            row = dt.NewRow();
            row["emp_no"] = "3";
            row["dept_no"] = "200";
            row["dept_name"] = "연구소";
            dt.Rows.Add(row);

            dt.AcceptChanges();
            ds.Merge(dt);


            dataGridView1.DataSource = ds.Tables[0];

        }
    }
}