using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Hello_DataSets
{
    class DB_work
    {
        // declare    Common_db MyDBtest   
        Common_db MyDBTest;
        // implement DB_work(string conn) constructor to initiate MyDBtest
        public DB_work(string conn)
        {
            MyDBTest = new Common_db(conn);
        }
        // implement  void DB_conn() to check the MyDBtest 
        public void DB_conn()
        {
            if (MyDBTest.MyConnect())
            {
                Console.WriteLine("Connected successfully !");
            }
            else 
            {
                Console.WriteLine("Connection is wrong !!!");
            }
        }
        public void DB_Disconn()
        {
            if(MyDBTest.MyDisConnect())
            {
                Console.WriteLine("Disconnected successfully !");
            }
            else
            {
                Console.WriteLine("Disconnection is wrong !!!");
            }
        }
        // implement void Courses_Update_ds(string table_name, string key, string key_value, string clmn, string clmn_value)
        // to update table_name using MyDBtest.MyTable_update_ds method with parameters in try-catch block
       public void Courses_Update_ds(string table_name, string key_name, string key_value, string clmn_name, string clmn_value)
        {
            MyDBTest.MyTable_update_ds(table_name, key_name, key_value, clmn_name, clmn_value);
        }


        // implement void Courses_Insert_bldr(string table_name, string key,  string [] clmn, string[] clmn_value)
        // to insert into table_name using MyDBtest.MyTable_insert_bldr method with parameters in try-catch block
        public void Courses_Insert_bldr(string table_name, string key_name, string[] clmns, string[] clmn_values)
        {
            try
            {
                   MyDBTest.MyTable_insert_bldr(table_name, key_name, clmns , clmn_values);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Outter Courses_Insert_bldr exception Message : " + ex.Message);
            }
        }
 


        // implement void Courses_Update_bldr(string table_name, string key, string key_value, string clmn, string clmn_value)
        // to update table_name using MyDBtest.MyTable_update_bldr method with parameters in try-catch block
        public void Courses_Update_bldr(string table_name, string key_name, string key_value, string clmn_name, string clmn_value)
        {
            try
            {
                MyDBTest.MyTable_update_bldr(table_name, key_name, key_value, clmn_name, clmn_value);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Outter Courses_Update_bldr exception Message : " + ex.Message);
            }
        }


        // implement void Courses_Update(string table_name, string key, string key_value, string clmn, string clmn_value)
        // to update table_name using MyDBtest.MyTable_update method with parameters in try-catch block
        public void Courses_Update(string table_name, string key_name, string key_value, string clmn_name, string clmn_value)
        {
            MyDBTest.MyTable_update(table_name, key_name, key_value, clmn_name, clmn_value);
        }
        // implement void Courses_Read(string table_name) method
        // to read table_name using MyDBtest.MyTable_read method with parameters in try-catch block
        public void Courses_Read(string table_name)
        {

            //create new DataTable object and define its TableName property

            //call MyDBtest.MyTable_read with parameter
            //foreach DataRow item  write its value to the console
            try
            {
                DataTable dt = new DataTable();
                dt.TableName = table_name;
                MyDBTest.MyTable_read(dt);
                foreach (DataRow item in dt.Rows)
                {
                    Console.WriteLine(item);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Outter Courses_Read exception Message : " + ex.Message);
            }

        }
        




        // implement Courses_Delete(string table_name, string key, string key_value) method
        // to delete row from the table_name using MyDBtest.MyTable_delete method with parameters in try-catch block

                //create new DataTable object and define its TableName property

                //call MyDBtest.MyTable_delete with parameters
        public void Courses_Delete(string table_name, string key_name, string key_value)
        {
            try
            {
                DataTable dt = new DataTable();
                dt.TableName = table_name;
                MyDBTest.MyTable_delete(dt, key_name, key_value);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Outter Courses_Delete exception Message : " + ex.Message);
            }
            
        }

    }
}
