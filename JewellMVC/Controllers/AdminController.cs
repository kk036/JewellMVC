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
    public class AdminController : Controller
    {
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;

        // GET: Admin

        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }

        void connectionString()
        {
            con.ConnectionString = "Data Source=LAPTOP-LBI62H71\\SQLEXPRESS;Initial Catalog=JewelDB;Integrated Security=True";

        }

        [HttpPost]
        public ActionResult Login(Admin log)
        {
            connectionString();
            con.Open();
            cmd.Connection = con;

            cmd.CommandText = "select * from Login where UserName='" + log.UserName + "' and UserPassword='" + log.UserPassword + "'";

            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                con.Close();
                return View("AdminArea");
            }
            else
            {
                con.Close();
                return View("Wrong");
            }
        }



    }
}