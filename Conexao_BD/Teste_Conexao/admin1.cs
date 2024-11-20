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
    
    public partial class admin1 : Form
    {
        SqlConnection conexao;
        public admin1()
        {
            InitializeComponent();
        }

        private void txtcodBarravisaoprod_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnBuscarprodvisao_Click(object sender, EventArgs e)
        {

            //criar uma conexao
            conexao = clnConexao.getConexao();
            int cod = 0;
            try
            {
                //recuperar o id(matricula) do Form(textBox)
                cod = Convert.ToInt32(txtcodBarravisaoprod.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falha ao converter! " +
                    "Digite somente números" + ex.Message);
            }
            //criar um objeto Produto
            Produto prod = new Produto();
            //adicionar o id(matricula) recuperado
            prod.Codbar_prod = cod;
            //criar um objeto FuncionarioDAL
            ProdutoDAL prodDAL = new ProdutoDAL();
            try
            {   //funcDAL --> abrir a conexao
                prodDAL.abrirConexao(conexao);
                //funcDAL --> realizar a pesquisa
                prod = prodDAL.pesquisarProd(conexao, prod);
                //popular o objeto funcionario e preencher os textbox 
                //correspondentes
                txtNomeprodvisao.Text = prod.NomeProd;
                cmbcategoprodvisao.Text = prod.Categoria;
                txtPrecoprodvisao.Text = Convert.ToDouble(prod.Preco).ToString();
                cmbmedidaprodvisao.Text = prod.Medida;
                txtQuantprodvisao.Text = Convert.ToInt32(prod.Quant).ToString();
            }
            catch (Exception ex)
            {//mensagem de funcionario nao encontrado
                MessageBox.Show("Produto não encontrado!"
                    + ex.Message);
            }
            finally
            {//funcDAL -->fechar a conexao
                prodDAL.fecharConexao(conexao);
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtNomeprodvisao.Clear();
            txtcodBarravisaoprod.Clear();
            cmbcategoprodvisao.SelectedIndex = -1;
            cmbmedidaprodvisao.SelectedIndex = -1;
            txtPrecoprodvisao.Clear();
            txtQuantprodvisao.Clear();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {

            //criar uma conexao
            conexao = clnConexao.getConexao();
            int codBarras = 0;
            try
            {
                //recuperar o id(matricula) do Form(textBox)
                codBarras = Convert.ToInt32(txtcodBarravisaoprod.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falha ao converter! " +
                    "Digite somente números" + ex.Message);
            }
            //criar um objeto Produto 
            Produto prod = new Produto();
            prod.Codbar_prod = codBarras;
            // popular comos dados do  formulário
            prod.NomeProd = txtNomeprodvisao.Text;
            prod.Categoria = cmbcategoprodvisao.Text;
            prod.Preco = Convert.ToDouble(txtPrecoprodvisao.Text);
            prod.Medida = cmbmedidaprodvisao.Text;
            prod.Quant = Convert.ToInt32(txtQuantprodvisao.Text);

            //criar um objeto ProdutoDAL  
            ProdutoDAL ProdDal = new ProdutoDAL();
            //e executar a inserção
            try
            {
                //abrir a conexao
                ProdDal.abrirConexao(conexao);
                //executar o insert
                ProdDal.alterar(conexao, prod);

                MessageBox.Show("Dados salvos com sucesso!");
                btnLimpar.PerformClick();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falha: " + ex.Message);
            }

        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {


            DialogResult resultado = MessageBox.Show("Deseja excluir?", "Atenção", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);

            if (resultado == DialogResult.OK)
            {
                //String de conexão com o banco de dados
                string strConexao = @"Server=OLIVEIRAMH\SQLEXPRESS;
 Database=CNX_TETOVERDE;Integrated Security = True";
                string cmdDelete =
                 "DELETE produto where codbar_prod=" + txtcodBarravisaoprod.Text;
                SqlConnection con = new SqlConnection(strConexao);
                SqlCommand sqlCommand = new SqlCommand(cmdDelete, con);
                con.Open();
                sqlCommand.ExecuteNonQuery();
                MessageBox.Show("Dados excluidos com sucesso!");
                btnLimpar.PerformClick();
                con.Close();
                /*int codProd = 0;
                //recuperar o id(matricula) do Form(textBox)
                codProd = Convert.ToInt32(txtMatricula.Text);
                MessageBox.Show("excluir...");
                //criar uma conexao
                conexao = clnConexao.getConexao();
                Produto prod = new Produto();
         
                //criar um objeto ProdutoDAL 
                ProdutoDAL prodDal = new ProdutoDAL();

                //e executar a inserção
                try
                {
                    //abrir a conexao
                    prodDal.abrirConexao(conexao);
                    //executar o delete
                    prodDal.DelProd(conexao, prod);

                    MessageBox.Show("Dados excluidos com sucesso!");
                    btnLimpar.PerformClick();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Falha: " + ex.Message);
                }
            }*/
            }
            else
            {
                MessageBox.Show("Cancelar...");

            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {

            //criar uma conexao
            conexao = clnConexao.getConexao();
            //criar um objeto Funcionario 
            Produto prod = new Produto();
            // popular comos dados do  formulário
            prod.NomeProd = txtNomeprodvisao.Text;
            prod.Categoria = cmbcategoprodvisao.Text;
            prod.Preco = Convert.ToDouble(txtPrecoprodvisao.Text);
            prod.Medida = cmbmedidaprodvisao.Text;
            prod.Quant = Convert.ToInt32((txtQuantprodvisao.Text).ToString());

            //criar um objeto FuncionarioDAL 
            ProdutoDAL prodDal = new ProdutoDAL();
            //e executar a inserção
            try
            {
                //abrir a conexao
                prodDal.abrirConexao(conexao);
                //executar o insert
                prodDal.adicionar(conexao, prod);

                MessageBox.Show("Dados salvos com sucesso!");
                btnLimpar.PerformClick();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falha: " + ex.Message);
            }
        }

        private void btnpesquisafunc_Click(object sender, EventArgs e)
        {
            //criar uma conexao
            conexao = clnConexao.getConexao();
            int matr = 0;
            try
            {
                //recuperar o id(matricula) do Form(textBox)
                matr = Convert.ToInt32(txtMatriculavisao.Text);
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
                txtNomefuvisao.Text = func.NomeFunc;
                txtRgvisao.Text = func.RgFunc;
                txtCpfvisao.Text = func.CpfFunc;
                txtUsuariovisao.Text = func.NomeUser;
                txtSenhavisao.Text = func.SenhaUser;
            }
            catch (Exception ex)
            {//mensagem de funcionario nao encontrado
                MessageBox.Show("Funcionário não encontrado! "
                    + ex.Message);
            }
            finally
            {//funcDAL -->fechar a conexao
                funcDAL.fecharConexao(conexao);
            }

        }

        private void txtMatriculavisao_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtNomefuvisao.Clear();
            txtCpfvisao.Clear();
            txtRgvisao.Clear();
            txtSenhavisao.Clear();
            txtUsuariovisao.Clear();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //criar uma conexao
            conexao = clnConexao.getConexao();
            int matr = 0;
            try
            {
                //recuperar o id(matricula) do Form(textBox)
                matr = Convert.ToInt32(txtMatriculavisao.Text);
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
            func.NomeFunc = txtNomefuvisao.Text;
            func.RgFunc = txtRgvisao.Text;
            func.CpfFunc = txtCpfvisao.Text;
            func.NomeUser = txtUsuariovisao.Text;
            func.SenhaUser = txtSenhavisao.Text;

            //criar um objeto FuncionarioDAL 
            FuncionarioDAL funcDal = new FuncionarioDAL();
            //e executar a inserção
            try
            {
                //abrir a conexao
                funcDal.abrirConexao(conexao);
                //executar o insert
                funcDal.alterar(conexao, func);

                MessageBox.Show("Dados alterados com sucesso!");
                btnLimpar.PerformClick();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falha: " + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            DialogResult resultado = MessageBox.Show("Deseja excluir?", "Atenção", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);

            if (resultado == DialogResult.OK)
            {
                //String de conexão com o banco de dados
                string strConexao = @"Server=JOREL\SQLEXPRESS;
 Database=BD_Floricultura;Integrated Security = True";
                string cmdDelete =
                 "DELETE funcionarios where id_func =" + txtMatriculavisao.Text;
                SqlConnection con = new SqlConnection(strConexao);
                SqlCommand sqlCommand = new SqlCommand(cmdDelete, con);
                con.Open();
                sqlCommand.ExecuteNonQuery();
                MessageBox.Show("Dados excluidos com sucesso!");
                btnLimpar.PerformClick();
                con.Close();


                //dialogresult resultado = messagebox.show("deseja excluir?", "atenção", messageboxbuttons.okcancel, messageboxicon.exclamation);

                //if (resultado == dialogresult.ok)
                //{
                //    messagebox.show("excluir...");
                //    recuperar o id do funcionario

                //    criar uma conexao
                //    conexao = clnconexao.getconexao();
                //    int matr = 0;
                //    try
                //    {
                //        recuperar o id(matricula) do form(textbox)
                //        matr = convert.toint32(txtmatricula.text);
                //    }
                //    catch (exception ex)
                //    {
                //        messagebox.show("falha ao converter! " +
                //            "digite somente números" + ex.message);
                //    }
                //    criar a conexao
                //    criar o objeto funcionario e atribuir o id
                //    criar o objeto funcionariodal
                //    com o funcionariodal
                //    abrir conexao
                //    executar a exclusão
                //    enviar msg informando a exclusão
                //    fechar conexao
                //}
                //else
                //{
                //    messagebox.show("cancelar...");

                //}

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //criar uma conexao
            conexao = clnConexao.getConexao();
            //criar um objeto Funcionario 
            Funcionario func = new Funcionario();
            // popular comos dados do  formulário
            func.NomeFunc = txtNomefuvisao.Text;
            func.RgFunc = txtRgvisao.Text;
            func.CpfFunc = txtCpfvisao.Text;
            func.NomeUser = txtUsuariovisao.Text;
            func.SenhaUser = txtSenhavisao.Text;

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

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FPrincipal obj = new FPrincipal();
            this.Hide();
            obj.ShowDialog();
        }
    }
}
