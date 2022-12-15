﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_MS
{
    internal class Functions
    {
        private SqlConnection Con;
        private SqlCommand Cmd;
        private DataTable dt;
        private SqlDataAdapter sda;
        private string ConStr;

        //DB connection
        public Functions()
        {
            ConStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ethan\OneDrive\Documents\EmpDb.mdf;Integrated Security=True;Connect Timeout=30";
            Con = new SqlConnection(ConStr);
            Cmd = new SqlCommand();
            Cmd.Connection = Con;
        }

        public DataTable GetData(string Query)
        {
            dt = new DataTable();
            sda = new SqlDataAdapter(Query, Con);
            sda.Fill(dt);
            return dt;
        }

        public int SetData(string Query)
        {
            int Cnt = 0;
            if(Con.State == ConnectionState.Closed)
            {
                Con.Open();
            }
            Console.WriteLine(Query);
            Cmd.CommandText = Query;
            Cnt = Cmd.ExecuteNonQuery();
            Con.Close();
            return Cnt;
        }
    }
}
