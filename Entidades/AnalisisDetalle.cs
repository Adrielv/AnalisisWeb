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
           
            public string Analisis { get; set; }
            public string Resultado { get; set; }

            public AnalisisDetalle()
            {
             this.AnalisisDetalleId = 0;
            this.Analisis = string.Empty;

            this.Resultado = string.Empty;
            }


            public AnalisisDetalle(string analisis, string Resultado)
            {
             this.Analisis = analisis;
             this.Resultado = Resultado;
            }
        }
    }

