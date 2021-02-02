using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ConnectionArch
{
    class Parameter
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
        public int InsertWithParameters()
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
                cmd = new SqlCommand("insert into emptablee values(@empname,@salary,@deptno)", cn);
                cmd.Parameters.Add("@empname", SqlDbType.VarChar, 20).Value = empname;
                cmd.Parameters.Add("@salary", SqlDbType.Float).Value = salary;
                cmd.Parameters.Add("@deptno", SqlDbType.Int).Value = deptno;
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                ShowData();
                return i;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 1;
            }
            finally
            {
                cn.Close();
            }

        }
        public int DeleteWithParameters()
        {
            try
            {
                Console.WriteLine("Enter empid");
                var empid = Console.ReadLine();

                cn = new SqlConnection("Data Source=YASWANTH;Initial Catalog=WFA3DotNet;Integrated Security=True");
                cmd = new SqlCommand("Delete from emptablee  where(empid=@empid)", cn);
                cmd.Parameters.Add("@empid", SqlDbType.Int).Value = empid;
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                ShowData();
                return i;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 1;
            }
            finally
            {
                cn.Close();
            }

        }
        public int UpdateWithParameters()
        {
            try
            {
                Console.WriteLine("Enter empid");
                var empid = Console.ReadLine();
                Console.WriteLine("Enter salary");
                var salary = Convert.ToSingle(Console.ReadLine());
                cn = new SqlConnection("Data Source=YASWANTH;Initial Catalog=WFA3DotNet;Integrated Security=True");
                cmd = new SqlCommand("update emptablee set salary=@salary where(empid=@empid)", cn);
                cmd.Parameters.Add("@empid", SqlDbType.Int).Value = empid;
                cmd.Parameters.Add("@salary", SqlDbType.Float).Value = salary;

                cn.Open();
                int i = cmd.ExecuteNonQuery();
                ShowData();
                return i;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 1;
            }
            finally
            {
                cn.Close();
            }

        }
        public int SearchWithParameters()
        {
            try
            {
                Console.WriteLine("Enter empid");
                var empid = Console.ReadLine();

                cn = new SqlConnection("Data Source=YASWANTH;Initial Catalog=WFA3DotNet;Integrated Security=True");
                cmd = new SqlCommand("select * from emptablee  where(empid=@empid)", cn);
                cmd.Parameters.Add("@empid", SqlDbType.Int).Value = empid;
                cn.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Console.WriteLine($" empname: {dr["empname"]}\n deptno : {dr["deptno"]}\nsalary : {dr["salary"]}");
                }

                return 1;

            }
            catch (Exception ex)
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
    class WithParameters
    {
        static void Main()
        {
            Parameter p = new Parameter();
            bool w = true;
            while(w)
            {
                Console.WriteLine("\n1.Insert\n2.update\n3.delete\n4.Search\n5.Exit");
                int ch = Convert.ToInt32(Console.ReadLine());
                switch(ch)
                {
                    case 1:
                        p.InsertWithParameters();
                        break;
                    case 2:
                        p.DeleteWithParameters();
                        break;
                    case 3:
                        p.UpdateWithParameters();
                        break;
                    case 4:
                        p.SearchWithParameters();
                        break;
                    default:
                        break;
                }
            }
                
            
        }
    }
}
