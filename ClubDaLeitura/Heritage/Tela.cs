using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubDaLeitura.Heritage
{
    public class Tela
    {
        public void ApresentaMensagem(string mensagem, ConsoleColor cor)
        {
            Console.ForegroundColor = cor;
            Console.WriteLine(mensagem);
            Console.ResetColor();
            Console.ReadKey();
        }
        public bool VerificaObjetosValidos(Object objeto)
        {
            if (objeto == null)
            {
                return false;
            }
            else
                return true;
        }
    }

}

