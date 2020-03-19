using System;
using System.Text;
using System.Collections.Generic;


namespace Modelos
{

    public class Usuario
    {
        public virtual int Id { get; set; }
        public virtual string Nome { get; set; }

        public virtual IList<Tarefa> Tarefas { get; set; }

        public Usuario()
        {
            Tarefas = new List<Tarefa>();
        }

        public virtual void IncluirTarefa(Tarefa tarefa)
        {
            tarefa.Usuario = this;
            Tarefas.Add(tarefa);
        }
    }
}
