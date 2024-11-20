using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DAL;
using Model;

namespace Teste_Conexao
{
    public partial class FPrincipal : Form
    {
        SqlConnection conexao;
        public FPrincipal()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Formfuncionario obj01 = new Formfuncionario();
            this.Hide();
            obj01.ShowDialog();
        }



        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FrmProdutos obj02 = new FrmProdutos();
            this.Hide();
            obj02.ShowDialog();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void btnentrar_Click(object sender, EventArgs e)
        {    

             
            try
            {

                if (txtusuario.Text.Equals("Sandra@gmail.com") && txtsenha.Text.Equals("8888"))
                {
                    MessageBox.Show("Acesso Liberado!");
                    FrmProdutos frmProdutos = new FrmProdutos();
                    this.Hide();

                    frmProdutos.ShowDialog();



                }
                if (txtusuario.Text.Equals("Moisesh@gmail.com") && txtsenha.Text.Equals("1980"))
                {
                    MessageBox.Show("Acesso Liberado!");
                   Escolha escolha = new Escolha();
                    this.Hide();

                    escolha.ShowDialog();
                    
                    
                }
                if (txtusuario.Text.Equals("Karinaadriana@gmail.com") && txtsenha.Text.Equals("7315"))
                {
                    MessageBox.Show("Acesso Liberado!");
                    admin1 admin1 = new admin1();
                    this.Hide();

                    admin1.ShowDialog();
                     

                }
                if (txtusuario.Text.Equals("Fabianasant@gmail.com") && txtsenha.Text.Equals("9731"))
                {
                    MessageBox.Show("Acesso Liberado!");
                    FrmProdutos frmProdutos= new FrmProdutos();
                    this.Hide();

                    frmProdutos.ShowDialog();


                }

                else
                {
                    MessageBox.Show(" Usuario ou Senha inválidos!");
                }

            }
            catch (Exception)
            {
                MessageBox.Show(" Usuario ou Senha inválidos!");
            }
           


        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void txtusuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click_2(object sender, EventArgs e)
        {

        }
    }
}