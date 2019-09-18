using BLL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AnalisisWeb.Registro
{
    public partial class rAnalisis : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ValoresDeDropdowns();
                RegAnalisisLimpiar();
                RegTipoAnalisisLimpiar();

                ViewState["Analisis"] = new Analisis();
                BindGrid();
            }
        }
        private void ValoresDeDropdowns()
        {
            RepositorioBase<Pacientes> db = new RepositorioBase<Pacientes>();
            var listado = new List<Pacientes>();
            listado = db.GetList(p => true);

            PacienteDropDown.DataSource = listado;
            PacienteDropDown.DataValueField = "PacienteId";
            PacienteDropDown.DataTextField = "Nombres";
            PacienteDropDown.DataBind();

            RepositorioBase<TipoAnalisis> repositorio = new RepositorioBase<TipoAnalisis>();
            var list = new List<TipoAnalisis>();
            list = repositorio.GetList(p => true);
            TiposAnalisisDropDown.DataSource = list;

            TiposAnalisisDropDown.DataValueField = "TipoId";
            TiposAnalisisDropDown.DataTextField = "Descripcion";
            TiposAnalisisDropDown.DataBind();
        }
        private Analisis RegAnalisisLlenaClase()
        {
            Analisis Analisis = new Analisis();

            Analisis = (Analisis)ViewState["Analisis"];
            Analisis.AnalisisId = Utils.ToInt(AnalisisIdTextBox.Text);
      //      Analisis.Paciente = PacienteDropDown.SelectedItem.ToString();
            Analisis.Fecha = Utils.ToDateTime(FechaTextBox.Text);

            return Analisis;
        }
        protected void BindGrid()
        {
            if (ViewState["Analisis"] != null)
            {
                DetalleGridView.DataSource = ((Analisis)ViewState["Analisis"]).Detalle;
                DetalleGridView.DataBind();
            }
        }
        private void RegAnalisisLimpiar()
        {
            AnalisisIdTextBox.Text = "0";
            FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
       //     PacienteDropDown.SelectedIndex = 0;
            TiposAnalisisDropDown.SelectedIndex = 0;
            ResultadoTextBox.Text = string.Empty;
            DetalleGridView.DataSource = null;
            DetalleGridView.DataBind();
        }

        private bool RegAnalisisExisteEnLaBaseDeDatos()
        {
            RepositorioBase<Analisis> Repositorio = new RepositorioBase<Analisis>();
            Analisis Analisis = Repositorio.Buscar(Utils.ToInt(AnalisisIdTextBox.Text));
            return (Analisis != null);
        }
        private void RegAnalisisLlenaCampo(Analisis Analisis)
        {
            ((Analisis)ViewState["Analisis"]).Detalle = Analisis.Detalle;
            AnalisisIdTextBox.Text = Convert.ToString(Analisis.AnalisisId);
            FechaTextBox.Text = Analisis.Fecha.ToString("yyyy-MM-dd");
            PacienteDropDown.SelectedValue = Analisis.Paciente;
            this.BindGrid();
        }

        protected void buscarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Analisis> Repositorio = new RepositorioBase<Analisis>();

            Analisis analisis = new Analisis();

            analisis = Repositorio.Buscar(Utils.ToInt(AnalisisIdTextBox.Text));

            if (analisis != null)
                RegAnalisisLlenaCampo(analisis);
            else
            {
                Utils.ShowToastr(this.Page, "Error no se pudo buscar", "Error", "error");
                RegTipoAnalisisLimpiar();
            }
        }

        protected void nuevoButton_Click(object sender, EventArgs e)
        {
            RegAnalisisLimpiar();
        }

        protected void guardarButton_Click(object sender, EventArgs e)
        {
            Analisis Analisis = new Analisis();
            RepositorioBase<Analisis> Repositorio = new RepositorioBase<Analisis>();
            bool paso = false;

            Analisis = RegAnalisisLlenaClase();

            if (Utils.ToInt(AnalisisIdTextBox.Text) == 0)
            {
                paso = Repositorio.Guardar(Analisis);
                RegAnalisisLimpiar();
            }
            else
            {
                if (!RegAnalisisExisteEnLaBaseDeDatos())
                {

                    Utils.ShowToastr(this, "No se pudo guardar", "Error", "error");
                    return;
                }
                paso = Repositorio.Modificar(Analisis);
                RegAnalisisLimpiar();
            }

            if (paso)
            {
                Utils.ShowToastr(this, "Guardado", "Exito", "success");
                return;
            }
            else
                Utils.ShowToastr(this, "No se pudo guardar", "Error", "error");

            RegAnalisisLimpiar();
        }

        protected void eliminarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Analisis> Repositorio = new RepositorioBase<Analisis>();

            var Analisis = Repositorio.Buscar(Utils.ToInt(AnalisisIdTextBox.Text));

            if (Analisis != null)
            {
                if (Repositorio.Eliminar(Utils.ToInt(AnalisisIdTextBox.Text)))
                {
                Utils.ShowToastr(this.Page, "eliminado con exito!!", "Eliminado", "info");
                }
                 else
                Utils.ShowToastr(this.Page, "No se pudo eliminar", "Error", "error");
            }
            else
                Utils.ShowToastr(this.Page, "No se pudo eliminar, usuario no existe", "error", "error");

            RegTipoAnalisisLimpiar();
        }
        protected void AgregarGrid_Click(object sender, EventArgs e)
        {
            Analisis Analisis = new Analisis();

            Analisis = (Analisis)ViewState["Analisis"];
            Analisis.Detalle.Add(new AnalisisDetalle(TiposAnalisisDropDown.SelectedItem.ToString(), ResultadoTextBox.Text));

            ViewState["Detalle"] = Analisis.Detalle;
            this.BindGrid();

         
            ResultadoTextBox.Text = string.Empty;
        }

        protected void Grid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Analisis Analisis = new Analisis();
            Analisis = (Analisis)ViewState["Analisis"];
            ViewState["Detalle"] = Analisis.Detalle;

            int Fila = e.RowIndex;

            Analisis.Detalle.RemoveAt(Fila);
            this.BindGrid();
            ResultadoTextBox.Text = string.Empty;
        }

        protected void Grid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DetalleGridView.DataSource = ViewState["Detalle"];
            DetalleGridView.PageIndex = e.NewPageIndex;
            DetalleGridView.DataBind();
        }


        //Comienzo del registro Tipo Analisis
        private bool TipoAnalisisExisteEnLaBaseDeDatos()
        {
            RepositorioBase<TipoAnalisis> Repositorio = new RepositorioBase<TipoAnalisis>();
            TipoAnalisis Tipos = Repositorio.Buscar(Utils.ToInt(TipoIdTextBox.Text));
            return (Tipos != null);
        }
        private void RegTipoAnalisisLimpiar()
        {
            TipoIdTextBox.Text = "0";
            AnalisisTextBox.Text = string.Empty;
           
        }
        private TipoAnalisis TipoAnalisisLlenaClase()
        {
            TipoAnalisis tipoAnalisis = new TipoAnalisis();

            tipoAnalisis.TipoId = Utils.ToInt(TipoIdTextBox.Text);
            tipoAnalisis.Descripcion = AnalisisTextBox.Text;
          

            return tipoAnalisis;
        }
        private void RegTipoAnalisisLlenaCampo(TipoAnalisis Tipos)
        {
            TipoIdTextBox.Text = Tipos.TipoId.ToString();
            AnalisisTextBox.Text = Tipos.Descripcion;
            
        }
     
 
        protected void TipoNuevoButton_Click(object sender, EventArgs e)
        {
            RegTipoAnalisisLimpiar();
        }

        protected void TipoGuardarButton_Click(object sender, EventArgs e)
        {
            TipoAnalisis Tipo = new TipoAnalisis();
            RepositorioBase<TipoAnalisis> Repositorio = new RepositorioBase<TipoAnalisis>();

            bool paso = false;

            Tipo = TipoAnalisisLlenaClase();

            if (Utils.ToInt(TipoIdTextBox.Text) == 0)
            {
                paso = Repositorio.Guardar(Tipo);
                RegTipoAnalisisLimpiar();
            }
            else
            {
                if (!TipoAnalisisExisteEnLaBaseDeDatos())
                {

                    Utils.ShowToastr(this, "No se pudo guardar", "Error", "error");
                    return;
                }
                paso = Repositorio.Modificar(Tipo);
                RegTipoAnalisisLimpiar();
            }

            if (paso)
            {
                Utils.ShowToastr(this, "Guardado", "Exito", "success");
                return;
            }
                  else
            Utils.ShowToastr(this, "No se pudo guardar", "Error", "error");
        }

        protected void TipoEliminarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<TipoAnalisis> Repositorio = new RepositorioBase<TipoAnalisis>();

            var tiposAnalisis = Repositorio.Buscar(Utils.ToInt(TipoIdTextBox.Text));

            if (tiposAnalisis != null)
            {
                if (Repositorio.Eliminar(Utils.ToInt(TipoIdTextBox.Text)))
                {
                    Utils.ShowToastr(this.Page, "Eliminado con exito!!", "Eliminado", "info");
                }
                 else
                    Utils.ShowToastr(this.Page, "Fallo al Eliminar :(", "Error", "error");
            }
            else
                Utils.ShowToastr(this.Page, "No se pudo eliminar, usuario no existe", "error", "error");

            RegTipoAnalisisLimpiar();
        }

        protected void TipoBuscarButton_Click(object sender, EventArgs e)
        {

            RepositorioBase<TipoAnalisis> Repositorio = new RepositorioBase<TipoAnalisis>();

            TipoAnalisis Tipo = new TipoAnalisis();

            Tipo = Repositorio.Buscar(Utils.ToInt(TipoIdTextBox.Text));

            if (Tipo != null)
                RegTipoAnalisisLlenaCampo(Tipo);
            else
            {
                Utils.ShowToastr(this.Page, "Error al busacar", "Error", "error");
                RegTipoAnalisisLimpiar();
            }
        }
    }
}