using Persistencia;
using System;

namespace AgendamentoConsole
{
    class Program
    {
        public static void Main(string[] args)
        {
            DAO dao = new DAO();

            var usuario = dao.getUsuario(1);

            dao.ListarUsuarios();

            Console.WriteLine("Fim...");
        }
    }
}
