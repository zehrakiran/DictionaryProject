using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DictionaryProject.Helpers
{
    public class RepositoryFactory
    {
        static WordsRepositoryJson _repoWords;
        public static IRepositoryWords CreateRepo(string tip)
        {
            if (_repoWords == null)
            {
                if (tip == "WORD")
                {
                    lock (new object())
                    {
                        _repoWords = new WordsRepositoryJson();
                    }
                    return _repoWords;
                }
                else
                    return null;
            }
            else
                return _repoWords;
        }
    }
}
