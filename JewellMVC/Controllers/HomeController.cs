using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using JewellMVC.Models;

namespace JewellMVC.Controllers
{
    public class HomeController : Controller
    {

        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;

        void connectionString()
        {
            con.ConnectionString = "Data Source=LAPTOP-LBI62H71\\SQLEXPRESS;Initial Catalog=JewelDB;Integrated Security=True";

        }


        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        // GET: Home
        public ActionResult About()
        {
            return View();
        }



        [HttpGet]
        public ActionResult Contact()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Msg(Contact log)
        {
            connectionString();
            con.Open();
            cmd.Connection = con;

            cmd.CommandText = "insert into Contact(Name,Email,Contact,Message) values('" + log.SName + "','" + log.SEmail + "','"+log.SContact + "','" + log.SMsg + "')";
            cmd.ExecuteNonQuery();
            con.Close();

            return View("Messages");


        }


    }
}