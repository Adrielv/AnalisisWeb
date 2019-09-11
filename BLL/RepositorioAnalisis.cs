using Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    class RepositorioAnalisis : RepositorioBase<Analisis>
    {
        public override Analisis Buscar(int id)
        {
            Analisis analisis = new Analisis();
            try
            {
                analisis = contextos.Analisis.Find(id);

                if (analisis != null)
                {
                    analisis.Detalle.Count();

                    foreach (var item in analisis.Detalle)
                    { string s = item.TipoAnalisis.Descripcion; }

                }
            }
            catch (Exception)
            {

                throw;
            }
            return analisis;
        }

        public override bool Modificar(Analisis analisis)
        {
            bool paso = false;
            try
            {
                var Anterior = contextos.Analisis.Find(analisis.AnalisisId);
                foreach (var item in Anterior.Detalle)
                {
                    if (!analisis.Detalle.Exists(d => d.TipoId == item.TipoId))
                    {
                        item.TipoAnalisis = null;
                        contextos.Entry(item).State = EntityState.Deleted;
                    }
                }

                foreach (var item in analisis.Detalle)
                {
                    var estado = item.TipoId > 0 ? EntityState.Modified : EntityState.Added;
                    contextos.Entry(item).State = estado;
                }

                contextos.Entry(analisis).State = EntityState.Modified;

                if (contextos.SaveChanges() > 0)
                    paso = true;
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }
    }
}
