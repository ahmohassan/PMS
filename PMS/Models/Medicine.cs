using Castle.MicroKernel.SubSystems.Conversion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PMS.Models
{
    public class Medicine
    {
        [Key]
        public int MedicineID { get; set; }
        public string MedcineCat { get; set; }
        public string MedicineName { get; set; }
        public string Description { get; set; }

    }
}
