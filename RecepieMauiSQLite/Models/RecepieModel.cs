using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace RecepieMauiSQLite.Models
{
    [Table("Recepies")]
    public class RecepieModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(250), Unique]
            public string Name { get; set; }
        [MaxLength(250)]
            public string CreatedBy { get; set; }
        [MaxLength(50)]
        public string Category { get; set; }
        
        [MaxLength(250)]
            public string Ingredients { get; set; }  
        [MaxLength(250)]
        public string Description { get; set; }
        
        public string Emoji { get; set; }
    }
}
