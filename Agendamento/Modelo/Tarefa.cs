using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Modelos
{

    public class Tarefa
    {
        public int ID { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Usuario> Enrollments { get; set; }


    }
}