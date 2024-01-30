using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using EvolutionDemographique.Classes.Classe_connexion_et_classe_rapport;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows;

namespace EvolutionDemographique.Classes.Classe_Projets
{
    class Rapport_Dashboard
    {
        SqlConnection conn = db.connection();
        public int gettotalpersonne()
        {
            int total = 0;
            SqlCommand cmd = new SqlCommand("select * from totalpersonne", conn);
            conn.Open();
            SqlDataReader data = cmd.ExecuteReader();
            while (data.Read())
            {
                total = Convert.ToInt32(data[0]);
            }
            conn.Close();
            return total;

        }


        public void chargementChart(Chart graphique,string requete)
        {
            graphique.Series["Series1"].Points.Clear();
            try { 
              int total = 0;
            SqlCommand cmd = new SqlCommand(""+requete, conn);
            conn.Open();
            SqlDataReader data = cmd.ExecuteReader();
            while (data.Read())
            {
                graphique.Series["Series1"].Points.AddXY("" + data[0].ToString(), int.Parse(data[1].ToString()));
            }
            conn.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("erreur de chargement" + ex);
            }
          
           

        }


        public int gettotalDeces()
        {
            int total = 0;
            SqlCommand cmd = new SqlCommand("select * from  totaldeath", conn);
            conn.Open();
            SqlDataReader data = cmd.ExecuteReader();
            while (data.Read())
            {
                total = Convert.ToInt32(data[0]);
            }
            conn.Close();
            return total;

        }
        public int gettotalNaissance()
        {
            int total = 0;
            SqlCommand cmd = new SqlCommand("select * from totalnaissance", conn);
            conn.Open();
            SqlDataReader data = cmd.ExecuteReader();
            while (data.Read())
            {
                total = Convert.ToInt32(data[0]);
            }
            conn.Close();
            return total;

        }
    }
}
