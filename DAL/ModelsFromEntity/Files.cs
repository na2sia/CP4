using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ModelsFromEntity
{
    public class Files
    {        
        public int Id { get; set; }
        public string FileName { get; set; }
        public Files() { }
        public Files(string fileName)
        {
            this.FileName = fileName;
        }

    }
}
