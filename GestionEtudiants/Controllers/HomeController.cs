using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;

namespace GestionEtudiants.Controllers
{
    public class HomeController : Controller
    {
        public List<Models.Etudiant> ListEtudiant;
        public HomeController()
        {
            ListEtudiant =new List<Models.Etudiant>();
        }
        // GET: Home
        public ActionResult Index()
        {
            GetAllMatricules();
            return View(ListEtudiant);

        }

        public JsonResult GetStudentInfo(string id)
        {
            string connectionstring = @"server=192.168.1.28;DataBase=ExerciceAJAX;Uid=Alex123;Pwd=1234";
            SqlConnection MyConnection = new SqlConnection(connectionstring);
            MyConnection.Open();

            SqlCommand MyCmd = new SqlCommand();
            MyCmd.Connection=MyConnection;
            MyCmd.CommandText = "getStudentInfo";
            MyCmd.CommandType = CommandType.StoredProcedure;
            MyCmd.Parameters.AddWithValue("@Matricule", id);
            SqlDataReader reader;
            reader = MyCmd.ExecuteReader();
            reader.Read();
            Models.Etudiant et = new Models.Etudiant { Nom = reader["Nom"].ToString(), Prenom = reader["Prenom"].ToString(), Localite = reader["Localite"].ToString() };
            reader.Close();
            MyConnection.Close();
            return Json(et);
        }
        private void GetAllMatricules()
        {
            string connectionstring = @"server=192.168.1.28;DataBase=ExerciceAJAX;Uid=Alex123;Pwd=1234";
            SqlConnection MyConnection = new SqlConnection(connectionstring);
            MyConnection.Open();

            SqlCommand MyCmd = new SqlCommand();
            MyCmd.Connection = MyConnection;
            MyCmd.CommandText = "getAllMatricule";
            MyCmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader;
            reader = MyCmd.ExecuteReader();
            while (reader.Read())
            {
                ListEtudiant.Add(new Models.Etudiant { Matricule=reader["Matricule"].ToString() });
                
            }
            reader.Close();
            MyConnection.Close();
        }
    }
}