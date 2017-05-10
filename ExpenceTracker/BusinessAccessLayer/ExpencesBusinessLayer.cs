using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace BusinessAccessLayer
{
    public class ExpencesBusinessLayer
    {
        public IEnumerable<Expences> ExpencesList
        {
            get
            {
                string connectionstring = ConfigurationManager.ConnectionStrings["ExpencesContext"].ConnectionString;

                List<Expences> expences = new List<Expences>();
                using (SqlConnection con = new SqlConnection(connectionstring)) {
                    SqlCommand cmd = new SqlCommand("GetExpenceDetails", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while(dr.Read())
                    {
                        Expences exp = new Expences();
                        exp.ExpenceID = Convert.ToInt32(dr["ExpenceID"]);
                        exp.ExpenceType = Convert.ToString(dr["ExpenceType"]);
                        exp.ExpenceAmt = Convert.ToInt32(dr["ExpenceAmt"]);
                        exp.ExpenceDate = Convert.ToDateTime(dr["ExpenceDate"]);
                        expences.Add(exp);
                    }
                }
                return expences;
            }
        }

        //public IEnumerable<Expences> SingleExpences
        //{
        //    get
        //    {
        //        string connectionstring = ConfigurationManager.ConnectionStrings["ExpencesContext"].ConnectionString;

        //        List<Expences> expences = new List<Expences>();
        //        using (SqlConnection con = new SqlConnection(connectionstring))
        //        {
        //            SqlCommand cmd = new SqlCommand("GetSingleExpenceDetails", con);
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@ExpenceID", expences.ExpenceID);
        //            con.Open();
        //            SqlDataReader dr = cmd.ExecuteReader();
        //            while (dr.Read())
        //            {
        //                Expences exp = new Expences();
        //                exp.ExpenceID = Convert.ToInt32(dr["ExpenceID"]);
        //                exp.ExpenceType = Convert.ToString(dr["ExpenceType"]);
        //                exp.ExpenceAmt = Convert.ToInt32(dr["ExpenceAmt"]);
        //                exp.ExpenceDate = Convert.ToDateTime(dr["ExpenceDate"]);
        //                expences.Add(exp);
        //            }
        //        }
        //        return expences;
        //    }
        //}
        public IEnumerable<ExpencesType> ExpencesType
        {
            get
            {
                string connectionstring = ConfigurationManager.ConnectionStrings["ExpencesContext"].ConnectionString;

                List<ExpencesType> expencestype = new List<ExpencesType>();
                using (SqlConnection con = new SqlConnection(connectionstring))
                {
                    SqlCommand cmd = new SqlCommand("GetExpenceTypeDetails", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        ExpencesType exptyp = new ExpencesType();
                        exptyp.ExpenceTypeID = Convert.ToInt32(dr["ExpenceTypeID"]);
                        exptyp.ExpenceType = Convert.ToString(dr["ExpenceType"]);

                        expencestype.Add(exptyp);
                    }
                }
                return expencestype;
            }
        }

        public void AddExpence(Expences expences)
        {
            string connectionstr = ConfigurationManager.ConnectionStrings["ExpencesContext"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionstr))
            {
                SqlCommand cmd = new SqlCommand("AddExpence", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ExpenceTypeID", expences.ExpenceType);
                cmd.Parameters.AddWithValue("@ExpenceAmt", expences.ExpenceAmt);
                cmd.Parameters.AddWithValue("@ExpenceDescription", expences.ExpenceDescription);
                
                cmd.Parameters.AddWithValue("@DOE", expences.ExpenceDate);
                con.Open();
                cmd.ExecuteNonQuery();

            }

        }
    }
}
        
    

        //using(SqlConnection con = new SqlConnection(connectionstring))
   


