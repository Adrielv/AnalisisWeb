using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
   
        [Serializable]
        public class Analisis
        {
            [Key]
            public int AnalisisId { get; set; }
            public DateTime Fecha { get; set; }
            public int PacienteId { get; set; }
            public virtual List<AnalisisDetalle> Detalle { get; set; }

            public Analisis()
            {
                AnalisisId = 0;
                Fecha = DateTime.Now;
                PacienteId = 0;
                Detalle = new List<AnalisisDetalle>();
            }

            public Analisis(int AnalisisID, List<AnalisisDetalle> DetalleAnalisis, int PacienteID, DateTime Fecha)
            {
                this.AnalisisId = AnalisisID;
                this.PacienteId = PacienteID;
                this.Detalle = DetalleAnalisis;
                this.Fecha = Fecha;
            }
            public void AgregarDetalle(int detalleAnalisisID, int analisisID, int tipoAnalisisID, string resultado)
            {
                this.Detalle.Add(new AnalisisDetalle(detalleAnalisisID, analisisID, tipoAnalisisID, resultado));
            }
        }
    }

