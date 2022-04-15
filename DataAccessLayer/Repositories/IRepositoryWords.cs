using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public interface IRepositoryWords
    {
        void AddOrUpdate(Words words);
        void Delete(Words words);
        void Delete(int id);
        List<Words> List();
        void SaveChanges();
    }
}
