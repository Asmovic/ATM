using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace ATM.Models
{
    public class DBConnection
    {

        public string var1;
    public DBConnection()
    {
        //
        // TODO: Add constructor logic here
    }

    public static SqlConnection Connect()
    {
        string strConn = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
        SqlConnection objConn = new SqlConnection(strConn);

        if (objConn.State != System.Data.ConnectionState.Open)
            objConn.Open();

        return objConn;
    }
    //
    }
}