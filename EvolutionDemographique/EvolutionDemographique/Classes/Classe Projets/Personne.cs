using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using EvolutionDemographique.Classes.Classe_connexion_et_classe_rapport;

namespace EvolutionDemographique.Classes.Classe_Projets
{
    class Personne
    {
        SqlConnection conn = db.connection();

        public int insert(string nom, string postnom, string prenom, string sexe,string lieunaissance,DateTime date,string profession,string etatcivil, string nompere, string nommere, string numerocartenational,int idadress)
        {
            SqlCommand cmd = new SqlCommand("personnes", conn);
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "insert");
            cmd.Parameters.AddWithValue("@nom ", nom);
            cmd.Parameters.AddWithValue("@postnom ", postnom);
            cmd.Parameters.AddWithValue("@prenom ", prenom);
            cmd.Parameters.AddWithValue("@sexe ", sexe);
            cmd.Parameters.AddWithValue("@lieunaissance ", lieunaissance);
            cmd.Parameters.AddWithValue("@datenaissance ", date);
            cmd.Parameters.AddWithValue("@proffession ", profession);
            cmd.Parameters.AddWithValue("@etatcivil ", etatcivil);
            cmd.Parameters.AddWithValue("@nompere ", nompere);
            cmd.Parameters.AddWithValue("@nommere ", nommere);
            cmd.Parameters.AddWithValue("@numerocartenational ", numerocartenational);
            cmd.Parameters.AddWithValue("@idavenu ", idadress);
            cmd.Parameters.Add("@statuscode", SqlDbType.Int).Direction = ParameterDirection.Output;
            conn.Open();
             cmd.ExecuteNonQuery();
             int resultat = Convert.ToInt32(cmd.Parameters["@statuscode"].Value);
            conn.Close();
            return resultat;

        }
        public int update (string nom, string postnom, string prenom, string sexe, string lieunaissance, DateTime date, string profession, string etatcivil, string nompere, string nommere, string numerocartenational, int idadress, int id_personne)
        {
            SqlCommand cmd = new SqlCommand("personnes", conn);
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "update");
            cmd.Parameters.AddWithValue("@idpersonne", id_personne);
            cmd.Parameters.AddWithValue("@nom ", nom);
            cmd.Parameters.AddWithValue("@postnom ", postnom);
            cmd.Parameters.AddWithValue("@prenom ", prenom);
            cmd.Parameters.AddWithValue("@sexe ", sexe);
            cmd.Parameters.AddWithValue("@lieunaissance ", lieunaissance);
            cmd.Parameters.AddWithValue("@datenaissance ", date);
            cmd.Parameters.AddWithValue("@proffession ", profession);
            cmd.Parameters.AddWithValue("@etatcivil ", etatcivil);
            cmd.Parameters.AddWithValue("@nompere ", nompere);
            cmd.Parameters.AddWithValue("@nommere ", nommere);
            cmd.Parameters.AddWithValue("@numerocartenational ", numerocartenational);
            cmd.Parameters.AddWithValue("@idavenu ", idadress);
            cmd.Parameters.Add("@statuscode", SqlDbType.Int).Direction = ParameterDirection.Output;
            conn.Open();
            int resultat = cmd.ExecuteNonQuery();
            conn.Close();
            return resultat;
        }

        public int delete(int id_personne)
        {
            SqlCommand cmd = new SqlCommand("personnes", conn);
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "suppression");
            cmd.Parameters.AddWithValue("@idpersonne", id_personne);
            cmd.Parameters.Add("@statuscode", SqlDbType.Int).Direction = ParameterDirection.Output;
            conn.Open();
            int resultat = cmd.ExecuteNonQuery();
            conn.Close();
            return resultat;
        }

        public DataTable getPersonne()
        {
            SqlCommand cmd = new SqlCommand("select * from getpersonne", conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public DataTable getPersonneVerifier()
        {
            SqlCommand cmd = new SqlCommand("select p.id_personne,p.nom,p.postnom,p.prenom,p.sexe,p.lieunaissance,p.datenaissance,p.proffession,p.etatcivile,p.nompere,p.nommere,p.numerocartenational,a.designationavenue,p.Etat,p.createdat from personne p inner join avenue a on p.idavenu=a.id_avenue  where p.Etat in (select Etat from personne where Etat='vivante')", conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public DataTable getPersonneContact()
        {
            SqlCommand cmd = new SqlCommand("select * from getpersonnecontact", conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
    }
}
