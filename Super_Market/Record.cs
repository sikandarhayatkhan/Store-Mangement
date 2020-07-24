using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;
using System.Collections;
using System.Data;

namespace Super_Market
{
   public class Record
    {
        
        Product p = new Product();
        SqlConnection conn;
        public Record()
        {
           
            try
            {
                conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\sikandar\Downloads\Super_Market\Super.mdf;Integrated Security=True");
                conn.Open();
            }
            catch (Exception ex)
            {
                 Console.WriteLine(ex.Message);
            }
        }

        public void add()
        {
            Console.Clear();
            string date = DateTime.UtcNow.ToShortDateString();
            //Console.WriteLine(date);
            Console.WriteLine("\n\t\t ***** Add Menu *****");
            Console.WriteLine(" \nEnter the id  :");
            p.Id = int.Parse(Console.ReadLine());
            Console.WriteLine("\nEnter the Name : ");
            p.Name = Console.ReadLine();
            Console.WriteLine("\n Enter the Product Quantity : ");
            p.Sold = int.Parse(Console.ReadLine());

            try
            {
                string command = "insert into Super(Id,Name,EntryTime,Quantity)Values('" + p.Id + "','" + p.Name + "','" + date + "','" + p.Sold + "')";
                SqlCommand cmd = new SqlCommand(command, conn);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Record Saved successfully");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void del()
        {
            Console.Clear();
            Console.WriteLine("\n\t\t ***** Delete Menu *****");
            Console.WriteLine("\nEnter id to delete the record");
            p.Id = int.Parse(Console.ReadLine());
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("select Id from Super where id = '" + p.id + "'", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if(dt.Rows.Count>0)
                {

                    string command = "delete from Super where  id ='" + p.Id + "'";
                    SqlCommand cmd = new SqlCommand(command, conn);
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Record Deleted  successfully");
                }
                else
                {
                    Console.WriteLine("Id does not exist");

                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
           
        }
        public void modifyN()
        {
            Console.Clear();
            Console.WriteLine("\n\t\t Modify Name using Id");
            Console.WriteLine("\nEnter Id whose name you want to update");
            p.Id = int.Parse(Console.ReadLine());
            SqlDataAdapter da = new SqlDataAdapter("select Id from Super where id = '" + p.id + "'", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Console.WriteLine("\nEnter New Name");
                p.Name = Console.ReadLine();
                try
                {

                    string command = "update Super set Name= '" + p.Name + "'" + " where Id='" + p.Id + "'";
                    ;
                    SqlCommand cmd = new SqlCommand(command, conn);
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Record Updated successfully");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Id does not exist");

            }

        }
        public void modifyI()
        {
            Console.Clear();
            Console.WriteLine("\n\t\t Modify Quantity using Id");
            Console.WriteLine("\nEnter Id whose quantity you want to update");
            p.Id = int.Parse(Console.ReadLine());
            SqlDataAdapter da = new SqlDataAdapter("select Id from Super where id = '" + p.id + "'", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Console.WriteLine("\nEnter New Quantity");
                p.Sold = int.Parse(Console.ReadLine());
                try
                {

                    string command = "update Super set Quantity= '" + p.Sold + "'" + " where Id='" + p.Id + "'";
                    SqlCommand cmd = new SqlCommand(command, conn);
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Record Updated successfully");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Id does not exist");

            }


        }
        public void modify()
        {
            string ok ;
            Console.WriteLine("You want to modify Name or Quantity");
            ok = Console.ReadLine();
            switch(ok)
            {
                case "Name":
                case "name":
                    modifyN();
                    break;
                case "Quantity":
                case "quantity":
                case "Q":
                case "q":
                    modifyI();
                    break;
                default:
                    Console.WriteLine("Invalid Choce...!");
                    break;          
            }
               
        }
        public void show()
        {
            Console.Clear();
            Console.WriteLine("\t\t ***** Database View *****\n");
            try
            {
                string command = "select * from Super";
                SqlCommand com = new SqlCommand(command, conn);
                SqlDataReader dr = com.ExecuteReader();
               
                while (dr.Read())
                {
                    Console.WriteLine( "\n Id number :  " + dr["Id"].ToString() + " \t");
                    Console.WriteLine(" Person Name : " + dr["Name"].ToString() + " \t");
                    Console.WriteLine(" Entry Time :  "+ dr["EntryTime"].ToString() + " \t");
                    Console.WriteLine(" Product Quantity : " + dr["Quantity"].ToString() + "\t");
                    Console.WriteLine(" Availabe\n");
                }
                dr.Close();
                
            }
            catch (Exception ex)
            {
               Console.WriteLine(ex.Message);
            }
        }
         public void search()
        {
            Console.Clear();
            Console.WriteLine("\t\tSearch  \n");
            Console.WriteLine("Enter Id to search ");
            p.Id = int.Parse(Console.ReadLine());
            SqlDataAdapter da = new SqlDataAdapter("select Id from Super where id = '" + p.id + "'", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                try
                {
                    string command = "select * from Super where id = '" + p.Id + "'";
                    SqlCommand com = new SqlCommand(command, conn);
                    SqlDataReader dr = com.ExecuteReader();

                    while (dr.Read())
                    {
                        Console.WriteLine("\n Id number :  " + dr["Id"].ToString() + " \t");
                        Console.WriteLine(" Person Name : " + dr["Name"].ToString() + " \t");
                        Console.WriteLine(" Entry Time :  " + dr["EntryTime"].ToString() + " \t");
                        Console.WriteLine(" Product Quantity : " + dr["Quantity"].ToString() + "\t");
                        Console.WriteLine(" Availabe\n");
                    }
                    dr.Close();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Not exist");
            }
        }
    } // end of class
   
    
}// end of namespace 
