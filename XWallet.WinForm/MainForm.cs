using BAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XWallet.WinForm
{
    public partial class MainForm : Form
    {
        private Empleado Empleado;
        public MainForm()
        {
            InitializeComponent();
            Empleado = new Empleado();

            dgvEmplados.DataSource = Empleado.GetList();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            EditForm frm = new EditForm();

            frm.ShowDialog();
            frm.Dispose();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {

        }
    }
}
