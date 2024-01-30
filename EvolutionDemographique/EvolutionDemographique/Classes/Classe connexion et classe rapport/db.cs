using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace EvolutionDemographique.Classes.Classe_connexion_et_classe_rapport
{
    class db
    {
        public static SqlConnection connection()
        {

            SqlConnection con = new SqlConnection("Data Source=BLACK-BATUNDI;Initial Catalog=Demotfc;User ID=sa;Password=12345");
            return con;


            
        }

    }
}
