using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ItayProject.WebPages
{
    public partial class tblUsers : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            {

                if (!IsPostBack)
                {
                    string SQLStr = "SELECT * FROM tblUsers";
                    DataSet ds = RetrieveUserTable(SQLStr);
                    DataTable dt = ds.Tables["tblUsers"];
                    string table = BuilUsersTable(dt);
                    tableDiv.InnerHtml = table;
                }
            }

        }
        public DataSet RetrieveUserTable(string SQLStr)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\IMOE001\source\repos\ItayProject\ItayProject\App_Data\Database.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = SQLStr;
            cmd.Connection = con;

            SqlDataAdapter ad = new SqlDataAdapter(cmd);

            DataSet ds = new DataSet();

            ad.Fill(ds, "tblUsers");

            return ds;
        }
        public string BuilUsersTable(DataTable dt)
        {
            string str = "<table class='user-table' align='center'>";
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
                str += "<td>" + CreateRadioBtn(row["userId"].ToString()) + "</td>";
                str += "</tr>";

            }
            str += "</tr>";
            str += "</table>";
            return str;
        }
        public string SQLStrBuild(string str)
        {
            if (str.Length == 0)
            {
                return "SELECT * FROM tblUsers";
            }

            string SQLStr = $"SELECT * FROM tblUsers " +
                $"WHERE firstName LIKE '%{str}%' OR lastName LIKE '%{str}%' ";
            return SQLStr;
        }
        public void Click_Filter(object sender, EventArgs e)
        {
            string SQLStr = SQLStrBuild(Request.Form["filter"]);
            DataSet ds = RetrieveUserTable(SQLStr);
            string table = BuilUsersTable(ds.Tables[0]);
            tableDiv.InnerHtml = table;

        }
        public string CreateRadioBtn(string id)
        {
            return $"<input type='checkbox' name='chk{id}' id='chk{id}' runat='server' />";
        }
public void Delete(object sender, EventArgs e)
{
    string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\IMOE001\source\repos\ItayProject\ItayProject\App_Data\Database.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);

    string SQLStr = "SELECT * FROM tblUsers";
    SqlCommand cmd = new SqlCommand(SQLStr, con);
    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
    DataSet ds = new DataSet();
    adapter.Fill(ds, "tblUsers");

    for (int i = 1; i < Request.Form.Count; i++)
    {
        if (Request.Form.AllKeys[i].Contains("chk"))
        {
            int userId = int.Parse(Request.Form.AllKeys[i].Remove(0, 3));
            DataRow[] dr = ds.Tables["tblUsers"].Select($"userId = {userId}");
            dr[0].Delete();
        }
    }
    SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
    adapter.UpdateCommand = builder.GetDeleteCommand();
    adapter.Update(ds, "tblUsers");

    string table = BuilUsersTable(ds.Tables["tblUsers"]);
    tableDiv.InnerHtml = table;
}
public void Edit(object sender, EventArgs e)
{
    for (int i = 1; i < Request.Form.Count; i++)
    {
        if (Request.Form.AllKeys[i].Contains("chk"))
        {
            Session["userToUpdate"] = int.Parse(Request.Form.AllKeys[i].Remove(0, 3));
            Response.Redirect("https://localhost:44342/EditUser");
        }
    }

}
    }
}
