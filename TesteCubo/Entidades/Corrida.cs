using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TesteCubo.Entidades
{
    public class Corrida
    {
        public string nome { get; set; }
        public List<Volta> listaVoltas { get; set; }

        public Corrida()
        {
            listaVoltas = new List<Volta>();
        }
    }
}