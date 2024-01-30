using DevExpress.XtraReports.UI;
using EvolutionDemographique.Classes;
using EvolutionDemographique.Classes.Classe_Adresses;
using EvolutionDemographique.Classes.Classe_connexion_et_classe_rapport;
using EvolutionDemographique.Classes.Classe_Projets;
using EvolutionDemographique.Rapport;
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

namespace EvolutionDemographique
{
    public partial class Form1 : MaterialForm
    {
        SqlConnection conn = db.connection();

        //service
        Service srv = new Service();
        public int idservice;
        public string designationservice;
        //type declartion
        TypeDeclaration dcl = new TypeDeclaration();
        public int id_typedeclarant;
        public string designationtype;
        //type Agent
        TypeAgent typeagenet = new TypeAgent();
        public int id_typeagent;
        public string designationdeclarant;

        //Agent
        Agent agent = new Agent();
        public int id_agent;
        public int idpersonne;
        public int idtypeagent;
        public int idservice_Agent;

        //personne 
        Personne prsn = new Personne();
        public int id_personne;
        public string nom;
        public string postnom;
        public string prenom;
        public string sexe;
        public string lieunaissance;
        public DateTime date;
        public string profession;
        public string etatcivil;
        public string nompere;
        public string nommere;
        public string numerocartenational;
        public int idadress;
        public int etat;

        //declaration
        Declaration declt = new Declaration();
        public string motif;
        public DateTime createdat;
        public int idrefdeclarant;
        public int idrefpersonnedeclare;
        public int idtypedeclarant;
        public int id_declarant;
        public int idagent;

        Pays pays = new Pays();
        public int id;
        public string designationpay;

        Ville vle = new Ville();
        public int id_ville;
        public  int idpay;
        public string designationville;

        Commune commne = new Commune();
        public string designationcommune;
        public int idville; 
        public int id_commune;

        Quartier qrt = new Quartier();
        public int id_quartier;
        public string designationquartier;
        public int idcommune;

        Avenu av = new Avenu();
        public int id_avenue;
        public string designationavenue;
        public int idquartier;

        Contact ct = new Contact();
        public int id_contact;
        public int numeroTel;
        public int idpersonneContact;
        

        Rapport_Dashboard dsh = new Rapport_Dashboard();
        public Form1()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey900, Primary.BlueGrey900, Primary.BlueGrey500, Accent.Teal700, TextShade.WHITE);
           }
        public void loading_database()
        {
            dsh.chargementChart(chart2, "select CONCAT(CASE WHEN SEXE='Feminin (F)' THEN 'Feminin' ELSE 'Masculin' END,' (',COUNT(declaration.id_declarant),')') ,COUNT(*) from dbo.declaration inner join dbo.personne on personne.id_personne=declaration.idrefpersonnedeclare where declaration.idtypedeclarant=1 group by sexe");
            dsh.chargementChart(chart3, "select CONCAT(CASE WHEN SEXE='Feminin (F)' THEN 'Feminin' ELSE 'Masculin' END,' (',COUNT(declaration.id_declarant),')') ,COUNT(*) from dbo.declaration inner join dbo.personne on personne.id_personne=declaration.idrefpersonnedeclare where declaration.idtypedeclarant=2 group by sexe");
            dsh.chargementChart(chart1, "select CONCAT(CASE WHEN SEXE='Feminin (F)' THEN 'Feminin' ELSE 'Masculin' END,' (',COUNT(*),')') ,COUNT(*) from personne group by sexe");
   
            DataGridViewSerice.DataSource = srv.getService();
            DataGridViewTypeDeclaration.DataSource = dcl.getTypeDeclaration();
            DataGridViewTypeAgent.DataSource = typeagenet.getTypeAgent();
            DataGridViewAgent.DataSource = agent.getAgent();
            DataGridViewPersonne.DataSource = prsn.getPersonne();
            DataGridViewDeclaration.DataSource = declt.getDeclaration();
            DataGridViewPays.DataSource = pays.getPays();
            DataGridViewVille.DataSource = vle.getVille();
            DataGridViewCommune.DataSource = commne.getCommune();
            DataGridViewQuartier.DataSource = qrt.getQuartier();
            DataGridViewAvenu.DataSource = av.getAvenue();
            DataGridViewPersonneDeclarant.DataSource = prsn.getPersonneVerifier();
            DataGridViewPersonneDeclaree.DataSource = prsn.getPersonneVerifier();
            DataGridViewContact.DataSource = ct.getContact();
            DataGridViewPersonneConatctReference.DataSource = prsn.getPersonneContact();
            
            // appellation des combox

            service();
            typeAgent();
            personne();
            adresse();
            PersonneDeclarant();
            TypeDeclaration();
            PersonneDeclaree();
            officier();
            province();
            ville();
            commune();
            quartier();
            PersonneContact();
            //label2
            label2.Text = dsh.gettotalpersonne().ToString();
            label3.Text = dsh.gettotalNaissance().ToString();
            label5.Text = dsh.gettotalDeces().ToString();
   

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            loading_database();
            
        }

        //chargement
        void service()
        {
            ComboBoxService.ValueMember = "id_service";
            ComboBoxService.DisplayMember = "designationservice";
            ComboBoxService.DataSource = new Service().getService();
        }
        void typeAgent()
        {
            ComboBoxTypeAgent.ValueMember = "id_typeagent";
            ComboBoxTypeAgent.DisplayMember = "designationdeclarant";
            ComboBoxTypeAgent.DataSource = new TypeAgent().getTypeAgent();
        }
        void personne()
        {
            ComboBoxPersonne.ValueMember = "id_personne";
            ComboBoxPersonne.DisplayMember = "prenom";
            ComboBoxPersonne.DataSource = new Personne().getPersonne();
        }
        void adresse()
        {
            comboBoxAdress.ValueMember = "id_avenue";

            comboBoxAdress.DisplayMember = "designationavenue";
            comboBoxAdress.DataSource = new Avenu().getAvenue();
         //   comboBox1.DataSource = new Avenu().getAvenue();
        }
        void officier()
        {
            ComboBoxOfficier.ValueMember = "id_agent";
            ComboBoxOfficier.DisplayMember = "Agent";
            ComboBoxOfficier.DataSource = new Agent().getAgent();
        }
        void PersonneDeclarant()
        {
            ComboBoxDeclarant.ValueMember = "id_personne";
            ComboBoxDeclarant.DisplayMember = "nom";
            ComboBoxDeclarant.DataSource = new Personne().getPersonneVerifier();
        }
        void TypeDeclaration()
        {
            ComboBoxDeclaration.ValueMember = "id_typedeclarant";
            ComboBoxDeclaration.DisplayMember = "designationtype";
            ComboBoxDeclaration.DataSource = new TypeDeclaration().getTypeDeclaration();
        }
        void PersonneDeclaree()
        {
            ComboBoxDeclaree.ValueMember = "id_personne";
            ComboBoxDeclaree.DisplayMember = "nom";
            ComboBoxDeclaree.DataSource = new Personne().getPersonneVerifier();
        }

        void PersonneContact()
        {
            ComboBoxPersonneContact.ValueMember = "id_personne";
            ComboBoxPersonneContact.DisplayMember = "nom";
            ComboBoxPersonneContact.DataSource = new Personne().getPersonne();
        }
        void province()
        {
             ComboBoxProvince.ValueMember = "id";
             ComboBoxProvince.DisplayMember = "designationpay";
             ComboBoxProvince.DataSource = new Pays().getPays();
        }
        void ville()
        {
            ComboBoxVille.ValueMember = "id_ville";
            ComboBoxVille.DisplayMember = "designationville";
            ComboBoxVille.DataSource = new Ville().getVille();

            ComboxVille.ValueMember = "id_ville";
            ComboxVille.DisplayMember = "designationville";
            ComboxVille.DataSource = new Ville().getVille();
            
        }
        
        void commune()
        {
            ComboBoxCommune.ValueMember = "id_commune";
            ComboBoxCommune.DisplayMember = "designationcommune"; 
            ComboBoxCommune.DataSource = new Commune().getCommune();

            ComboxCommune.ValueMember = "id_commune";
            ComboxCommune.DisplayMember = "designationcommune";
            ComboxCommune.DataSource = new Commune().getCommune();
        }
        void quartier()
        {

            ComboBoxQuartier.ValueMember = "id_quartier";
            ComboBoxQuartier.DisplayMember = "designationquartier";
            ComboBoxQuartier.DataSource = new Quartier().getQuartier();

            ComboxQuartier.ValueMember = "id_quartier";
            ComboxQuartier.DisplayMember = "designationquartier";
            ComboxQuartier.DataSource = new Quartier().getQuartier();
        }
        // Service

        private void BtnSaveService_Click(object sender, EventArgs e)
        {
            if(TextServiceDesignation.Text!="")
            {
                designationservice = TextServiceDesignation.Text;
                int succ = srv.insert(this.designationservice);
                if (succ > 0)
                {
                    MessageBox.Show("insertion su service avec succes");
                    DataGridViewSerice.DataSource = srv.getService();
                    clearTextService();
                    loading_database();

                }
                else
                {
                    MessageBox.Show("erreur");
                }
            }
            else
            {
                MessageBox.Show("Veuillez entre le service");
            }
           
        }

        private void btnUpdateService_Click(object sender, EventArgs e)
        {
            this.designationservice = TextServiceDesignation.Text;
            if (this.idservice > 0)
            {

                int c = srv.update(this.designationservice, this.idservice);

                MessageBox.Show("mise en jour du service avec success");
                DataGridViewSerice.DataSource = srv.getService();
                clearTextService();
                loading_database();


            }
            else
            {
                MessageBox.Show("veillez selectioner un element dans le tableau service");
            }
        }

        private void btnDeleteService_Click(object sender, EventArgs e)
        {
            if (this.idservice > 0)
            {
                int c = srv.delete(this.idservice);
                if (c > 0)
                {
                    MessageBox.Show("suppression  du service avec success");
                    DataGridViewSerice.DataSource = srv.getService();
                    clearTextService();
                    loading_database();
                }
                else
                {
                    MessageBox.Show("erreur");
                }
            }
            else
            {
                MessageBox.Show("erreur");
            }
        }

        private void DataGridViewSerice_Click(object sender, EventArgs e)
        {
            try
            {
                var row = DataGridViewSerice.CurrentRow;
                this.idservice = int.Parse(row.Cells[0].Value.ToString());
                this.designationservice = row.Cells[1].Value.ToString();
                TextServiceDesignation.Text = this.designationservice;
            }
            catch
            {
                MessageBox.Show("erreur");
            }
        }

        private void btnPrintService_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch
            {
                MessageBox.Show("imprimer");
            }
        }
        private void clearTextService()
        {
            TextIdService.Text = "";
            TextServiceDesignation.Text = "";
        }


        //type declaration
        private void btnSaveDeclaration_Click(object sender, EventArgs e)
        {
            if (TextDesignationDeclaration.Text!="")
            {
                designationtype = TextDesignationDeclaration.Text;
                int succ = dcl.insert(this.designationtype);
                if (succ > 0)
                {
                    MessageBox.Show("insertion type declarant avec succes");
                    DataGridViewTypeDeclaration.DataSource = dcl.getTypeDeclaration();
                    clearTextTypeDeclaration();
                    loading_database();
                }
                else
                {
                    MessageBox.Show("erreur");
                }
            }
            else
            {
                MessageBox.Show("Veuillez Entre la designation du type declarant");
            }
        }

        private void btnUpdateDeclaration_Click(object sender, EventArgs e)
        {
            this.designationtype = TextDesignationDeclaration.Text;
            if (this.id_typedeclarant > 0)
            {
                int c = dcl.update(this.designationtype, this.id_typedeclarant);

                MessageBox.Show("mise en jour type declarant avec success");
                DataGridViewTypeDeclaration.DataSource = dcl.getTypeDeclaration();
                clearTextTypeDeclaration();
                loading_database();


            }
            else
            {
                MessageBox.Show("erreur!! il y'a pas les donneés à modifier");
            }
        }

        private void btnDeleteDeclaration_Click(object sender, EventArgs e)
        {
            if (this.id_typedeclarant > 0)
            {
                int c = dcl.delete(this.id_typedeclarant);
                if (c > 0)
                {
                    MessageBox.Show("suppression du type declarant avec success");
                    DataGridViewTypeDeclaration.DataSource = dcl.getTypeDeclaration();
                    clearTextTypeDeclaration();
                    loading_database();
                }
                else
                {
                    MessageBox.Show("erreur");
                }
            }
            else
            {
                MessageBox.Show("erreur!! il y'a pas les donneés à supprimer");
            }
        }

        private void DataGridViewTypeDeclaration_Click(object sender, EventArgs e)
        {
            try
            {
                var row = DataGridViewTypeDeclaration.CurrentRow;
                this.id_typedeclarant = int.Parse(row.Cells[0].Value.ToString());
                this.designationtype = row.Cells[1].Value.ToString();
                TextDesignationDeclaration.Text = this.designationtype;
            }
            catch
            {
                MessageBox.Show("erreur");
            }
        }

        private void clearTextTypeDeclaration()
        {
            TextIdTypeDeclaration.Text = "";
            TextDesignationDeclaration.Text = "";
        }
        // type Agent
        private void btnSaveTypeAgent_Click(object sender, EventArgs e)
        {

            this.designationdeclarant = TextDesignationTypeAgent.Text;

            int succ = typeagenet.insert(this.designationdeclarant);
            if (succ > 0)
            {
                MessageBox.Show("insertion type agent avec succes");
                DataGridViewTypeAgent.DataSource = typeagenet.getTypeAgent();
                clearTextTypeAgent();
                loading_database();
                
            }
            else
            {
                MessageBox.Show("erreur");
            }


        }

        private void btnUpdateTypeAgent_Click(object sender, EventArgs e)
        {
            this.designationdeclarant = TextDesignationTypeAgent.Text;
            if (this.id_typeagent > 0)
            {
                int c = typeagenet.update(this.designationdeclarant, this.id_typeagent);

                MessageBox.Show("mise en jour type agent avec success");
                DataGridViewTypeAgent.DataSource = typeagenet.getTypeAgent();
                clearTextTypeAgent();
                loading_database();


            }
            else
            {
                MessageBox.Show("erreur");
            }
        }

        private void btnDeleteTypeAgent_Click(object sender, EventArgs e)
        {
            if (this.id_typeagent > 0)
            {
                int c = typeagenet.delete(this.id_typeagent);
                if (c > 0)
                {
                    MessageBox.Show("suppression du type declarant avec success");
                    DataGridViewTypeAgent.DataSource = typeagenet.getTypeAgent();
                    clearTextTypeAgent();
                    loading_database();
                }
                else
                {
                    MessageBox.Show("erreur");
                }
            }
            else
            {
                MessageBox.Show("erreur");
            }
        }

        private void DataGridViewTypeAgent_Click(object sender, EventArgs e)
        {
            try
            {
                var row = DataGridViewTypeAgent.CurrentRow;
                this.id_typeagent = int.Parse(row.Cells[0].Value.ToString());
                this.designationdeclarant = row.Cells[1].Value.ToString();
                TextDesignationTypeAgent.Text = this.designationdeclarant;

            }
            catch
            {
                MessageBox.Show("erreur");
            }
        }

        private void clearTextTypeAgent()
        {
            TextIdTypeAgent.Text = "";
            TextDesignationTypeAgent.Text = "";
        }


        //Agent
        private void btnSaveAgent_Click(object sender, EventArgs e)
        {
            this.idpersonne = Convert.ToInt16(ComboBoxPersonne.SelectedValue.ToString());
            this.idtypeagent = Convert.ToInt16(ComboBoxTypeAgent.SelectedValue.ToString());
            this.idservice_Agent = Convert.ToInt16(ComboBoxService.SelectedValue.ToString());
            int succ = agent.insert(this.idpersonne, this.idtypeagent, this.idservice_Agent);

            if (succ > 0)
            {
                MessageBox.Show("insertion agent avec succes");
                DataGridViewAgent.DataSource = agent.getAgent();
                clearTextAgent();
                loading_database();

            }
            else
            {
                MessageBox.Show("erreur");
            }
        }

        private void btnUpdateAgent_Click(object sender, EventArgs e)
        {
            this.idpersonne = Convert.ToInt16(ComboBoxPersonne.SelectedValue.ToString());
            this.idtypeagent = Convert.ToInt16(ComboBoxTypeAgent.SelectedValue.ToString()); ;
            this.idservice_Agent = Convert.ToInt16(ComboBoxService.SelectedValue.ToString()); ;

            if (this.id_agent > 0)
            {
                int c = agent.update(this.idpersonne, this.idtypeagent, this.idservice_Agent, this.id_agent);

                MessageBox.Show("mise en jour  de l'agent avec success");
                DataGridViewAgent.DataSource = agent.getAgent();
                clearTextAgent();
                loading_database();


            }
            else
            {
                MessageBox.Show("erreur");
            }
        }

        private void btnDeleteAgent_Click(object sender, EventArgs e)
        {
            if (this.id_agent > 0)
            {
                int c = agent.delete(this.id_agent);
                if (c > 0)
                {
                    MessageBox.Show("suppression du type declarant avec success");
                    DataGridViewAgent.DataSource = agent.getAgent();
                    clearTextAgent();
                    loading_database();
                }
                else
                {
                    MessageBox.Show("erreur");
                }
            }
            else
            {
                MessageBox.Show("erreur");
            }
        }

        private void DataGridViewAgent_Click(object sender, EventArgs e)
        {
            try
            {
                var row = DataGridViewAgent.CurrentRow;
                this.id_agent = int.Parse(row.Cells[0].Value.ToString());
                ComboBoxPersonne.Text = "" + DataGridViewAgent.CurrentRow.Cells[1].Value.ToString();
                ComboBoxTypeAgent.Text = "" + DataGridViewAgent.CurrentRow.Cells[2].Value.ToString();
                ComboBoxService.Text = "" + DataGridViewAgent.CurrentRow.Cells[3].Value.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void clearTextAgent()
        {
            ComboBoxPersonne.SelectedIndex = -1;
            ComboBoxTypeAgent.SelectedIndex = -1;
            ComboBoxService.SelectedIndex = -1;
        }
        //personne
        private void btnSavePersonne_Click(object sender, EventArgs e)
        {
            if (TextNom.Text != "" && TextPostnom.Text != "" && TextPrenom.Text != "" && ComboBoxGenre.Text != "" && TextLieu.Text != "" && DateNaissance.Text != "" && TextProfession.Text != "" && ComboBoxEtatCivil.Text != "" && TextPere.Text != "" && TextMere.Text != "" && TextNumero.Text!="")
            {
                this.nom = TextNom.Text;
                this.postnom = TextPostnom.Text;
                this.prenom = TextPrenom.Text;
                this.sexe = ComboBoxGenre.Text;
                this.lieunaissance = TextLieu.Text;
                this.date = DateTime.Parse(DateNaissance.Text);
                this.profession = TextProfession.Text;
                this.etatcivil = ComboBoxEtatCivil.Text;
                this.nompere = TextPere.Text;
                this.nommere = TextMere.Text;
                this.numerocartenational = TextNumero.Text;
                this.idadress = Convert.ToInt16(comboBoxAdress.SelectedValue);
                int succ = prsn.insert(this.nom, this.postnom, this.prenom, this.sexe, this.lieunaissance, this.date, this.profession, this.etatcivil, this.nompere, this.nommere, this.numerocartenational, this.idadress);
                if (succ == 200)
                {
                    MessageBox.Show("insertion Personne avec succes");
                    DataGridViewPersonne.DataSource = prsn.getPersonne();
                    dsh.gettotalpersonne();
                    clearTextPersonne();
                    loading_database();
                }
                else if (succ == 210)
                {
                    MessageBox.Show("date super to now");
                }
                else if (succ == 204)
                {
                    MessageBox.Show("numero existe");
                }
                else
                {
                    MessageBox.Show("insertion echoue");
                }
            }
            else
            {
                MessageBox.Show("Veuillez Remplire tous les champs");
            }

            

        }

        private void btnUpdatePersonne_Click(object sender, EventArgs e)
        {
            this.nom = TextNom.Text;
            this.postnom = TextPostnom.Text;
            this.prenom = TextPrenom.Text;
            this.sexe = ComboBoxGenre.Text;
            this.lieunaissance = TextLieu.Text;
            this.date = DateTime.Parse(DateNaissance.Text);
            this.profession = TextProfession.Text;
            this.etatcivil = ComboBoxEtatCivil.Text;
            this.nompere = TextPere.Text;
            this.nommere = TextMere.Text;
            this.numerocartenational = TextNumero.Text;
            this.idadress = Convert.ToInt16(comboBoxAdress.SelectedValue.ToString());
            if (this.id_personne > 0)
            {
                int c = prsn.update(this.nom, this.postnom, this.prenom, this.sexe, this.lieunaissance, this.date, this.profession, this.etatcivil, this.nompere, this.nommere, this.numerocartenational, this.idadress, this.id_personne);
                MessageBox.Show("mise en jour  de la personne avec success");
                DataGridViewPersonne.DataSource = prsn.getPersonne();
                clearTextPersonne();
                loading_database();
            }
            else
            {
                MessageBox.Show("Il y'a pas les donneés à modifier");
            }
        }
        private void btnDeletePersonne_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.id_personne > 0)
                {
                    int c = prsn.delete(this.id_personne);
                    if (c > 0)
                    {
                        MessageBox.Show("suppression de la personne avec success");
                        DataGridViewPersonne.DataSource = prsn.getPersonne();
                        clearTextPersonne();
                        loading_database();
                    }
                    else
                    {
                        MessageBox.Show(" supprission echoue");
                    }
                }
                else
                {
                    MessageBox.Show("Il y'a pas les donneés à supprimer");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DataGridViewPersonne_Click(object sender, EventArgs e)
        {

        }

        private void clearTextPersonne()
        {

            TextNom.Text = "";
            TextPostnom.Text = "";
            TextPrenom.Text = "";
            TextLieu.Text = "";
            TextProfession.Text = "";
            TextPere.Text = "";
            TextMere.Text = "";
            TextNumero.Text = "";
            ComboBoxGenre.SelectedIndex = -1;
            ComboBoxEtatCivil.SelectedIndex = -1;
            comboBoxAdress.SelectedIndex = -1;
        }

        private void DataGridViewPersonne_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var row = DataGridViewPersonne.CurrentRow;
                this.id_personne = int.Parse(row.Cells[0].Value.ToString());
                this.nom = row.Cells[1].Value.ToString();
                this.postnom = row.Cells[2].Value.ToString();
                this.prenom = row.Cells[3].Value.ToString();
                this.sexe = row.Cells[4].Value.ToString();
                this.lieunaissance = row.Cells[5].Value.ToString();
                this.date = DateTime.Parse(row.Cells[6].Value.ToString());
                this.profession = row.Cells[7].Value.ToString();
                this.etatcivil = row.Cells[8].Value.ToString();
                this.nompere = row.Cells[9].Value.ToString();
                this.nommere = row.Cells[10].Value.ToString();
                this.numerocartenational = row.Cells[11].Value.ToString();
                comboBoxAdress.Text = "" + DataGridViewPersonne.CurrentRow.Cells[12].Value.ToString();
                TextNom.Text = this.nom;
                TextPostnom.Text = this.postnom;
                TextPrenom.Text = this.prenom;
                ComboBoxGenre.Text = this.sexe;
                TextLieu.Text = this.lieunaissance;
                DateNaissance.Value = DateTime.Parse(row.Cells[6].Value.ToString());
                TextProfession.Text = this.profession;
                ComboBoxEtatCivil.Text = this.etatcivil;
                TextPere.Text = this.nompere;
                TextMere.Text = this.nommere;
                TextNumero.Text = this.numerocartenational;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Recherch_Click(object sender, EventArgs e)
        {

        }

        //declaration
        private void btnSave_Click(object sender, EventArgs e)
        {

            this.motif = TextMotif.Text;
            this.createdat = DateTime.Parse(DateDeclaration.Text);
            this.idrefdeclarant = Convert.ToInt16(ComboBoxDeclarant.SelectedValue);
            this.idrefpersonnedeclare = Convert.ToInt16(ComboBoxDeclaree.SelectedValue);
            this.idtypedeclarant = Convert.ToInt16(ComboBoxDeclaration.SelectedValue);
            this.idagent = Convert.ToInt16(ComboBoxOfficier.SelectedValue);
            int succ = declt.insert(this.motif, this.createdat, this.idrefdeclarant, this.idrefpersonnedeclare, this.idtypedeclarant, this.idagent);
            if (succ > 0)
            {

                MessageBox.Show("insertion declaration avec succes");
                DataGridViewDeclaration.DataSource = declt.getDeclaration();
                clearTextDeclation();
                loading_database();
            }
            else
            {
                MessageBox.Show("erreur");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.id_declarant > 0)
                {
                    int c = declt.delete(this.id_declarant);
                    if (c > 0)
                    {
                        MessageBox.Show("suppression de la personne avec success");
                        DataGridViewDeclaration.DataSource = declt.getDeclaration();
                        clearTextDeclation();
                        loading_database();
                    }
                    else
                    {
                        MessageBox.Show(" supprission echoue");
                    }
                }
                else
                {
                    MessageBox.Show("erreur");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void clearTextDeclation()
        {

            TextMotif.Text = "";
            ComboBoxDeclarant.SelectedIndex = -1;
            ComboBoxDeclaree.SelectedIndex = -1;
            ComboBoxDeclaration.SelectedIndex = -1;
            ComboBoxOfficier.SelectedIndex = -1;
        }

        private void DataGridViewDeclaration_Click(object sender, EventArgs e)
        {
            try
            {
                var row = DataGridViewDeclaration.CurrentRow;
                this.id_declarant = int.Parse(row.Cells[0].Value.ToString());
                this.motif = row.Cells[1].Value.ToString();
                this.createdat = DateTime.Parse(row.Cells[2].Value.ToString());
                ComboBoxDeclarant.Text = ""+row.Cells[3].Value.ToString();
                ComboBoxDeclaree.Text = ""+row.Cells[4].Value.ToString();
                ComboBoxDeclaration.Text = ""+row.Cells[5].Value.ToString();
                ComboBoxOfficier.Text = ""+row.Cells[6].Value.ToString();

                TextIdDeclaration.Text= Convert.ToString(this.id_declarant);

                TextMotif.Text = this.motif;
                DateDeclaration.Value = DateTime.Parse(row.Cells[2].Value.ToString());

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        //localisation a faire
        private void btnSavePays_Click(object sender, EventArgs e)
        {
            this.designationpay = TextPays.Text;

            int succ = pays.insert(this.designationpay);
            if (succ > 0)
            {
                MessageBox.Show("insertion Province avec succes");
                DataGridViewPays.DataSource = pays.getPays();
                clearTextTypeAgent();
                loading_database();
            }
            else
            {
                MessageBox.Show("erreur");
            }
        }

        private void btnUpdatePays_Click(object sender, EventArgs e)
        {
            this.designationpay = TextPays.Text;
            if (this.id > 0)
            {
                int c = pays.update(this.designationpay, this.id);

                MessageBox.Show("mise en jour Province avec success");
                DataGridViewPays.DataSource = pays.getPays();
                clearTextTypeAgent();
                loading_database();


            }
            else
            {
                MessageBox.Show("erreur");
            }
        }

        private void DataGridViewPays_Click(object sender, EventArgs e)
        {
            try
            {
                var row = DataGridViewPays.CurrentRow;
                this.id = int.Parse(row.Cells[0].Value.ToString());
                this.designationpay = row.Cells[1].Value.ToString();
                TextPays.Text = this.designationpay;

            }
            catch
            {
                MessageBox.Show("erreur");
            }
        }

        private void btnSaveVille_Click(object sender, EventArgs e)
        {
            this.idpay = Convert.ToInt16(ComboBoxProvince.SelectedValue);
            this.designationville = TextVille.Text;

            int succ = vle.insert(this.designationville, this.idpay);
            if (succ > 0)
            {
                MessageBox.Show("insertion Province avec succes");
                DataGridViewVille.DataSource = vle.getVille();
                clearTextTypeAgent();
                loading_database();
            }
            else
            { MessageBox.Show("erreur"); }

        }

        private void btnUpdateVille_Click(object sender, EventArgs e)
        {
            this.idpay = Convert.ToInt16(ComboBoxProvince.SelectedValue);
            this.designationville = TextVille.Text;
            if (this.id_ville > 0)
            {
                int c = vle.update(this.designationville,this.idpay, this.id_ville);

                MessageBox.Show("mise en jour Province avec success");
                DataGridViewVille.DataSource = vle.getVille();
                clearTextTypeAgent();
                loading_database();


            }
            else
            {
                MessageBox.Show("erreur");
            }
        }

        private void DataGridViewVille_Click(object sender, EventArgs e)
        {
            try
            {
                var row = DataGridViewVille.CurrentRow;
                this.id_ville = int.Parse(row.Cells[0].Value.ToString());
                this.designationville = row.Cells[1].Value.ToString();
                this.idpay = int.Parse(row.Cells[2].Value.ToString());

                TextVille.Text = this.designationville;
                ComboBoxProvince.SelectedValue = this.idpay;



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSaveCommune_Click(object sender, EventArgs e)
        {
            this.idville = Convert.ToInt16(ComboBoxVille.SelectedValue);
            this.designationcommune = TextCommune.Text;

            int succ = commne.insert(this.designationcommune, this.idville);
            if (succ > 0)
            {
                MessageBox.Show("insertion Commune avec succes");
                DataGridViewCommune.DataSource = commne.getCommune();
                clearTextTypeAgent();
                loading_database();
            }
            else
            { MessageBox.Show("erreur"); }
        }

        private void btnUpdateCommune_Click(object sender, EventArgs e)
        {
            this.idville = Convert.ToInt16(ComboBoxVille.SelectedValue);
            this.designationcommune = TextCommune.Text;
            if (this.id_commune > 0)
            {
                int c = commne.update(this.designationcommune, this.idville, this.id_commune);

                MessageBox.Show("mise en jour Province avec success");
                DataGridViewCommune.DataSource = commne.getCommune();
                clearTextTypeAgent();
                loading_database();
            }
            else
            {
                MessageBox.Show("erreur");
            }
        }

        private void DataGridViewCommune_Click(object sender, EventArgs e)
        {
            try
            {
                var row = DataGridViewCommune.CurrentRow;
                this.id_commune = int.Parse(row.Cells[0].Value.ToString());
                this.designationcommune = row.Cells[1].Value.ToString();
                this.idville = int.Parse(row.Cells[2].Value.ToString());

                TextCommune.Text = this.designationcommune;
                ComboBoxVille.SelectedValue = this.idville;



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void gunaComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSaveQuartier_Click(object sender, EventArgs e)
        {
            this.idcommune = Convert.ToInt16(ComboBoxCommune.SelectedValue);
            this.designationquartier = TextQuartier.Text;

            int succ = qrt.insert(this.designationquartier, this.idcommune);
            if (succ > 0)
            {
                MessageBox.Show("insertion Quartier avec succes");
                DataGridViewQuartier.DataSource = qrt.getQuartier();
                clearTextTypeAgent();
                loading_database();
            }
            else
            { MessageBox.Show("erreur"); }

        }
        private void btnUpdateQuartier_Click(object sender, EventArgs e)
        {
            this.idcommune = Convert.ToInt16(ComboBoxCommune.SelectedValue);
            this.designationquartier = TextQuartier.Text;
            if (this.id_quartier > 0)
            {
                int c = qrt.update(this.designationquartier, this.idcommune, this.id_quartier);

                MessageBox.Show("mise en jour Quartier avec success");
                DataGridViewQuartier.DataSource = qrt.getQuartier();
                clearTextTypeAgent();
                loading_database();
            }
            else
            {
                MessageBox.Show("erreur");
            }
        }

        private void DataGridViewQuartier_Click(object sender, EventArgs e)
        {
            try
            {
                var row = DataGridViewQuartier.CurrentRow;
                this.id_quartier = int.Parse(row.Cells[0].Value.ToString());
                this.designationquartier = row.Cells[1].Value.ToString();
                this.idcommune = int.Parse(row.Cells[2].Value.ToString());

                TextQuartier.Text = this.designationquartier;
                ComboBoxCommune.SelectedValue = this.idcommune;



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSaveAvenu_Click(object sender, EventArgs e)
        {
            this.idquartier = Convert.ToInt16(ComboBoxQuartier.SelectedValue);
            this.designationavenue = TextAvenu.Text;

            int succ = av.insert(this.designationavenue, this.idquartier);
            if (succ > 0)
            {
                MessageBox.Show("insertion Quartier avec succes");
                DataGridViewAvenu.DataSource = av.getAvenue();
                clearTextTypeAgent();
                loading_database();
            }
            else
            { MessageBox.Show("erreur"); }
        }

       private void btnUpdateAvenu_Click(object sender, EventArgs e)
       {
           this.idquartier = Convert.ToInt16(ComboBoxQuartier.SelectedValue);
           this.designationavenue = TextAvenu.Text;

           if (this.id_avenue > 0)
           {
               int c = qrt.update(this.designationavenue, this.idquartier, this.id_avenue);

               MessageBox.Show("mise en jour Quartier avec success");
               DataGridViewAvenu.DataSource = av.getAvenue();
               clearTextTypeAgent();
               loading_database();
           }
           else
           {
               MessageBox.Show("erreur");
           }
       }

       private void DataGridViewAvenu_Click(object sender, EventArgs e)
       {
           try
           {
               var row = DataGridViewAvenu.CurrentRow;
               this.id_avenue = int.Parse(row.Cells[0].Value.ToString());
               this.designationavenue = row.Cells[1].Value.ToString();
               this.idquartier = int.Parse(row.Cells[2].Value.ToString());

               TextAvenu.Text = this.designationavenue;
               ComboBoxQuartier.SelectedValue = this.idquartier;



           }
           catch (Exception ex)
           {
               MessageBox.Show(ex.Message);
           }
       }

       private void materialButton47_Click(object sender, EventArgs e)
       {
           Application.Exit();
        
       }

       private void materialButton50_Click(object sender, EventArgs e)
       {
           Form1 frm = new Form1();
           frm.Show();
       }

       private void label9_Click(object sender, EventArgs e)
       {
         
       }

       private void materialTabControl1_Click(object sender, EventArgs e)
       {
           DataGridViewSerice.DataSource = srv.getService();
           service();
       }

       private void chart1_Click(object sender, EventArgs e)
       {

       }

       private void DataGridViewPersonne_CellContentClick(object sender, DataGridViewCellEventArgs e)
       {
          // label10.Text = "" + DataGridViewPersonne.CurrentRow.Cells[12].Value.ToString();
           
       
       }

       private void chart2_Click(object sender, EventArgs e)
       {

       }

       private void materialButton2_Click(object sender, EventArgs e)
       {
           try
           {
               ListPersonne rpt = new ListPersonne();
               rpt.DataSource = clsGlossiaires.GetInstance().rapport_par_date("getpersonne", " where createdat>='" + debut.Value.ToString("yyyy-MM-dd") + "' and createdat<='"+fin.Value.ToString("yyyy-MM-dd")+"'");
               //rpt.DataSource = clsGlossiaires.GetInstance().get_Report_liste("getdeath");
               using (ReportPrintTool printTool = new ReportPrintTool(rpt))
               {
                   printTool.ShowPreviewDialog();
               }
           }
           catch (Exception ex)
           {
               MessageBox.Show(ex.Message);
           }
       }

       private void btnNaissance_Click(object sender, EventArgs e)
       {
           try
           {
               ActeNaissance rpt = new ActeNaissance();
               rpt.DataSource = clsGlossiaires.GetInstance().get_Report_one("ActeNaissance", "id_declarant", TextIdDeclaration.Text);
               using (ReportPrintTool printTool = new ReportPrintTool(rpt))
               {
                   printTool.ShowPreviewDialog();
               }
           }
           catch (Exception ex)
           {
               MessageBox.Show(ex.Message);
           }
       }

       private void btnDeces_Click(object sender, EventArgs e)
       {
           try
           {
               ActeDeces rpt = new ActeDeces();
               rpt.DataSource = clsGlossiaires.GetInstance().get_Report_one("acteDeces", "id_declarant", TextIdDeclaration.Text);
               using (ReportPrintTool printTool = new ReportPrintTool(rpt))
               {
                   printTool.ShowPreviewDialog();
               }
           }
           catch (Exception ex)
           {
               MessageBox.Show(ex.Message);
           }
       }

       private void materialButton1_Click(object sender, EventArgs e)
       {
           try
           {
               ListeDeces rpt = new ListeDeces();
               rpt.DataSource = clsGlossiaires.GetInstance().rapport_par_date("getdeath", " where createdate>='" + debut.Value.ToString("yyyy-MM-dd") + "' and createdate<='" + fin.Value.ToString("yyyy-MM-dd") + "'");
               using (ReportPrintTool printTool = new ReportPrintTool(rpt))
               {
                   printTool.ShowPreviewDialog();
               }
           }
           catch (Exception ex)
           {
               MessageBox.Show(ex.Message);
           }
       }

       private void TextSearchPersonne_KeyPress(object sender, KeyPressEventArgs e)
       {
          
           String td=TextSearchPersonne.Text;
           SqlCommand cmd = new SqlCommand("select p.id_personne,p.nom,p.postnom,p.prenom,p.sexe,p.lieunaissance,p.datenaissance,p.proffession,p.etatcivile,p.nompere,p.nommere,p.numerocartenational,a.designationavenue,p.Etat,p.createdat from personne p inner join avenue a on p.idavenu=a.id_avenue where  p.nom like '" + td + "%' or p.nom like '%" + td + "%' and p.postnom like '" + td + "%' or p.postnom like '%" + td + "%' and p.prenom like '" + td + "%' or p.prenom like '%" + td + "%'", conn);
           SqlDataAdapter adapter = new SqlDataAdapter(cmd);
           DataTable table = new DataTable();
           adapter.Fill(table);
           DataGridViewPersonne.DataSource = table;
       }

       private void listePersonnepardate_Click(object sender, EventArgs e)
       {
           try
           {
               ListPersonne rpt = new ListPersonne();
               rpt.DataSource = clsGlossiaires.GetInstance().get_Report_liste("getpersonne");
               using (ReportPrintTool printTool = new ReportPrintTool(rpt))
               {
                   printTool.ShowPreviewDialog();
               }
           }
           catch (Exception ex)
           {
               MessageBox.Show(ex.Message);
           }
       }

       private void DataGridViewPersonneDeclaree_CellContentClick(object sender, DataGridViewCellEventArgs e)
       {

       }

       private void DataGridViewPersonneDeclarant_Click(object sender, EventArgs e)
       {
           var row = DataGridViewPersonneDeclarant.CurrentRow;
           ComboBoxDeclarant.Text = "" + DataGridViewPersonneDeclarant.CurrentRow.Cells[1].Value.ToString();
       }

       private void DataGridViewPersonneDeclaree_Click(object sender, EventArgs e)
       {
           var row = DataGridViewPersonneDeclaree.CurrentRow;
           ComboBoxDeclaree.Text = "" + DataGridViewPersonneDeclaree.CurrentRow.Cells[1].Value.ToString();
           
       }

       private void materialButton4_Click(object sender, EventArgs e)
       {
           try
           {
               listeNaissance rpt = new listeNaissance();
               rpt.DataSource = clsGlossiaires.GetInstance().rapport_par_date("getbirth", " where createdate>='" + debut.Value.ToString("yyyy-MM-dd") + "' and createdate<='" + fin.Value.ToString("yyyy-MM-dd") + "'");
               using (ReportPrintTool printTool = new ReportPrintTool(rpt))
               {
                   printTool.ShowPreviewDialog();
               }
           }
           catch (Exception ex)
           {
               MessageBox.Show(ex.Message);
           }

       }

       private void searcheDataDeclaration_KeyPress(object sender, KeyPressEventArgs e)
       {
           
       }

       private void searchDeclarant_KeyPress(object sender, KeyPressEventArgs e)
       {
           String td = searchDeclarant.Text;
           (DataGridViewPersonneDeclarant.DataSource as DataTable).DefaultView.RowFilter = string.Format("nom like '{0}%' OR postnom like '{0}%' OR prenom like '{0}%'", td);

       }

       private void searchDeclaree_KeyPress(object sender, KeyPressEventArgs e)
       {
           String td = searchDeclaree.Text;
           (DataGridViewPersonneDeclaree.DataSource as DataTable).DefaultView.RowFilter = string.Format("nom like '{0}%' OR postnom like '{0}%' OR prenom like '{0}%'", td);

       }

       private void materialLabel30_Click(object sender, EventArgs e)
       {
           
       }

       private void btnSaveContact_Click(object sender, EventArgs e)
       {
           this.idpersonneContact = Convert.ToInt16(ComboBoxPersonneContact.SelectedValue);
           this.numeroTel = Convert.ToInt32(TextNumeroTel.Text);

           int succ = ct.insert(this.numeroTel, this.idpersonneContact);
           if (succ > 0)
           {
               MessageBox.Show("insertion contact avec succes");
               DataGridViewContact.DataSource = ct.getContact();
               
               loading_database();
           }
           else
           { MessageBox.Show("erreur"); }
       }

       private void DataGridViewPersonneConatctReference_Click(object sender, EventArgs e)
       {
           var row = DataGridViewPersonneConatctReference.CurrentRow;
           ComboBoxPersonneContact.Text = "" + DataGridViewPersonneConatctReference.CurrentRow.Cells[1].Value.ToString();
       }

       private void btnUpdateContact_Click(object sender, EventArgs e)
       {
           this.idpersonneContact = Convert.ToInt16(ComboBoxPersonneContact.SelectedValue);
           this.numeroTel = Convert.ToInt32(TextNumeroTel.Text);

           if (this.id_contact > 0)
           {
               int c = ct.update(this.numeroTel, this.idpersonneContact, this.id_contact);

               MessageBox.Show("mise en jour du contact avec success");
               DataGridViewContact.DataSource = ct.getContact();
               loading_database();
           }
           else
           {
               MessageBox.Show("erreur");
           }
       }

       private void materialTextBox21_KeyPress(object sender, KeyPressEventArgs e)
       {
           String td = TextContact.Text;
           SqlCommand cmd = new SqlCommand("select p.id_personne,p.nom,p.postnom,p.prenom,p.Etat from personne p inner join avenue a on p.idavenu=a.id_avenue where  p.nom like '" + td + "%' or p.nom like '%" + td + "%' and p.postnom like '" + td + "%' or p.postnom like '%" + td + "%' and p.prenom like '" + td + "%' or p.prenom like '%" + td + "%'", conn);
           SqlDataAdapter adapter = new SqlDataAdapter(cmd);
           DataTable table = new DataTable();
           adapter.Fill(table);
           DataGridViewPersonneConatctReference.DataSource = table;
       }

       }
     
    }

