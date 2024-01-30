using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using EvolutionDemographique.Classes.Classe_connexion_et_classe_rapport;
namespace EvolutionDemographique.Classes.Classe_Adresses
{
    class Commune
    {

        SqlConnection conn = db.connection();

        public int insert(string designationcommune, int idville)
        {
            SqlCommand cmd = new SqlCommand("proccommune", conn);
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "insert");
            cmd.Parameters.AddWithValue("@designation", designationcommune);
            cmd.Parameters.AddWithValue("@idville", idville);
            conn.Open();
            int resultat = cmd.ExecuteNonQuery();
            conn.Close();
            return resultat;

        }
        public int update(string designationcommune, int idville, int id_commune)
        {
            SqlCommand cmd = new SqlCommand("proccommune", conn);
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "update");
            cmd.Parameters.AddWithValue("@idcommune", id_commune);
            cmd.Parameters.AddWithValue("@designation", designationcommune);
            cmd.Parameters.AddWithValue("@idville", idville);
            conn.Open();
            int resultat = cmd.ExecuteNonQuery();
            conn.Close();
            return resultat;
        }

        public int delete(int id_commune)
        {
            SqlCommand cmd = new SqlCommand("proccommune", conn);
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "delete");
            cmd.Parameters.AddWithValue("@idcommune", id_commune);
            conn.Open();
            int resultat = cmd.ExecuteNonQuery();
            conn.Close();
            return resultat;
        }

        public DataTable getCommune()
        {
            SqlCommand cmd = new SqlCommand("select * from commune", conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
    }
}
