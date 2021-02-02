using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ConnectionArch
{
    class WithoutParameters
    {
        SqlConnection cn = null;
        SqlCommand cmd = null;
        SqlDataReader dr = null;
        public int ShowData()
        {
            try
            {

                Console.WriteLine("Data from the table after DML Command");
                cn = new SqlConnection("Data Source=YASWANTH;Initial Catalog=WFA3DotNet;Integrated Security=True");
                cmd = new SqlCommand("Select * from Emptablee", cn);
                cn.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Console.WriteLine($"{dr["empid"]}\t{dr["empname"]}\t{dr["Salary"]}\t{dr["deptno"]}");
                }
                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                return 1;
            }
            finally
            {
                cn.Close();
            }
        }
        public int InsertOneRow()
        {
            try
            {
                Console.WriteLine("Enter empname");
                var empname = Console.ReadLine();
                Console.WriteLine("Enter salary");
                var salary = Convert.ToSingle(Console.ReadLine());
                Console.WriteLine("Enter deptno");
                var deptno = Convert.ToInt32(Console.ReadLine());
                cn = new SqlConnection("Data Source=YASWANTH;Initial Catalog=WFA3DotNet;Integrated Security=True");
                cmd = new SqlCommand("Insert into emptablee values('" + empname + "'," + salary + "," + deptno + ")", cn);
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                Console.WriteLine("One row added to the table");
                ShowData();
                return i;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                return 1;
            }
            finally
            {
                cn.Close();
            }
        }
        public int DeleteOneRow()
        {
            try
            {
                Console.WriteLine("Enter employee id");
                int eid = Convert.ToInt32(Console.ReadLine());
                cn = new SqlConnection("Data Source=YASWANTH;Initial Catalog=WFA3DotNet;Integrated Security=True");
                cmd = new SqlCommand("Delete from emptablee  where empid=" +eid + "", cn);
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                Console.WriteLine("One row deleted");
                ShowData();
                return i;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                return 1;
            }
            finally
            {
                cn.Close();
            }
        }
        public int UpdateOneRow()
        {
            try
            {

                Console.WriteLine("Enter eid");
                int empid = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter deptno");
                int deptno = Convert.ToInt32(Console.ReadLine());
                cn = new SqlConnection("Data Source=YASWANTH;Initial Catalog=WFA3DotNet;Integrated Security=True");
                cmd = new SqlCommand("update emptablee set deptno=" + deptno + "where empid=" + empid + "", cn);
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                Console.WriteLine("One row updated to the table");
                ShowData();
                return i;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                return 1;
            }
            finally
            {
                cn.Close();
            }
        }
        public int SearchOneRow()
        {
            try
            {
                Console.WriteLine("Enter empname : ");
                var empname = Console.ReadLine();

                cn = new SqlConnection("Data Source=YASWANTH;Initial Catalog=WFA3DotNet;Integrated Security=True");
                cmd = new SqlCommand("Select * from Emptablee where empname='" + empname + "'", cn);
                cn.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Console.WriteLine($" empid: {dr["empid"]}\n deptno : {dr["deptno"]}\nsalary : {dr["salary"]}");
                }
                return 0;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                return 1;
            }
            finally
            {
                cn.Close();
            }
        }
        

    }
    class Program
    {
        static void Main(string[] args)
        {
            WithoutParameters wp = new WithoutParameters();
            bool w = true;
            while(w)
            {
                Console.WriteLine("\n1.Insert\n2.delete\n3.update\n4.Search\n5.Exit");
            
               int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        wp.InsertOneRow();
                        break;
                    case 2:
                        wp.DeleteOneRow();
                        break;
                    case 3:
                        wp.UpdateOneRow();
                        break;
                    case 4:
                        wp.SearchOneRow();
                        break;
                    default:
                        break;
                }        
            }

        }
    }
}
