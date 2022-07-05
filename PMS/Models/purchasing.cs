using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PMS.Models
{
    public class purchasing
    {
        public int purchasingID { get; set; }
        

        public int Price { get; set; }
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime Date { get; set; }

        [ForeignKey("Customer")]
        public int CustomerID { get; set; }
        public virtual Customer Customer { get; set; }
        [ForeignKey("Medicine")]
        public int MedicineID { get; set; }
        public virtual Medicine Medicine { get; set; }
    }
}
