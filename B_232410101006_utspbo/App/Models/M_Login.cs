using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_232410101006_utspbo.App.Models
{
    internal class M_Login
    {
        [Key]
        public int username { get; set; }
        [Required]
        public string password { get; set; }
    }
}
