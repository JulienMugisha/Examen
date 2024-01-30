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
    class Declaration
    {
          SqlConnection conn = db.connection();

          public int insert(string motif, DateTime createdat, int idrefdeclarant, int idrefpersonnedeclare, int idtypedeclarant, int idagent)
        {
            SqlCommand cmd = new SqlCommand("procdeclaration", conn);
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "insert");
            cmd.Parameters.AddWithValue("@motif", motif);
            cmd.Parameters.AddWithValue("@date", createdat);
            cmd.Parameters.AddWithValue("@iddeclarant", idrefdeclarant);
            cmd.Parameters.AddWithValue("@idpersonnedeclare", idrefpersonnedeclare);
            cmd.Parameters.AddWithValue("@idtypedeclaration", idtypedeclarant);
            cmd.Parameters.AddWithValue("@idagent", idagent);
            
            conn.Open();
            int resultat = cmd.ExecuteNonQuery();
            conn.Close();
            return resultat;

        }
        public int update(string motif, DateTime createdat, int idrefdeclarant ,int idrefpersonnedeclare ,int idtypedeclarant, int id_declarant)
        {
            SqlCommand cmd = new SqlCommand("procdeclaration", conn);
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "update");
            cmd.Parameters.AddWithValue("@iddeclaration", id_declarant);
            cmd.Parameters.AddWithValue("@motif", motif);
            cmd.Parameters.AddWithValue("@date", createdat);
            cmd.Parameters.AddWithValue("@iddeclarant", idrefdeclarant);
            cmd.Parameters.AddWithValue("@idpersonnedeclare", idrefpersonnedeclare);
            cmd.Parameters.AddWithValue("@idtypedeclaration", idtypedeclarant);
            
            conn.Open();
            int resultat = cmd.ExecuteNonQuery();
            conn.Close();
            return resultat;
        }

        public int delete(int id_declarant)
        {
            SqlCommand cmd = new SqlCommand("procdeclaration", conn);
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "delete");
            cmd.Parameters.AddWithValue("@iddeclaration", id_declarant);
            conn.Open();
            int resultat = cmd.ExecuteNonQuery();
            conn.Close();
            return resultat;
        }

        public DataTable getDeclaration()
        {
            SqlCommand cmd = new SqlCommand("select * from getdeclaration", conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
    }
    
}
