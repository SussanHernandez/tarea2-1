using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppEje2_1.Models
{
    public class Vid
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public String path { get; set; }
        public String FileName { get; set; }
    }
}
