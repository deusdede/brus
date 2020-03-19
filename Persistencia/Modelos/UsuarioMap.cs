using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Modelos;
using FluentNHibernate.Mapping;

namespace Modelo
{
    public class UsuarioMap : ClassMap<Usuario>
    {

        public UsuarioMap()
        {
            Id(x => x.Id);
            Map(x => x.Nome);
            Table("Usuario");
        }
    }
}
