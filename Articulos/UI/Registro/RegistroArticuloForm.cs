using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Articulos.Entidades;
using Articulos.DAL;

namespace Articulos.UI.Registro
{
    public partial class RegistroArticuloForm : Form
    {
        public RegistroArticuloForm()
        {
            InitializeComponent();
        }

        private rArticulos LlenarClase()
        {

            rArticulos art = new rArticulos();

            art.ArticuloId = Convert.ToInt32(IdnumericUpDown.Value);
            art.Descripcion = DescripciontextBox.Text;
            art.Precio = PreciotextBox.Text;
            art.FechaVencimiento = VencimientodateTimePicker.Value;
            art.CantidadCotizada = Convert.ToInt32(CantCottextBox.Text);

            return art;
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(IdnumericUpDown.Value);
            rArticulos articulo = ArticulosBLL.BLL.ArticulosBLL.Buscar(id);

            if (articulo != null)
            {

                DescripciontextBox.Text = articulo.Descripcion;
                PreciotextBox.Text = articulo.Precio;
                VencimientodateTimePicker.Text = articulo.FechaVencimiento.ToString();
                CantCottextBox.Text = articulo.CantidadCotizada.ToString();

            }
            else
                MessageBox.Show("No se encontro", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);


        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            rArticulos articulo = LlenarClase();
            bool paso = false;

            //Determinar si es Guardar o Modificar
            if (IdnumericUpDown.Value == 0)
                paso = ArticulosBLL.BLL.ArticulosBLL.Guardar(articulo);
            else
                paso = ArticulosBLL.BLL.ArticulosBLL.Modificar(LlenarClase());

            //Informar el resultado
            if (paso)

                MessageBox.Show("Guardado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No se pudo guardar", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            IdnumericUpDown.Value = 0;
            DescripciontextBox.Clear();
            PreciotextBox.Clear();
            CantCottextBox.Clear();

        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {

            int id = Convert.ToInt32(IdnumericUpDown.Value);

            if (ArticulosBLL.BLL.ArticulosBLL.Eliminar(id))
                MessageBox.Show("Eliminado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No se pudo eliminar", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
    }
}
