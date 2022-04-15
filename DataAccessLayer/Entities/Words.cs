using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Words
    {
        public int Id { get; set; }
        public string Kelime { get; set; }
        public string KelimeAnlami { get; set; }
    }
}
