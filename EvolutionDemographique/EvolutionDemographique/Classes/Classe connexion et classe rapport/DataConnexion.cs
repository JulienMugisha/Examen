using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace EvolutionDemographique.Classes.Classe_connexion_et_classe_rapport
{
    class Dataconnexion
    {
        public string serverName { get; set; }
        public string dataBase { get; set; }
        public string UserName { get; set; }
        public string pswd { get; set; }

        public static Dataconnexion instance;

        public static Dataconnexion Instance
        {
            get
            {
                if (instance == null)
                    instance = new Dataconnexion();
                return instance;
            }
        }

        public SqlConnection con = null;
        public bool Connection()
        {

            try
            {

                string connexionString = "Data source=" + serverName + ";" +
                                              "Initial Catalog=" + dataBase + ";" + "User id=" + UserName + ";" + "Password=" + pswd + ";";

                con = new SqlConnection(connexionString);
                con.Open();
                return true;
            }
            catch (SqlException ex)
            {
                Console.Out.WriteLine(ex.Message);
                return false;
            }


        }
    }
}
