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
    public class PFluent
    {
        private ISessionFactory fabrica;

        public PFluent()
        {
            fabrica = CreateSessionFactory();
        }
        public ISessionFactory CreateSessionFactory()
        {
            string stringConexao = ConfigurationManager.ConnectionStrings["brus"].ConnectionString;

            return Fluently.Configure()
                    .Database(MsSqlConfiguration.MsSql2008.ConnectionString(stringConexao))
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<PFluent>())
                    .BuildSessionFactory();
        }

        internal Usuario getUsuario(int id)
        {
            return fabrica.OpenSession().Get<Usuario>(id);
        }

        internal void ListarUsuarios()
        {
            var usuarios = fabrica.OpenSession().QueryOver<Usuario>().List();

            foreach (var usuario in usuarios)
            {
                Console.WriteLine($"{usuario.Id} - {usuario.Nome}");
            }

        }
        internal IList<Tarefa> ListarTarefas()
        {
            return fabrica.OpenSession().QueryOver<Tarefa>().List();

        }

        internal void IncluirTarefa(Tarefa tarefa)
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
