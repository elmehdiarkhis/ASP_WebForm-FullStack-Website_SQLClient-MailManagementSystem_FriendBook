using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prjSiteRencontre
{
    public partial class envoyerMessage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

                //sqlConnection---------------
                SqlConnection myCon = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=rencontreDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                myCon.Open();

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

                }
                myReader.Close();
                myCon.Close();
                //----------------------------
            

        }

        protected void btnDisconnect_Click(object sender, EventArgs e)
        {
            Server.Transfer("index.aspx");
        }

        protected void btnEnvoyer_Click(object sender, EventArgs e)
        {
            string emailExpediteur="";
            SqlConnection myCon = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=rencontreDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            myCon.Open();

            //recuperer email expediteur
            string sqlEmail = "SELECT Email FROM Membres WHERE RefMembre="+Convert.ToInt32(Session["v_RefMembre"]);
            SqlCommand myComEmail = new SqlCommand(sqlEmail, myCon);
            SqlDataReader myReaderEmail = myComEmail.ExecuteReader();
            if (myReaderEmail.Read())
            {
                emailExpediteur = myReaderEmail["Email"].ToString().Trim();
            }
            myReaderEmail.Close();

            //envoyer message
            string titre = txtTitre.Text.Trim();
            string emailDestinataire = txtEmail.Text.Trim();
            string message = txtMessage.Text.Trim();
            DateTime dateCreation = DateTime.Now;
            string sqlInsert = "INSERT INTO Messages(Titre,Message,Destinataire,DateCreation,Expediteur) VALUES('"+titre+"','"+message+"','"+emailDestinataire+"','"+dateCreation+"','"+emailExpediteur+"')";
            SqlCommand myComInsert = new SqlCommand(sqlInsert, myCon);
            myComInsert.ExecuteNonQuery();
            lblEnvoyer.Text = "Message Envoyer";

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
    }
}