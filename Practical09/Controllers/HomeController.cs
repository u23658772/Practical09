using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Web.UI;
using System.Xml.Linq;
using Practical09.Models;
using Microsoft.Ajax.Utilities;


namespace Practical09.Controllers
{
    
    public class HomeController : Controller
    {
        SqlConnection myConnection = new SqlConnection(Globals.ConnectionString);
       

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Insert()
        {
            return View();
        }

        public ActionResult DoInsert(string Name, string ClubName, int Age, double? Fee)
        {
            try
            {
                SqlCommand myCommand = new SqlCommand("Insert into Members VALUES('" + Name + "','" + ClubName + "','" + Age + "','" + Fee + "')", myConnection);
                myConnection.Open();
                ViewBag.Message = "Sucess: " + myCommand.ExecuteNonQuery() + " rows added.";


            }
            catch (Exception err)
            {
                ViewBag.Message = err.Message;

            }
            finally { myConnection.Close(); }
            return View("Index");
        }

        public ActionResult Update()
        {
            
            return View();
        }

        public ActionResult GetID(int Id)
        {
            Practical09.Models.Member member = null; 

            try
            {

                {
                    myConnection.Open();
                    SqlCommand myCommand2 = new SqlCommand(
                        "SELECT Id, Name, ClubName, Age, Fee FROM Members WHERE ID = @Id",
                        myConnection);
                    myCommand2.Parameters.AddWithValue("@Id", Id);

                    SqlDataReader myReader = myCommand2.ExecuteReader();
                    if (myReader.Read())
                    {
                        member = new Practical09.Models.Member
                        {
                            Id = Convert.ToInt32(myReader["Id"]),
                            Name = myReader["Name"].ToString(),
                            ClubName = myReader["ClubName"].ToString(),
                            Age = Convert.ToInt32(myReader["Age"]),
                            Fee = Convert.ToDouble(myReader["Fee"])
                        };
                    }
                    
                        myReader.Close(); 
                }
            }
            catch (Exception err)
            {
                ViewBag.Message = err.Message;
            }
            finally { myConnection.Close(); }
            
            return View("Update",member); // Return the member to the view
        }

        public ActionResult DoUpdate(Practical09.Models.Member member)
        {
            try
            {
                myConnection.Open();
                SqlCommand myCommand = new SqlCommand("Update Members SET Name='" + member.Name + "',ClubName='" + member.ClubName + "',Age='" + member.Age + "',Fee='" + member.Fee + "' where ID=" + member.Id, myConnection);
                ViewBag.Message = "Sucess: " + myCommand.ExecuteNonQuery() + " rows updated.";


                

            }
            catch (Exception err)
            {
                ViewBag.Message = err.Message;

            }
            finally { myConnection.Close(); }
            return View("Index");
        }

        public ActionResult Delete()
        {
            return View();
        }


        public ActionResult DoDelete(int Id)
        {
            try
            {
                SqlCommand myCommand = new SqlCommand("Delete FROM Members WHERE ID=" + Id, myConnection);

                myConnection.Open();
                ViewBag.Message = "Sucess: " + myCommand.ExecuteNonQuery() + " rows deleted.";


            }
            catch (Exception err)
            {
                ViewBag.Message = err.Message;

            }
            finally { myConnection.Close(); }
            return View("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}