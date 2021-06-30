using System;
using System.Collections.Generic;
using System.Text;

namespace MyBooks
{
    class Book
    {
        [SQLite.PrimaryKey, SQLite.AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
    }
}
