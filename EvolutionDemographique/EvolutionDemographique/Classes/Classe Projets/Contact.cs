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
   
    class Contact
    {
        SqlConnection conn = db.connection();

        public int insert(int numeroTel, int personne)
        {
            SqlCommand cmd = new SqlCommand("procContatct", conn);
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "insert");
            cmd.Parameters.AddWithValue("@numero", numeroTel);
            cmd.Parameters.AddWithValue("@idpersonne", personne);
            conn.Open();
            int resultat = cmd.ExecuteNonQuery();
            conn.Close();
            return resultat;

        }
        public int update(int numeroTel, int idpersonne, int id_contact)
        {
            SqlCommand cmd = new SqlCommand("procContatct", conn);
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "update");
            cmd.Parameters.AddWithValue("@idcontact", id_contact);
            cmd.Parameters.AddWithValue("@numero", numeroTel);
            cmd.Parameters.AddWithValue("@idpersonne", idpersonne);
            conn.Open();
            int resultat = cmd.ExecuteNonQuery();
            conn.Close();
            return resultat;
        }

        public int delete(int id_contact)
        {
            SqlCommand cmd = new SqlCommand("procContatct", conn);
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "delete");
            cmd.Parameters.AddWithValue("@idcontact", id_contact);
            conn.Open();
            int resultat = cmd.ExecuteNonQuery();
            conn.Close();
            return resultat;
        }

        public DataTable getContact()
        {
            SqlCommand cmd = new SqlCommand("select * from getcontact", conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
    }
}
