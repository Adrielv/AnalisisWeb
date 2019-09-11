using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
   public class Pacientes
    {
        [Key]

        public int PacienteID { get; set; }
        public string Nombres { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Cedula { get; set; }

        public Pacientes()
        {
            PacienteID = 0;
            Nombres = string.Empty;
            Direccion = string.Empty;
            Telefono = string.Empty;
            Cedula = string.Empty;
        }

        public Pacientes(int pacienteID, string nombres, string direccion, string Telefono)
        {
            PacienteID = pacienteID;
            Nombres = nombres;
            Direccion = direccion;
            this.Telefono = Telefono;
        }
    }
}
