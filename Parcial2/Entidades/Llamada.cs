using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Parcial2.Entidades
{
    public class Llamada
    {
        [Key]
        public int LlamadaId { get; set; }
        public string Descripcion { get; set; }

        [ForeignKey("LlamadaId")]
        public virtual List<LlamadaDetalle> LlamadasDetalle { get; set; }

        public Llamada()
        {
            LlamadaId = 0;
            Descripcion = string.Empty;

            LlamadasDetalle = new List<LlamadaDetalle>();
        }
    }
}
