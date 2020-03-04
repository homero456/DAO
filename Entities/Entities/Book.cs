using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Book
    {
        // Using automatically implemented properties feature of C# 3.0
        public int Bookid { get; set; }
        public string Title { get; set; }
        public string Authors { get; set; }
        public string Publishers { get; set; }
        public double Price { get; set; }
    }
}
