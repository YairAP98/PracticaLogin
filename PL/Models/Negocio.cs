using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.EnterpriseServices.Internal;
using System.Linq;
using System.Web;

namespace PL.Models
{
    public class Negocio
    {

        public bool result { get; set; }
        public int IdUsuario { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public static Models.Negocio Login(Models.Negocio negocio)
        {
            Models.Negocio objetonegocio = new Models.Negocio();
            try
            {

                using (SqlConnection context = new SqlConnection(Datos.Conexion.GetLogin()))
                {
                    string query = "SELECT IdUsuario, UserName, Password FROM Login WHERE UserName = @UserName";

                    SqlCommand cmd = new SqlCommand(query, context);
                    SqlParameter[] colleccion = new SqlParameter[1];

                    colleccion[0] = new SqlParameter("Username", SqlDbType.VarChar);
                    colleccion[0].Value = negocio.IdUsuario;
                    cmd.Parameters.AddRange(colleccion);


                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);



                    if (dt.Rows.Count < 0)
                    {
                        DataRow dr = dt.Rows[0];

                        negocio.IdUsuario = int.Parse(dr[0].ToString());
                        negocio.Username = dr[1].ToString();
                        negocio.Password = dr[2].ToString();
                        negocio.result = true;
                    }
                    else
                    {
                        negocio.result = false;

                    }
                }



            }
            catch (Exception)
            {

                negocio.result = false;
            }




            return negocio;
        }
    }
}