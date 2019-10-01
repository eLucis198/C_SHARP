using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Atividade_05_09.Models
{
    public class Noticia
    {
        public int Id { get; set; }
        public string Categoria { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }

        public void Insert()
        {

        }

        public void Updade()
        {

        }

        public void Delete()
        {

        }

        public List<Noticia> Read()
        {
            List<Noticia> listaNoticia = new List<Noticia>();
            SqlConnection con = new SqlConnection("Data Source =.; Initial Catalog = Atividade; Integrated Security = True");
            SqlCommand comando = new SqlCommand("sp_read", con);
            comando.CommandType = CommandType.StoredProcedure;
            try
            {
                con.Open();
                using (SqlDataReader dataReader = comando.ExecuteReader())
                    while (dataReader.Read())
                    {
                        Noticia noticia = new Noticia();
                        noticia.Id = dataReader.GetInt32(0);
                        noticia.Categoria = dataReader.GetString(1);
                        noticia.Titulo = dataReader.GetString(2);
                        noticia.Descricao = dataReader.GetString(3);
                        listaNoticia.Add(noticia);
                    }
                con.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
            return listaNoticia;
        }
    }
}