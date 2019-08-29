using CRM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM.Repository
{
    public interface ICrmRepository
    {
        Person[] GetPersonList(string LastName);
        Person GetPerson(int id);
        void DeletePerson(int id);
        void SavePerson(Person p);
    }
}
