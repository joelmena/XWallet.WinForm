﻿using BAL;
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
            dgvEmplados.AutoGenerateColumns = false;
            ActualizarGridView();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            EditForm frm = new EditForm();

            frm.ShowDialog();
            frm.Dispose();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }



        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string busqueda = txtBuscar.Text;
            ActualizarGridView(busqueda);
        }


        private void dgvEmplados_Click(object sender, EventArgs e)
        {
            txtCodigoEmpleado.Enabled = false;
            lblID.Text = dgvEmplados.SelectedRows[0].Cells["colId"].Value.ToString();
            txtCodigoEmpleado.Text = dgvEmplados.SelectedRows[0].Cells["colCodigo"].Value.ToString();
            txtNombre.Text = dgvEmplados.SelectedRows[0].Cells["colNombre"].Value.ToString();
            chkVerificado.Checked = (bool)dgvEmplados.SelectedRows[0].Cells["colVerificado"].Value;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Empleado.Id = (lblID.Text != "NUEVO") ? int.Parse(lblID.Text) : 0;
            Empleado.CodigoEmpleado = txtCodigoEmpleado.Text;
            Empleado.Nombre = txtNombre.Text;
            Empleado.Password = mkPassword.Text;
            Empleado.Verificado = chkVerificado.Checked;

            if (Empleado.Saved(Empleado))
            {
                ActualizarGridView(txtBuscar.Text);
                Limpiar();
                MessageBox.Show("Registro guardado");
            }
            else
            {
                MessageBox.Show("Error al guardar el registro");
            }
        }


        private void ActualizarGridView(string busqueda = null)
        {
            var result = Empleado.GetList(busqueda);
            dgvEmplados.DataSource = result;
            lblTotal.Text = result.Rows.Count.ToString();
        }
        private void Limpiar()
        {
            txtCodigoEmpleado.Enabled = true;
            lblID.Text = "NUEVO";
            txtCodigoEmpleado.Text = string.Empty;
            txtNombre.Text = string.Empty;
            mkPassword.Text = string.Empty;
            chkVerificado.Checked = false;
        }

    }
}
