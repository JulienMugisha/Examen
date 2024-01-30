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
    class Quartier
    {
        SqlConnection conn = db.connection();

        public int insert(string designationquartier, int idcommune)
        {
            SqlCommand cmd = new SqlCommand("proquartier", conn);
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "insert");
            cmd.Parameters.AddWithValue("@designation", designationquartier);
            cmd.Parameters.AddWithValue("@idcommune", idcommune);
            conn.Open();
            int resultat = cmd.ExecuteNonQuery();
            conn.Close();
            return resultat;

        }
        public int update(string designationquartier, int idcommune, int id_quartier)
        {
            SqlCommand cmd = new SqlCommand("proquartier", conn);
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "update");
            cmd.Parameters.AddWithValue("@idquartier", id_quartier);
            cmd.Parameters.AddWithValue("@designation", designationquartier);
            cmd.Parameters.AddWithValue("@idcommune", idcommune);
            conn.Open();
            int resultat = cmd.ExecuteNonQuery();
            conn.Close();
            return resultat;
        }

        public int delete(int id_quartier)
        {
            SqlCommand cmd = new SqlCommand("proquartier", conn);
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "delete");
            cmd.Parameters.AddWithValue("@idquartier", id_quartier);
            conn.Open();
            int resultat = cmd.ExecuteNonQuery();
            conn.Close();
            return resultat;
        }

        public DataTable getQuartier()
        {
            SqlCommand cmd = new SqlCommand("select * from quartier", conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
    }
}
