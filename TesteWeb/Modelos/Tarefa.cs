using System;
using System.Text;
using System.Collections.Generic;


namespace Modelos
{

    public class Tarefa
    {
        public virtual int Id { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual string Descricao { get; set; }
        public virtual DateTime? DataAgendamento { get; set; }
    }
}
