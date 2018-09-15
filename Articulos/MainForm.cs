using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Articulos.UI.Registro;
using Articulos.UI.Consulta;
using ArticulosBLL;

namespace Articulos
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void registrosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ArticulosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistroArticuloForm registro = new RegistroArticuloForm();
            registro.MdiParent = this;
            registro.Show();
        }

        private void ArticulosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ConsultaArticuloForm consulta = new ConsultaArticuloForm();
            consulta.MdiParent = this;
            consulta.Show();
        }
    }
}
