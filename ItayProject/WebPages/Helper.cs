using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using ItayProject.WebPages;

public static class Helper
{
    public const string DBName = "Database.mdf";   //Name of the MSSQL Database.
    public const string tblName = "Users";      // Name of the user Table in the Database
    public const string conString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\IMOE001\source\repos\ItayProject\ItayProject\App_Data\Database.mdf;Integrated Security=True"
                                    + DBName + "; Integrated Security=True";   // The Data Base is in the App_Data = |DataDirectory|

    public static DataSet RetrieveTable(string SQLStr)
    // Gets A table from the data base acording to the SELECT Command in SQLStr;
    // Returns DataSet with the Table.
    {
        // connect to DataBase
        SqlConnection con = new SqlConnection(conString);

        // Build SQL Query
        SqlCommand cmd = new SqlCommand(SQLStr, con);

        // Build DataAdapter
        SqlDataAdapter ad = new SqlDataAdapter(cmd);

        // Build DataSet to store the data
        DataSet ds = new DataSet();

        // Get Data form DataBase into the DataSet
        ad.Fill(ds, tblName);

        return ds;
    }

    internal static bool CheckLogin(string userName, string password)
    {
        SqlConnection con = new SqlConnection(conString);
        con.Open();

        using (SqlCommand StrQuer = new SqlCommand("SELECT * FROM tblUsers WHERE userName=@userid AND password=@password", con))
        {
            StrQuer.Parameters.AddWithValue("@userid", userName);
            StrQuer.Parameters.AddWithValue("@password", password);
            SqlDataReader dr = StrQuer.ExecuteReader();
            if (dr.HasRows)
            {
                con.Close();
                return true;
            }
            con.Close();
            return false;
        }
    }


    internal static User GetUser(string userName, string password)
    {

        SqlConnection con;
        SqlDataAdapter adapter;
        DataSet ds = new DataSet();
        //create connection object
        con = new SqlConnection(conString);
        try
        {
            //create query string(SELECT QUERY)
            String query =
                 @"SELECT *
    FROM tblUsers 
    WHERE userName = '" + userName +"'";
            con.Open();
            //Adapter bind to query and connection object
            adapter = new SqlDataAdapter(query, con);
            //fill the dataset
            adapter.Fill(ds);
        }
        catch (Exception ex)
        {
            con.Close();
        }
        User user = new User();
        var curRow = ds.Tables[0].Rows[0];
        user.Admin = Convert.ToBoolean(curRow["admin"]);
        return user;
    }
    public static object GetScalar(string SQL)
    {
        // התחברות למסד הנתונים
        SqlConnection con = new SqlConnection(conString);

        // בניית פקודת SQL
        SqlCommand cmd = new SqlCommand(SQL, con);

        // ביצוע השאילתא
        con.Open();
        object scalar = cmd.ExecuteScalar();
        con.Close();

        return scalar;
    }

    public static int ExecuteNonQuery(string SQL)
    {
        // התחברות למסד הנתונים
        SqlConnection con = new SqlConnection(conString);

        // בניית פקודת SQL
        SqlCommand cmd = new SqlCommand(SQL, con);

        // ביצוע השאילתא
        con.Open();
        int n = cmd.ExecuteNonQuery();
        con.Close();

        // return the number of rows affected
        return n;
    }

    public static void Delete(int[] userIdToDelete)
    // The Array "userIdToDelete" contain the id of the users to delete. 
    // Delets all the users in the array "userIdToDelete".
    {
        // התחברות למסד הנתונים
        SqlConnection con = new SqlConnection(conString);

        // טעינת הנתונים
        string SQL = "SELECT * FROM " + tblName;
        SqlCommand cmd = new SqlCommand(SQL, con);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        adapter.Fill(ds, tblName);

        // מחיקת שורות שנבחרו מתוך הדאטה סט
        for (int i = 0; i < userIdToDelete.Length; i++)
        {
            {
                DataRow[] dr = ds.Tables[tblName].Select($"Userid = {userIdToDelete[i]}");
                dr[0].Delete();
            }
        }

        // עדכון הדאטה סט בבסיס הנתונים
        SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
        adapter.UpdateCommand = builder.GetDeleteCommand();
        adapter.Update(ds, tblName);
    }

    public static void Update(User user)
    // The Method recieve a user objects. Find the user in the DataBase acording to his userId and update all the other properties in DB.
    {
        // HttpRequest Request
        // התחברות למסד הנתונים
        SqlConnection con = new SqlConnection(conString);

        // בניית פקודת SQL
        string SQLStr = "SELECT * FROM " + Helper.tblName + $" Where Userid={user.UserId}";
        SqlCommand cmd = new SqlCommand(SQLStr, con);

        //  טעינת הנתונים לתוך DataSet
        DataSet ds = new DataSet();
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        adapter.Fill(ds, tblName);

        // בניית השורה להוספה
        DataRow dr = ds.Tables[tblName].Rows[0];
        dr["fName"] = user.FirstName;
        dr["lName"] = user.LastName;
        dr["uName"] = user.UserName;
        dr["pass"] = user.Password;
        dr["phone"] = user.Phone;

        // עדכון הדאטה סט בבסיס הנתונים
        SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
        adapter.UpdateCommand = builder.GetUpdateCommand();
        adapter.Update(ds, tblName);

    }

    public static void Insert(User user)
    // The Method recieve a user objects and insert it to the Database as new row. 
    // The Method does't check if the user is already taken.
    {
        //HttpRequest Request
        // התחברות למסד הנתונים
        //string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\gilad\source\repos\DBWeb\DBWeb\App_Data\Database.mdf;Integrated Security=True";
        SqlConnection con = new SqlConnection(conString);

        // בניית פקודת SQL
        string SQLStr = $"SELECT * FROM " + "tblUsers" + " WHERE 0=1";
        SqlCommand cmd = new SqlCommand(SQLStr, con);

        // בניית DataSet
        DataSet ds = new DataSet();

        // טעינת סכימת הנתונים
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        adapter.Fill(ds, "tblUsers");

        // בניית השורה להוספה
        DataRow dr = ds.Tables["tblUsers"].NewRow();
        dr["firstName"] = user.FirstName;
        dr["lastName"] = user.LastName;
        dr["userName"] = user.UserName;
        dr["password"] = user.Password;
        dr["email"] = user.Email;
        dr["phone"] = user.Phone;
        dr["admin"] = user.Admin;
        ds.Tables["tblUsers"].Rows.Add(dr);

        // עדכון הדאטה סט בבסיס הנתונים
        SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
        adapter.UpdateCommand = builder.GetInsertCommand();
        adapter.Update(ds, "tblUsers");
    }

    public static User GetRow(string userName, string password)
    // The Method check if there is a user with userName and Password. 
    // If true the Method return a user with the first Name and Admin property.
    // If not the Method return a user with first name "Visitor" and Admin = false

    {
        // התחברות למסד הנתונים
        SqlConnection con = new SqlConnection(conString);

        // בניית פקודת SQL
        string SQL = $"SELECT fName, admin FROM " + tblName +
                $" WHERE uName='{userName}' AND pass = '{password}'";
        SqlCommand cmd = new SqlCommand(SQL, con);

        // ביצוע השאילתא
        con.Open();
        SqlDataReader reader = cmd.ExecuteReader();

        // שימוש בנתונים שהתקבלו
        User user = new User();
        if (reader.HasRows)
        {
            reader.Read();
            user.UserName = reader.GetString(0);
            user.Admin = reader.GetBoolean(1);
        }
        else
        {
            user.UserName = "Visitor";
            user.Admin = false;
        }
        reader.Close();
        con.Close();
        return user;
    }

    public static string BuildSimpleUsersTable(DataTable dt)
    // the Method Build HTML user Table using the users in the DataTable dt.
    {
        string str = "<table class='usersTable' align='center'>";
        str += "<tr>";
        foreach (DataColumn column in dt.Columns)
        {
            str += "<td>" + column.ColumnName + "</td>";
        }

        foreach (DataRow row in dt.Rows)
        {
            str += "<tr>";
            foreach (DataColumn column in dt.Columns)
            {
                str += "<td>" + row[column] + "</td>";
            }
            str += "</tr>";
        }
        str += "</tr>";
        str += "</Table>";
        return str;
    }

    public static string BuildUsersTable(DataTable dt)
    // the Method Build HTML user Table with checkBoxes using the users in the DataTable dt.
    {

        string str = "<table class='usersTable' align='center'>";
        str += "<tr>";
        str += "<td> </td>";
        foreach (DataColumn column in dt.Columns)
        {
            str += "<td>" + column.ColumnName + "</td>";
        }

        foreach (DataRow row in dt.Rows)
        {
            str += "<tr>";
            str += "<td>" + CreateRadioBtn(row["userId"].ToString()) + "</td>";
            foreach (DataColumn column in dt.Columns)
            {
                str += "<td>" + row[column] + "</td>";
            }
            str += "</tr>";
        }
        str += "</tr>";
        str += "</Table>";
        return str;
    }

    public static string CreateRadioBtn(string id)
    {
        return $"<input type='checkbox' name='chk{id}' id='chk{id}' runat='server' />";
    }

    public static DataTable SortTable(DataTable dt, string column, string dir)
    {
        dt.DefaultView.Sort = column + " " + dir;
        return dt.DefaultView.ToTable();
    }

    public static DataTable FilterTable(DataTable dt, string column, string criteria)
    {
        dt.DefaultView.RowFilter = column + "=" + criteria;
        return dt.DefaultView.ToTable();
    }
}