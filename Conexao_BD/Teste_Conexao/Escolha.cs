using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Teste_Conexao
{
    public partial class Escolha : Form
    {
        public Escolha()
        {
            InitializeComponent();
        }

        private void btnprodutos_Click(object sender, EventArgs e)
        {
            FrmProdutos frmProdutos = new FrmProdutos();
            this.Hide();
            frmProdutos.ShowDialog();
        }

        private void btnfuncionario_Click(object sender, EventArgs e)
        { Formfuncionario  formfuncionario = new Formfuncionario();
            this.Hide();
            formfuncionario.ShowDialog();

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            FPrincipal obj = new FPrincipal();
            this.Hide();
            obj.ShowDialog();
        }
    }
}
