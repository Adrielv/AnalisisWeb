using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
  
     [Serializable]
     public class AnalisisDetalle
        {
            [Key]
            public int AnalisisDetalleId { get; set; }
            public int AnalisisId { get; set; }
            public virtual Analisis Analisis { get; set; }
            public int TipoId { get; set; }
            public virtual TipoAnalisis TipoAnalisis { get; set; }
            public string Resultado { get; set; }

            public AnalisisDetalle()
            {
                this.AnalisisDetalleId = 0;
                this.AnalisisId = 0;
                this.TipoId = 0;
                this.Resultado = string.Empty;
            }


            public AnalisisDetalle(int DetalleAnalisisID, int AnalisisID, int TipoAnalisisID, string Resultado)
            {
                this.AnalisisDetalleId = DetalleAnalisisID;
                this.AnalisisId = AnalisisID;
                this.TipoId = TipoAnalisisID;
                this.Resultado = Resultado;
            }
        }
    }

