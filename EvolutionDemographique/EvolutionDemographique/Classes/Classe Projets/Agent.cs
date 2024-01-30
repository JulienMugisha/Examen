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
    class Agent
    {
        SqlConnection conn = db.connection();

        public int insert(int idpersonne, int idtypeagent, int idservice)
        {
            SqlCommand cmd = new SqlCommand("procagent", conn);
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "insert");
            cmd.Parameters.AddWithValue("@idpersonne", idpersonne);
            cmd.Parameters.AddWithValue("@idtypeagent", idtypeagent);
            cmd.Parameters.AddWithValue("@idservice", idservice);
            conn.Open();
            int resultat = cmd.ExecuteNonQuery();
            conn.Close();
            return resultat;

        }
        public int update(int idpersonne, int idtypeagent, int idservice, int id_agent)
        {
            SqlCommand cmd = new SqlCommand("procagent", conn);
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "update");
            cmd.Parameters.AddWithValue("@idagent", id_agent);
            cmd.Parameters.AddWithValue("@idpersonne", idpersonne);
            cmd.Parameters.AddWithValue("@idtypeagent", idtypeagent);
            cmd.Parameters.AddWithValue("@idservice", idservice);
            conn.Open();
            int resultat = cmd.ExecuteNonQuery();
            conn.Close();
            return resultat;
        }

        public int delete(int id_agent)
        {
            SqlCommand cmd = new SqlCommand("procagent", conn);
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "delete");
            cmd.Parameters.AddWithValue("@idagent", id_agent);
            conn.Open();
             int resultat = cmd.ExecuteNonQuery();
            conn.Close();
            return resultat;
        }

        public DataTable getAgent()
        {
            SqlCommand cmd = new SqlCommand("select * from getagent", conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

    }
}
