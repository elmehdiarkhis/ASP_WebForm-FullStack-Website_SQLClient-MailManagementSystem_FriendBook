using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.IO;
using System.Collections.Generic;
using System;
using System.IO;
using System.Web.UI;

namespace prjSiteRencontre
{
    public partial class succes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Page.IsPostBack == false)
            {
                RemplirDropDownListNatio();
            }

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

                lblUserNameDescription.Text = "Mon UserName : " + myReader["UserName"].ToString().Trim();
                lblAge.Text = "Mon Age : " + myReader["Age"].ToString().Trim();
                lblGenre.Text = "Mon Genre : " + myReader["Genre"].ToString().Trim();
                lblEmail.Text = "Mon Email : " + myReader["Email"].ToString().Trim();
                lblNationalite.Text = "Ma Nationalite : " + myReader["Nationalite"].ToString().Trim();
            }
            myReader.Close();
            //----------------------------
            

            
            //Remplir le Select All
            string sqlAll = "SELECT * FROM Membres";
            SqlCommand mySqlCommandAll = new SqlCommand(sqlAll, myCon);
            SqlDataReader myReaderAll = mySqlCommandAll.ExecuteReader();

            //=================================
            while (myReaderAll.Read())
            {
                if (Convert.ToInt32(myReaderAll["RefMembre"])!= Convert.ToInt32(Session["v_RefMembre"])){
                    Panel pan = new Panel();
                    pan.CssClass = "flex";
                    panSelectAll.Controls.Add(pan);


                    Image img = new Image();
                    img.ImageUrl = "images/" + myReaderAll["Photo"].ToString().Trim();
                    img.CssClass = "user-img";

                    Label lbl = new Label();
                    lbl.Text = myReaderAll["UserName"].ToString().Trim();
                    lbl.CssClass = "username";

                    Panel panGreen = new Panel();
                    panGreen.CssClass = "user-status";

                    pan.Controls.Add(img);
                    pan.Controls.Add(lbl);
                    pan.Controls.Add(panGreen);
                }

            }
  
            myReaderAll.Close();

            //====================================

            myCon.Close();


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



        protected void btnMyProfile_Click(object sender, EventArgs e)
        {
            Server.Transfer("succes.aspx");
        }

        protected void btnMessages_Click(object sender, EventArgs e)
        {

        }

        protected void btnDisconnect_Click(object sender, EventArgs e)
        {
            Server.Transfer("index.aspx");
        }

        protected void btnSearchGenre_Click(object sender, EventArgs e)
        {
            SqlConnection myCon = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=rencontreDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            myCon.Open();



            if (RadioButtonListGenre.SelectedIndex != -1)
            {
                string genre = RadioButtonListGenre.SelectedItem.Text;
                string sqlGenre = "SELECT RefMembre,UserName,Genre,Nationalite,Email,Age,Photo FROM Membres WHERE Genre='"+genre+"'";
                SqlCommand myComGenre = new SqlCommand(sqlGenre, myCon);
                SqlDataReader myReaderGenre = myComGenre.ExecuteReader();
                while (myReaderGenre.Read())
                {
                    if (Convert.ToInt32(myReaderGenre["RefMembre"]) != Convert.ToInt32(Session["v_RefMembre"]))
                    {
                        Panel panFilterV1 = new Panel();
                        panFilterV1.CssClass = "flex";
                        panFilter.Controls.Add(panFilterV1);

                        //image
                        Image imgFilter = new Image();
                        imgFilter.ImageUrl = "images/" + myReaderGenre["Photo"].ToString().Trim();
                        imgFilter.CssClass = "user-img";

                        //userName
                        Label lblFilterUser = new Label();
                        lblFilterUser.Text = myReaderGenre["UserName"].ToString().Trim();
                        lblFilterUser.CssClass = "username";

                        //Genre
                        Label lblFilterGenre = new Label();
                        lblFilterGenre.Text = myReaderGenre["Genre"].ToString().Trim();
                        lblFilterGenre.CssClass = "user-status-Fake";

                        //Nationalite
                        Label lblFilterNationalite = new Label();
                        lblFilterNationalite.Text = myReaderGenre["Nationalite"].ToString().Trim();
                        lblFilterNationalite.CssClass = "user-status-Fake";

                        //Email
                        Label lblFilterEmail = new Label();
                        lblFilterEmail.Text = myReaderGenre["Email"].ToString().Trim();
                        lblFilterEmail.CssClass = "user-status-Fake";

                        //Age
                        Label lblFilterAge = new Label();
                        lblFilterAge.Text = myReaderGenre["Age"].ToString().Trim() + " ans";
                        lblFilterAge.CssClass = "user-status-Fake";


                        panFilterV1.Controls.Add(imgFilter);
                        panFilterV1.Controls.Add(lblFilterUser);
                        panFilterV1.Controls.Add(lblFilterGenre);
                        panFilterV1.Controls.Add(lblFilterNationalite);
                        panFilterV1.Controls.Add(lblFilterEmail);
                        panFilterV1.Controls.Add(lblFilterAge);
                    }                   
                }

                //GridViewFilter.DataSource = myReaderGenre;
                //GridViewFilter.DataBind();
                myReaderGenre.Close();
                myCon.Close();
            }

            myCon.Close();

        }

        protected void btnSearchNation_Click(object sender, EventArgs e)
        {
            SqlConnection myCon = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=rencontreDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            myCon.Open();

            if (DropDownListNatio.SelectedIndex != -1)
            {
                string nationalite = DropDownListNatio.SelectedItem.Text;
                string sqlNationalite = "SELECT RefMembre,UserName,Genre,Nationalite,Email,Age,Photo FROM Membres WHERE Nationalite='" + nationalite+"'";
                SqlCommand myComNationalite = new SqlCommand(sqlNationalite, myCon);
                SqlDataReader myReaderNationalite = myComNationalite.ExecuteReader();

                while (myReaderNationalite.Read())
                {
                    if (Convert.ToInt32(myReaderNationalite["RefMembre"]) != Convert.ToInt32(Session["v_RefMembre"]))
                    {
                        Panel panFilterV1 = new Panel();
                        panFilterV1.CssClass = "flex";
                        panFilter.Controls.Add(panFilterV1);

                        //image
                        Image imgFilter = new Image();
                        imgFilter.ImageUrl = "images/" + myReaderNationalite["Photo"].ToString().Trim();
                        imgFilter.CssClass = "user-img";

                        //userName
                        Label lblFilterUser = new Label();
                        lblFilterUser.Text = myReaderNationalite["UserName"].ToString().Trim();
                        lblFilterUser.CssClass = "username";

                        //Genre
                        Label lblFilterGenre = new Label();
                        lblFilterGenre.Text = myReaderNationalite["Genre"].ToString().Trim();
                        lblFilterGenre.CssClass = "user-status-Fake";

                        //Nationalite
                        Label lblFilterNationalite = new Label();
                        lblFilterNationalite.Text = myReaderNationalite["Nationalite"].ToString().Trim();
                        lblFilterNationalite.CssClass = "user-status-Fake";

                        //Email
                        Label lblFilterEmail = new Label();
                        lblFilterEmail.Text = myReaderNationalite["Email"].ToString().Trim();
                        lblFilterEmail.CssClass = "user-status-Fake";

                        //Age
                        Label lblFilterAge = new Label();
                        lblFilterAge.Text = myReaderNationalite["Age"].ToString().Trim() + " ans";
                        lblFilterAge.CssClass = "user-status-Fake";


                        panFilterV1.Controls.Add(imgFilter);
                        panFilterV1.Controls.Add(lblFilterUser);
                        panFilterV1.Controls.Add(lblFilterGenre);
                        panFilterV1.Controls.Add(lblFilterNationalite);
                        panFilterV1.Controls.Add(lblFilterEmail);
                        panFilterV1.Controls.Add(lblFilterAge);
                    }
                }


                //GridViewFilter.DataSource = myReaderNationalite;
                //GridViewFilter.DataBind();
                myReaderNationalite.Close();
                myCon.Close();
            }

            myCon.Close();
        }

        protected void btnSearchByAge_Click(object sender, EventArgs e)
        {
            SqlConnection myCon = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=rencontreDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            myCon.Open();

            if (txtMinimum.Text.Trim().Length != 0 && txtMaximum.Text.Trim().Length != 0)
            {
                int ageMinimum = Convert.ToInt32(txtMinimum.Text.Trim());
                int ageMaximum = Convert.ToInt32(txtMaximum.Text.Trim());

                string sqlAge = "SELECT RefMembre,UserName,Genre,Nationalite,Email,Age,Photo FROM Membres WHERE Age BETWEEN " + ageMinimum+" AND "+ageMaximum+";";
                SqlCommand myComAge = new SqlCommand(sqlAge, myCon);
                SqlDataReader myReaderAge = myComAge.ExecuteReader();

                while (myReaderAge.Read())
                {
                    if (Convert.ToInt32(myReaderAge["RefMembre"]) != Convert.ToInt32(Session["v_RefMembre"]))
                    {
                        Panel panFilterV1 = new Panel();
                        panFilterV1.CssClass = "flex";
                        panFilter.Controls.Add(panFilterV1);

                        //image
                        Image imgFilter = new Image();
                        imgFilter.ImageUrl = "images/" + myReaderAge["Photo"].ToString().Trim();
                        imgFilter.CssClass = "user-img";

                        //userName
                        Label lblFilterUser = new Label();
                        lblFilterUser.Text = myReaderAge["UserName"].ToString().Trim();
                        lblFilterUser.CssClass = "username";

                        //Genre
                        Label lblFilterGenre = new Label();
                        lblFilterGenre.Text = myReaderAge["Genre"].ToString().Trim();
                        lblFilterGenre.CssClass = "user-status-Fake";

                        //Nationalite
                        Label lblFilterNationalite = new Label();
                        lblFilterNationalite.Text = myReaderAge["Nationalite"].ToString().Trim();
                        lblFilterNationalite.CssClass = "user-status-Fake";

                        //Email
                        Label lblFilterEmail = new Label();
                        lblFilterEmail.Text = myReaderAge["Email"].ToString().Trim();
                        lblFilterEmail.CssClass = "user-status-Fake";

                        //Age
                        Label lblFilterAge = new Label();
                        lblFilterAge.Text = myReaderAge["Age"].ToString().Trim() + " ans";
                        lblFilterAge.CssClass = "user-status-Fake";


                        panFilterV1.Controls.Add(imgFilter);
                        panFilterV1.Controls.Add(lblFilterUser);
                        panFilterV1.Controls.Add(lblFilterGenre);
                        panFilterV1.Controls.Add(lblFilterNationalite);
                        panFilterV1.Controls.Add(lblFilterEmail);
                        panFilterV1.Controls.Add(lblFilterAge);
                    }
                }

                //GridViewFilter.DataSource = myReaderAge;
                //GridViewFilter.DataBind();
                myReaderAge.Close();
                myCon.Close();
            }

            myCon.Close();
        }

        protected void btnSearchUserName_Click(object sender, EventArgs e)
        {
            SqlConnection myCon = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=rencontreDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            myCon.Open();

            if (txtUserName.Text.Trim().Length!=0)
            {
                string userName = txtUserName.Text.Trim();

                string sqlUser = "SELECT RefMembre,UserName,Genre,Nationalite,Email,Age,Photo FROM Membres WHERE UserName='" + userName+"'";
                SqlCommand myComUser = new SqlCommand(sqlUser, myCon);
                SqlDataReader myReaderUser = myComUser.ExecuteReader();

                while (myReaderUser.Read())
                {
                    if (Convert.ToInt32(myReaderUser["RefMembre"]) != Convert.ToInt32(Session["v_RefMembre"]))
                    {
                        Panel panFilterV1 = new Panel();
                        panFilterV1.CssClass = "flex";
                        panFilter.Controls.Add(panFilterV1);

                        //image
                        Image imgFilter = new Image();
                        imgFilter.ImageUrl = "images/" + myReaderUser["Photo"].ToString().Trim();
                        imgFilter.CssClass = "user-img";

                        //userName
                        Label lblFilterUser = new Label();
                        lblFilterUser.Text = myReaderUser["UserName"].ToString().Trim();
                        lblFilterUser.CssClass = "username";

                        //Genre
                        Label lblFilterGenre = new Label();
                        lblFilterGenre.Text = myReaderUser["Genre"].ToString().Trim();
                        lblFilterGenre.CssClass = "user-status-Fake";

                        //Nationalite
                        Label lblFilterNationalite = new Label();
                        lblFilterNationalite.Text = myReaderUser["Nationalite"].ToString().Trim();
                        lblFilterNationalite.CssClass = "user-status-Fake";

                        //Email
                        Label lblFilterEmail = new Label();
                        lblFilterEmail.Text = myReaderUser["Email"].ToString().Trim();
                        lblFilterEmail.CssClass = "user-status-Fake";

                        //Age
                        Label lblFilterAge = new Label();
                        lblFilterAge.Text = myReaderUser["Age"].ToString().Trim() + " ans";
                        lblFilterAge.CssClass = "user-status-Fake";


                        panFilterV1.Controls.Add(imgFilter);
                        panFilterV1.Controls.Add(lblFilterUser);
                        panFilterV1.Controls.Add(lblFilterGenre);
                        panFilterV1.Controls.Add(lblFilterNationalite);
                        panFilterV1.Controls.Add(lblFilterEmail);
                        panFilterV1.Controls.Add(lblFilterAge);
                    }
                }


                //GridViewFilter.DataSource = myReaderUser;
                //GridViewFilter.DataBind();
                myReaderUser.Close();
                myCon.Close();
            }

            myCon.Close();
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            RadioButtonListGenre.SelectedIndex = -1;
            DropDownListNatio.SelectedIndex = 0;
            txtMinimum.Text = "";
            txtMaximum.Text = "";
            txtUserName.Text = "";

            GridViewFilter.DataSource = null;
            GridViewFilter.DataBind();
        }

        protected void btnComboSearch_Click(object sender, EventArgs e)
        {
            SqlConnection myCon = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=rencontreDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            myCon.Open();

            if (RadioButtonListGenre.SelectedIndex != -1 && DropDownListNatio.SelectedIndex != -1 && txtMinimum.Text.Trim().Length != 0 && txtMaximum.Text.Trim().Length != 0)
            {
                string genre = RadioButtonListGenre.SelectedItem.Text;
                string nationalite = DropDownListNatio.SelectedItem.Text;
                int ageMinimum = Convert.ToInt32(txtMinimum.Text.Trim());
                int ageMaximum = Convert.ToInt32(txtMaximum.Text.Trim());


                string sqlUser = "SELECT RefMembre,UserName,Genre,Nationalite,Email,Age,Photo FROM Membres WHERE  Genre='" + genre+ "' AND Nationalite='"+nationalite+ "' AND Age BETWEEN "+ageMinimum+" AND "+ageMaximum+";";
                SqlCommand myComUser = new SqlCommand(sqlUser, myCon);
                SqlDataReader myReaderUser = myComUser.ExecuteReader();

                while (myReaderUser.Read())
                {
                    if (Convert.ToInt32(myReaderUser["RefMembre"]) != Convert.ToInt32(Session["v_RefMembre"]))
                    {
                        Panel panFilterV1 = new Panel();
                        panFilterV1.CssClass = "flex";
                        panFilter.Controls.Add(panFilterV1);

                        //image
                        Image imgFilter = new Image();
                        imgFilter.ImageUrl = "images/" + myReaderUser["Photo"].ToString().Trim();
                        imgFilter.CssClass = "user-img";

                        //userName
                        Label lblFilterUser = new Label();
                        lblFilterUser.Text = myReaderUser["UserName"].ToString().Trim();
                        lblFilterUser.CssClass = "username";

                        //Genre
                        Label lblFilterGenre = new Label();
                        lblFilterGenre.Text = myReaderUser["Genre"].ToString().Trim();
                        lblFilterGenre.CssClass = "user-status-Fake";

                        //Nationalite
                        Label lblFilterNationalite = new Label();
                        lblFilterNationalite.Text = myReaderUser["Nationalite"].ToString().Trim();
                        lblFilterNationalite.CssClass = "user-status-Fake";

                        //Email
                        Label lblFilterEmail = new Label();
                        lblFilterEmail.Text = myReaderUser["Email"].ToString().Trim();
                        lblFilterEmail.CssClass = "user-status-Fake";

                        //Age
                        Label lblFilterAge = new Label();
                        lblFilterAge.Text = myReaderUser["Age"].ToString().Trim() + " ans";
                        lblFilterAge.CssClass = "user-status-Fake";


                        panFilterV1.Controls.Add(imgFilter);
                        panFilterV1.Controls.Add(lblFilterUser);
                        panFilterV1.Controls.Add(lblFilterGenre);
                        panFilterV1.Controls.Add(lblFilterNationalite);
                        panFilterV1.Controls.Add(lblFilterEmail);
                        panFilterV1.Controls.Add(lblFilterAge);
                    }
                }


                //GridViewFilter.DataSource = myReaderUser;
                //GridViewFilter.DataBind();
                myReaderUser.Close();
                myCon.Close();
            }

            myCon.Close();
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