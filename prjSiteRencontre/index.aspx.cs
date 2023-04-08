using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace prjSiteRencontre
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            //sqlConnection----------------------
            SqlConnection myCon = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=rencontreDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            myCon.Open();


            //sqlCommand------------------------
            string email = txtEmail.Text.Trim();
            string pass = txtPass.Text.Trim();
            string sql = "SELECT RefMembre FROM Membres WHERE Email='" + email + "' AND Pass='" + pass + "'";

            SqlCommand myCom = new SqlCommand(sql, myCon);
             SqlDataReader myReader = myCom.ExecuteReader();
            if (myReader.Read())
            {
                Session["v_RefMembre"] = myReader["RefMembre"];
                myReader.Close();
                myCon.Close();
                Server.Transfer("succes.aspx");
            }
            else
            {
                lblConnectionResultat.Text = "Wrong Email or Password !!!";
                myReader.Close();
                myCon.Close();
            }
            //--------------------------------------
        }

        protected void btnSignup_Click(object sender, EventArgs e)
        {
            Server.Transfer("signUp.aspx");
        }


        

    }
}