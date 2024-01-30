using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using EvolutionDemographique.Classes.Classe_connexion_et_classe_rapport;

namespace EvolutionDemographique.Classes
{
    class TypeAgent
    {
         SqlConnection conn = db.connection();

        public int insert(string designationdeclarant)
        {
            SqlCommand cmd = new SqlCommand("proctypeagent", conn);
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "insert");
            cmd.Parameters.AddWithValue("@designation", designationdeclarant);
            conn.Open();
            int resultat = cmd.ExecuteNonQuery();
            conn.Close();
            return resultat;

        }
        public int update(string designationdeclarant, int id_typeagent)
        {
            SqlCommand cmd = new SqlCommand("proctypeagent", conn);
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "update");
            cmd.Parameters.AddWithValue("@idtypeagent", id_typeagent);
            cmd.Parameters.AddWithValue("@designation", designationdeclarant);
            conn.Open();
            int resultat = cmd.ExecuteNonQuery();
            conn.Close();
            return resultat;
        }

        public int delete(int id_typeagent)
        {
            SqlCommand cmd = new SqlCommand("proctypeagent", conn);
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "delete");
            cmd.Parameters.AddWithValue("@idtypeagent", id_typeagent);
            conn.Open();
            int resultat = cmd.ExecuteNonQuery();
            conn.Close();
            return resultat;
        }

        public DataTable getTypeAgent()
        {
            SqlCommand cmd = new SqlCommand("select * from typeagent", conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

    }
 }

