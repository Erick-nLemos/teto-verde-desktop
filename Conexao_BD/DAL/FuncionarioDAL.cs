using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Model;

namespace DAL
{
    public class FuncionarioDAL : SqlHelper
    {
        //Métodos -- executam os comandos SQL
        public bool adicionar(SqlConnection con, Funcionario objFunc)
        {
           string inserirFuncionario = "INSERT into funcionarios (nome_func, rg_func, " +
           "cpf_func, nome_user, senha_user) VALUES ('"+objFunc.NomeFunc+"', '"+objFunc.RgFunc+
           "','" + objFunc.CpfFunc + "','" + objFunc.NomeUser + "','" + objFunc.SenhaUser + "')";
            try
            {
                executarComando(inserirFuncionario, con);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool alterar(SqlConnection con, Funcionario objFunc)
        {

            /*
             *  UPDATE funcionarios 
                  SET nome_func = 'PEPE2',
                  rg_func = '123',
                  cpf_func = '123456789',
                  nome_user = 'pepe01',
                  senha_user = '123'
                  WHERE id_func = 7;
             * 
             * 
             */
            string alterarFuncionario = " UPDATE funcionarios SET " +
            "nome_func = '" + objFunc.NomeFunc + "'," +
            "rg_func = '" + objFunc.RgFunc + "'," +
            "cpf_func = '" + objFunc.CpfFunc + "'," +
            "nome_user = '" + objFunc.NomeUser + "'," +
            "senha_user = '" + objFunc.SenhaUser + "'" +
            " WHERE id_func = " + objFunc.IdFunc + " ";

            /*string alterarFuncionario = " UPDATE funcionarios SET nome_func ='" + objFunc.NomeFunc + "',rg_func ='" + objFunc.RgFunc + "', +cpf_func = '" + objFunc.CpfFunc + "', +nome_user = '" + objFunc.NomeUser + "',senha_user = '" + objFunc.SenhaUser + " WHERE id_func = " + objFunc.IdFunc + "";
            
            */
            try
            {
                executarComando(alterarFuncionario, con);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool excluir(SqlConnection con, Funcionario objFunc)
        {
            string excluirFuncionario = "delete from funcionarios where id_func = " +
            objFunc.IdFunc;
            try
            {
                executarComando(excluirFuncionario, con);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        
    }
        public Funcionario pesquisarFuncId(SqlConnection con, Funcionario objFunc)
        {
            string buscarFuncionarioID = "select * from funcionarios where id_func=" +
            objFunc.IdFunc;
            try
            {
                SqlDataReader dr = retornaDataReader(buscarFuncionarioID, con);
                dr.Read();
                objFunc.NomeFunc = dr[1].ToString();
                objFunc.RgFunc = dr[2].ToString();
                objFunc.CpfFunc = dr[3].ToString();
                objFunc.NomeUser = dr[4].ToString();
                objFunc.SenhaUser = dr[5].ToString();
                return objFunc;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Funcionario> listarFuncionarios(SqlConnection con)
        {
            string buscarTodosFuncionario = "select * from funcionarios";
            List<Funcionario> listaFunc = new List<Funcionario>();
            try
            {
                SqlDataReader dr = retornaDataReader(buscarTodosFuncionario, con);
                while (dr.Read())
                {
                    Funcionario objFunc = new Funcionario();
                    objFunc.IdFunc = Convert.ToInt32(dr[0].ToString());
                    objFunc.NomeFunc = dr[1].ToString();
                    objFunc.RgFunc = dr[2].ToString();
                    objFunc.CpfFunc = dr[3].ToString();
                    objFunc.NomeUser = dr[4].ToString();
                    objFunc.SenhaUser = dr[5].ToString();
                    listaFunc.Add(objFunc);
                }
                return listaFunc;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
