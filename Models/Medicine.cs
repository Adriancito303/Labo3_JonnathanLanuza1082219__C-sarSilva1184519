using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Labo3_JonnathanLanuza1082219__CésarSilva1184519.Models
{
    public class Medicine
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Product { get; set; }
        public int Price { get; set; }
        public int? Existence { get; set; }
        public string dock { get; set; }
    }
}
