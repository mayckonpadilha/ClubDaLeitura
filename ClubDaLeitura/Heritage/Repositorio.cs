using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubDaLeitura.Heritage
{
    public class Repositorio
    {
        public int id = 1;
        public List<Object> listaEntidades = new List<Object>();
        public int IncrementaId()
        
        {
            return id++;
        }
    }
}
