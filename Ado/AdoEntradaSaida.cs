using Benner.REPOSITORIO;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Ado
{
    public class AdoEntradaSaida
    {
        internal Contexto contexto;

        public int CreateEntrada(Entities.EntradaSaida es)
        {
            try
            {
                using (contexto = new Contexto())
                {
                    var cmd = contexto.Comando();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "CreateEntradaSaida";
                    cmd.Parameters.AddWithValue("@PlacaVeiculo", SqlDbType.VarChar).Value = es.PlacaVeiculo;             
                    cmd.Parameters.AddWithValue("@DataCadastro", SqlDbType.DateTime).Value = DateTime.Now;
                    cmd.Parameters.AddWithValue("@DataAlteracao", SqlDbType.DateTime).Value = DateTime.Now;
                    cmd.Parameters.AddWithValue("@HorarioChegada", SqlDbType.DateTime).Value = es.HorarioChegada;
                    //cmd.Parameters.AddWithValue("@HorarioSaida", SqlDbType.DateTime).Value = es.HorarioSaida;
                    //cmd.Parameters.AddWithValue("@Duracao", SqlDbType.DateTime).Value = es.Duracao;
                    //cmd.Parameters.AddWithValue("@TempoCobrado", SqlDbType.Float).Value = es.TempoCobrado;
                    //cmd.Parameters.AddWithValue("@IdPreco", SqlDbType.Int).Value = es.IdPreco;
                    //cmd.Parameters.AddWithValue("@ValorPagar", SqlDbType.Int).Value = es.ValorPagar;
                    Int32 idretorno = Convert.ToInt32(cmd.ExecuteScalar());
                    return idretorno;
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int UpdateEntrada(Entities.EntradaSaida es)
        {
            try
            {
                using (contexto = new Contexto())
                {
                    var cmd = contexto.Comando();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "UpdateEntradaSaida";
                    cmd.Parameters.AddWithValue("@IdEntradaSaida", SqlDbType.Float).Value = es.IdEntradaSaida;
                    cmd.Parameters.AddWithValue("@PlacaVeiculo", SqlDbType.VarChar).Value = es.PlacaVeiculo;
                    cmd.Parameters.AddWithValue("@DataAlteracao", SqlDbType.DateTime).Value = DateTime.Now;
                    cmd.Parameters.AddWithValue("@HorarioChegada", SqlDbType.DateTime).Value = es.HorarioChegada;
                    cmd.Parameters.AddWithValue("@HorarioSaida", SqlDbType.DateTime).Value = es.HorarioSaida;
                    cmd.Parameters.AddWithValue("@Duracao", SqlDbType.DateTime).Value = es.Duracao;
                    cmd.Parameters.AddWithValue("@TempoCobrado", SqlDbType.Float).Value = es.TempoCobrado;
                    cmd.Parameters.AddWithValue("@IdPreco", SqlDbType.Int).Value = es.IdPreco;
                    cmd.Parameters.AddWithValue("@ValorPagar", SqlDbType.Int).Value = es.ValorPagar;
                    cmd.ExecuteNonQuery();
                    return 1;
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
 
        public bool DeleteEntrada(int IdEntradaSaida)
        {
            try
            {
                using (contexto = new Contexto())
                {
                    var cmd = contexto.Comando();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "DeleteEntradaSaida";
                    cmd.Parameters.AddWithValue("@IdEntradaSaida", SqlDbType.Float).Value = IdEntradaSaida;
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public DataTable ReadEntradaSaida(int? IdEntradaSaida)
        {
            DataTable dt = new DataTable();
            try
            {
                using (contexto = new Contexto())
                {
                    var cmd = contexto.Comando();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "ReadEntradaSaida";
                    if (IdEntradaSaida > 0)
                        cmd.Parameters.AddWithValue("@IdEntradaSaida", SqlDbType.Int).Value = IdEntradaSaida;
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    dataAdapter.SelectCommand = cmd;
                    dataAdapter.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
