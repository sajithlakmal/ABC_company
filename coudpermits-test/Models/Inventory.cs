using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace coudpermits_test.Models
{
    public class Inventory
    {
        private readonly InventoryContext _context;
        public int ID { get; set; }


        [Required]
        public string Name { get; set; }

        [Required]
        public int NumberNumber_of_units_available { get; set; }

        [Required]
        public int Re_order_level { get; set; }

        [Required]
        public int Unit_price { get; set; }


        }
    }