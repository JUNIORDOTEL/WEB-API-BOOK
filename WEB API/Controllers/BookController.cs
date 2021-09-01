using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WEB_API.Models;

namespace WEB_API.Controllers
{
    public class BookController : ApiController
    {
        public HttpResponseMessage Get()
        {
            string query = @"
                select ID,Title,Description,PageCount,Excerpt,PublishDate,Test from dbo.Book";

            DataTable table = new DataTable();
            using (var conn = new SqlConnection(ConfigurationManager.
                ConnectionStrings["BookDB"].ConnectionString))
            using (var cmd = new SqlCommand(query, conn))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }

            return Request.CreateResponse(HttpStatusCode.OK, table);
            



        }

        public string Post(Book dep)
        {

            try
            {
                string query = @"
                    insert into dbo.Book values
                     ('" + dep.Test + @"')
                      ";

                DataTable table = new DataTable();
                using (var conn = new SqlConnection(ConfigurationManager.
                    ConnectionStrings["BookDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, conn))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "Agregado correctamente";
            }
            catch (Exception)
            {

                return "Falla al agregar";
            }
        }


        public string Put(Book dep)
        {

            try
            {
                string query = @"
                    update dbo.Book set Title = 
                     '" + dep.Title + @"'
                      where ID = "+ dep.ID+@"
                      ";

                DataTable table = new DataTable();
                using (var conn = new SqlConnection(ConfigurationManager.
                    ConnectionStrings["BookDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, conn))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "Editado correctamente";
            }
            catch (Exception)
            {

                return "Falla al editar";
            }
        }


        public string Delete(int id)
        {

            try
            {
                string query = @"
                    Delete from dbo.Book
                      where ID = " + id + @"
                      ";

                DataTable table = new DataTable();
                using (var conn = new SqlConnection(ConfigurationManager.
                    ConnectionStrings["BookDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, conn))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "Eliminado correctamente";
            }
            catch (Exception)
            {

                return "Falla al Eliminar";
            }
        }


    }
}
