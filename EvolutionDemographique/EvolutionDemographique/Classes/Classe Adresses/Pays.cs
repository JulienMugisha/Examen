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
    class Pays
    {
        SqlConnection conn = db.connection();

        public int insert(string designationpay)
        {
            SqlCommand cmd = new SqlCommand("procpay", conn);
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "insert");
            cmd.Parameters.AddWithValue("@designation", designationpay);
            cmd.Parameters.AddWithValue("@idpays", 34);
            conn.Open();
            int resultat = cmd.ExecuteNonQuery();
            conn.Close();
            return resultat;

        }
        public int update(string designationpay, int id)
        {
            SqlCommand cmd = new SqlCommand("procpay", conn);
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "update");
            cmd.Parameters.AddWithValue("@idpays", id);
            cmd.Parameters.AddWithValue("@designation", designationpay);
            conn.Open();
            int resultat = cmd.ExecuteNonQuery();
            conn.Close();
            return resultat;
        }

        public int delete(int id)
        {
            SqlCommand cmd = new SqlCommand("procpay", conn);
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "delete");
            cmd.Parameters.AddWithValue("@idpays", id);
            conn.Open();
            int resultat = cmd.ExecuteNonQuery();
            conn.Close();
            return resultat;
        }

        public DataTable getPays()
        {
            SqlCommand cmd = new SqlCommand("select * from pays", conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

    }
}

