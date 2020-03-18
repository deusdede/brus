using System;
using System.Collections.Generic;
using System.Text;

namespace Modelos
{
    public class Usuario
    {
        public int ID { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Tarefa> agendamentos { get; set; }
    }
}
