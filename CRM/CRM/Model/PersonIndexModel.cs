using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM.Model
{
    public class PersonIndexModel
    {
        public string LastName{get;set;}
        public Person[] People { get; set; }
    }
}
