using Benner.REPOSITORIO;
using System;
using System.Data;
using System.Data.SqlClient;

namespace  Ado
{
    public class AdoPreco
    {
        internal Contexto contexto;       

        public int CreatePreco(Entities.Precos e)
        {
            try
            {
                using (contexto = new Contexto())
                {
                    var cmd = contexto.Comando();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "CreatePreco";
                    cmd.Parameters.AddWithValue("@Descricao", SqlDbType.Float).Value = e.Descricao;
                    cmd.Parameters.AddWithValue("@Preco", SqlDbType.Float).Value = e.Preco;
                    cmd.Parameters.AddWithValue("@PrecoAdicional", SqlDbType.Float).Value = e.PrecoAdicional;
                    cmd.Parameters.AddWithValue("@DataCadastro", SqlDbType.DateTime).Value = DateTime.Now;
                    cmd.Parameters.AddWithValue("@DataAlteracao", SqlDbType.DateTime).Value = DateTime.Now;
                    cmd.Parameters.AddWithValue("@Flag", SqlDbType.Bit).Value = e.Flag;
                    Int32 idretorno = Convert.ToInt32(cmd.ExecuteScalar());
                    return idretorno;
                }                
            }
            catch (Exception ex)
            {
                return 0;
            }
        }            

        public int UpdatePreco(Entities.Precos e)
        {
            try
            {
                using (contexto = new Contexto())
                {
                    var cmd = contexto.Comando();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "UpdatePreco";
                    cmd.Parameters.AddWithValue("@IdPreco", SqlDbType.Float).Value = e.IdPreco;
                    cmd.Parameters.AddWithValue("@Descricao", SqlDbType.Float).Value = e.Descricao;
                    cmd.Parameters.AddWithValue("@Preco", SqlDbType.Float).Value = e.Preco;
                    cmd.Parameters.AddWithValue("@PrecoAdicional", SqlDbType.Float).Value = e.PrecoAdicional;              
                    cmd.Parameters.AddWithValue("@DataAlteracao", SqlDbType.DateTime).Value = DateTime.Now;
                    cmd.Parameters.AddWithValue("@Flag", SqlDbType.Bit).Value = e.Flag;
                    cmd.ExecuteNonQuery();
                    return 1;
                }                
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public void ClearFlag()
        {
            try
            {
                using (contexto = new Contexto())
                {
                    var cmd = contexto.Comando();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "ClearFlags";              
                    cmd.ExecuteNonQuery();                     
                }
            }
            catch (Exception ex)
            {             
            }
        }

        public bool DeletePreco(int IdPreco)
        {
            try
            {
                using (contexto = new Contexto())
                {
                    var cmd = contexto.Comando();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "DeletePreco";
                    cmd.Parameters.AddWithValue("@IdPreco", SqlDbType.Float).Value = IdPreco;
                    cmd.ExecuteNonQuery();
                    return true;
                }                
            }
            catch (Exception ex)
            {
                return false;
            }
        }
             
        public DataTable ReadPreco(int? IdPreco, int? Flag)
        {
            DataTable dt = new DataTable();
            try
            {
                using (contexto = new Contexto())
                {
                    var cmd = contexto.Comando();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "ReadPreco";
                    if (IdPreco > 0)
                        cmd.Parameters.AddWithValue("@IdPreco", SqlDbType.Int).Value = IdPreco;

                    if (Flag > 0)
                        cmd.Parameters.AddWithValue("@Flag", SqlDbType.Int).Value = Flag;

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
