﻿using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentProject.Persistencia;
using Modelos;
using NHibernate;
using System;
using System.Configuration;

namespace FluentProject
{
    class Program
    {
        static void Main()
        {

            PFluent persistencia = new PFluent();

            var fabrica = persistencia.CreateSessionFactory();

            persistencia.ListarUsuarios();
            persistencia.ListarTarefas();

            //using (var session = fabrica.OpenSession())
            //{
            //    var usuarios = session.QueryOver<Usuario>().List();

            //    foreach (var usuario in usuarios)
            //    {
            //        Console.WriteLine(usuario.Nome);
            //    }

            //    var tarefas = session.QueryOver<Tarefa>().List();

            //    foreach (var tarefa in tarefas)
            //    {
            //        Console.WriteLine($"{tarefa.Descricao} {tarefa.DataAgendamento}");
            //    }
            //}

            Console.WriteLine("Fim...");

            Console.ReadLine();

        }

        //private static ISessionFactory CreateSessionFactory()
        //{
        //    string stringConexao = ConfigurationManager.ConnectionStrings["brus"].ConnectionString;

        //    return Fluently.Configure()
        //            .Database(MsSqlConfiguration.MsSql2008.ConnectionString(stringConexao))
        //            .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Program>())
        //            .BuildSessionFactory();
        //}
    }
}

