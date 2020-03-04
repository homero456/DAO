using System;

using System.Configuration;


namespace Data.SQLServer
{
    public class DataBase
    {
        static public String ConnectionString
        {
            get
            {    // get connection string with name  database from  web.config.
                //return ConfigurationManager.AppSettings["database"];
                return ConfigurationManager.ConnectionStrings["database"].ConnectionString;
            }
        }
    }
}
