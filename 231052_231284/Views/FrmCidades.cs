﻿using _231052_231284.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _231052_231284.Views
{
    public partial class FrmCidades : Form
    {
        Cidade c;
        public FrmCidades()
        {
            InitializeComponent();
        }

        void limpaControles()
        {
            txtID.Clear();
            txtUF.Clear();
            txtSearch.Clear();
            txtnome.Clear();
        }

        void carregarGrid(string pesquisa)
        {
            c = new Cidade()
            {
                nome = pesquisa
            };
            dgvCidades.DataSource = c.Consultar();
        }

        private void FrmCidades_Load(object sender, EventArgs e)
        {
            limpaControles();
            carregarGrid("");
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            if (txtnome.Text == String.Empty) return;

            c = new Cidade()
            {
                nome = txtnome.Text,
                uf = txtUF.Text
            };
            c.Incluir();

            limpaControles();
            carregarGrid("");

        }

        private void dgvCidades_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCidades.RowCount > 0)
            {
                txtID.Text = dgvCidades.CurrentRow.Cells["id"].Value.ToString();
                txtnome.Text = dgvCidades.CurrentRow.Cells["nome"].Value.ToString();
                txtUF.Text = dgvCidades.CurrentRow.Cells["uf"].Value.ToString();
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (txtID.Text == String.Empty) return;

            c = new Cidade()
            {
                id = int.Parse(txtID.Text),
                nome = txtnome.Text,
                uf = txtUF.Text
            };
            c.Alterar();

            limpaControles();
            carregarGrid("");
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "") return;

            if (MessageBox.Show("Deseja excluir a cidade?", "Exlusão",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                c = new Cidade()
                {
                    id = int.Parse(txtID.Text)
                };
                c.Excluir();

                limpaControles();
                carregarGrid("");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpaControles();
            carregarGrid("");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            carregarGrid(txtSearch.Text);
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }   
}
