using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using System.Collections.Generic;
using System.Globalization;

namespace SecondAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private IConfiguration _configuration;


        public NotesController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        [HttpGet]
        [Route("GetNotes")]
        public JsonResult GetNotes()
        {
            string query = "select * from Notes";

            DataTable table = new DataTable();

            string sqlconn = _configuration.GetConnectionString("todoajithconnection");

            SqlDataReader sqlreader;

            using (SqlConnection myconn = new SqlConnection(sqlconn))
            {
                myconn.Open();

                using (SqlCommand mycommand = new SqlCommand(query, myconn))
                {
                    sqlreader = mycommand.ExecuteReader();
                    table.Load(sqlreader);
                    sqlreader.Close();

                    myconn.Close();

                }


            }


            return new JsonResult(table);


        }

        [HttpPost]
        [Route("AddNotes")]
        public JsonResult AddNotes([FromForm] string newNotes)
        {
            string query = "insert into Notes values(@newNotes)";

            DataTable table = new DataTable();

            string sqlconn = _configuration.GetConnectionString("todoajithconnection");

            SqlDataReader sqlreader;

            using (SqlConnection myconn = new SqlConnection(sqlconn))
            {
                myconn.Open();

                using (SqlCommand mycommand = new SqlCommand(query, myconn))
                {
                    mycommand.Parameters.AddWithValue("@newNotes", newNotes);
                    sqlreader = mycommand.ExecuteReader();
                    table.Load(sqlreader);
                    sqlreader.Close();

                    myconn.Close();

                }


            }


            return new JsonResult("added successfully");
        }

        [HttpDelete]
        [Route("DeleteNotes")]
        public JsonResult DeleteNotes(int id)
        {
            string query = "delete from  Notes where id=@id";

            DataTable table = new DataTable();

            string sqlconn = _configuration.GetConnectionString("todoajithconnection");

            SqlDataReader sqlreader;

            using (SqlConnection myconn = new SqlConnection(sqlconn))
            {
                myconn.Open();

                using (SqlCommand mycommand = new SqlCommand(query, myconn))
                {
                    mycommand.Parameters.AddWithValue("@id", id);

                    sqlreader = mycommand.ExecuteReader();
                    table.Load(sqlreader);
                    sqlreader.Close();

                    myconn.Close();

                }


            }


            return new JsonResult("deleted successfully");
        }

        [HttpGet]
        [Route("GetNotessp")]
        public JsonResult GetNotessp()
        {
            var getnotessp = "GetNotessp";
            DataTable table = new DataTable();
            string sqlconn = _configuration.GetConnectionString("todoajithconnection");
            SqlDataReader sqlreader;
            using (SqlConnection myconn = new SqlConnection(sqlconn))
            {
                myconn.Open();
                using (SqlCommand cmd = new SqlCommand(getnotessp, myconn))
                {

                    cmd.CommandText = getnotessp;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    sqlreader = cmd.ExecuteReader();

                    table.Load(sqlreader);
                    sqlreader.Close();
                    myconn.Close();


                }
                return new JsonResult(table);
            }
        }
        [HttpPost]
        [Route("AddNotessp3")]
        public JsonResult AddNotessp([FromForm] string newNotes)
        {
            string addnotessp = "AddNotessp3";
            DataTable table = new DataTable();
            string sqlconn = _configuration.GetConnectionString("todoajithconnection");
            SqlDataReader sqlreader;
            using (SqlConnection myconn = new SqlConnection(sqlconn))
            {
                myconn.Open();
                using (SqlCommand cmd = new SqlCommand(addnotessp, myconn))
                {
                    cmd.CommandText = addnotessp;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;


                    cmd.Parameters.AddWithValue("@description", newNotes);

                    sqlreader = cmd.ExecuteReader();

                    table.Load(sqlreader);
                    sqlreader.Close();
                    myconn.Close();
                }
                return new JsonResult("added successfully");
            }
        }
        [HttpDelete]
        [Route("DeleteNotessp")]
        public JsonResult DeleteNotessp(int id)
        {
            var deletenotesp = "DeleteNotessp";
            DataTable table = new DataTable();
            string sqlconn = _configuration.GetConnectionString("todoajithconnection");
            SqlDataReader sqlreader;
            using (SqlConnection myconn = new SqlConnection(sqlconn))
            {
                myconn.Open();
                using (SqlCommand cmd = new SqlCommand(deletenotesp, myconn))
                {
                    cmd.CommandText = deletenotesp;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id", id);

                    sqlreader = cmd.ExecuteReader();

                    table.Load(sqlreader);
                    sqlreader.Close();
                    myconn.Close();
                }
                return new JsonResult("Deleted Succesfully");
            }
        }
    }
}
