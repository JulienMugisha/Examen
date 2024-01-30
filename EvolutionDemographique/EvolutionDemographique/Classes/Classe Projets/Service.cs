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
    class Service
    {
         SqlConnection conn = db.connection();
        
        public int insert(string designationservice)
        {
            SqlCommand cmd = new SqlCommand("procservice",conn);
            cmd.Connection=conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "insert");
            cmd.Parameters.AddWithValue("@designation", designationservice);
            conn.Open();
           int resultat=cmd.ExecuteNonQuery();
            conn.Close();
            return resultat;

        }
        public int update(string designationservice,int id_service)
        {
            SqlCommand cmd = new SqlCommand("procservice",conn);
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "update");
            cmd.Parameters.AddWithValue("@idservice", id_service);
            cmd.Parameters.AddWithValue("@designation", designationservice);
            conn.Open();
            int resultat=cmd.ExecuteNonQuery();
            conn.Close();
            return resultat;
        }

        public int delete(int id_service)
        {
            SqlCommand cmd = new SqlCommand("procservice",conn);
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "delete");
            cmd.Parameters.AddWithValue("@idservice", id_service);
            conn.Open();
            int x = cmd.ExecuteNonQuery();
            conn.Close();
            return x;
        }

        public DataTable getService()
        {
            SqlCommand cmd = new SqlCommand("select * from servicesE", conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return  table;
        }

        

    }
 }
