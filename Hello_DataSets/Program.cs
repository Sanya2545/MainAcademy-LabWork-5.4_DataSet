using System;
using System.Data;
using System.Data.SqlClient;

namespace Hello_DataSets
{
    class Program
    {

        static void Main(string[] args)
        {
            // update connection string for current LocalDB instance 
            Common_db common_Db = new Common_db();
            DataTable dataTableUser = new DataTable("courses");
            string query = "select * from courses";
            using (SqlConnection conn = new SqlConnection(common_Db.ConnString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                // create data adapter
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                Console.WriteLine(dataTableUser.TableName);

                // this will query your database and return the result to your datatable
                da.Fill(dataTableUser);
                
                common_Db.MyTable_delete(dataTableUser, "something", "Mathematics");
                common_Db.MyTable_update(dataTableUser, "course_id", "5", "course_id", "5");
            }
            
            //    DB_work mywrk = new DB_work(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\tect_datasets_db.mdf;Integrated Security=True;Connect Timeout=30");
            //    mywrk.DB_conn();
            //    Console.WriteLine("Reading courses table");
            //    mywrk.Courses_Read("courses");
            //    Console.WriteLine();

            //    Console.WriteLine("Update courses table");
            //    mywrk.Courses_Update("courses", "course_id", "C13", "begin_date", "2014-01-06");

            //    Console.WriteLine("Reading courses table");
            //    mywrk.Courses_Read("courses");
            //    Console.WriteLine();

            //    Console.WriteLine("Update courses table by DataSet");
            //    mywrk.Courses_Update_ds("courses", "course_id", "C13", "begin_date", "2013-01-01");

            //    Console.WriteLine("Reading courses table");
            //    mywrk.Courses_Read("courses");
            //    Console.WriteLine();

            //    Console.WriteLine("Update courses table by Builder");
            //    mywrk.Courses_Update_bldr("courses", "course_id", "C13", "begin_date", "2012-01-01");

            //    Console.WriteLine("Reading courses table");
            //    mywrk.Courses_Read("courses");
            //    Console.WriteLine();

            //    Console.WriteLine("Insert  to courses table by Builder");
            //    string[] clmns = new string[] { "course_name", "contract", "facl_id" };
            //    string[] clmn_values = new string[] { "biology", "0", "" };
            //    mywrk.Courses_Insert_bldr("courses", "course_id", clmns, clmn_values);

            //    Console.WriteLine("Reading courses table");
            //    mywrk.Courses_Read("courses");
            //    Console.WriteLine();

            //    Console.WriteLine("Delete from courses table");

            //    Console.WriteLine("Write  key to delete: \r\n");
            //    string del_key = Console.ReadLine();
            //    mywrk.Courses_Delete("courses", "course_id", del_key);

            //    Console.WriteLine("Reading courses table");
            //    mywrk.Courses_Read("courses");

            //    Console.ReadKey();
            //}



        }
    }
}
