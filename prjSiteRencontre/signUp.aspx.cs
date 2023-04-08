using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Collections.Generic;

namespace prjSiteRencontre
{
    public partial class signUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                //Remplir
                RemplirDropDownListNatio();
            }
            else
            {
                lblErreur.Text = "";
            }
        }

        private void RemplirDropDownListNatio()
        {
            DropDownListNatio.Items.Add(new ListItem("Veuillez choisir votre Nationalite"));
            DropDownListNatio.SelectedIndex = 0;

            SqlConnection myCon = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=rencontreDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            myCon.Open();

            string sql = "SELECT Nationalite FROM NationaliteTable";
            SqlCommand myComDrop = new SqlCommand(sql, myCon);

            SqlDataReader myReaderDrop = myComDrop.ExecuteReader();
            while (myReaderDrop.Read())
            {
                DropDownListNatio.Items.Add(new ListItem(myReaderDrop["Nationalite"].ToString()));
            }
            myReaderDrop.Close();
            myCon.Close();

        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            if (DropDownListNatio.SelectedIndex == 0)
            {
                lblErreur.Text = "Veuillez choisir votre Nationalite SVP !! ";
                return;
            }

            DateTime dateNais = Convert.ToDateTime(dateNaissance.Text);
            int age = DateTime.Now.Year - dateNais.Year;

            if (age < 18)
            {
                lblErreur.Text = "ce site est reserver au personne de +18ans !! ";
                return;
            }

            
            SqlConnection myCon = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=rencontreDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            myCon.Open();

            //Si il est deja Membre===========================
            string email = txtEmail.Text.Trim();
            string pass = txtPass.Text.Trim();
            string userName = txtUserName.Text.Trim();
            string sql = "SELECT RefMembre FROM Membres WHERE Email='"+email+"' AND Pass='"+pass+"' AND UserName='"+userName+"'";
            SqlCommand myComMembre = new SqlCommand(sql, myCon);
            SqlDataReader myReaderMembre = myComMembre.ExecuteReader();
            if (myReaderMembre.Read())
            {
                lblErreur.Text = "Vous etes deja Membres du FriendsBook";
                myReaderMembre.Close();
                myCon.Close();
                return;
            }
            myReaderMembre.Close();
            //===================================================

            string genre = RadioButtonListGenre.SelectedItem.Text;
            string nationalite = DropDownListNatio.SelectedItem.Text;

      
            if (FileUpload1.HasFile)
            {
                string fileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
                FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Images/") + fileName);
                //Response.Redirect(Request.Url.AbsoluteUri);
                string sqlInsert = "INSERT INTO Membres(Age,Genre,Nationalite,UserName,Email,Pass,Photo) VALUES("+age+",'"+genre+"','"+nationalite+"','"+userName+"','"+email+"','"+pass+"','"+fileName+"')";
                SqlCommand myComInsert = new SqlCommand(sqlInsert, myCon);
                myComInsert.ExecuteNonQuery();
                myCon.Close();
                Server.Transfer("index.aspx");
            }
            else
            {
                lblErreur.Text = "Veuillez Uploader votre Photo SVP !!!";
            }

            
            
            
           
        }

        protected void btnReturnToLogin_Click(object sender, EventArgs e)
        {
            
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
          

        }
    }
}