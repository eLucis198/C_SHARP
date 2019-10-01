using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace _1_Valdney.Models
{
    public class Vendedor
    {

        public int codVendedor { get; set; }
        [Required(ErrorMessage = "O Campo Nome É Obrigatório")]
        public string Nome { get; set; }
        
        [Required(ErrorMessage = "O Campo Salario Fixo É Obrigatório")]
        public int SalarioFixo { get; set; }
        [Required(ErrorMessage = "O Campo Faixa Comissão É Obrigatório")]
        public string FaixaComissao { get; set; }
        [Required(ErrorMessage = "O Campo Sexo É Obrigatório")]
        public string Sexo { get; set; }
        [Required(ErrorMessage = "O Campo Ativo É Obrigatório")]
        public bool Ativo { get; set; }
        [Required(ErrorMessage = "O Campo Email É Obrigatório")]
        public string Email { get; set; }
        [Required(ErrorMessage = "O Campo Senha É Obrigatório")]
        public string Senha { get; set; }

        public void Insert()
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=Valdney01;Integrated Security=True");
            SqlCommand comando = new SqlCommand("SP_InsertVendedor", con);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add("@nomeVendedor", SqlDbType.VarChar).Value = Nome;
            comando.Parameters.Add("@salarioFixo", SqlDbType.Int).Value = SalarioFixo;
            comando.Parameters.Add("@faixaComissao", SqlDbType.VarChar).Value = FaixaComissao;
            comando.Parameters.Add("@sexo", SqlDbType.VarChar).Value = Sexo;
            comando.Parameters.Add("@ativo", SqlDbType.Bit).Value = 1;
            comando.Parameters.Add("@email", SqlDbType.VarChar).Value = Email;
            comando.Parameters.Add("@senha", SqlDbType.VarChar).Value = Senha;
            try
            {
                con.Open();
                comando.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Update()
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=Valdney01;Integrated Security=True");
            SqlCommand comando = new SqlCommand("SP_UpdateVendedor", con);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add("@codVendedor", SqlDbType.Int).Value = codVendedor;
            comando.Parameters.Add("@nome", SqlDbType.VarChar).Value = Nome;
            comando.Parameters.Add("@salarioFixo", SqlDbType.Int).Value = SalarioFixo;
            comando.Parameters.Add("@faixaComissao", SqlDbType.VarChar).Value = FaixaComissao;
            comando.Parameters.Add("@sexo", SqlDbType.VarChar).Value = Sexo;
            comando.Parameters.Add("@ativo", SqlDbType.Bit).Value = Ativo;
            comando.Parameters.Add("@email", SqlDbType.VarChar).Value = Email;
            comando.Parameters.Add("@senha", SqlDbType.VarChar).Value = Senha;
            try
            {
                con.Open();
                comando.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
        }


    }
}