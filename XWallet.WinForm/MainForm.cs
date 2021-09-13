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
        public MainForm()
        {
            InitializeComponent();
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
