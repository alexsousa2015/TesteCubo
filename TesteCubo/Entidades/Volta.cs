using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TesteCubo.Entidades
{
    public class Volta
    {
        public int numero { get; set; }
        public Piloto piloto { get; set; }
        public TimeSpan tempo { get; set; }
        public double velocidadeMedia { get; set; }
        public TimeSpan hora { get; set; }
    }
}