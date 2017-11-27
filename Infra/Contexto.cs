using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Infra
{
    public class Contexto : IDisposable
    {
        private readonly SqlConnection cnn;
        private readonly SqlCommand cmd;

        public Contexto()
        {
            cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["strConnectionBenner"].ConnectionString);
            cnn.Open();
        }


        public SqlCommand Comando()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnn;
            return cmd;
        }


        public void Dispose()
        {
            if (cnn.State == ConnectionState.Open)
            {
                cnn.Close();
            }
        }
    }
}

