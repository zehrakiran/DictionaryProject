using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class WordsRepositoryJson : IRepositoryWords
    {
        static List<Words> _word = new List<Words>();
        public void AddOrUpdate(Words words)
        {
            if (words.Id <= 0)
            {
                if (!_word.Any())
                {
                    words.Id = 1;
                }
                else
                {
                    words.Id = _word.Max(c => c.Id) + 1;
                }
                    
                
                
                _word.Add(words);
            }
            else
            {
                Words updateEdilecek = _word.First(c => c.Id == words.Id);
                updateEdilecek.Kelime = words.Kelime;
                updateEdilecek.KelimeAnlami = words.KelimeAnlami;
                
            }
            SaveChanges();
        }

        public void Delete(Words words)
        {
            _word.Remove(words);
            SaveChanges();
        }

        public void Delete(int id)
        {
            Words silinecek = _word.FirstOrDefault(c => c.Id == id);
           
            if (silinecek != null)
            {
                Delete(silinecek);
            }
        }

        public List<Words> List()
        {
            string fileContent = File.ReadAllText(@"C:\Users\Aksamci\source\repos\DictionaryProject\DictionaryProject\bin\Debug\net5.0\Kelimeler.json");
            _word = JsonSerializer.Deserialize<List<Words>>(fileContent);
            return _word.ToList();
        }

        public void SaveChanges()
        {
            string serializedWord = JsonSerializer.Serialize(_word);
            File.WriteAllText(@"C:\Users\Aksamci\source\repos\DictionaryProject\DictionaryProject\bin\Debug\net5.0\Kelimeler.json", serializedWord);
        }
    }
}
