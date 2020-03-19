using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Modelos;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace Persistencia
{
    public class DAO
    {
        private ISessionFactory fabrica;

        public DAO()
        {
            fabrica = CreateSessionFactory();
        }
        public ISessionFactory CreateSessionFactory()
        {
            string stringConexao = ConfigurationManager.ConnectionStrings["brus"].ConnectionString;

            return Fluently.Configure()
                    .Database(MsSqlConfiguration.MsSql2008.ConnectionString(stringConexao))
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<DAO>())
                    .BuildSessionFactory();
        }

        public Usuario getUsuario(int id)
        {
            return fabrica.OpenSession().Get<Usuario>(id);
        }

        public void ListarUsuarios()
        {
            var usuarios = fabrica.OpenSession().QueryOver<Usuario>().List();

            foreach (var usuario in usuarios)
            {
                Console.WriteLine($"{usuario.Id} - {usuario.Nome}");
            }

        }
        public void ListarTarefas()
        {
            var tarefas = fabrica.OpenSession().QueryOver<Tarefa>().List();

            foreach (var tarefa in tarefas)
            {
                Console.WriteLine($"{tarefa.Descricao} {tarefa.DataAgendamento}");
            }
        }

        public void IncluirTarefa(Tarefa tarefa)
        {
            using (var sessao = fabrica.OpenSession())
            {
                using (var transaction = sessao.BeginTransaction())
                {
                    sessao.SaveOrUpdate(tarefa);
                    transaction.Commit();
                }
            }
        }
    }

}
