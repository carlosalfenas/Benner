using System;
using System.Collections.Generic;
using System.Linq;
using Ado;
using System.Data;

namespace Repository
{
    /// <summary>
    /// Todo: Classe Intermediaria, caso queria usar outros tipos de conexao como Entity Framework...etc.. 
    /// </summary>
    public sealed class RepPrecos
    {
        private readonly AdoPreco repositorio;
      

        public RepPrecos()
        {
            repositorio = new AdoPreco();   
        }

        public int Create(Entities.Precos e)
        {
            return repositorio.CreatePreco(e);
        }

        public int Update(Entities.Precos e)
        {
            return repositorio.UpdatePreco(e);
        }
        
        public bool Delete(int Id)
        {
           return repositorio.DeletePreco(Id);
        }

        public DataTable Read(int? IdPreco, int? Flag)
        {
            return repositorio.ReadPreco(IdPreco, Flag);
        }

        public void ClearFlag()
        {
            repositorio.ClearFlag();
        }
    }
}
