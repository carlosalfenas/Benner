using Ado;
using System.Data;

namespace Repository
{
    public sealed class RepEntradaSaida
    {
        private readonly AdoEntradaSaida repositorio;

        public RepEntradaSaida()
        {
            repositorio = new AdoEntradaSaida();
        }

        public int Create(Entities.EntradaSaida es)
        {
            return repositorio.CreateEntrada(es);
        }

        public int Update(Entities.EntradaSaida es)
        {
            return repositorio.UpdateEntrada(es);
        }

        public bool Delete(int Id)
        {
            return repositorio.DeleteEntrada(Id);
        }

        public DataTable Read(int? Id)
        {
            return repositorio.ReadEntradaSaida(Id);
        }
    
    }
}
