using System;
using WindowsFormTesteLogica;

namespace TesteLogica
{
    public class Network : NetworkAbstratct
    {
        public override int[] Construtor(int elementos)
        {
            var arrary = new int[elementos];

            for (int i = 1; i < elementos; i++)
            {
                arrary[i] = i;
            }
            return arrary;
        }

        public override int Conectar(int a, int b)
        {
            throw new NotImplementedException();
        }

        public override int Consultar(int a, int b)
        {
            throw new NotImplementedException();
        }
    }
}
