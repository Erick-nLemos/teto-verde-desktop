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
using System.IO;
using System.Security.Cryptography.X509Certificates;


namespace Teste_Conexao
{
    public partial class Formfuncionario : Form
    {
        SqlConnection conexao;
        public Formfuncionario()
        {
            InitializeComponent();
        }

        private void lblRg_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            {

                //criar uma conexao
                conexao = clnConexao.getConexao();
                int matr = 0;
                try
                {
                    //recuperar o id(matricula) do Form(textBox)
                    matr = Convert.ToInt32(txtMatricula.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Falha ao converter! " +
                        "Digite somente números" + ex.Message);
                }
                //criar um objeto Funcionario 
                Funcionario func = new Funcionario();
                func.IdFunc = matr;
                // popular comos dados do  formulário
                func.NomeFunc = txtNome.Text;
                func.RgFunc = txtRg.Text;
                func.CpfFunc = txtCpf.Text;
                func.NomeUser = txtUsuario.Text;
                func.SenhaUser = txtSenha.Text;

                //criar um objeto FuncionarioDAL 
                FuncionarioDAL funcDal = new FuncionarioDAL();
                //e executar a inserção
                try
                {
                    //abrir a conexao
                    funcDal.abrirConexao(conexao);
                    //executar o insert
                    funcDal.alterar(conexao, func);

                    MessageBox.Show("Dados Alterados!");
                    btnLimpar.PerformClick();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Falha: " + ex.Message);
                }


            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            {
                txtNome.Clear();
                txtCpf.Clear();
                txtRg.Clear();
                txtSenha.Clear();
                txtUsuario.Clear();
            }

        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            {
                //criar uma conexao
                conexao = clnConexao.getConexao();
                //criar um objeto Funcionario 
                Funcionario func = new Funcionario();
                // popular comos dados do  formulário
                func.NomeFunc = txtNome.Text;
                func.RgFunc = txtRg.Text;
                func.CpfFunc = txtCpf.Text;
                func.NomeUser = txtUsuario.Text;
                func.SenhaUser = txtSenha.Text;

                //criar um objeto FuncionarioDAL 
                FuncionarioDAL funcDal = new FuncionarioDAL();
                //e executar a inserção
                try
                {
                    //abrir a conexao
                    funcDal.abrirConexao(conexao);
                    //executar o insert
                    funcDal.adicionar(conexao, func);

                    MessageBox.Show("Dados salvos com sucesso!");
                    btnLimpar.PerformClick();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Falha: " + ex.Message);
                }


            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            {



                DialogResult resultado = MessageBox.Show("Deseja excluir?", "Atenção", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);

                if (resultado == DialogResult.OK)
                {
                    //String de conexão com o banco de dados
                    string strConexao = @"Server=OLIVEIRAMH\SQLEXPRESS;
 Database=CNX_TETOVERDE;Integrated Security = True";
                    string cmdDelete =
                     "DELETE funcionarios where id_func =" + txtMatricula.Text;
                    SqlConnection con = new SqlConnection(strConexao);
                    SqlCommand sqlCommand = new SqlCommand(cmdDelete, con);
                    con.Open();
                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Dados Excluidos !");
                    btnLimpar.PerformClick();
                    con.Close();


                   

                }
            }
        }

        private void btnaddfoto_Click(object sender, EventArgs e)
        {

        }

        private void pb_foto_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnpesquisafunc_Click(object sender, EventArgs e)
        {
            //criar uma conexao
            conexao = clnConexao.getConexao();
            int matr = 0;
            try
            {
                //recuperar o id(matricula) do Form(textBox)
                matr = Convert.ToInt32(txtMatricula.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falha ao converter! " +
                    "Digite somente números" + ex.Message);
            }
            //criar um objeto Funcionario
            Funcionario func = new Funcionario();
            //adicionar o id(matricula) 

            func.IdFunc = matr;
            //criar um objeto FuncionarioDAL
            FuncionarioDAL funcDAL = new FuncionarioDAL();
            try
            {   //funcDAL --> abrir a conexao
                funcDAL.abrirConexao(conexao);
                //funcDAL --> realizar a pesquisa
                func = funcDAL.pesquisarFuncId(conexao, func);
                //popular o objeto funcionario e preencher os textbox 
                //correspondentes
                txtNome.Text = func.NomeFunc;
                txtRg.Text = func.RgFunc;
                txtCpf.Text = func.CpfFunc;
                txtUsuario.Text = func.NomeUser;
                txtSenha.Text = func.SenhaUser;
            }
            catch (Exception ex)
            {//mensagem de funcionario nao encontrado
                MessageBox.Show("Funcionario não encontrado! Erro: "
                    + ex.Message);
            }
            finally
            {//funcDAL -->fechar a conexao
                funcDAL.fecharConexao(conexao);
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            FPrincipal obj = new FPrincipal();
            this.Hide();
            obj.ShowDialog();
        }
    }
}
