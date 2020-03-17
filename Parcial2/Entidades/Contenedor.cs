using System;
using System.Collections.Generic;
using System.Text;

namespace Parcial2.Entidades
{
    public class Contenedor
    {
        public Llamada llamada { get; set; }
        public LlamadaDetalle llamadaDetalle { get; set; }

        public Contenedor()
        {
            llamada = new Llamada();
            llamadaDetalle = new LlamadaDetalle();
        }
    }
}
