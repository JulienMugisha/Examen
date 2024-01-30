using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace EvolutionDemographique.Classes.Classe_connexion_et_classe_rapport
{
    class clsGlossiaires
    {
        clsConnexion cnx = null;
        private static clsGlossiaires glos;
        public SqlConnection con = null;
        public SqlCommand cmd = null;
        public SqlDataAdapter dt = null;
        public SqlDataReader dr = null;
        //DataSet ds = null;
        //innitialisation de la connexion
        public void innitialiseConnect()
        {
            try
            {
                cnx = new clsConnexion();
                con = new SqlConnection(clsConnexion.chemin);
            }
            catch (Exception)
            {
                throw new Exception("l'un de vos fichiers de configuration est incorrect");
            }

        }
        public static clsGlossiaires GetInstance()
        {
            if (glos == null)
                glos = new clsGlossiaires();
            return glos;
        }
        private static void setParameter(SqlCommand cmd, string name, DbType type, int length, object paramValue)
        {

            IDbDataParameter a = cmd.CreateParameter();
            a.ParameterName = name;
            a.Size = length;
            a.DbType = type;

            if (paramValue == null)
            {
                if (!a.IsNullable)
                {
                    a.DbType = DbType.String;
                }
                a.Value = DBNull.Value;
            }
            else
                a.Value = paramValue;
            cmd.Parameters.Add(a);

        }

        //=============================================================================================================================================
        //============================= LES REPORTS ============================================================================================


        public DataSet Rapport_Procedure_Date(string nomTable, string nomChamp, DateTime date1, DateTime date2)
        {
            DataSet dst;
            try
            {
                innitialiseConnect();
                if (!con.State.ToString().ToLower().Equals("open")) con.Open();
                cmd = new SqlCommand("select * from " + nomTable + " where " + nomChamp + " between @date1 and @date2", con);
                setParameter(cmd, "@date1", DbType.Date, 20, date1);
                setParameter(cmd, "@date2", DbType.Date, 20, date2);
                dt = new SqlDataAdapter(cmd);
                dst = new DataSet();
                dt.Fill(dst, nomTable);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                dt.Dispose(); con.Close();
            }
            return dst;
        }


        public DataSet get_Report_Trie(string nomTable, string nomchamp, string valchamp)
        {
            DataSet dst;
            try
            {
                innitialiseConnect();
                if (!con.State.ToString().ToLower().Equals("open")) con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM " + nomTable + " WHERE " + nomchamp + "=@valchamp", con);
                cmd.Parameters.AddWithValue("@valchamp", valchamp);
                dt = new SqlDataAdapter(cmd);
                dst = new DataSet();
                dt.Fill(dst, nomTable);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                dt.Dispose(); con.Close();
            }
            return dst;
        }


        public DataSet get_Report_liste(string nomTable)
        {
            DataSet dst;
            try
            {
                innitialiseConnect();
                if (!con.State.ToString().ToLower().Equals("open")) con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM " + nomTable + " ", con);
                dt = new SqlDataAdapter(cmd);
                dst = new DataSet();
                dt.Fill(dst, nomTable);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                dt.Dispose(); con.Close();
            }
            return dst;
        }

       



        public DataSet rapport_par_date(string nomTable,string suite)
        {
            DataSet dst;
            try
            {
                innitialiseConnect();
                if (!con.State.ToString().ToLower().Equals("open")) con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM " + nomTable + " "+suite, con);
                dt = new SqlDataAdapter(cmd);
                dst = new DataSet();
                dt.Fill(dst, nomTable);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                dt.Dispose(); con.Close();
            }
            return dst;
        }



        public DataSet get_Report_S(string nomTable, string idTable)
        {
            DataSet dst;
            try
            {
                innitialiseConnect();
                if (!con.State.ToString().ToLower().Equals("open")) con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM " + nomTable + " ORDER BY" + idTable + "", con);
                dt = new SqlDataAdapter(cmd);
                dst = new DataSet();
                dt.Fill(dst, nomTable);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                dt.Dispose(); con.Close();
            }
            return dst;
        }
        public DataSet get_Report_one(string nomTable, string idNomTable, string idTable)
        {
            DataSet dst;
            try
            {
                innitialiseConnect();
                if (!con.State.ToString().ToLower().Equals("open")) con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM " + nomTable + " WHERE " + idNomTable + "=" + idTable + "", con);
                dt = new SqlDataAdapter(cmd);
                dst = new DataSet();
                dt.Fill(dst, nomTable);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                dt.Dispose(); con.Close();
            }
            return dst;
        }




    }
}
