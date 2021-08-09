using System;
using System.Data.SqlClient;

namespace adonet1
{
    class Program
    {
         static SqlConnection con = null;
        static void createTable()
        {
           
            try
            {
                con = new SqlConnection("data source=.; database=school; integrated security=SSPI");

                SqlCommand cm = new SqlCommand("create table Worker(Worker_Id int not null,First_Name varchar(50),  Last_Name varchar(20) ,Salary int , Joining_Date varchar(12) , Department varchar(10))", con);
                
                con.Open();

                cm.ExecuteNonQuery();

                Console.WriteLine("Table created Successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine("OOPs, something went wrong." + e);
            }

            finally
            {
                con.Close();
            }
        }

        static void insertNewWorker(int WorkerId , string  First_Name , string Last_Name , int Salary , string Joining_Date, string  Departmen)
        {
            try
            {
                con = new SqlConnection("data source=.; database=school; integrated security=SSPI");

                SqlCommand cm = new SqlCommand("insert into Worker values(" + "'" + WorkerId + "'" + ", " + "'" + First_Name + "'"  + " , " + "'" + Last_Name + "'" + ", " + "'" +  Salary + "'" + " , " + "'" + Joining_Date + "'" + " , " + "'" + Departmen + "'" + ")", con);
                con.Open();

                cm.ExecuteNonQuery();

                Console.WriteLine("Insert Successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine("OOPs, something went wrong." + e);
            }

            finally
            {
                con.Close();
            }
        }

        static void DisplayResult()
        {

           /* try
            {
                  
                con = new SqlConnection("data source=.; database=school; integrated security=SSPI");
                SqlCommand cm = new SqlCommand("Select DISTINCT Department from Worker", con);
                con.Open();
             
                SqlDataReader sdr = cm.ExecuteReader();
                Console.WriteLine("\n Departments \n");
                while (sdr.Read())
                {
                    // Console.WriteLine(sdr["Worker_Id"] + " " + sdr["First_Name"] + " " + sdr["Salary"]  +" "+ sdr["Department"]);

                    Console.WriteLine(sdr["Department"]);
                }
               // sdr.Close();

               
            }
            catch (Exception e)
            {
                Console.WriteLine("OOPs, something went wrong.\n" + e);
            }
           */
            try
            {
                Console.WriteLine("\nfirst three characters of FIRST_NAME\n");
                SqlCommand cm = new SqlCommand("Select LEN(First_Name) as firstname from Worker", con);
                con.Open();
                SqlDataReader sdr1 = cm.ExecuteReader();

                while (sdr1.Read())
                {
                    Console.WriteLine(sdr1["firstname"]);
                }
                sdr1.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);            }

        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //createTable();
            //insertNewWorker(101, "vijay", "Kumar", 332000, "11-11-2021", "cse");

            //insertNewWorker(102, "mani", "Kumar", 32000, "11-01-2024", "ece");
            //insertNewWorker(103, "karthik", "Kumar", 32000, "21-11-2022", "mech");
            //insertNewWorker(104, "ravi", "Kumar", 33000, "11-11-2021", "cse");

            //DisplayResult();
        }
    }
}
