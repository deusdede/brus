using FluentProject.Persistencia;
using Modelos;
using System;

namespace FluentProject
{
    class Program
    {
        static void Main()
        {

            PFluent persistencia = new PFluent();

            var fabrica = persistencia.CreateSessionFactory();

            Usuario usuario = persistencia.getUsuario(1);

            var incluir = false;

            if (incluir) {
                var tarefa = new Tarefa();
                tarefa.Descricao = "Enviar artefatos para o André";
                tarefa.DataAgendamento = DateTime.Parse("2020-03-20");
                tarefa.Usuario = usuario;

                persistencia.IncluirTarefa(tarefa);

            }

            persistencia.ListarUsuarios();
            persistencia.ListarTarefas();

            Console.WriteLine("Fim...");

            Console.ReadLine();

        }

    }
}


