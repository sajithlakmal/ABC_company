using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace coudpermits_test.Models
{
    public class Inventory
    {

        public string ID { get; set; }


        [Required]
        public string Name { get; set; }

        [Required]
        public string NumberNumber_of_units_available { get; set; }

        [Required]
        public string Re_order_level { get; set; }

        [Required]
        public string Unit_price { get; set; }


        }
    }