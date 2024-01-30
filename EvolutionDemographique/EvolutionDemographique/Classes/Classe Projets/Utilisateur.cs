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
    class Utilisateur
    {
        public string CodeUtilisateur { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
       


        public int Ajouter(Utilisateur utilisateur)
        {
            int resultat = 0;
            string query = "insert into users(username,password) values ('" + utilisateur.Username + "','" + utilisateur.Password + "')";
            SqlCommand cmd;
            if (Dataconnexion.Instance.Connection())
            {
                cmd = new SqlCommand(query, Dataconnexion.Instance.con);
                resultat = cmd.ExecuteNonQuery();
            }
            return resultat;
        }
        //-------------------------------------------
        public List<Utilisateur> getUtilisateurs()
        {
            List<Utilisateur> list = new List<Utilisateur>();
            string query = "select *from users ";
            SqlCommand cmd;
            if (Dataconnexion.Instance.Connection())
            {
                cmd = new SqlCommand(query, Dataconnexion.Instance.con);
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    Utilisateur utilisateur = new Utilisateur();
                    utilisateur.CodeUtilisateur = rd["id"].ToString();
                    utilisateur.Username = rd["username"].ToString();
                    utilisateur.Password = rd["password"].ToString();
                    list.Add(utilisateur);

                }
            }
            return list;
        }
        //-----------------------------------------------------
        public int Modifier(Utilisateur utilisateur)
        {
            int resultat = 0;
            string query = "update users set username='" + utilisateur.Username + "', password='" + utilisateur.Password + "' where id='" + utilisateur.CodeUtilisateur + "'";

            if (Dataconnexion.Instance.Connection())
            {
                SqlCommand cmd = new SqlCommand(query, Dataconnexion.Instance.con);
                resultat = cmd.ExecuteNonQuery();

            }


            return resultat;
        }
        //-------------------------------------------------

        public int Supprimer(string id)
        {
            int resultat = 0;
            string query = " delete from users where id='" + id + "'";
            if (Dataconnexion.Instance.Connection())
            {
                SqlCommand cmd = new SqlCommand(query, Dataconnexion.Instance.con);
                resultat = cmd.ExecuteNonQuery();
            }
            return resultat;
        }
    }
}
