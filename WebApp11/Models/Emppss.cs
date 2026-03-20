using System;
using System.Collections.Generic;

namespace WebApp11.Models
{
    public partial class Emppss
    {
        public int Eid { get; set; }
        public string Ename { get; set; } = null!;
        public DateTime Ejoin { get; set; }
        public string Ejob { get; set; } = null!;
        public decimal Esalary { get; set; }
    }
}
