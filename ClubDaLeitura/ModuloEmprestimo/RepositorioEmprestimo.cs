using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubDaLeitura.Heritage;
using System.Collections;

namespace ClubDaLeitura.ModuloEmprestimo
{
    public class RepositorioEmprestimo : Repositorio
    {
        public void InserirEmprestimo(Emprestimo emprestimo)
        {
            emprestimo.id = id;
            listaEntidades.Add(emprestimo);
            IncrementaId();
        }
        public List<Object> RetornarTodososEmprestimos()
        {
            return listaEntidades;
        }
        public void AtualizaEmprestimo(int id, Emprestimo emprestimo)
        {
            foreach (Emprestimo e in listaEntidades)
            {
                if (BuscaEmprestimo(id).Equals(e))
                {
                    e.emAberto = true;
                    e.amigoQueEmprestou = emprestimo.amigoQueEmprestou;
                    e.revistaEmprestada = emprestimo.revistaEmprestada;
                    e.dataDoEmpresimo = emprestimo.dataDoEmpresimo;
                    e.dataDeDevolução = emprestimo.dataDeDevolução;

                }
            }
        }
        public Emprestimo BuscaEmprestimo(int id)
        {
            Emprestimo emprestimo = null;
            foreach (Emprestimo e in listaEntidades)
            {
                if (e.id == id)
                {
                    emprestimo = e;
                    return emprestimo;
                }
            }
            return emprestimo;
        }
        public void DeletaEmprestimo(int id)
        {
            foreach (Emprestimo r in listaEntidades)
            {
                if (BuscaEmprestimo(id).Equals(r))
                {
                    listaEntidades.Remove(r);
                    break;
                }
            }
        }
        public void FechaEmprestimo(int id)
        {
            foreach (Emprestimo r in listaEntidades)
            {
                if (BuscaEmprestimo(id).Equals(r))
                {
                    r.emAberto = false;
                    break;
                }
            }
        }
    }
}
