using System.Data.SqlClient;
using System;


namespace ADOHandsOn
{
    class Program
    {
        static void Main(string[] args)
        {
            //new Program().CreateTable();
            //new Program().InsertTable();
            //new Program().Viewdata();

            Console.ReadKey();
        }
        public  void CreateTable()
        {
            SqlConnection con = null;
            try
            {
                ////Creating Connection
                con = new SqlConnection("data source=.\\SQLEXPRESS; database=Student; integrated security=SSPI");
                //writing  sql Query
                SqlCommand cm = new SqlCommand
                    ("Create table StudentTbl(id int not null,name varchar(250),email varchar(250),join_date date)", con);
                con.Open();
                cm.ExecuteNonQuery();
                Console.WriteLine("Table created Successfully");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message); 
            }
            finally
            {
            con.Close();
            }
         
        }
        public void InsertTable()
        {
            SqlConnection con = null;
            try{
                con = new SqlConnection("data source=.\\SQLEXPRESS; database=Student; integrated security=SSPI");
                SqlCommand cm = new SqlCommand
                    ("insert into StudentTbl" +
                    "(id,name,email,join_date) values(1,'Rishit','rk@gmail.com','2001-07-07'),(2,'Hardi'    ,'hg@gmail.com','2000-07-07'),(3,'Hemangi','hn@gmail.com','2000-07-07')",con);
                con.Open();
                cm.ExecuteNonQuery();
                Console.WriteLine("Values enterd ");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                con.Close();
            }
        }
        public void Viewdata()
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection("data source=.\\SQLEXPRESS; database=Student; integrated security=SSPI");
                SqlCommand cm = new SqlCommand
                    ("Select * from StudentTbl", con);
                con.Open();
                SqlDataReader sdr = cm.ExecuteReader();
                while (sdr.Read())
                {
                    Console.WriteLine(sdr["id"]+" "+sdr["name"]+" " + sdr["email"]+ " " + sdr["join_date"]);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                con.Close();
            }
        }
    } 
}
