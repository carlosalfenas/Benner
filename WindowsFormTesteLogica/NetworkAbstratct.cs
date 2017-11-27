using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormTesteLogica
{
   public abstract class NetworkAbstratct
    {
        public abstract int[] Construtor(int elementos);
        public abstract int Conectar(int a, int b);
        public abstract int Consultar(int a, int b);
    }
}
