using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
    public class Pagos
    {
        [Key]
        public int PagosId { get; set; }
        public DateTime FechaPago { get; set; }

        public virtual List<PagosDetalle> Detalle { get; set; }

        public Pagos()
        {
            PagosId = 0;
            FechaPago = DateTime.Now;
            Detalle = new List<PagosDetalle>();

        }
    }
}
