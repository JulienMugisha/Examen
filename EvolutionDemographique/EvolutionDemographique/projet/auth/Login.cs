using EvolutionDemographique.Classes;
using EvolutionDemographique.Classes.Classe_Adresses;
using EvolutionDemographique.Classes.Classe_connexion_et_classe_rapport;
using EvolutionDemographique.Classes.Classe_Projets;
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace EvolutionDemographique.formulaire
{
    public partial class Login : MaterialForm
    {
        public Login()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey900, Primary.BlueGrey900, Primary.BlueGrey500, Accent.Teal700, TextShade.WHITE);
        }

        private void Login_Load(object sender, EventArgs e)
        {
            Dataconnexion.Instance.serverName = "BLACK-BATUNDI";
            Dataconnexion.Instance.dataBase = "Demotfc";
            Dataconnexion.Instance.UserName = "sa";
            Dataconnexion.Instance.pswd = "12345";

            if (Dataconnexion.Instance.Connection())
            {
                //MessageBox.Show("connexion etablie", "connexion a la base Bd", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("connexion echouee", "connexion a la base Bd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            Class_Login lg = new Class_Login();
            string password = lg.User(TextUser.Text);
            if (password == TextPass.Text && password != "")
            {
                MessageBox.Show("Connecte etant que " + TextUser.Text + "");
                splashscreen splsh = new splashscreen();
                splsh.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Nom d'utilisateur ou mot de passe incorrect", "Connexion Utilisateur", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
            
        }

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

      
    }
}
