using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRM.Model;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace CRM.Repository
{
    public class CrmRepository:ICrmRepository
    {
        ICrmDbContext _db;
        public CrmRepository(ICrmDbContext db)
        {
            _db = db;
        }

        public void DeletePerson(int id)
        {
            _db.Delete<Person>(id);
        }

        public Person GetPerson(int id)
        {
            return _db.FindById<Person>(id);
        }

        public Person[] GetPersonList(string LastName)
        {
            return _db.People.Where(p => p.LastName.StartsWith(LastName)).ToArray();
        }

        public void SavePerson(Person p)
        {
            _db.Save(p);
        }
    }
}
