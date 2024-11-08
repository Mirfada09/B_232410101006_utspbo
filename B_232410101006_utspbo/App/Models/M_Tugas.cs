using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_232410101006_utspbo.App.Models
{
    internal class M_Tugas
    {
        [Key]
        public int nomor { get; set; }
        [Required]
        public string nama_tugas { get; set; }
        [Required]
        public int deadline { get; set; }
    }
}
