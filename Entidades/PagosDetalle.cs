using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
    public class PagosDetalle
    {
        [Key]

        public int PagosDetalleId { get; set; }
        public int AnalisisId { get; set; }

        public decimal Cantidad { get; set; }

        public PagosDetalle()
        {
            PagosDetalleId = 0;
            AnalisisId = 0;
            Cantidad = 0;
        }

        public PagosDetalle(int analisisId, decimal cantidad)
        {
          
            AnalisisId = analisisId;
            Cantidad = cantidad;
        }
    }
}
