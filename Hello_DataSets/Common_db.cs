using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Hello_DataSets
{
    public class Common_db
    {
        // define string MyConnectionString
        string MyConnectionString = "";
        public string ConnString
        {
            get
            {
                return MyConnectionString;
            }
        }
        public Common_db(string connectionString = "Data Source=ASUS-VIVOBOOK-P\\SASHASQLSERVER;Initial Catalog=DataSetDB;Integrated Security=True")
        {
            MyConnectionString = connectionString;

        }
        public static SqlDataAdapter CreateCustomerAdapter(string dbcon)
        {
            SqlConnection connection = new SqlConnection(dbcon);
            SqlDataAdapter adapter = new SqlDataAdapter();

            // Create the SelectCommand.
            SqlCommand command = new SqlCommand("SELECT * FROM courses", connection);

            adapter.SelectCommand = command;

            // Create the InsertCommand.
            command = new SqlCommand(
                "INSERT INTO courses (course_id, course_name, type, facl_id, size, marks, quantity, begin_date, contract) " +
                "VALUES (@COURSE_ID, @COURSE_NAME, @TYPE, @FACL_ID, @SIZE, @MARKS, @QUANTITY, @BEGIN_DATE, @CONTRACT)", connection);

            // Add the parameters for the InsertCommand.
            command.Parameters.Add("@COURSE_ID", SqlDbType.Char, 3, "course_id");
            command.Parameters.Add("@COURSE_NAME", SqlDbType.VarChar, 40, "course_name");
            command.Parameters.Add("@TYPE", SqlDbType.VarChar, 20, "type");
            command.Parameters.Add("@FACL_ID", SqlDbType.Char, 3, "facl_id");
            command.Parameters.Add("@SIZE", SqlDbType.Int, 15, "size");
            command.Parameters.Add("@MARKS", SqlDbType.Decimal, 6, "marks");
            command.Parameters.Add("@QUANTITY", SqlDbType.Int, 15, "quantity");
            command.Parameters.Add("@BEGIN_DATE", SqlDbType.Date, 50, "begin_date");
            command.Parameters.Add("@CONTRACT", SqlDbType.SmallInt, 10, "contract");

            adapter.InsertCommand = command;

            // Create the UpdateCommand.
            command = new SqlCommand(
                "UPDATE courses SET course_id = @COURSE_ID, course_name = @COURSE_NAME, " +
                "type = @TYPE, facl_id = @FACL_ID, size = @SIZE, marks = @MARKS, quantity = @QUANTITY, " +
                "begin_date = @BEGIN_DATE, contract = @CONTRACT" +
                "WHERE course_id = @COURSE_ID", connection);

            // Add the parameters for the UpdateCommand.
            command.Parameters.Add("@COURSE_ID", SqlDbType.Char, 3, "course_id");
            command.Parameters.Add("@COURSE_NAME", SqlDbType.VarChar, 40, "course_name");
            command.Parameters.Add("@TYPE", SqlDbType.VarChar, 20, "type");
            command.Parameters.Add("@FACL_ID", SqlDbType.Char, 3, "facl_id");
            command.Parameters.Add("@SIZE", SqlDbType.Int, 15, "size");
            command.Parameters.Add("@MARKS", SqlDbType.Decimal, 6, "marks");
            command.Parameters.Add("@QUANTITY", SqlDbType.Int, 15, "quantity");
            command.Parameters.Add("@BEGIN_DATE", SqlDbType.Date, 50, "begin_date");
            command.Parameters.Add("@CONTRACT", SqlDbType.SmallInt, 10, "contract");

            SqlParameter parameter = command.Parameters.Add(
                "@COURSE_ID", SqlDbType.Int, 32, "course_id");
            parameter.SourceVersion = DataRowVersion.Original;

            adapter.UpdateCommand = command;

            // Create the DeleteCommand.
            command = new SqlCommand(
                "DELETE FROM courses WHERE course_id = '@COURSE_ID'", connection);

            // Add the parameters for the DeleteCommand.
            parameter = command.Parameters.Add(
                "@COURSE_ID", SqlDbType.Char, 3, "course_id");
            parameter.SourceVersion = DataRowVersion.Original;

            adapter.DeleteCommand = command;

            return adapter;
        }
        public bool MyTable_delete(DataTable user_table, string key_name, string key_value)
        {
            bool result = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(MyConnectionString))
                {
                    conn.Open();
                    string commandText = $"Select * from courses";
                    SqlCommand cmd = new SqlCommand(commandText, conn);
                    SqlDataAdapter adapter = CreateCustomerAdapter(MyConnectionString);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds, user_table.TableName);
                    char[] charArr = new char[40];
                    DataColumn dataColumn = new DataColumn(key_name, charArr.GetType());
                    dataColumn.DefaultValue = key_value.ToCharArray();
                    dataColumn.AllowDBNull = true;
                    var keys = new DataColumn[1];
                    keys[0] = dataColumn;
                    //user_table.Columns.Add(dataColumn);
                    //user_table.AcceptChanges();
                    DataRow row = user_table.NewRow();
                    char[] chars = new char[3];
                    string temp = "C15";

                    row["course_id"] = temp;//course_id does not belog to the table courses 
                    row[1] = "ADO.NET";
                    row[2] = "programming";
                    row[3] = "SC1";
                    row[4] = 400;
                    row[5] = 11.4;
                    row[6] = 34;
                    row[7] = DateTime.Now;
                    row[8] = 1;
                    //user_table.Rows.Add(row);
                    //user_table.AcceptChanges();
                    //row.SetAdded();

                    commandText = $"delete from courses where course_id =  'C13'";
                    SqlCommand command = conn.CreateCommand();
                    command.CommandText = commandText;
                    command.Connection = conn;
                    command.Parameters.AddWithValue("@COURSE_ID", "C13");
                    Console.WriteLine(command.ExecuteNonQuery());
                    result = true;
                    Console.ReadKey();
                    Console.WriteLine(adapter.Update(user_table));
                    return result = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n" + ex.Message + "\n" + ex.StackTrace);
                return result = false;
            }
        }
        // in try-catch block open connection, create adapter UpdateCommand  using connection CreateCommand method

        // Open connection

        // define UpdateCommand for adapter 
        // define its CommandText for string to delete row
        // execute query

        // exception message output

        // assign true for result

        // return result

        // exception message output
        // return false
        // implement Common_db constructor with string parameter for connection string

        // implement bool MyTable_delete(DataTable usr_table, string key, string key_value) method
        // with parameters fot DataTable , string key name, string key value to delete row

        // define bool result and initiate it with false
        // in try-catch block implement using block for work new SglConnection with connection string MyConnectionString

        // create SqlCommand object for SglConnection object
        // define its CommandText like sql query to select all from "usr_table.tablename" from database

        // create SqlDataAdapter object associated with SqlCommand object

        // populate usr_table by data from database

        // define usr_table primary key by new DataColumn[], initiate it by key value

        // accept changes for usr_table

        //define DataRow object as the usr_table row with key value which equals key_value

        // create string for sql query to delete this row in the database table

        // in try-catch block open connection, create adapter UpdateCommand  using connection CreateCommand method

        // Open connection

        // define UpdateCommand for adapter 
        // define its CommandText for string to delete row
        // execute query

        // exception message output

        // assign true for result

        // return result

        // exception message output
        // return false



        public bool MyTable_update(string user_table, string key, string key_value, string clmn, string clmn_value)
        {
            bool result = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(MyConnectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand($"select * from {user_table}", conn);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet, user_table);
                    DataTable dt = dataSet.Tables[user_table];
                    DataColumn dc = dt.Columns[key];
                    
                    //dataColumn.DefaultValue = key_value.ToCharArray();
                    
                    var keys = new DataColumn[1];
                    keys[0] = dc;
                    dt.PrimaryKey = keys;
                    dt.AcceptChanges();


                    DataRow dataRow = dt.NewRow();
                    dataRow[0] = key_value;
                    string query = $"UPDATE courses SET {dc.ColumnName} = {clmn_value} where {key} = '3'";
                    command = new SqlCommand(query, conn);

                    adapter.UpdateCommand = conn.CreateCommand();
                    adapter.UpdateCommand = command;
                    command.Connection = conn;

                    Console.WriteLine(adapter.UpdateCommand.ExecuteNonQuery());
                    return result = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("MyTable_update Message : " + ex.Message + "\nStack Trace : " + ex.StackTrace);
                return result = false;
            }

        }
        // implement bool MyTable_update(DataTable usr_table, string key, string key_value, string clmn, string clmn_value) method
        // with parameters fot DataTable , string key name, string key value, string clmn, string clmn_value to update row

        // define bool result and initiate it with false
        // in try-catch block implement using block for work new SglConnection with connection string MyConnectionString

        // create SqlCommand object for SglConnection object
        // define its CommandText like sql query to select all from "usr_table.tablename" from database

        // create SqlDataAdapter object associated with SqlCommand object

        // populate usr_table by data from database

        // define usr_table primary key by new DataColumn[], initiate it by key value

        // accept changes for usr_table

        //define DataRow object as the usr_table row with key value which equals key_value

        // create string for sql query to update this row in the database table

        // in try-catch block open connection, create adapter UpdateCommand  using connection CreateCommand method

        // Open connection
        // define UpdateCommand for adapter 
        // define its CommandText for string to update row
        // execute query

        // exception message output

        // assign true for result

        // return result

        // exception message output
        // return false
        // implement bool MyTable_insert_bldr(string usr_table, string key,  string[] clmn, string[] clmn_value) method
        // with parameters fot DataTable , string key name, string clmn, string clmn_value to insert row
        public bool MyTable_insert_bldr(string user_table, string key, string[] clmn, string[] clmn_value)
        {

            // define bool result and initiate it with false
            bool result = false;
            // in try-catch block implement using block for work new SglConnection with connection string MyConnectionString
            try
            {
                // create SqlCommand object for SglConnection object
                using (SqlConnection conn = new SqlConnection(MyConnectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand($"Select * from {user_table}", conn);
                    // define its CommandText like sql query to select all from "usr_table" from database
                    // create SqlDataAdapter object associated with SqlCommand object
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    // create new  SqlCommandBuilder  object associated with adapter
                    SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                    // create new DataSet
                    DataSet dataSet = new DataSet();
                    // fill it using usr_table
                    adapter.Fill(dataSet, user_table);
                    // define DataTable object  from DataSet with usr_table name ***********
                    DataTable dt = dataSet.Tables[user_table];

                    // define its primary key by new DataColumn[], initiate it by key value
                    dt.PrimaryKey = new DataColumn[] { dt.Columns[key] };
                    // accept changes for DataTable object
                    dt.AcceptChanges();
                    // create next key value using Next_key_gen method
                    string nextKey = Next_key_gen(dt, key);//
                    // declare DataRow object
                    DataRow dataRow;
                    //asiign DataTable object NewRow method result to it
                    dataRow = dt.NewRow();
                    // define it key value
                    dataRow[0] = nextKey;
                    // assign DataRow object column values in the for loop
                    for (int i = 0; i < dt.Columns.Count; i++)//Inderx out of bounds exception !!!
                    {
                        dataRow[clmn[i]] = clmn_value[i];
                    }
                    // add this row to the DataTable object
                    dt.Rows.Add(dataRow);
                    adapter.Update(dt);
                    // assign true for result
                    // return result
                    return result = true;
                }
            }
            catch (Exception ex)
            {
                // exception message output
                Console.WriteLine("MyTable_insert_bldr Message : " + ex.Message + "\nStack Trace : " + ex.StackTrace);
                // return false
                return result = false;
            }
        }




        public string Next_key_gen(DataTable dt, string key)
        {
            // implement string Next_key_gen(DataTable dt, string key ) method  to receive the next key value

            // create List<string> new object

            // in foreach loop for DataRow item in dt.Rows add key values to List

            // sort the List object

            // find the last key value

            //Console.WriteLine("Max key: {0} . Write next key value: \r\n", Last_key_value);
            // return Console.ReadLine();
            string max = dt.AsEnumerable().Select(x => x[key].ToString()).Max();
            Console.WriteLine("Max key: {0} . Write next key value: \n", max);
            Console.ReadLine();
            return max;
        }
        // implement bool MyTable_update_bldr(string usr_table, string key, string key_value, string clmn, string clmn_value) method
        // with parameters fot table name , string key name,  string key_value,string clmn, string clmn_value to update the table
        public bool MyTable_update_bldr(string user_table, string key_name, string key_value, string clmn_name, string clmn_value)
        {
            // define bool result and initiate it with false
            bool result = false;
            try
            {
                // in try-catch block implement using block for work new SglConnection with connection string MyConnectionString
                using (SqlConnection conn = new SqlConnection(MyConnectionString))
                {
                    conn.Open();
                    // create SqlCommand object for SglConnection object
                    // define its CommandText like sql query to select all from "usr_table" from database
                    SqlCommand command = new SqlCommand($"select * from {user_table}", conn);
                    // create SqlDataAdapter object associated with SqlCommand object
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    // Set up the CommandBuilder
                    SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);
                    // create new DataSet
                    DataSet dataSet = new DataSet();
                    // fill it using usr_table
                    adapter.Fill(dataSet, user_table);
                    // define DataTable object  from DataSet with usr_table name
                    DataTable dt = dataSet.Tables[user_table];
                    // define its primary key by new DataColumn[], initiate it by key value
                    dt.PrimaryKey = new DataColumn[] { dt.Columns[key_name] };
                    // accept changes for DataTable object
                    dt.AcceptChanges();
                    // create DataRow object and assign  DataTable object Rows.Find(key_value) result to it
                    DataRow row = dt.Rows.Find(key_value);
                    // assign to its clmn column clmn_value
                    row[clmn_name] = clmn_value;
                    // call adapter Update method to update usr_table
                    adapter.Update(dataSet, user_table);
                    // assign true for result
                    result = true;
                    // return result
                    return true;
                }
            }
            catch (Exception ex)
            {
                // exception message output
                Console.WriteLine("MyTable_update_bldr Message : " + ex.Message + "\nStack Trace : " + ex.StackTrace);
                //return false
                return result = false;
            }
        }

        // implement bool MyTable_update_ds(string usr_table, string key, string key_value, string clmn, string clmn_value) method
        // with parameters fot table name , string key name,  string key_value, string clmn, string clmn_value to update the table
        public bool MyTable_update_ds(string user_table, string key_name, string key_value, string clmn_name, string clmn_value)
        {
            //define bool result and initiate it with false
            bool result = false;
            // in try-catch block implement using block for work new SglConnection with connection string MyConnectionString
            try
            {
                using (SqlConnection conn = new SqlConnection(MyConnectionString))
                {
                    conn.Open();
                    // create SqlCommand object for SglConnection object
                    // define its CommandText like sql query to select all from "usr_table" from database
                    SqlCommand command = new SqlCommand($"select * from {user_table}", conn);
                    // create SqlDataAdapter object associated with SqlCommand object
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                    // create new DataSet
                    DataSet dataSet = new DataSet();
                    // fill it using usr_table
                    adapter.Fill(dataSet, user_table);
                    // define DataTable object  from DataSet with usr_table name
                    DataTable dt = dataSet.Tables[user_table];
                    // define its primary key by new DataColumn[], initiate it by key value
                    DataColumn[] primaryKeyColumns = new DataColumn[1];
                    primaryKeyColumns[0] = dt.Columns[key_name];

                    dt.PrimaryKey = primaryKeyColumns;
                    // accept changes for DataTable object
                    dt.AcceptChanges();
                    // create DataRow object and assign  DataTable object Rows.Find(key_value) result to it
                    DataRow row = dt.Rows.Find(key_value);
                    // assign to its clmn column clmn_value
                    row[clmn_name] = clmn_value;
                    // create string for sql query to update clmn column for clmn_value where key = key_value
                    string updateQuery = $"Update {user_table} set {clmn_name} = '{clmn_value}' where {key_name} = '{key_value}'";
                    // in try-catch block open connection, create adapter UpdateCommand  using connection CreateCommand method
                    // Open connection
                    adapter.UpdateCommand = new SqlCommand(updateQuery, conn);
                    // define UpdateCommand for adapter 
                    // define its CommandText for string to update row
                    // call adapter update method to update usr_table
                    adapter.Update(dataSet, user_table);
                    return result = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("MyTable_update_ds Message : " + ex.Message + "\nStack Trace : " + ex.StackTrace);
                return result = false;
            }




            // exception message output

            // assign true for result

            // return result

            // exception message output
            // return false
        }
























        //implement bool MyTable_read(DataTable usr_table) method to read from usr_table
        public bool MyTable_read(DataTable user_table)
        {
            bool result = false;
            try
            {
                // define bool result and initiate it with false
                // in try-catch block implement using block for work new SglConnection with connection string MyConnectionString

                // create SqlCommand object for SglConnection object
                // define its CommandText like sql query to select all from "usr_table" from database
                using (SqlConnection conn = new SqlConnection(MyConnectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand($"select * from {user_table.TableName}", conn);
                    // create SqlDataAdapter object associated with SqlCommand object
                    // fill  usr_table

                    // define DataTable object  from DataSet with usr_table name
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(user_table);
                }

                // assign true for result

                // return result

                
                return result = true; 
            }
            catch (Exception ex)
            {
                Console.WriteLine("MyTable_read Message : " + ex.Message + "\nStack Trace : " + ex.StackTrace);
                return result = false;
                // exception message output
                // return false
            }
        }
        
        // implement MyConnect() method to open and check the connection
        public bool MyConnect()
        {
            // define bool result and initiate it with false
            // in try-catch block implement using block for work new SglConnection with connection string MyConnectionString
            bool result = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(MyConnectionString))
                {
                    // Open connection
                    conn.Open();
                    // assign true for result
                    return result = true;
                    // return result

                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("MyConnect Message : " + ex.Message + "\nStack Trace : " + ex.StackTrace);
                return result = false;
                // exception message output
                // return false
            }
        }

        // implement MyConnect() method to close and check the connection
        public bool MyDisConnect()
        {
            bool result = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(MyConnectionString))
                {

                    // define bool result and initiate it with false
                    // in try-catch block implement using block for work new SglConnection with connection string MyConnectionString

                    // close connection
                    // assign true for result

                    // return result
                    conn.Close();
                    return result = false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("MyConnect Message : " + ex.Message + "\nStack Trace : " + ex.StackTrace);
                return result = false;
                // exception message output
                // return false
            }
            
        }


    }
}