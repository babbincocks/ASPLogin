using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.Configuration;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace ASPLogin
{
    public partial class Default : System.Web.UI.Page
    {
        int LoginAttempts = 1;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                try
                {
                    if (txtLogin.Text.Any())
                    {
                        if (txtPass.Text.Any())
                        {
                            //string connString = @"Server=PL1\MTCDB;Database=Sandbox;Trusted_Connection=True;" ;
                            SqlConnection sqlConn = new SqlConnection();
                            if (RadioButtonList1.SelectedIndex == 0)
                            {
                                sqlConn = new SqlConnection(WebConfigurationManager.ConnectionStrings["DesktopWindow"].ConnectionString);
                            }
                            else if (RadioButtonList1.SelectedIndex == 1)
                            {
                                sqlConn = new SqlConnection(WebConfigurationManager.ConnectionStrings["DesktopDoor"].ConnectionString);
                            }
                            else if (RadioButtonList1.SelectedIndex == 2)
                            {
                                sqlConn = new SqlConnection(WebConfigurationManager.ConnectionStrings["Laptop"].ConnectionString);
                            }

                            SqlDataAdapter sqlAdapt = new SqlDataAdapter("dbo.sp_AllUserInfo", sqlConn);

                            DataTable dtUsers = new DataTable();

                            sqlAdapt.Fill(dtUsers);

                            DataRow[] result = dtUsers.Select("Username = '" + txtLogin.Text + "'");
                            if (result.Length != 0)
                            {
                                if (result[0].ItemArray[1].ToString() == txtPass.Text)
                                {
                                    Response.Write("We found your record! It says that you're smelly. That's unfortunate.");
                                }
                                else
                                {
                                    Response.Write("Good news: you exist. Bad news: your password seems to be incorrect.");
                                }
                            }
                            else
                            {
                                Response.Write("Login could not be found.");
                            }
                        }
                        else
                        {
                            Response.Write("Please put in a password.");
                        }
                    }
                    else if (txtPass.Text.Any())
                    {
                        Response.Write("Please put in a login name.");
                    }
                    else
                    {
                        Response.Write("Please put in your login information.");
                    }
                }
                catch(Exception ex)
                {
                    Response.Write(ex.Message);
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (ViewState["Attempts"] != null)
                {
                    LoginAttempts = (int)ViewState["Attempts"] + 1;
                }
                txtLoginAttempts.Text = LoginAttempts.ToString();
                ViewState["Attempts"] = LoginAttempts;
            }
            catch(Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
    }
}