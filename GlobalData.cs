using System;


public class GlobalData
{
    // you can read connection string from web.config/app.config
    // Connect to database
    SqlConnection con = new SqlConnection("data source = " + HostConexion + "; initial catalog = dbSIA; user id = " + user + "; password = " + pass + "";");
    public GlobalData() { }
    public DataTable GetData(string query)
    {
        SqlDataAdapter da = new SqlDataAdapter(query, con);
        DataTable dtToReturn = new DataTable();
        da.Fill(dtToReturn);
        return dtToReturn;
    }
}
