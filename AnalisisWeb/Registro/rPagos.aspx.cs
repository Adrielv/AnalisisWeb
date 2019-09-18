using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Entidades;

namespace AnalisisWeb.Registro
{
    public partial class rPagos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ValoresDeDropdowns();
                Limpiar();
               
                ViewState["Pagos"] = new Pagos();
                BindGrid();
            }
        }
        private void ValoresDeDropdowns()
        {
            RepositorioBase<Analisis> db = new RepositorioBase<Analisis>();
            var listado = new List<Analisis>();
            listado = db.GetList(p => true);

            AnalisisDropDown.DataSource = listado;
            AnalisisDropDown.DataValueField = "AnalisisId";
            AnalisisDropDown.DataTextField = "AnalisisId";
            AnalisisDropDown.DataBind();

           
        }
        private Pagos LlenaClase()
        {
            Pagos pagos = new Pagos();

            pagos = (Pagos)ViewState["Pagos"];
            pagos.PagosId = Utils.ToInt(PagosIdTextBox.Text);
            pagos.FechaPago = Utils.ToDateTime(FechaPagoTextBox.Text);

            return pagos;
        }
        //Arreglar
        protected void BindGrid()
        {
            if (ViewState["Pagos"] != null)
            {
                DetalleGridView.DataSource = ((Pagos)ViewState["Pagos"]).Detalle;
                DetalleGridView.DataBind();
            }
        }
        private void Limpiar()
        {
            PagosIdTextBox.Text = "0";
            FechaPagoTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");          
            AnalisisDropDown.SelectedIndex = 0;
            CantidadTextBox.Text = string.Empty;
            DetalleGridView.DataSource = null;
            DetalleGridView.DataBind();
        }
        private bool ExisteEnLaBaseDeDatos()
        {
            RepositorioBase<Pagos> Repositorio = new RepositorioBase<Pagos>();
            Pagos pagos = Repositorio.Buscar(Utils.ToInt(PagosIdTextBox.Text));
            return (pagos != null);
        }
        //Arreglar
        private void LlenaCampo(Pagos pagos)
        {
            ((Pagos)ViewState["Pagos"]).Detalle = pagos.Detalle;
            PagosIdTextBox.Text = Convert.ToString(pagos.PagosId);
            FechaPagoTextBox.Text = pagos.FechaPago.ToString("yyyy-MM-dd");
           
            this.BindGrid();
        }

        protected void nuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void guardarButton_Click(object sender, EventArgs e)
        {
            Pagos pagos = new Pagos();
            RepositorioBase<Pagos> Repositorio = new RepositorioBase<Pagos>();
            bool paso = false;

            pagos = LlenaClase();

            if (Utils.ToInt(PagosIdTextBox.Text) == 0)
            {
                paso = Repositorio.Guardar(pagos);
                Limpiar();
            }
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    Utils.ShowToastr(this, "No se pudo guardar", "Error", "error");
                    
                    return;
                }
                paso = Repositorio.Modificar(pagos);
                Limpiar();
            }

            if (paso)
            {

                Utils.ShowToastr(this, "Guardado", "Exito", "success");
               
                return;
            }
            else
                Utils.ShowToastr(this, "No se pudo guardar", "Error", "error");
          

            Limpiar();
        }

        protected void eliminarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Pagos> Repositorio = new RepositorioBase<Pagos>();

            var Analisis = Repositorio.Buscar(Utils.ToInt(PagosIdTextBox.Text));

            if (Analisis != null)
            {
                if (Repositorio.Eliminar(Utils.ToInt(PagosIdTextBox.Text)))
                {
                    Utils.ShowToastr(this.Page, "eliminado con exito!!", "Eliminado", "info");
                }
                else
                    Utils.ShowToastr(this.Page, "No se pudo eliminar", "Error", "error");
            }
            else
                Utils.ShowToastr(this.Page, "No se pudo eliminar, usuario no existe", "error", "error");

           
            Limpiar();
        }

        protected void buscarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Pagos> Repositorio = new RepositorioBase<Pagos>();
            Pagos pagos = new Pagos();
           

            pagos = Repositorio.Buscar(Utils.ToInt(PagosIdTextBox.Text));

            if (pagos != null)
                LlenaCampo(pagos);
            else
            {
                Utils.ShowToastr(this.Page, "Error no se pudo buscar", "Error", "error");
                Limpiar();
            }
        }
        //Arreglar
        protected void AgregarGrid_Click(object sender, EventArgs e)
        {
            Pagos pagos = new Pagos();

            pagos = (Pagos)ViewState["Pagos"];
            pagos.Detalle.Add(new PagosDetalle(Convert.ToInt32(AnalisisDropDown.SelectedItem), Convert.ToInt32(CantidadTextBox.Text)));

            ViewState["Detalle"] = pagos.Detalle;
            this.BindGrid();

           
            CantidadTextBox.Text = string.Empty;
        }
    }
}