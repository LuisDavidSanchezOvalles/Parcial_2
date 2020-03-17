﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Parcial2.Entidades
{
    public class LlamadaDetalle
    {
        [Key]
        public int LlamadaDetalleId { get; set; }
        public int LlamadaId { get; set; }
        public string Problema { get; set; }
        public string Solucion { get; set; }

        public LlamadaDetalle()
        {
            LlamadaDetalleId = 0;
            LlamadaId = 0;
            Problema = string.Empty;
            Solucion = string.Empty;
        }

        public LlamadaDetalle(int llamadaId, string problema, string solucion)
        {
            LlamadaDetalleId = 0;
            LlamadaId = llamadaId;
            Problema = problema;
            Solucion = solucion;
        }
    }
}
