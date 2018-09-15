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

namespace Articulos.UI.Consulta
{
    public partial class ConsultaArticuloForm : Form
    {
        public ConsultaArticuloForm()
        {
            InitializeComponent();
        }

        private void Imprimirbutton_Click(object sender, EventArgs e)
        {

        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            //Inicializando el filtro en True
            System.Linq.Expressions.Expression<Func<rArticulos, bool>> filtro = x => true;

            int id;
            int cant;
            DateTime fecha;
            switch (filtrarcomboBox.SelectedIndex)
            {
                case 0://ID
                    id = Convert.ToInt32(CriteriotextBox.Text);
                    filtro = x => x.ArticuloId == id;
                    break;
                case 1:// Descripcion
                    filtro = x => x.Descripcion.Contains(CriteriotextBox.Text);
                    break;
                case 2:// precio
                    filtro = x => x.Precio.Contains(CriteriotextBox.Text);
                    break;
                case 3://Fecha de vencimiento
                    fecha = Convert.ToDateTime(CriteriotextBox.Text);
                    filtro = x => x.FechaVencimiento == fecha;
                    break;
                case 4:// Cantidad amortizada
                    cant = Convert.ToInt32(CriteriotextBox.Text);
                    filtro = x => x.CantidadCotizada == cant;
                    break;
            }
            ConsultadataGridView.DataSource = ArticulosBLL.BLL.ArticulosBLL.GetList(filtro);
        }
    }
}
