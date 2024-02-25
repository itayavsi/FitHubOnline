using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace ItayProject.WebPages
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                string SQLStr = $"SELECT * FROM tblUsers " +
                                $"WHERE userName='{Request.Form["userName"]}' AND password = '{Request.Form["password"]}'";

            }

        }
        protected void Submit_Click(object sender, EventArgs e)
        {

           bool isLogin = Helper.CheckLogin(userName.Value, password.Value);
         
            if (isLogin)
            {
                User user = Helper.GetUser(userName.Value, password.Value);
                Session["userName"] = userName.Value;
                Session["admin"] = user.Admin; //tbd get from db
                Session["Login"] = true;
                message.InnerHtml = "";
                Response.Redirect("/WebPages/index.aspx");
            }
            else
            {

                Session["userName"] = "Visitor";
                Session["Login"] = false;
                Session["admin"] = false;
                message.InnerHtml = "Unknown username or password";
            }
            
        }
        public DataSet RetrieveUserTable(string SQLStr)
        {
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(Helper.conString);

            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = SQLStr;
            cmd.Connection = con;

            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "tblUsers");
            con.Close();

            return ds;
        }
    }
}