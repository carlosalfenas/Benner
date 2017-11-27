using System;

namespace Entities
{
    public class Precos
    {
        public int IdPreco { get; set; }
        public string Descricao{ get; set; }
        public double Preco { get; set; }
        public double PrecoAdicional { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAlteracao { get; set; }
        public byte Ativo { get; set; }   
        public bool Flag { get; set; } 
    }
}
