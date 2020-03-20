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
            Map(x => x.Subject).Column("descricao");
            Map(x => x.Start).Column("inicio_agendamento");
            Map(x => x.End).Column("fim_agendamento");
            Map(x => x.UserID).Column("usuario_id");
            Table("Tarefa");
        }
    }
}
