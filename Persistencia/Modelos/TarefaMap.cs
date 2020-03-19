using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NHibernate.Mapping.ByCode.Conformist;
using Modelos;
using FluentNHibernate.Mapping;

namespace Modelo {
    
    
    public class TarefaMap : ClassMap<Tarefa> {
        
        public TarefaMap() {
            Id(x => x.Id);
            Map(x => x.Descricao);
            Map(x => x.DataAgendamento).Column("data_agendamento");
            References(c => c.Usuario).Column("usuario_id");
            Table("Tarefa");
        }
    }
}
