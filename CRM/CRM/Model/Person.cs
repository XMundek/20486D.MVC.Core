using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CRM.Model
{
    [Table("Person")]
    public class Person:BaseEntity
    {       
        [Required]
        public string LastName { get; set; }
        public string FirstName { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }        
    }
}
