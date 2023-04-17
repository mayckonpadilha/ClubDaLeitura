using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubDaLeitura.Heritage;

namespace ClubDaLeitura
{
    public class Revista: Entidade
    {
        public string colecao;
        public bool estaEmprestada;
        public string edicao;
        public DateTime anoDaRevista;
        public Caixa caixa;
    }
}
