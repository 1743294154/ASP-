﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string constr = "Provider=SQLOLEDB;data source=3b414-18; initial catalog=student;User ID=sa;Password=1111";
            OleDbConnection scon = new OleDbConnection(constr);

            OleDbCommand scom = new OleDbCommand();
            scom.CommandText = "SELECT * FROM 管理员 WHERE rtrim(用户名)='" + textBox1.Text + "'";
            scom.CommandType = CommandType.Text;
            scom.Connection = scon;
            OleDbDataAdapter sdp = new OleDbDataAdapter();
            DataSet ds = new DataSet();
            sdp.SelectCommand = scom;
            if (scon.State != ConnectionState.Open)
            {
                scon.Open();
            }
            scom.ExecuteNonQuery();
            if (scon.State != ConnectionState.Closed)
            { scon.Close(); }
            sdp.Fill(ds);
            if (ds.Tables[0].Rows.Count == 0)
            {
                label4.Text = "输入用户名或密码有误，请重试";
                return;
            }
            if (ds.Tables[0].Rows[0]["密码"].ToString() == textBox2.Text)
                label4.Text = "登录成功";
            else
            {
                label4.Text = "输入用户名或密码有误，请重试";
                return;
            }



        }
    }
}
