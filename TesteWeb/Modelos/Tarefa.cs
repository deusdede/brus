using System;
using System.Text;
using System.Collections.Generic;


namespace Modelos
{

    public class Tarefa
    {
        public virtual int Id { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual string Subject { get; set; }
        public virtual DateTime? Start { get; set; }
        public virtual DateTime? End { get; set; }
        public virtual int UserID { get; set; }
    }
}
