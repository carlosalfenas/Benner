using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
   public class EntradaSaida
    {
        public int IdEntradaSaida { get; set; }
        public string PlacaVeiculo { get; set; }   
        public DateTime DataCadastro { get; set; }
        public DateTime DataAlteracao { get; set; }
        public DateTime HorarioChegada { get; set; }
        public DateTime HorarioSaida { get; set; }
        public DateTime Duracao { get; set; }
        public int TempoCobrado { get; set; }
        public int IdPreco { get; set; }
        public double ValorPagar { get; set; }
        public byte Ativo { get; set; }
         
    }
}
