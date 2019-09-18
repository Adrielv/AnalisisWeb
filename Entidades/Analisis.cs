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
            public string Paciente { get; set; }

             public decimal Monto { get; set; }
             public decimal Balance { get; set; }
            public virtual List<AnalisisDetalle> Detalle { get; set; }

            public Analisis()
            {
                AnalisisId = 0;
                Fecha = DateTime.Now;
                Paciente = string.Empty;
                Balance = 0;
                Monto = 0;
                Detalle = new List<AnalisisDetalle>();
            }

        public Analisis(int AnalisisID, List<AnalisisDetalle> DetalleAnalisis, string Paciente, decimal Balance, DateTime Fecha)
            {
                this.AnalisisId = AnalisisID;
                this.Paciente = Paciente;
                this.Detalle = DetalleAnalisis;
                 this.Balance = Balance;
                this.Fecha = Fecha;
            }
            public void AgregarDetalle(string descripcion, string resultado)
            {
                this.Detalle.Add(new AnalisisDetalle(resultado,descripcion));
            }
        }
    }

