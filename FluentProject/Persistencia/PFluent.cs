using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Modelos;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace FluentProject.Persistencia
{
    public class PFluent
    {
        private ISessionFactory secao;

        public PFluent()
        {
            secao = CreateSessionFactory();
        }
        public ISessionFactory CreateSessionFactory()
        {
            string stringConexao = ConfigurationManager.ConnectionStrings["brus"].ConnectionString;

            return Fluently.Configure()
                    .Database(MsSqlConfiguration.MsSql2008.ConnectionString(stringConexao))
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Program>())
                    .BuildSessionFactory();
        }

        internal void ListarUsuarios()
        {
            var usuarios = secao.OpenSession().QueryOver<Usuario>().List();

            foreach (var usuario in usuarios)
            {
                Console.WriteLine(usuario.Nome);
            }

        }
        internal void ListarTarefas()
        {
            var tarefas = secao.OpenSession().QueryOver<Tarefa>().List();

            foreach (var tarefa in tarefas)
            {
                Console.WriteLine($"{tarefa.Descricao} {tarefa.DataAgendamento}");
            }
        }
    }
   
}
