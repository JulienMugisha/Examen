using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using EvolutionDemographique.Classes.Classe_connexion_et_classe_rapport;

namespace EvolutionDemographique.Classes.Classe_Projets
{
    class Class_Login
    {
        public string nomutilisateur { get; set; }
        public string motdepass { get; set; }

        public string User(string username)
        {
            string password = "";
            string query = "select* from users where username='" + username + "'";
            SqlCommand cmd;
            if (Dataconnexion.Instance.Connection())
            {

                cmd = new SqlCommand(query, Dataconnexion.Instance.con);
                SqlDataReader rd = cmd.ExecuteReader();


                while (rd.Read())
                {

                    password = rd["password"].ToString();

                }

            }
            return password;
        }
    }
}

