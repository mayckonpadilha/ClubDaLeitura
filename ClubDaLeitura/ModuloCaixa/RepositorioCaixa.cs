using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubDaLeitura.Heritage;

namespace ClubDaLeitura.ModuloCaixa
{
     public class RepositorioCaixa : Repositorio
    {
        public void InserirCaixas(Caixa caixa)
        {
            caixa.id = id;
            listaEntidades.Add(caixa);
            IncrementaId();
        }

        public List<Object> MostraTodasAsCaixas()
        {
            return listaEntidades;
        }
        public void AtualizaCaixas(int id, Caixa caixaRevistas)
        {
            foreach (Caixa c in listaEntidades)
            {
                if (BuscaCaixas(id).Equals(c))
                {
                    c.cor = caixaRevistas.cor;
                    c.etiqueta = caixaRevistas.etiqueta;
                    c.numero = caixaRevistas.numero;
                }
            }
        }
        public void DeletaCaixas(int id)
        {
            foreach (Caixa c in listaEntidades)
            {
                if (BuscaCaixas(id).Equals(c))
                {
                    listaEntidades.Remove(c);
                    break;
                }
            }
        }
        public Caixa BuscaCaixas(int id)
        {
            Caixa caixa = null;

            foreach (Caixa c in listaEntidades)
            {
                if (c.id == id)
                {
                    caixa = c;
                    return caixa;
                }
            }
            return caixa;
        }
    }
}
