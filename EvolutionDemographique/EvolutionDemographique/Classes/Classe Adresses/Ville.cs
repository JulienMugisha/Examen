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
    class Ville
    {

        SqlConnection conn = db.connection();

        public int insert(string designationville, int idpay)
        {
            SqlCommand cmd = new SqlCommand("procville", conn);
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "insert");
            cmd.Parameters.AddWithValue("@designation", designationville);
            cmd.Parameters.AddWithValue("@idpay", idpay);
            conn.Open();
            int resultat = cmd.ExecuteNonQuery();
            conn.Close();
            return resultat;

        }
        public int update(string designationville,int idpay,  int id_ville)
        {
            SqlCommand cmd = new SqlCommand("procville", conn);
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "update");
            cmd.Parameters.AddWithValue("@idville", id_ville);
            cmd.Parameters.AddWithValue("@designation", designationville);
            cmd.Parameters.AddWithValue("@idpay", idpay);
            conn.Open();
            int resultat = cmd.ExecuteNonQuery();
            conn.Close();
            return resultat;
        }

        public int delete(int id_ville)
        {
            SqlCommand cmd = new SqlCommand("procville", conn);
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "delete");
            cmd.Parameters.AddWithValue("@idville",id_ville);
            conn.Open();
            int resultat = cmd.ExecuteNonQuery();
            conn.Close();
            return resultat;
        }

        public DataTable getVille()
        {
            SqlCommand cmd = new SqlCommand("select * from ville", conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

    }
}
