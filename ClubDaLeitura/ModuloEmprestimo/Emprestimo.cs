using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubDaLeitura.Heritage;

namespace ClubDaLeitura.ModuloEmprestimo
{
    public class Emprestimo: Entidade
    {
        public bool emAberto;
        public Amigo amigoQueEmprestou;
        public Revista revistaEmprestada;
        public DateTime dataDoEmpresimo;
        public DateTime dataDeDevolução;
    }
}
