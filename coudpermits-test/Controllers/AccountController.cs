using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using coudpermits_test.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace coudpermits_test.Controllers
{
    public class AccountController : Controller
    {

        public IConfiguration Configuration { get; }

        public AccountController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IActionResult dashboard()
        {
            List<Inventory> inventorylist = new List<Inventory>();

            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //SqlDataReader
                connection.Open();

                string sql = "Select * From inventory";
                SqlCommand command = new SqlCommand(sql, connection);

                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        Inventory inventory = new Inventory();

                        inventory.ID = Convert.ToInt32(dataReader["ID"]);
                        inventory.Name = Convert.ToString(dataReader["Name"]);
                        inventory.Re_order_level = Convert.ToInt32(dataReader["Re_order_level"]);
                        inventory.NumberNumber_of_units_available = Convert.ToInt32(dataReader["NumberNumber_of_units_available"]);
                        inventory.Unit_price = Convert.ToInt32(dataReader["Unit_price"]);

                        inventorylist.Add(inventory);
                    }
                }

                connection.Close();
            }
            return View(inventorylist);
        }

        public IActionResult create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult create(Inventory inventory)
        {
            if (ModelState.IsValid)
            {
                string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sql = $"Insert Into inventory (Name, ID, NumberNumber_of_units_available, Unit_price,Re_order_level) Values ('{inventory.Name}', '{inventory.ID}','{inventory.NumberNumber_of_units_available}','{inventory.Unit_price}','{inventory.Re_order_level}')";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.CommandType = CommandType.Text;

                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                    return RedirectToAction("dashboard");
                }
            }
            else
                return View();
        }

        public IActionResult update(int id)
        {
            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];

            Inventory inventory = new Inventory();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"Select * From inventory Where Id='{id}'";
                SqlCommand command = new SqlCommand(sql, connection);

                connection.Open();

                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        inventory.ID = Convert.ToInt32(dataReader["Id"]);
                        inventory.Name = Convert.ToString(dataReader["Name"]);
                        inventory.Re_order_level = Convert.ToInt32(dataReader["Re_order_level"]);
                        inventory.NumberNumber_of_units_available = Convert.ToInt32(dataReader["NumberNumber_of_units_available"]);
                        inventory.Unit_price = Convert.ToInt32(dataReader["Unit_price"]);
                        
                    }
                }

                connection.Close();
            }
            return View(inventory);
        }

        [HttpPost]
        [ActionName("Update")]
        public IActionResult update_Post(Inventory inventory)
        {
            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"Update inventory SET Name='{inventory.Name}', Unit_price='{inventory.Unit_price}', Re_order_level='{inventory.Re_order_level}', NumberNumber_of_units_available='{inventory.NumberNumber_of_units_available}' Where Id='{inventory.ID}'";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }

            return RedirectToAction("dashboard");
        }

        [HttpPost]
        public IActionResult delete(int id)
        {
            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"Delete From inventory Where Id='{id}'";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        ViewBag.Result = "Operation got error:" + ex.Message;
                    }
                    connection.Close();
                }
            }

            return RedirectToAction("dashboard");
        }

    }
}
