using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prjSiteRencontre
{
    public partial class messageRecu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //sqlConnection---------------
            SqlConnection myCon = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=rencontreDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            myCon.Open();

            string emailUser = "";
            //Remplir les Infos Personnels-----------------
            string sql = "SELECT * FROM Membres WHERE RefMembre=" + Convert.ToInt32(Session["v_RefMembre"]);
            SqlCommand myCom = new SqlCommand(sql, myCon);

            SqlDataReader myReader = myCom.ExecuteReader();
            if (myReader.Read())
            {

                img.ImageUrl = "images/" + myReader["Photo"].ToString().Trim();
                imgProfile.ImageUrl = "images/" + myReader["Photo"].ToString().Trim();

                lblUserName.Text = myReader["UserName"].ToString().Trim();
                lblUserNameAccount.Text = myReader["UserName"].ToString().Trim();

                emailUser = myReader["Email"].ToString().Trim();

            }
            myReader.Close();
            //----------------------------


            string sqlMessage = "SELECT Expediteur,Destinataire,DateCreation,Titre,Message FROM Messages WHERE Destinataire='" + emailUser+"'";
            SqlCommand myComMessage = new SqlCommand(sqlMessage, myCon);
            SqlDataReader myReaderMessage = myComMessage.ExecuteReader();
            GridViewMessageRecu.DataSource = myReaderMessage;
            GridViewMessageRecu.DataBind();
            myReaderMessage.Close();
            myCon.Close();
        }

        protected void btnMyProfile_Click(object sender, EventArgs e)
        {
            Server.Transfer("succes.aspx");
        }

        protected void btnEnvoyerMessage_Click(object sender, EventArgs e)
        {
            Server.Transfer("envoyerMessage.aspx");
        }

        protected void btnMessageRecu_Click(object sender, EventArgs e)
        {
            Server.Transfer("MessageRecu.aspx");
        }

        protected void btnDisconnect_Click(object sender, EventArgs e)
        {
            Server.Transfer("index.aspx");
        }
    }
}